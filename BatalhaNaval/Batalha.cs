using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BatalhaNaval
{
    public partial class Batalha : Form
    {
        /*LOGICA DO JOGO*/
        NetworkStream stream;
        TcpClient client;
        bool ehHost, minhavez = false, mudanca = false, sair = false, acabou = false, online;
        int[,] myField, Opponent = new int[10, 10];
        int[] lastAttack = new int[2], PontOP = new int[4] { 8, 9, 8, 5 }, pontME = new int[4] { 8, 9, 8, 5 };
        int[] leftMe = new int[4] { 4, 3, 2, 1 }, leftOP = new int[4] { 4, 3, 2, 1 };
        int Pontos = 0, HP = 30, EnemyPontos = 0, eHP = 30;
        String nome1, nome2, Status;
        Thread eventos, carreg;

        /*-------------Logica I.A----------------------*/
        int[,] iaField = new int[10, 10];
        int[,] feedbackArray = new int[10, 10];
        int[] posAcerto = new int[2];
        int[] posInicial = new int[2];
        int[] tamanhos = new int[4] { 1, 2, 3, 4 };
        int oqEra = 0;
        int[] tentativas;
        int quantofalta = 0;
        int sentidocerto = -2;
        bool correto = false;
        bool pesquisando = false;
        bool acerteialgo = false;
        bool terminei = true;
        /*---------------------------------------------*/

        public Batalha(int[,] myField, String nome1, String nome2, bool ehHost, String endereco = "", TcpListener host = null, bool online = true)
        {
            InitializeComponent();
            eventos = new Thread(EventosRede);
            if (!online)
            {
                carreg = new Thread(telaCarregando);
                carreg.Start();
            }
            this.ControlBox = false;
            this.nome1 = nome1;
            this.nome2 = nome2;
            this.myField = myField;
            this.ehHost = ehHost;
            this.online = online;
            minhavez = true;
            if (online == true)
            {
                if (ehHost)
                {
                    minhavez = true;
                    client = host.AcceptTcpClient();
                    stream = client.GetStream();
                    eventos.Start();
                }
                else
                {
                    minhavez = false;
                    client = new TcpClient(endereco, 8585);
                    stream = client.GetStream();
                    eventos.Start();
                }
            }
            else
            {
                GerarCampoIA();
                BTN_DisconectarInGame.Text = "Exit";
            }
            TXT_NOME1battle.Text = nome1;
            for (int i = 0; i < 10; i++)
            {
                Grade.Rows.Add();
                for (int j = 0; j < 11; j++)
                {
                    Grade.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (j > 0)
                    {
                        Grade.Rows[i].Cells[j].Value = Properties.Resources.WaterSpot;
                    }
                    else
                    {
                        Grade.Rows[i].Cells[j].Value = i + 1;
                    }

                }
                Grade.Rows[i].Height = 50;
            }
            int letra = 65;
            for (int i = 0; i < 10; i++)
            {
                Grid_Minha.Columns.Add("coluna" + i, ((char)(letra + i)).ToString());
                Grid_Minha.Columns[i].Width = 19;
            }
            for (int i = 0; i < 10; i++)
            {
                Grid_Minha.Rows.Add();
                for (int j = 0; j < 10; j++)
                {
                    Grid_Minha.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (myField[i, j] == 0)
                    {
                        Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                    }
                    else if (myField[i, j] > 0 && myField[i, j] < 5)
                    {
                        Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    }
                    else if (myField[i, j] == 5)
                    {
                        Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                    }
                    else if (myField[i, j] == 6)
                    {
                        Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    }
                    Grid_Minha.Rows[i].Height = 19;
                }
            }
        }

        private void telaCarregando()
        {
            Carregando carregando = new Carregando();
            carregando.ShowDialog();
        }

        private void GerarCampoIA()
        {
            int[] resto = new int[4] { 4, 3, 2, 1 };
            int[] tamanho = new int[4] { 1, 2, 3, 4 };
            int[] coord = new int[2];
            for (int i = 0; i < 4; i++)
            {

                while (resto[i] > 0)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    Thread.Sleep(100);
                    coord[0] = rnd.Next(0, 10);
                    coord[1] = rnd.Next(0, 10);
                    bool entra = true;
                    if (myField[coord[0], coord[1]] > 0 && myField[coord[0], coord[1]] < 5)
                    {
                        Console.WriteLine("Ja tem");
                        entra = false;
                    }

                    int orient = rnd.Next(0, 2);
                    bool permitido = true;

                    if (orient == 0 && entra == true)
                    {
                        if (coord[0] + (tamanho[i]+1) > 9)
                        {
                            Console.WriteLine("Jumping" + i);
                        }
                        else
                        {
                            Console.WriteLine("Tentando na posicao x:" + coord[0] + " y:" + coord[1] + "a peca " + i);
                            int size = tamanho[i]+1;
                            while (size > -1)
                            {
                                Console.WriteLine("Vamo la " + size + " " + orient + " peca " + i);
                                if (iaField[coord[0] + size, coord[1]] > 0 && iaField[coord[0] + size, coord[1]] < 5)
                                {
                                    Console.WriteLine("proibido");
                                    permitido = false;

                                }
                                for (int j = -1; j < 2; j++)
                                {
                                    Console.WriteLine("Verificando " + i);
                                    if (coord[1] > 0 && coord[1] < 9 && coord[0] > 0 && coord[0] < 9)
                                    {
                                        if (iaField[(coord[0]-1) + size, coord[1] + j] > 0 && iaField[(coord[0] - 1) + size, coord[1] + j] < 5)
                                        {
                                            Console.WriteLine("proibidoporlado");
                                            permitido = false;
                                        }
                                    }
                                    /*if (coord[1] > 0 && coord[1] < 9 && coord[0] == 0 && coord[0] < 9)
                                    {
                                        if (iaField[(coord[0]) + size, coord[1] + j] > 0 && iaField[(coord[0]) + size, coord[1] + j] < 5)
                                        {
                                            Console.WriteLine("proibidoporlado");
                                            permitido = false;
                                        }
                                    }*/
                                    else if(coord[1] == 0 && coord[1] < 9 && coord[0] > 0 && coord[0] < 9)
                                    {
                                        if(j > -1)
                                        {
                                            if (iaField[(coord[0] - 1) + size, coord[1] + j] > 0 && iaField[(coord[0] - 1) + size, coord[1] + j] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                        
                                    }
                                    /*else if (coord[1] > 0 && coord[1] == 9 && coord[0] == 0 && coord[0] < 9)
                                    {
                                        if (j < 1)
                                        {
                                            if (iaField[(coord[0]) + size, coord[1] + j] > 0 && iaField[(coord[0]) + size, coord[1] + j] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                    }*/
                                    /*else if(coord[1] > 0 && coord[1] == 9 && coord[0] > 0 && coord[0] < 9)
                                    {
                                        if(j < 1)
                                        {
                                            if (iaField[(coord[0]-1) + size, coord[1] + j] > 0 && iaField[(coord[0]-1) + size, coord[1] + j] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                    }*/
                                }
                                size--;
                            }
                            size = tamanho[i];
                            Console.WriteLine("vamos colocar " + i);
                            if (permitido == true)
                            {
                                Console.WriteLine("entrou " + i);
                                while (size > -1)
                                {
                                    Console.WriteLine("Put!");
                                    iaField[coord[0] + size, coord[1]] = i + 1;
                                    size--;
                                }
                                Console.WriteLine("Colocou uma peça: " + i);
                                if (size == -1)
                                    resto[i]--;
                            }
                        }
                    }
                    if (orient == 1 && entra == true)
                    {
                        if (coord[1] + (tamanho[i] + 1) > 9)
                        {
                            Console.WriteLine("Pulando" + i);
                        }
                        else
                        {
                            Console.WriteLine("Tentando na posicao x:" + coord[0] + " y:" + coord[1] + "a peca " + i);
                            int size = tamanho[i]+1;
                            while (size > -1)
                            {
                                Console.WriteLine("Vamo la " + size + " " + orient + " peca " + i);
                                if (iaField[coord[0], coord[1] + size] > 0 && iaField[coord[0], coord[1] + size] < 5)
                                {
                                    Console.WriteLine("proibido");
                                    permitido = false;

                                }
                                for (int j = -1; j < 2; j++)
                                {
                                    Console.WriteLine("Verificando " + i);
                                    if (coord[0] > 0 && coord[0] < 9 && coord[1] > 0 && coord[1] < 9)
                                    {
                                        if (iaField[coord[0] + j, (coord[1]-1) + size] > 0 && iaField[coord[0] + j, (coord[1] - 1) + size] < 5)
                                        {
                                            Console.WriteLine("proibidoporlado");
                                            permitido = false;
                                        }
                                    }
                                    else if(coord[0] == 0 && coord[0] < 9 && coord[1] == 0 && coord[1] < 9) {
                                        if(j > -1)
                                        {
                                            if (iaField[coord[0] + j, (coord[1]) + size] > 0 && iaField[coord[0] + j, (coord[1]) + size] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                    }
                                    /*else if (coord[0] > 0 && coord[0] < 9 && coord[1] == 0 && coord[1] < 9)
                                    {
                                        if (iaField[coord[0] + j, (coord[1]) + size] > 0 && iaField[coord[0] + j, (coord[1]) + size] < 5)
                                        {
                                            Console.WriteLine("proibidoporlado");
                                            permitido = false;
                                        }
                                    }*/
                                    /*else if (coord[0] == 0 && coord[0] < 9 && coord[1] > 0 && coord[1] < 9)
                                    {
                                        if (j > -1)
                                        {
                                            if (iaField[coord[0] + j, (coord[1]-1) + size] > 0 && iaField[coord[0] + j, (coord[1]-1) + size] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                    }*/
                                    /*else if (coord[0] > 0 && coord[0] == 9 && coord[1] == 0 && coord[1] < 9)
                                    {
                                        if (j < 1)
                                        {
                                            if (iaField[coord[0] + j, (coord[1]) + size] > 0 && iaField[coord[0] + j, (coord[1]) + size] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                    }*/
                                    /*else if (coord[0] > 0 && coord[0] == 9 && coord[1] > 0 && coord[1] < 9)
                                    {
                                        if (j < 1)
                                        {
                                            if (iaField[coord[0] + j, (coord[1]-1) + size] > 0 && iaField[coord[0] + j, (coord[1]-1) + size] < 5)
                                            {
                                                Console.WriteLine("proibidoporlado");
                                                permitido = false;
                                            }
                                        }
                                    }*/
                                }
                                size--;
                            }
                            size = tamanho[i];
                            Console.WriteLine("vamos colocar " + i);
                            if (permitido == true)
                            {
                                Console.WriteLine("entrou " + i);
                                while (size > -1)
                                {
                                    Console.WriteLine("Put!");
                                    iaField[coord[0], coord[1] + size] = i + 1;
                                    size--;
                                }
                                Console.WriteLine("Colocou uma peça: " + i);
                                if (size == -1)
                                    resto[i]--;
                            }
                        }
                    }
                }
            }
            carreg.Abort();
            Console.WriteLine("Concluido!");
        }

        private void BTN_DisconectarInGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the game?", "Alert!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sair = true;
            }
            else
            {
                return;
            }
        }

        private void FeedBack(int L, int C)
        {
            Byte[] Pacote;
            if (myField[L, C] == 0)
            {
                Pacote = Encoding.ASCII.GetBytes("FD|miss");
                myField[L, C] = 5;
                mudanca = true;
                stream.Write(Pacote, 0, Pacote.Length);
                minhavez = !minhavez;
            }
            else if (myField[L, C] > 0 && myField[L, C] < 5)
            {
                Pacote = Encoding.ASCII.GetBytes("FD|hit|" + myField[L, C]);
                pontME[myField[L, C] - 1]--;
                myField[L, C] = 6;
                HP--;
                EnemyPontos++;
                stream.Write(Pacote, 0, Pacote.Length);
                mudanca = true;
            }
        }

        private void EventosRede()
        {
            String msg = "";
            String[] msgs;
            Byte[] Pacote = new Byte[128];
            int BYTE = 0;
            while ((BYTE = stream.Read(Pacote, 0, Pacote.Length)) != 0)
            {
                msg = Encoding.ASCII.GetString(Pacote, 0, BYTE);
                msgs = msg.Split('|');
                //Console.WriteLine("Está Recebendo");
                if (msg == "Sair")
                {
                    Byte[] Exit = Encoding.ASCII.GetBytes("Sair");
                    stream.Write(Exit, 0, Exit.Length);
                    sair = true;
                    MessageBox.Show("The other player left the game");
                    client.Close();
                    break;
                }
                if (msgs[0] == "Pos")
                {
                    int posl = Int32.Parse(msgs[1]);
                    int posc = Int32.Parse(msgs[2]);
                    FeedBack(posl, posc);
                    posc--;
                    //minhavez = !minhavez;
                    Console.WriteLine("L=" + msgs[1] + "C=" + msgs[2]);
                }
                if (msgs[0] == "FD" && msgs[1] == "hit")
                {
                    Console.WriteLine("HIT");
                    Opponent[lastAttack[0], lastAttack[1]] = 2;
                    Pontos++;
                    PontOP[Int32.Parse(msgs[2]) - 1]--;
                    eHP--;
                    mudanca = true;
                    int acerto = Int32.Parse(msgs[2]);
                    switch (acerto)
                    {
                        case 1:
                            Status = "Your last hit: Submarine";
                            break;
                        case 2:
                            Status = "Your last hit: Destroyer";
                            break;
                        case 3:
                            Status = "Your last hit: Tanker";
                            break;
                        case 4:
                            Status = "Your last hit: Aircraft Carrier";
                            break;
                    }
                }
                if (msgs[0] == "FD" && msgs[1] == "miss")
                {
                    Console.WriteLine("miss");
                    Opponent[lastAttack[0], lastAttack[1]] = 1;
                    Status = "Your last hit: Water";
                    minhavez = !minhavez;
                    //FeedBack(lastAttack[0], lastAttack[1]);
                    mudanca = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.RowIndex >= 0)
                if (Opponent[e.RowIndex, e.ColumnIndex - 1] == 0 && e.ColumnIndex > 0 && e.ColumnIndex < 11 && e.RowIndex > -1 && e.RowIndex < 10)
                {
                    if (minhavez)
                    {
                        lastAttack[0] = e.RowIndex;
                        lastAttack[1] = e.ColumnIndex - 1;
                        if (online)
                        {
                            String msg = "Pos|" + e.RowIndex + "|" + (e.ColumnIndex - 1);
                            Byte[] Pacote = Encoding.ASCII.GetBytes(msg);
                            stream.Write(Pacote, 0, Pacote.Length);
                        }
                        else
                        {
                            if (iaField[e.RowIndex, e.ColumnIndex - 1] > 0 && iaField[e.RowIndex, e.ColumnIndex - 1] < 5)
                            {
                                Opponent[lastAttack[0], lastAttack[1]] = 2;
                                int acerto = iaField[e.RowIndex, e.ColumnIndex - 1];
                                PontOP[acerto-1]--;
                                switch (acerto)
                                {
                                    case 1:
                                        Status = "Your last hit: Submarine";
                                        break;
                                    case 2:
                                        Status = "Your last hit: Destroyer";
                                        break;
                                    case 3:
                                        Status = "Your last hit: Tanker";
                                        break;
                                    case 4:
                                        Status = "Your last hit: Aircraft Carrier";
                                        break;
                                }
                                mudanca = true;
                                Pontos++;
                                eHP--;
                                //minhavez = !minhavez;
                            }
                            else if (iaField[e.RowIndex, e.ColumnIndex - 1] == 0)
                            {
                                Status = "Your last hit: Water";
                                Opponent[lastAttack[0], lastAttack[1]] = 1;
                                minhavez = !minhavez;
                                mudanca = true;
                            }
                        }
                        //minhavez = !minhavez;
                    }
                }
        }

        private int IaAtirar(int L, int C)
        {
            if(L >= 0 && L < 10 && C >= 0 && C < 10)
            {
                feedbackArray[L, C] = 1;
                if (myField[L,C] > 0 && myField[L,C] < 5)
                {
                    if (pesquisando == false)
                    {
                        Console.WriteLine("------------Cadastrando posicaoinicial---------------");
                        posInicial[0] = L;
                        posInicial[1] = C;
                    }
                    EnemyPontos++;
                    pesquisando = true;
                    posAcerto[0] = L;
                    posAcerto[1] = C;
                    pontME[myField[L, C] - 1]--;
                    HP--;
                    Console.WriteLine("Bomba! " + myField[L, C] +"\n" +
                        "na localizacao X:" + C + " Y:"+L);
                    mudanca = true;
                    return myField[L, C];
                }
                else if(myField[L,C] == 6 && pesquisando == true)
                {
                    posAcerto[0] = L;
                    posAcerto[1] = C;
                    return 6;
                }
                else
                {
                    if(myField[L,C] == 0)
                    {
                        myField[L, C] = 5;
                        minhavez = !minhavez;
                        terminei = true;
                        mudanca = true;
                    }
                    return myField[L, C];
                }
            }
            else
            {
                Console.WriteLine("Fora de alcance.");
                return -1;
            }
        }

        private void procurar(int sentido)
        {
            int i = 0;
            switch (sentido)
            {
                case -1:
                    i = -1;
                    break;
                case 0:
                    i = 1;
                    break;
                case 1:
                    i = -1;
                    break;
                case 2:
                    i = 1;
                    break;
            }
            int x = (sentido == 1 || sentido == 2) ? i : 0;
            int y = (sentido == -1 || sentido == 0) ? i : 0 ;

            if(posAcerto[0] + y >= 0 && posAcerto[0] + y < 10 && posAcerto[1] + x >= 0 && posAcerto[1] + x < 10)
            {
                if (feedbackArray[posAcerto[0] + y, posAcerto[1] + x] != 1 || myField[posAcerto[0] + y, posAcerto[1] + x] == 6)
                {
                    Console.WriteLine("Atirando em: L:" + (posAcerto[0] + y) + " C:" + (posAcerto[1] + x));
                    int result = IaAtirar(posAcerto[0] + y, posAcerto[1] + x);
                    if (result > 0 && result < 5)
                    {
                        myField[posAcerto[0], posAcerto[1]] = 6;
                        sentidocerto = sentido;
                        quantofalta--;
                        if (quantofalta <= 0)
                        {
                            Console.WriteLine("-----------afundou!------------");
                            pesquisando = false;
                        }
                    }
                    else if (result == 6)
                    {
                        sentidocerto = sentido;
                    }
                    else
                    {
                        Console.WriteLine("Errou, procurando outra direcao\n" +
                            "posinicial L:" + (posInicial[0]) + " C:" + (posInicial[1]) + "\n" +
                            "posinicial L: " + (posAcerto[0]) + " C: " + (posAcerto[1]) + "\n");
                        posAcerto = posInicial;
                        sentidocerto = -2;
                    }
                }
                else
                {
                    posAcerto = posInicial;
                    sentidocerto = -2;
                }
            }
            else
            {
                posAcerto = posInicial;
                sentidocerto = -2;
            }
            
        }

        private void Pensar()
        {
            terminei = false;
            Random RNG = new Random(DateTime.Now.Second);
            Thread.Sleep(100);
            if (pesquisando)
            {
                Console.WriteLine("Pesquisando!");
                int sentido;
                if(sentidocerto == -2)
                {
                    sentido = RNG.Next(-1, 3);
                    Console.WriteLine("sentido aleatorio: " + sentido);
                    procurar(sentido);
                }
                else
                {
                    Console.WriteLine("Continuando");
                    procurar(sentidocerto);
                }
            }
            else
            {
                int L = RNG.Next(0, 10);
                int iterador = 0;
                int[] temp = new int[10] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
                for(int i = 0; i < 10; i++)
                {
                    if(feedbackArray[L,i] == 0)
                    {
                        temp[i] = i;
                        iterador++;
                    }
                }
                if(iterador > 0)
                {
                    Console.WriteLine("\nIterador = " + iterador);
                    int cont = 0;
                    int[] range = new int[iterador];
                    for (int i = 0; i < 10; i++)
                    {
                        if (temp[i] > -1)
                        {
                            range[cont] = temp[i];
                            Console.Write(range[cont] + ",");
                            cont++;
                        }
                    }
                    int C = range[RNG.Next(0, iterador)];
                    int result = IaAtirar(L, C);
                    if (result > 0 && result < 5)
                    {
                        oqEra = result;
                        quantofalta = tamanhos[result - 1];
                        Console.WriteLine("\ntamanho da embarcacao: " + quantofalta);
                        myField[L, C] = 6;
                    }
                    else if (result == 0)
                    {
                        Console.WriteLine("\nÁgua.");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalido! " + result + "\n" +
                            "X: " + C + "Y: " + L);
                    }
                }
            }
        }

        private void Ticks_Tick(object sender, EventArgs e)
        {
            Grid_Minha.ClearSelection();

            TXT_LAST.Text = Status;
            for (int i = 0; i < 4; i++)
            {
                if (pontME[i] == 0)
                {
                    leftMe[i] = 0;
                }
                if (PontOP[i] == 0)
                {
                    leftOP[i] = 0;
                }
                switch (i)
                {
                    case 0:
                        if (pontME[i] == 6)
                        {
                            leftMe[i] = 3;
                        }
                        if (pontME[i] == 4)
                        {
                            leftMe[i] = 2;
                        }
                        if (pontME[i] == 2)
                        {
                            leftMe[i] = 1;
                        }
                        if (PontOP[i] == 6)
                        {
                            leftOP[i] = 3;
                        }
                        if (PontOP[i] == 4)
                        {
                            leftOP[i] = 2;
                        }
                        if (PontOP[i] == 2)
                        {
                            leftOP[i] = 1;
                        }
                        break;
                    case 1:
                        if (pontME[i] == 6)
                        {
                            leftMe[i] = 2;
                        }
                        if (pontME[i] == 3)
                        {
                            leftMe[i] = 1;
                        }
                        if (PontOP[i] == 6)
                        {
                            leftOP[i] = 2;
                        }
                        if (PontOP[i] == 3)
                        {
                            leftOP[i] = 1;
                        }
                        break;
                    case 2:
                        if (PontOP[i] == 4)
                        {
                            leftOP[i] = 1;
                        }
                        if (PontOP[i] == 4)
                        {
                            leftOP[i] = 1;
                        }
                        break;
                }
            }

            if (sair == true)
            {
                if (online)
                {
                    Console.WriteLine("Finalizando");
                    Byte[] Exit = Encoding.ASCII.GetBytes("Sair");
                    stream.Write(Exit, 0, Exit.Length);
                }
                eventos.Abort();
                this.Close();
            }

            if (HP == 0 && acabou == false)
            {
                acabou = true;
                sair = true;
                MessageBox.Show("You lost the game!");
            }
            if (eHP == 0 && acabou == false)
            {
                acabou = true;
                sair = true;
                MessageBox.Show("You won the game!");
            }

            TXT_NOME1battle.Text = nome1 + "\n" +
               "Points: " + Pontos + "\n" +
               "Still left :" + "\n" +
               leftMe[0] + " submarines\n" +
               leftMe[1] + " Destroyers\n" +
               leftMe[2] + " Tankers\n" +
               leftMe[3] + " Aircraft Carrier";
            TXT_NOMEOP.Text = nome2 + "\n" +
               "Points: " + EnemyPontos + "\n" +
               "Still left :" + "\n" +
               leftOP[0] + " — submarines\n" +
               leftOP[1] + " — Destroyers\n" +
               leftOP[2] + " — Tankers\n" +
               leftOP[3] + " — Aircraft Carrier";
            if (minhavez)
            {
                TXT_VEZ.Text = "Your turn!";
            }
            else
            {
                TXT_VEZ.Text = "Opponent's turn!";
                if (!online)
                {
                    Pensar();
                    if (pesquisando)
                    {
                        nome2 = "THINKING...";
                    }
                    else
                    {
                        nome2 = "Shooting Randomly...";
                    }
                }
            }

            if (mudanca)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (j > 0)
                        {
                            switch (Opponent[i, j - 1])
                            {
                                case 0:
                                    Grade.Rows[i].Cells[j].Value = Properties.Resources.WaterSpot;
                                    break;
                                case 1:
                                    Grade.Rows[i].Cells[j].Value = Properties.Resources.Nothing_Spot;
                                    break;
                                case 2:
                                    Grade.Rows[i].Cells[j].Value = Properties.Resources.Hit_Spot;
                                    break;
                            }
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (myField[i, j] == 0)
                        {
                            Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                        }
                        else if (myField[i, j] > 0 && myField[i, j] < 5)
                        {
                            Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        }
                        else if (myField[i, j] == 5)
                        {
                            Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                        }
                        else if (myField[i, j] == 6)
                        {
                            Grid_Minha.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        }
                    }
                }
                mudanca = false;
            }
        }
    }
}
