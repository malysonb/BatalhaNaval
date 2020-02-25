namespace BatalhaNaval
{
    partial class Lobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TXT_VERSUS = new System.Windows.Forms.Label();
            this.GRID_SELECT = new System.Windows.Forms.DataGridView();
            this.BTN_DisconectarLobby = new System.Windows.Forms.Button();
            this.Eventos = new System.Windows.Forms.Timer(this.components);
            this.Quantidades = new System.Windows.Forms.Label();
            this.BTN_Submarino = new System.Windows.Forms.Button();
            this.BTN_Destroyer = new System.Windows.Forms.Button();
            this.BTN_Navio_Tanque = new System.Windows.Forms.Button();
            this.BTN_Porta_Aviao = new System.Windows.Forms.Button();
            this.CHK_READY = new System.Windows.Forms.CheckBox();
            this.CHK_OPONENTE = new System.Windows.Forms.CheckBox();
            this.TXT_INFO = new System.Windows.Forms.Label();
            this.BTN_RESET = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GRID_SELECT)).BeginInit();
            this.SuspendLayout();
            // 
            // TXT_VERSUS
            // 
            this.TXT_VERSUS.AutoSize = true;
            this.TXT_VERSUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_VERSUS.Location = new System.Drawing.Point(12, 9);
            this.TXT_VERSUS.Name = "TXT_VERSUS";
            this.TXT_VERSUS.Size = new System.Drawing.Size(134, 31);
            this.TXT_VERSUS.TabIndex = 0;
            this.TXT_VERSUS.Text = "{0} Vs. {1}";
            // 
            // GRID_SELECT
            // 
            this.GRID_SELECT.AllowUserToAddRows = false;
            this.GRID_SELECT.AllowUserToDeleteRows = false;
            this.GRID_SELECT.AllowUserToResizeColumns = false;
            this.GRID_SELECT.AllowUserToResizeRows = false;
            this.GRID_SELECT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRID_SELECT.ColumnHeadersVisible = false;
            this.GRID_SELECT.Location = new System.Drawing.Point(149, 47);
            this.GRID_SELECT.MultiSelect = false;
            this.GRID_SELECT.Name = "GRID_SELECT";
            this.GRID_SELECT.ReadOnly = true;
            this.GRID_SELECT.RowHeadersVisible = false;
            this.GRID_SELECT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GRID_SELECT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GRID_SELECT.ShowCellToolTips = false;
            this.GRID_SELECT.ShowEditingIcon = false;
            this.GRID_SELECT.ShowRowErrors = false;
            this.GRID_SELECT.Size = new System.Drawing.Size(193, 193);
            this.GRID_SELECT.TabIndex = 1;
            this.GRID_SELECT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GRID_SELECT_CellContentClick);
            // 
            // BTN_DisconectarLobby
            // 
            this.BTN_DisconectarLobby.Location = new System.Drawing.Point(262, 270);
            this.BTN_DisconectarLobby.Name = "BTN_DisconectarLobby";
            this.BTN_DisconectarLobby.Size = new System.Drawing.Size(80, 23);
            this.BTN_DisconectarLobby.TabIndex = 2;
            this.BTN_DisconectarLobby.Text = "Desconectar";
            this.BTN_DisconectarLobby.UseVisualStyleBackColor = true;
            this.BTN_DisconectarLobby.Click += new System.EventHandler(this.BTN_DisconectarLobby_Click);
            // 
            // Eventos
            // 
            this.Eventos.Enabled = true;
            this.Eventos.Interval = 50;
            this.Eventos.Tick += new System.EventHandler(this.Eventos_Tick);
            // 
            // Quantidades
            // 
            this.Quantidades.AutoSize = true;
            this.Quantidades.Location = new System.Drawing.Point(111, 95);
            this.Quantidades.Name = "Quantidades";
            this.Quantidades.Size = new System.Drawing.Size(12, 13);
            this.Quantidades.TabIndex = 4;
            this.Quantidades.Text = "x";
            // 
            // BTN_Submarino
            // 
            this.BTN_Submarino.Location = new System.Drawing.Point(18, 85);
            this.BTN_Submarino.Name = "BTN_Submarino";
            this.BTN_Submarino.Size = new System.Drawing.Size(87, 23);
            this.BTN_Submarino.TabIndex = 5;
            this.BTN_Submarino.Text = "Submarino";
            this.BTN_Submarino.UseVisualStyleBackColor = true;
            this.BTN_Submarino.Click += new System.EventHandler(this.BTN_Submarino_Click);
            // 
            // BTN_Destroyer
            // 
            this.BTN_Destroyer.Location = new System.Drawing.Point(18, 114);
            this.BTN_Destroyer.Name = "BTN_Destroyer";
            this.BTN_Destroyer.Size = new System.Drawing.Size(87, 23);
            this.BTN_Destroyer.TabIndex = 5;
            this.BTN_Destroyer.Text = "Destroyer";
            this.BTN_Destroyer.UseVisualStyleBackColor = true;
            this.BTN_Destroyer.Click += new System.EventHandler(this.BTN_Destroyer_Click);
            // 
            // BTN_Navio_Tanque
            // 
            this.BTN_Navio_Tanque.Location = new System.Drawing.Point(18, 143);
            this.BTN_Navio_Tanque.Name = "BTN_Navio_Tanque";
            this.BTN_Navio_Tanque.Size = new System.Drawing.Size(87, 23);
            this.BTN_Navio_Tanque.TabIndex = 5;
            this.BTN_Navio_Tanque.Text = "Navio Tanque";
            this.BTN_Navio_Tanque.UseVisualStyleBackColor = true;
            this.BTN_Navio_Tanque.Click += new System.EventHandler(this.BTN_Navio_Tanque_Click);
            // 
            // BTN_Porta_Aviao
            // 
            this.BTN_Porta_Aviao.Location = new System.Drawing.Point(18, 172);
            this.BTN_Porta_Aviao.Name = "BTN_Porta_Aviao";
            this.BTN_Porta_Aviao.Size = new System.Drawing.Size(87, 23);
            this.BTN_Porta_Aviao.TabIndex = 5;
            this.BTN_Porta_Aviao.Text = "Porta Avião";
            this.BTN_Porta_Aviao.UseVisualStyleBackColor = true;
            this.BTN_Porta_Aviao.Click += new System.EventHandler(this.BTN_Porta_Aviao_Click);
            // 
            // CHK_READY
            // 
            this.CHK_READY.AutoSize = true;
            this.CHK_READY.Location = new System.Drawing.Point(18, 250);
            this.CHK_READY.Name = "CHK_READY";
            this.CHK_READY.Size = new System.Drawing.Size(57, 17);
            this.CHK_READY.TabIndex = 6;
            this.CHK_READY.Text = "Pronto";
            this.CHK_READY.UseVisualStyleBackColor = true;
            this.CHK_READY.CheckedChanged += new System.EventHandler(this.CHK_READY_CheckedChanged);
            // 
            // CHK_OPONENTE
            // 
            this.CHK_OPONENTE.AutoSize = true;
            this.CHK_OPONENTE.Enabled = false;
            this.CHK_OPONENTE.Location = new System.Drawing.Point(18, 227);
            this.CHK_OPONENTE.Name = "CHK_OPONENTE";
            this.CHK_OPONENTE.Size = new System.Drawing.Size(73, 17);
            this.CHK_OPONENTE.TabIndex = 7;
            this.CHK_OPONENTE.Text = "Oponente";
            this.CHK_OPONENTE.UseVisualStyleBackColor = true;
            // 
            // TXT_INFO
            // 
            this.TXT_INFO.AutoSize = true;
            this.TXT_INFO.Enabled = false;
            this.TXT_INFO.Location = new System.Drawing.Point(147, 250);
            this.TXT_INFO.Name = "TXT_INFO";
            this.TXT_INFO.Size = new System.Drawing.Size(194, 13);
            this.TXT_INFO.TabIndex = 8;
            this.TXT_INFO.Text = "Botão direito no mouse para virar peças";
            // 
            // BTN_RESET
            // 
            this.BTN_RESET.Location = new System.Drawing.Point(149, 270);
            this.BTN_RESET.Name = "BTN_RESET";
            this.BTN_RESET.Size = new System.Drawing.Size(75, 23);
            this.BTN_RESET.TabIndex = 9;
            this.BTN_RESET.Text = "Resetar Campo";
            this.BTN_RESET.UseVisualStyleBackColor = true;
            this.BTN_RESET.Click += new System.EventHandler(this.BTN_RESET_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 299);
            this.Controls.Add(this.BTN_RESET);
            this.Controls.Add(this.TXT_INFO);
            this.Controls.Add(this.CHK_OPONENTE);
            this.Controls.Add(this.CHK_READY);
            this.Controls.Add(this.BTN_Porta_Aviao);
            this.Controls.Add(this.BTN_Navio_Tanque);
            this.Controls.Add(this.BTN_Destroyer);
            this.Controls.Add(this.BTN_Submarino);
            this.Controls.Add(this.Quantidades);
            this.Controls.Add(this.BTN_DisconectarLobby);
            this.Controls.Add(this.GRID_SELECT);
            this.Controls.Add(this.TXT_VERSUS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Lobby";
            this.Text = "Lobby";
            ((System.ComponentModel.ISupportInitialize)(this.GRID_SELECT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TXT_VERSUS;
        private System.Windows.Forms.DataGridView GRID_SELECT;
        private System.Windows.Forms.Button BTN_DisconectarLobby;
        private System.Windows.Forms.Timer Eventos;
        private System.Windows.Forms.Label Quantidades;
        private System.Windows.Forms.Button BTN_Submarino;
        private System.Windows.Forms.Button BTN_Destroyer;
        private System.Windows.Forms.Button BTN_Navio_Tanque;
        private System.Windows.Forms.Button BTN_Porta_Aviao;
        private System.Windows.Forms.CheckBox CHK_READY;
        private System.Windows.Forms.CheckBox CHK_OPONENTE;
        private System.Windows.Forms.Label TXT_INFO;
        private System.Windows.Forms.Button BTN_RESET;
    }
}