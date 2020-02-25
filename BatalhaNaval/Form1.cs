using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatalhaNaval
{
    public partial class Form1 : Form
    {
        //Info Redes
        TcpListener servidor;
        TcpClient cliente;
        NetworkStream stream;
        //Menu
        String MeuNome;
        String OponenteNome;
        public bool host, fim = false, conectando;
        bool abort = false;
        Thread mensagem;
        public Form1()
        {
            //esse metodo inicia a janela de interface
            InitializeComponent();
        }

        //Esse metodo irá pingar em todos os ip da rede e apenas nos disponiveis com a porta aberta irá adicionar na lista
        public static string IpLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                    return ip.ToString();
                }
            }
            throw new Exception("Não há adaptadores de rede!");
        }

        //Inicia o servidor
        private void BTN_CREATEMATCH_Click(object sender, EventArgs e)
        {
            //Caso a conexão retorne verdadeiro:
            if (AbrirServidor())
            {
                //irá criar um novo objeto do tipo lobby (Onde montamos o cenario antes de jogar)
                Lobby jogo = new Lobby(MeuNome, OponenteNome, true,true, servidor, cliente);
                jogo.ShowDialog();
                jogo.Close();
                //Fecha o servidor depois de aberto
                if (servidor != null && servidor.Server.IsBound)
                {
                    servidor.Stop();
                    servidor = null;
                }
                this.Show();
            }
            else //Caso o servidor retorne falso (abortar)
            {
                this.Show();
                fim = false;
                if (servidor != null && servidor.Server.IsBound)
                {
                    servidor.Stop();
                    servidor = null;
                }
            }
        }

        //Dialogo aguardando o outro jogador
        public void showmessage()
        {
            Aguarde aguarde = new Aguarde();
            if(aguarde.ShowDialog() == DialogResult.Cancel) //caso clique no botão abortar:
            {
                abort = true;
            }
        }

        //Chamado ao abrir o servidor
        private bool AbrirServidor()
        {
            this.Hide(); //Esconde a janela inicial
            MeuNome = TXB_NOMEONLINE.Text;
            host = true;
            if(servidor == null)
            {
                servidor = new TcpListener(IPAddress.Any, 8585); //Servidor irá abrir em qualquer endereço local, ouvindo na porta 8585
            }
            mensagem = new Thread(showmessage);
            mensagem.Start(); // inicia o thread avisando que está esperando um novo jogador
            Thread online = new Thread(eventosOnline);
            online.Start(); // Inicia o thread com todos os enventos de comunicação online
            while(fim == false) // aguarda o fim da thread de eventos online
            {
                Thread.Sleep(30); // diminui a carga na cpu
                if (fim == true)
                {
                    mensagem.Abort();
                    online.Abort();
                    cliente.Close();
                    fim = false;
                    return true; // caso fim for verdadeiro irá retornar true assim iniciando o jogo
                }
                if (abort)
                {
                    online.Abort();
                    if(cliente != null)
                    {
                        cliente.Close();
                    }
                    host = false;
                    abort = false;
                    return false; // caso aperte o botão de abortar irá retornar false
                }
                else
                {
                    continue;
                }
            }
            return true;
        }

        //metodo para enviar uma mensagem para o cliente
        private void enviarPacote(String s)
        {
            Byte[] Pacote = new Byte[128];
            Pacote = Encoding.ASCII.GetBytes("N|" + s);
            stream.Write(Pacote, 0, Pacote.Length);
        }

        // Metodo utilizado para o comunicacao
        private void eventosOnline()
        {
            String msg = "";
            String[] msgs;
            Byte[] Pacote = new Byte[128];
            int BYTE = 0;
            if (host) // se o usuario estiver hospedando o servidor:
            {
                if (!servidor.Server.IsBound) // Caso o servidor estiver desligado
                {
                    servidor.Start();
                }
                while (fim == false)
                {
                    if(fim == false)
                    {
                        Console.WriteLine("Esperando cliente");
                        cliente = servidor.AcceptTcpClient(); // ao conectar-se com um cliente
                        stream = cliente.GetStream();       // recebe a transmissão de dados do cliente
                        Console.WriteLine("Concluido!");
                    }
                    Console.WriteLine("Tentar receber mensagem");
                    while ((BYTE = stream.Read(Pacote, 0, Pacote.Length)) != 0) // enquanto recebe uma mensagem
                    {
                        msg = Encoding.ASCII.GetString(Pacote, 0, BYTE);
                        msgs = msg.Split('|'); // divide a mensagem em substrings a cada "|"
                        if (msgs[0] == "conectar") // caso a mensagem seja conectar
                        {
                            Console.WriteLine("Esperando por nome!");
                            conectando = true;
                            OponenteNome = msgs[1]; // o nome será a seguinde substring
                            enviarPacote(MeuNome); // irá enviar um pacote com o seu nome para o outro jogador
                            fim = true;
                            cliente.Close();
                            Console.WriteLine("Fim!");
                            break;
                        }
                        if (msgs[0] == "Ping") // Caso só seja uma conexão de ping
                        {
                            Console.WriteLine("Pong!");
                            break;
                        }
                    }
                }
            }
            else // Caso seja o cliente
            {
                while (fim == false)
                {
                    cliente = new TcpClient(); 
                    cliente.Connect(TXB_ADDRESS.Text, 8585); // irá conectar no ip que está na caixa de endereço na porta 8585
                    stream = cliente.GetStream();
                    if (cliente.Connected) // caso consiga conectar
                    {
                        Pacote = Encoding.ASCII.GetBytes("conectar|" + MeuNome);
                        stream.Write(Pacote, 0, Pacote.Length); // irá enviar a mensagem com duas substrings conectar e o nome do jogador
                        conectando = true;
                        while ((BYTE = stream.Read(Pacote, 0, Pacote.Length)) != 0)
                        {
                            msg = Encoding.ASCII.GetString(Pacote, 0, BYTE);
                            msgs = msg.Split('|');
                            if (msgs[0] == "N") // caso a primeira mensagem seja N
                            {
                                Console.WriteLine("Foi");
                                OponenteNome = msgs[1]; // nome do oponente será a seguinte substring
                                fim = true;
                                cliente.Close();
                                break;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        // Bloqueará o acesso aos botões caso não tenha nenhum nome
        private void Tic_Tac_Tick(object sender, EventArgs e)
        {

            if(TXB_NOMEONLINE.TextLength <= 0)
            {
                BTN_CREATEMATCH.Enabled = false;
                BTN_ENTRAR.Enabled = false;
            }
            else
            {
                BTN_CREATEMATCH.Enabled = true;
                if (TXB_ADDRESS.TextLength == 0)
                {
                    BTN_ENTRAR.Enabled = false;
                }
                else
                {
                    BTN_ENTRAR.Enabled = true;
                }
            }
        }

        // botão entrar na partida
        private void BTN_ENTRAR_Click(object sender, EventArgs e)
        {
            if (EntrarServidor())
            {
                Lobby jogo = new Lobby(MeuNome, OponenteNome, false,true, null, cliente,TXB_ADDRESS.Text);
                this.Hide();
                jogo.ShowDialog();
                jogo.Close();
                cliente.Close();
                OponenteNome = "";
                this.Show();
            }
            else
            {

            }
        }

        private bool EntrarServidor()
        {
            host = false;
            try // tente conectar ao servidor
            {
                MeuNome = TXB_NOMEONLINE.Text;
                eventosOnline();
                if (fim == true)
                {
                    fim = false;
                    return true;
                }
                else
                return false;
            }
            catch // se não conectar irá mostrar uma mensagem de erro
            {
                MessageBox.Show("Não foi possivel conectar à este host: " + TXB_ADDRESS.Text + ":8585\n" +
                    "Verifique se ele está online.","Erro");
                return false;
            }
        }

        // irá procurar servidores na rede
        private void procurarServidor()
        {
            LIST_IP.Items.Clear();
            String ip = IpLocal();
            ip = ip.Remove(ip.Length - 1);
            Ping scan = new Ping();
            for(int i = 1; i < 256; i++)
            {
                try
                {
                    PingReply resposta = scan.Send(ip + i,2);
                    if (resposta.Status == IPStatus.Success)
                    {
                        //LIST_IP.Items.Add(ip + i);
                        TcpClient pingar = new TcpClient(ip+i, 8585);
                        if (pingar.Connected) // caso encontre um servidor
                        {
                            NetworkStream str = pingar.GetStream();
                            Byte[] pacote = Encoding.ASCII.GetBytes("Ping");
                            str.Write(pacote, 0, pacote.Length); // enviará um pacote chamado ping
                            pingar.Close();                     // disconectará logo em seguida
                            LIST_IP.Items.Add(ip + i);          // adicionará na lista o novo servidor
                        }
                        Console.WriteLine(ip+i);
                    }
                }
                catch
                {
                    continue;
                }
                
            }
        }

        // ao clicar em jogar sozinho
        private void BTN_SINGLEPLAYER_Click(object sender, EventArgs e)
        {
            MeuNome = TXB_NOMEONLINE.Text;
            Lobby jogo = new Lobby(MeuNome, "Computador", true, false); // irá iniciar o objeto de lobby com os parametros apenas necessarios para jogar
            this.Hide();
            jogo.ShowDialog();
            jogo.Close();
            this.Show();
        }

        // ao clicar na lista 
        private void LIST_IP_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXB_ADDRESS.Text = LIST_IP.GetItemText(LIST_IP.SelectedItem); // a caixa de endereço mudará para o texto da lista (endereço)
        }

        // ao clicar em atualizar o servidor
        private void BTN_REFRESH_Click(object sender, EventArgs e)
        {
            procurarServidor();
        }
    }
}
