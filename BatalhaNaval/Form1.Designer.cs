namespace BatalhaNaval
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GRUPO_ONLINE = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_REFRESH = new System.Windows.Forms.Button();
            this.LIST_IP = new System.Windows.Forms.ListBox();
            this.GRUPO_HOST = new System.Windows.Forms.GroupBox();
            this.BTN_CREATEMATCH = new System.Windows.Forms.Button();
            this.GRUPO_ENTERMATCH = new System.Windows.Forms.GroupBox();
            this.BTN_ENTRAR = new System.Windows.Forms.Button();
            this.TXT_INSERT_ADDRESS = new System.Windows.Forms.Label();
            this.TXB_ADDRESS = new System.Windows.Forms.TextBox();
            this.TXT_NOMEONLINE = new System.Windows.Forms.Label();
            this.TXB_NOMEONLINE = new System.Windows.Forms.TextBox();
            this.Tic_Tac = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_SINGLEPLAYER = new System.Windows.Forms.Button();
            this.GRUPO_ONLINE.SuspendLayout();
            this.GRUPO_HOST.SuspendLayout();
            this.GRUPO_ENTERMATCH.SuspendLayout();
            this.SuspendLayout();
            // 
            // GRUPO_ONLINE
            // 
            this.GRUPO_ONLINE.Controls.Add(this.label1);
            this.GRUPO_ONLINE.Controls.Add(this.BTN_REFRESH);
            this.GRUPO_ONLINE.Controls.Add(this.LIST_IP);
            this.GRUPO_ONLINE.Controls.Add(this.GRUPO_HOST);
            this.GRUPO_ONLINE.Controls.Add(this.GRUPO_ENTERMATCH);
            this.GRUPO_ONLINE.Location = new System.Drawing.Point(12, 52);
            this.GRUPO_ONLINE.Name = "GRUPO_ONLINE";
            this.GRUPO_ONLINE.Size = new System.Drawing.Size(397, 181);
            this.GRUPO_ONLINE.TabIndex = 8;
            this.GRUPO_ONLINE.TabStop = false;
            this.GRUPO_ONLINE.Text = "Jogar via LAN/Online";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Jogos nesta rede:";
            // 
            // BTN_REFRESH
            // 
            this.BTN_REFRESH.Location = new System.Drawing.Point(218, 152);
            this.BTN_REFRESH.Name = "BTN_REFRESH";
            this.BTN_REFRESH.Size = new System.Drawing.Size(172, 23);
            this.BTN_REFRESH.TabIndex = 6;
            this.BTN_REFRESH.Text = "Atualizar";
            this.BTN_REFRESH.UseVisualStyleBackColor = true;
            this.BTN_REFRESH.Click += new System.EventHandler(this.BTN_REFRESH_Click);
            // 
            // LIST_IP
            // 
            this.LIST_IP.FormattingEnabled = true;
            this.LIST_IP.Location = new System.Drawing.Point(218, 25);
            this.LIST_IP.Name = "LIST_IP";
            this.LIST_IP.Size = new System.Drawing.Size(172, 121);
            this.LIST_IP.TabIndex = 5;
            this.LIST_IP.SelectedIndexChanged += new System.EventHandler(this.LIST_IP_SelectedIndexChanged);
            // 
            // GRUPO_HOST
            // 
            this.GRUPO_HOST.Controls.Add(this.BTN_CREATEMATCH);
            this.GRUPO_HOST.Location = new System.Drawing.Point(6, 19);
            this.GRUPO_HOST.Name = "GRUPO_HOST";
            this.GRUPO_HOST.Size = new System.Drawing.Size(206, 51);
            this.GRUPO_HOST.TabIndex = 3;
            this.GRUPO_HOST.TabStop = false;
            this.GRUPO_HOST.Text = "Hospedar partida — *:8585";
            // 
            // BTN_CREATEMATCH
            // 
            this.BTN_CREATEMATCH.Location = new System.Drawing.Point(50, 19);
            this.BTN_CREATEMATCH.Name = "BTN_CREATEMATCH";
            this.BTN_CREATEMATCH.Size = new System.Drawing.Size(100, 23);
            this.BTN_CREATEMATCH.TabIndex = 2;
            this.BTN_CREATEMATCH.Text = "Criar Partida";
            this.BTN_CREATEMATCH.UseVisualStyleBackColor = true;
            this.BTN_CREATEMATCH.Click += new System.EventHandler(this.BTN_CREATEMATCH_Click);
            // 
            // GRUPO_ENTERMATCH
            // 
            this.GRUPO_ENTERMATCH.Controls.Add(this.BTN_ENTRAR);
            this.GRUPO_ENTERMATCH.Controls.Add(this.TXT_INSERT_ADDRESS);
            this.GRUPO_ENTERMATCH.Controls.Add(this.TXB_ADDRESS);
            this.GRUPO_ENTERMATCH.Location = new System.Drawing.Point(6, 76);
            this.GRUPO_ENTERMATCH.Name = "GRUPO_ENTERMATCH";
            this.GRUPO_ENTERMATCH.Size = new System.Drawing.Size(206, 100);
            this.GRUPO_ENTERMATCH.TabIndex = 4;
            this.GRUPO_ENTERMATCH.TabStop = false;
            this.GRUPO_ENTERMATCH.Text = "Entrar em uma partida";
            // 
            // BTN_ENTRAR
            // 
            this.BTN_ENTRAR.Location = new System.Drawing.Point(47, 58);
            this.BTN_ENTRAR.Name = "BTN_ENTRAR";
            this.BTN_ENTRAR.Size = new System.Drawing.Size(103, 23);
            this.BTN_ENTRAR.TabIndex = 3;
            this.BTN_ENTRAR.Text = "Juntar-se a Partida";
            this.BTN_ENTRAR.UseVisualStyleBackColor = true;
            this.BTN_ENTRAR.Click += new System.EventHandler(this.BTN_ENTRAR_Click);
            // 
            // TXT_INSERT_ADDRESS
            // 
            this.TXT_INSERT_ADDRESS.AutoSize = true;
            this.TXT_INSERT_ADDRESS.Location = new System.Drawing.Point(6, 16);
            this.TXT_INSERT_ADDRESS.Name = "TXT_INSERT_ADDRESS";
            this.TXT_INSERT_ADDRESS.Size = new System.Drawing.Size(144, 13);
            this.TXT_INSERT_ADDRESS.TabIndex = 2;
            this.TXT_INSERT_ADDRESS.Text = "Insira o endereço do servidor";
            // 
            // TXB_ADDRESS
            // 
            this.TXB_ADDRESS.Location = new System.Drawing.Point(6, 32);
            this.TXB_ADDRESS.MaxLength = 15;
            this.TXB_ADDRESS.Name = "TXB_ADDRESS";
            this.TXB_ADDRESS.Size = new System.Drawing.Size(194, 20);
            this.TXB_ADDRESS.TabIndex = 1;
            this.TXB_ADDRESS.Text = "127.0.0.1";
            // 
            // TXT_NOMEONLINE
            // 
            this.TXT_NOMEONLINE.AutoSize = true;
            this.TXT_NOMEONLINE.Location = new System.Drawing.Point(12, 10);
            this.TXT_NOMEONLINE.Name = "TXT_NOMEONLINE";
            this.TXT_NOMEONLINE.Size = new System.Drawing.Size(84, 13);
            this.TXT_NOMEONLINE.TabIndex = 7;
            this.TXT_NOMEONLINE.Text = "Insira seu nome:";
            // 
            // TXB_NOMEONLINE
            // 
            this.TXB_NOMEONLINE.Location = new System.Drawing.Point(12, 26);
            this.TXB_NOMEONLINE.MaxLength = 50;
            this.TXB_NOMEONLINE.Name = "TXB_NOMEONLINE";
            this.TXB_NOMEONLINE.Size = new System.Drawing.Size(212, 20);
            this.TXB_NOMEONLINE.TabIndex = 6;
            this.TXB_NOMEONLINE.Text = "Jogador";
            // 
            // Tic_Tac
            // 
            this.Tic_Tac.Enabled = true;
            this.Tic_Tac.Tick += new System.EventHandler(this.Tic_Tac_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Malyson Breno — Todos os direitos reservados";
            // 
            // BTN_SINGLEPLAYER
            // 
            this.BTN_SINGLEPLAYER.Location = new System.Drawing.Point(230, 25);
            this.BTN_SINGLEPLAYER.Name = "BTN_SINGLEPLAYER";
            this.BTN_SINGLEPLAYER.Size = new System.Drawing.Size(179, 22);
            this.BTN_SINGLEPLAYER.TabIndex = 10;
            this.BTN_SINGLEPLAYER.Text = "Um jogador — Offline";
            this.BTN_SINGLEPLAYER.UseMnemonic = false;
            this.BTN_SINGLEPLAYER.UseVisualStyleBackColor = true;
            this.BTN_SINGLEPLAYER.Click += new System.EventHandler(this.BTN_SINGLEPLAYER_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 252);
            this.Controls.Add(this.BTN_SINGLEPLAYER);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GRUPO_ONLINE);
            this.Controls.Add(this.TXT_NOMEONLINE);
            this.Controls.Add(this.TXB_NOMEONLINE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Batalha Naval";
            this.GRUPO_ONLINE.ResumeLayout(false);
            this.GRUPO_ONLINE.PerformLayout();
            this.GRUPO_HOST.ResumeLayout(false);
            this.GRUPO_ENTERMATCH.ResumeLayout(false);
            this.GRUPO_ENTERMATCH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GRUPO_ONLINE;
        private System.Windows.Forms.GroupBox GRUPO_HOST;
        private System.Windows.Forms.Button BTN_CREATEMATCH;
        private System.Windows.Forms.GroupBox GRUPO_ENTERMATCH;
        private System.Windows.Forms.Label TXT_INSERT_ADDRESS;
        private System.Windows.Forms.TextBox TXB_ADDRESS;
        private System.Windows.Forms.Label TXT_NOMEONLINE;
        private System.Windows.Forms.TextBox TXB_NOMEONLINE;
        private System.Windows.Forms.Button BTN_ENTRAR;
        private System.Windows.Forms.Timer Tic_Tac;
        private System.Windows.Forms.ListBox LIST_IP;
        private System.Windows.Forms.Button BTN_REFRESH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_SINGLEPLAYER;
    }
}

