using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BatalhaNaval
{
    public partial class Lobby : Form
    {
        private int selected = -1, Cont = 10;
        private int[] tamanhos = new int[4] { 1, 2, 3, 4 };
        private int[] quantidades = new int[4] { 4, 3, 2, 1 };
        private int[] mouseOver = new int[2];
        private int[] extra = new int[2];
        private int[,] myField = new int[10, 10];
        private bool permitido = true, orientacao = true, pronto = false, once = true, saiu = false;
        TcpListener host;
        TcpClient client;
        private bool jogador1, online, pronto2, tentando = false;
        String Endereco, men, nome1, nome2;
        NetworkStream stream;
        Thread msg;

        //Metodo construtor
        public Lobby(String Nome1, String Nome2, bool ehJogador1, bool online, TcpListener host = null, TcpClient client = null, String Endereco = "")
        {
            InitializeComponent();
            this.ControlBox = false;
            this.jogador1 = ehJogador1;
            if (online)
            {
                if (ehJogador1)
                {
                    this.host = host;
                    this.jogador1 = ehJogador1;
                }
                else
                {
                    this.client = client;
                    this.jogador1 = ehJogador1;
                    this.Endereco = Endereco;
                }
            }
            else
                BTN_DisconectarLobby.Text = "Sair";
            this.online = online;
            this.nome1 = Nome1;
            this.nome2 = Nome2;
            TXT_VERSUS.Text = Nome1 + " Vs. " + Nome2;
            GRID_SELECT.CellMouseEnter += GRID_SELECT_CellMouseEnter;
            GRID_SELECT.CellMouseLeave += GRID_SELECT_CellMouseLeave;
            GRID_SELECT.MouseClick += GRID_SELECT_MouseClick;
            GRID_SELECT.CellMouseClick += GRID_SELECT_CellMouseClick;
            int letra = 65;
            for (int i = 0; i < 10; i++)
            {
                GRID_SELECT.Columns.Add("coluna" + i, ((char)(letra + i)).ToString());
                GRID_SELECT.Columns[i].Width = 19;
            }
            for (int i = 0; i < 10; i++)
            {
                GRID_SELECT.Rows.Add();
                for (int j = 0; j < 10; j++)
                {
                    GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                    GRID_SELECT.Rows[i].Height = 19;
                }
            }
            if (online)
            {
                if (jogador1)
                {
                    if (client == null || !client.Connected || tentando == false)
                    {
                        conectar();
                    }
                }
                else
                {
                    if (!client.Connected && tentando == false)
                    {
                        conectar();
                    }
                }
            }
            else
            {

            }
        }

        private void GRID_SELECT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selected > -1 && quantidades[selected] > 0 && permitido && myField[e.RowIndex, e.ColumnIndex] != 1)
            {
                int size = tamanhos[selected];
                while (size != -1)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        if (orientacao)
                        {
                            if (e.RowIndex < 9)
                            {
                                if (e.ColumnIndex < 9 && e.ColumnIndex > 0)
                                {
                                    int posic = myField[e.RowIndex + size, e.ColumnIndex + i];
                                    if (posic > 0 && posic < 5)
                                    {
                                        permitido = false;
                                    }
                                    if (extra[0] + 1 <= 9 && myField[extra[0] + 1, extra[1] + i] > 0 && myField[extra[0] + 1, extra[1] + i] < 5)
                                    {
                                        permitido = false;
                                    }
                                    if (e.RowIndex - 1 >= 0 && myField[e.RowIndex - 1, e.ColumnIndex + i] > 0)
                                    {
                                        permitido = false;
                                    }
                                }
                                else if (e.ColumnIndex == 9)
                                {
                                    if (i < 1)
                                    {
                                        int posic = myField[e.RowIndex + size, e.ColumnIndex + i];
                                        if (posic > 0 && posic < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (extra[0] + 1 <= 9 && myField[extra[0] + 1, extra[1] + i] > 0 && myField[extra[0] + 1, extra[1] + i] < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (e.RowIndex - 1 >= 0 && myField[e.RowIndex - 1, e.ColumnIndex + i] > 0)
                                        {
                                            permitido = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (i > -1)
                                    {
                                        int posic = myField[e.RowIndex + size, e.ColumnIndex + i];
                                        if (posic > 0 && posic < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (extra[0] + 1 <= 9 && myField[extra[0] + 1, extra[1] + i] > 0 && myField[extra[0] + 1, extra[1] + i] < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (e.RowIndex - 1 >= 0 && myField[e.RowIndex - 1, e.ColumnIndex + i] > 0)
                                        {
                                            permitido = false;
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (e.ColumnIndex < 9)
                            {
                                if (e.RowIndex < 9 && e.RowIndex > 0)
                                {
                                    int posic = myField[e.RowIndex + i, e.ColumnIndex + size];
                                    if (posic > 0 && posic < 5)
                                    {
                                        permitido = false;
                                    }
                                    if (extra[1] + 1 <= 9 && myField[extra[0] + i, extra[1] + 1] > 0 && myField[extra[0] + i, extra[1] + 1] < 5)
                                    {
                                        permitido = false;
                                    }
                                    if (e.ColumnIndex - 1 >= 0 && myField[e.RowIndex + i, e.ColumnIndex - 1] > 0)
                                    {
                                        permitido = false;
                                    }
                                }
                                if (e.RowIndex == 9)
                                {
                                    if (i < 1)
                                    {
                                        int posic = myField[e.RowIndex + i, e.ColumnIndex + size];
                                        if (posic > 0 && posic < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (extra[1] + 1 <= 9 && myField[extra[0] + i, extra[1] + 1] > 0 && myField[extra[0] + i, extra[1] + 1] < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (e.ColumnIndex - 1 >= 0 && myField[e.RowIndex + i, e.ColumnIndex - 1] > 0)
                                        {
                                            permitido = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (i > -1)
                                    {
                                        int posic = myField[e.RowIndex + i, e.ColumnIndex + size];
                                        if (posic > 0 && posic < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (extra[1] + 1 <= 9 && myField[extra[0] + i, extra[1] + 1] > 0 && myField[extra[0] + i, extra[1] + 1] < 5)
                                        {
                                            permitido = false;
                                        }
                                        if (e.ColumnIndex - 1 >= 0 && myField[e.RowIndex + i, e.ColumnIndex - 1] > 0)
                                        {
                                            permitido = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    size--;
                }
                size = tamanhos[selected];
                if (permitido == true)
                {
                    while (size != -1)
                    {
                        if (orientacao)
                        {
                            if (e.RowIndex < 9)
                            {
                                myField[e.RowIndex + size, e.ColumnIndex] = selected + 1;
                            }
                            /*else
                            {
                                myField[e.RowIndex - size, e.ColumnIndex] = selected + 1;
                            }*/
                            size--;
                        }
                        else
                        {
                            if (e.ColumnIndex < 9)
                            {
                                myField[e.RowIndex, e.ColumnIndex + size] = selected + 1;
                            }
                            /*else
                            {
                                myField[e.RowIndex, e.ColumnIndex - size] = selected + 1;
                            }*/
                            size--;
                        }
                    }
                    quantidades[selected]--;
                    Cont--;
                    selected = -1;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                orientacao = !orientacao;
            }
        }

        private void GRID_SELECT_MouseClick(object sender, MouseEventArgs e)
        {

            //throw new NotImplementedException();
        }

        private void GRID_SELECT_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            GRID_SELECT.ClearSelection();
            if (e.RowIndex >= 0 && e.RowIndex < 10 && e.ColumnIndex >= 0 && e.ColumnIndex < 10)
            {
                if (myField[e.RowIndex, e.ColumnIndex] == 5)
                {
                    myField[e.RowIndex, e.ColumnIndex] = 0;
                }
            }
            //throw new NotImplementedException();
        }

        public void Atualizar()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (myField[i, j] == 0)
                    {
                        if (extra[0] == i && extra[1] == j)
                        {
                            permitido = true;
                            //GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.DarkBlue;
                        }
                        else
                        {
                            GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                        }
                        if(selected > -1)
                        {
                            for (int x = tamanhos[selected]; x > -1; x--)
                            {
                                if (orientacao && mouseOver[0] + x <= 9)
                                {
                                    GRID_SELECT.Rows[mouseOver[0] + x].Cells[mouseOver[1]].Style.BackColor = Color.DarkBlue;
                                }
                                if (orientacao == false && mouseOver[1] + x <= 9)
                                {
                                    GRID_SELECT.Rows[mouseOver[0]].Cells[mouseOver[1] + x].Style.BackColor = Color.DarkBlue;
                                }
                            }
                        }
                    }
                    else if (myField[i, j] > 0 && myField[i, j] < 5)
                    {
                        if ((extra[0] == i && extra[1] == j) || (mouseOver[0] == i && mouseOver[1] == j))
                        {
                            permitido = false;
                            GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        }
                    }
                    else if (myField[i, j] == 5)
                    {
                        //GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.DarkBlue;
                    }
                    else if (myField[i, j] == 6)
                    {
                        GRID_SELECT.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        private void BTN_RESET_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    myField[i, j] = 0;
                    quantidades = new int[4] { 4, 3, 2, 1 };
                    Cont = 10;
                    CHK_READY.Checked = false;
                }
            }
        }

        private void Eventos_Tick(object sender, EventArgs e)
        {
            Atualizar();

            if (online)
            {
                if (jogador1)
                {
                    CHK_OPONENTE.Checked = pronto2;
                }
                else
                {
                    CHK_OPONENTE.Checked = pronto;
                }
            }
            else
            {
                CHK_OPONENTE.Checked = true;
                pronto2 = true;
            }




            if (Cont > 0)
            {
                CHK_READY.Enabled = false;
            }
            else
            {
                CHK_READY.Enabled = true;
            }

            if (saiu == true)
            {
                if (online)
                {
                    Console.WriteLine("Finalizando");
                    Byte[] Exit = Encoding.ASCII.GetBytes("Sair");
                    stream.Write(Exit, 0, Exit.Length);
                    msg.Abort();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            Quantidades.Text = "x" + quantidades[0] + "\n" +
                                "\n" +
                                "x" + quantidades[1] + "\n" +
                                "\n" +
                                "x" + quantidades[2] + "\n" +
                                "\n" +
                                "x" + quantidades[3] + "\n" +
                                "\n";
            for (int i = 0; i < 4; i++)
            {
                if (quantidades[i] == 0)
                {
                    switch (i)
                    {
                        case 0:
                            BTN_Submarino.Enabled = false;
                            break;
                        case 1:
                            BTN_Destroyer.Enabled = false;
                            break;
                        case 2:
                            BTN_Navio_Tanque.Enabled = false;
                            break;
                        case 3:
                            BTN_Porta_Aviao.Enabled = false;
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            BTN_Submarino.Enabled = true;
                            break;
                        case 1:
                            BTN_Destroyer.Enabled = true;
                            break;
                        case 2:
                            BTN_Navio_Tanque.Enabled = true;
                            break;
                        case 3:
                            BTN_Porta_Aviao.Enabled = true;
                            break;
                    }
                }
            }
            if (pronto == true && pronto2 == true && once == true)
            {
                if (online)
                {
                    if (jogador1)
                    {
                        //msg.Abort();
                        client.Close();
                        Console.WriteLine("Iniciar");
                        Batalha batalha = new Batalha(myField, nome1, nome2, true, "", host);
                        once = false;
                        tentando = true;
                        this.Hide();
                        batalha.ShowDialog();

                        //batalha.Close();
                        host.Stop();
                        this.Close();
                    }
                    else
                    {
                        //msg.Abort();
                        client.Close();
                        Console.WriteLine("Iniciar");
                        Batalha batalha = new Batalha(myField, nome1, nome2, false, Endereco);
                        once = false;
                        tentando = true;
                        this.Hide();
                        batalha.ShowDialog();
                        //batalha.Close();
                        this.Close();
                    }
                }
            }
        }

        private void BTN_DisconectarLobby_Click(object sender, EventArgs e)
        {
            saiu = true;
        }

        public void conectar()
        {
            if (jogador1)
            {
                if (pronto == false || pronto2 == false)
                {
                    Console.WriteLine("Olha aqui");
                    client = host.AcceptTcpClient();
                    stream = client.GetStream();
                    msg = new Thread(mensagens);
                    msg.Start();
                    tentando = true;
                }
            }
            else
            {
                try
                {
                    if (pronto == false || pronto2 == false)
                    {
                        client = new TcpClient(Endereco, 8585);
                        stream = client.GetStream();
                        tentando = true;
                        msg = new Thread(mensagens);
                        msg.Start();
                    }
                }
                catch
                {
                    tentando = true;
                    this.Close();
                    MessageBox.Show("Você perdeu a conexão.");
                }
            }
        }

        public void mensagens()
        {
            men = "";
            if (jogador1)
            {
                try
                {
                    Byte[] Pacote = new Byte[128];
                    Console.WriteLine("Opa");
                    int i;
                    while ((i = stream.Read(Pacote, 0, Pacote.Length)) != 0)
                    {
                        men = Encoding.ASCII.GetString(Pacote, 0, i);
                        if (men == "Sair")
                        {
                            Byte[] Exit = Encoding.ASCII.GetBytes("Sair");
                            stream.Write(Exit, 0, Exit.Length);
                            saiu = true;
                            MessageBox.Show("O outro jogador saiu");
                            client.Close();
                            break;
                        }
                        if (pronto == true && pronto2 == true)
                        {
                            client.Close();
                            break;
                        }
                        if (men == "true")
                        {
                            pronto2 = true;
                            Console.WriteLine("true");
                            stream.Flush();
                            if (pronto) break;
                        }
                        else if (men == "false")
                        {
                            pronto2 = false;
                            Console.WriteLine("false");
                            stream.Flush();
                        }
                    }
                    client.Close();
                    tentando = false;
                }
                catch (SocketException e)
                {
                    tentando = false;
                    stream.Flush();
                    client.Close();
                    MessageBox.Show("ue " + e);
                }
            }
            else
            {
                try
                {
                    Byte[] pacote = new Byte[128];
                    int i;
                    while ((i = stream.Read(pacote, 0, pacote.Length)) != 0)
                    {
                        men = Encoding.ASCII.GetString(pacote, 0, i);
                        if (men == "Sair")
                        {
                            Byte[] Exit = Encoding.ASCII.GetBytes("Sair");
                            stream.Write(Exit, 0, Exit.Length);
                            saiu = true;
                            MessageBox.Show("O outro jogador saiu");
                            client.Close();
                            break;
                        }
                        if (pronto == true && pronto2 == true)
                        {
                            client.Close();
                            break;
                        }
                        if (men == "true")
                        {
                            pronto = true;
                            stream.Flush();
                            if (pronto2) break;
                        }
                        if (men == "false")
                        {
                            pronto = false;
                            stream.Flush();
                        }
                    }
                    client.Close();
                    tentando = false;
                }
                catch (SocketException e)
                {
                    tentando = false;
                    stream.Flush();
                    client.Close();
                    MessageBox.Show("Erro ao receber mensagem" + nome1 + "\n" + e);
                }
            }

        }

        private void GRID_SELECT_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            GRID_SELECT.ClearSelection();
            if (selected > -1)
            {
                if (e.RowIndex >= 0 && e.RowIndex < 10 && e.ColumnIndex >= 0 && e.ColumnIndex < 10)
                {
                    mouseOver[0] = e.RowIndex;
                    mouseOver[1] = e.ColumnIndex;
                    if (myField[e.RowIndex, e.ColumnIndex] == 0)
                    {
                        myField[e.RowIndex, e.ColumnIndex] = 5;
                    }
                    else
                    {
                        permitido = false;
                    }
                    switch (orientacao)
                    {
                        case true:
                            if (e.RowIndex <= 9)
                            {
                                extra[1] = e.ColumnIndex;
                                extra[0] = e.RowIndex + tamanhos[selected];
                            }
                            break;
                        case false:
                            if (e.ColumnIndex <= 9)
                            {
                                extra[1] = e.ColumnIndex + tamanhos[selected];
                                extra[0] = e.RowIndex;
                            }
                            break;
                    }


                }
            }
            if (extra[0] > 9 || extra[1] > 9)
            {
                permitido = false;
                orientacao = !orientacao;
                for(int i = tamanhos[selected]; i > -1; i--)
                {
                    try
                    {
                        if (orientacao && e.RowIndex + i <= 9)
                        {
                            GRID_SELECT.Rows[e.RowIndex + i].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                        }

                        if (orientacao == false && e.ColumnIndex + i <= 9)
                        {
                            GRID_SELECT.Rows[e.RowIndex].Cells[e.ColumnIndex + i].Style.BackColor = Color.Red;
                        }
                    }
                    catch
                    {

                    }
                }
                
            }
        }

        private void BTN_Submarino_Click(object sender, EventArgs e)
        {
            selected = 0;
        }

        private void BTN_Destroyer_Click(object sender, EventArgs e)
        {
            selected = 1;
        }

        private void BTN_Navio_Tanque_Click(object sender, EventArgs e)
        {
            selected = 2;
        }

        private void CHK_READY_CheckedChanged(object sender, EventArgs e)
        {
            if (online)
            {
                if (jogador1)
                {
                    if (CHK_READY.Checked)
                    {
                        stream.Flush();
                        pronto = true;
                        String valor = "true";
                        Byte[] pacote = Encoding.ASCII.GetBytes(valor);
                        stream.Write(pacote, 0, pacote.Length);
                    }
                    else
                    {
                        stream.Flush();
                        pronto = false;
                        String valor = "false";
                        Byte[] pacote = Encoding.ASCII.GetBytes(valor);
                        stream.Write(pacote, 0, pacote.Length);
                    }
                }
                else
                {
                    if (CHK_READY.Checked)
                    {
                        stream.Flush();
                        pronto2 = true;
                        String valor = "true";
                        Byte[] pacote = Encoding.ASCII.GetBytes(valor);
                        stream.Write(pacote, 0, pacote.Length);
                    }
                    else
                    {
                        stream.Flush();
                        pronto2 = false;
                        String valor = "false";
                        Byte[] pacote = Encoding.ASCII.GetBytes(valor);
                        stream.Write(pacote, 0, pacote.Length);
                    }
                }
            }
            else
            {
                if (CHK_READY.Checked)
                {
                    Batalha batalha = new Batalha(myField, nome1, nome2, true, "", null, false);
                    this.Hide();
                    batalha.ShowDialog();
                    this.Close();
                }
            }
        }

        private void BTN_Porta_Aviao_Click(object sender, EventArgs e)
        {
            selected = 3;
        }

        private void GRID_SELECT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
