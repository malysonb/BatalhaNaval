namespace BatalhaNaval
{
    partial class Batalha
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
            this.Grade = new System.Windows.Forms.DataGridView();
            this.NumerosLetras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.A = new System.Windows.Forms.DataGridViewImageColumn();
            this.B = new System.Windows.Forms.DataGridViewImageColumn();
            this.C = new System.Windows.Forms.DataGridViewImageColumn();
            this.D = new System.Windows.Forms.DataGridViewImageColumn();
            this.E = new System.Windows.Forms.DataGridViewImageColumn();
            this.F = new System.Windows.Forms.DataGridViewImageColumn();
            this.G = new System.Windows.Forms.DataGridViewImageColumn();
            this.H = new System.Windows.Forms.DataGridViewImageColumn();
            this.I = new System.Windows.Forms.DataGridViewImageColumn();
            this.J = new System.Windows.Forms.DataGridViewImageColumn();
            this.Grid_Minha = new System.Windows.Forms.DataGridView();
            this.Ticks = new System.Windows.Forms.Timer(this.components);
            this.TXT_NOME1battle = new System.Windows.Forms.Label();
            this.TXT_VEZ = new System.Windows.Forms.Label();
            this.BTN_DisconectarInGame = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TXT_NOMEOP = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TXT_LAST = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Minha)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grade
            // 
            this.Grade.AllowUserToAddRows = false;
            this.Grade.AllowUserToDeleteRows = false;
            this.Grade.AllowUserToResizeColumns = false;
            this.Grade.AllowUserToResizeRows = false;
            this.Grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumerosLetras,
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F,
            this.G,
            this.H,
            this.I,
            this.J});
            this.Grade.Location = new System.Drawing.Point(0, 0);
            this.Grade.MultiSelect = false;
            this.Grade.Name = "Grade";
            this.Grade.ReadOnly = true;
            this.Grade.RowHeadersVisible = false;
            this.Grade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grade.ShowEditingIcon = false;
            this.Grade.Size = new System.Drawing.Size(527, 529);
            this.Grade.TabIndex = 0;
            this.Grade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // NumerosLetras
            // 
            this.NumerosLetras.FillWeight = 21F;
            this.NumerosLetras.HeaderText = "";
            this.NumerosLetras.MinimumWidth = 21;
            this.NumerosLetras.Name = "NumerosLetras";
            this.NumerosLetras.ReadOnly = true;
            this.NumerosLetras.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumerosLetras.Width = 21;
            // 
            // A
            // 
            this.A.FillWeight = 50F;
            this.A.HeaderText = "A";
            this.A.MinimumWidth = 50;
            this.A.Name = "A";
            this.A.ReadOnly = true;
            this.A.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.A.Width = 50;
            // 
            // B
            // 
            this.B.FillWeight = 50F;
            this.B.HeaderText = "B";
            this.B.MinimumWidth = 50;
            this.B.Name = "B";
            this.B.ReadOnly = true;
            this.B.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.B.Width = 50;
            // 
            // C
            // 
            this.C.FillWeight = 50F;
            this.C.HeaderText = "C";
            this.C.MinimumWidth = 50;
            this.C.Name = "C";
            this.C.ReadOnly = true;
            this.C.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.C.Width = 50;
            // 
            // D
            // 
            this.D.FillWeight = 50F;
            this.D.HeaderText = "D";
            this.D.MinimumWidth = 50;
            this.D.Name = "D";
            this.D.ReadOnly = true;
            this.D.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.D.Width = 50;
            // 
            // E
            // 
            this.E.FillWeight = 50F;
            this.E.HeaderText = "E";
            this.E.MinimumWidth = 50;
            this.E.Name = "E";
            this.E.ReadOnly = true;
            this.E.Width = 50;
            // 
            // F
            // 
            this.F.FillWeight = 50F;
            this.F.HeaderText = "F";
            this.F.MinimumWidth = 50;
            this.F.Name = "F";
            this.F.ReadOnly = true;
            this.F.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.F.Width = 50;
            // 
            // G
            // 
            this.G.FillWeight = 50F;
            this.G.HeaderText = "G";
            this.G.MinimumWidth = 50;
            this.G.Name = "G";
            this.G.ReadOnly = true;
            this.G.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.G.Width = 50;
            // 
            // H
            // 
            this.H.FillWeight = 50F;
            this.H.HeaderText = "H";
            this.H.MinimumWidth = 50;
            this.H.Name = "H";
            this.H.ReadOnly = true;
            this.H.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.H.Width = 50;
            // 
            // I
            // 
            this.I.FillWeight = 50F;
            this.I.HeaderText = "I";
            this.I.MinimumWidth = 50;
            this.I.Name = "I";
            this.I.ReadOnly = true;
            this.I.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.I.Width = 50;
            // 
            // J
            // 
            this.J.FillWeight = 50F;
            this.J.HeaderText = "J";
            this.J.MinimumWidth = 50;
            this.J.Name = "J";
            this.J.ReadOnly = true;
            this.J.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.J.Width = 50;
            // 
            // Grid_Minha
            // 
            this.Grid_Minha.AllowUserToAddRows = false;
            this.Grid_Minha.AllowUserToDeleteRows = false;
            this.Grid_Minha.AllowUserToResizeColumns = false;
            this.Grid_Minha.AllowUserToResizeRows = false;
            this.Grid_Minha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grid_Minha.ColumnHeadersVisible = false;
            this.Grid_Minha.Location = new System.Drawing.Point(533, 12);
            this.Grid_Minha.MultiSelect = false;
            this.Grid_Minha.Name = "Grid_Minha";
            this.Grid_Minha.ReadOnly = true;
            this.Grid_Minha.RowHeadersVisible = false;
            this.Grid_Minha.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_Minha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Grid_Minha.ShowEditingIcon = false;
            this.Grid_Minha.Size = new System.Drawing.Size(193, 193);
            this.Grid_Minha.TabIndex = 1;
            // 
            // Ticks
            // 
            this.Ticks.Enabled = true;
            this.Ticks.Interval = 500;
            this.Ticks.Tick += new System.EventHandler(this.Ticks_Tick);
            // 
            // TXT_NOME1battle
            // 
            this.TXT_NOME1battle.AutoSize = true;
            this.TXT_NOME1battle.Location = new System.Drawing.Point(6, 16);
            this.TXT_NOME1battle.Name = "TXT_NOME1battle";
            this.TXT_NOME1battle.Size = new System.Drawing.Size(21, 13);
            this.TXT_NOME1battle.TabIndex = 2;
            this.TXT_NOME1battle.Text = "{0}";
            // 
            // TXT_VEZ
            // 
            this.TXT_VEZ.AutoSize = true;
            this.TXT_VEZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_VEZ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TXT_VEZ.Location = new System.Drawing.Point(532, 471);
            this.TXT_VEZ.Name = "TXT_VEZ";
            this.TXT_VEZ.Size = new System.Drawing.Size(83, 20);
            this.TXT_VEZ.TabIndex = 3;
            this.TXT_VEZ.Text = "SUA VEZ!";
            this.TXT_VEZ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BTN_DisconectarInGame
            // 
            this.BTN_DisconectarInGame.Location = new System.Drawing.Point(584, 494);
            this.BTN_DisconectarInGame.Name = "BTN_DisconectarInGame";
            this.BTN_DisconectarInGame.Size = new System.Drawing.Size(84, 23);
            this.BTN_DisconectarInGame.TabIndex = 4;
            this.BTN_DisconectarInGame.Text = "Desconectar";
            this.BTN_DisconectarInGame.UseVisualStyleBackColor = true;
            this.BTN_DisconectarInGame.Click += new System.EventHandler(this.BTN_DisconectarInGame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXT_NOMEOP);
            this.groupBox1.Location = new System.Drawing.Point(533, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Oponente";
            // 
            // TXT_NOMEOP
            // 
            this.TXT_NOMEOP.AutoSize = true;
            this.TXT_NOMEOP.Location = new System.Drawing.Point(6, 16);
            this.TXT_NOMEOP.Name = "TXT_NOMEOP";
            this.TXT_NOMEOP.Size = new System.Drawing.Size(21, 13);
            this.TXT_NOMEOP.TabIndex = 3;
            this.TXT_NOMEOP.Text = "{0}";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TXT_NOME1battle);
            this.groupBox2.Location = new System.Drawing.Point(533, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 120);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Suas Informações";
            // 
            // TXT_LAST
            // 
            this.TXT_LAST.AutoSize = true;
            this.TXT_LAST.Location = new System.Drawing.Point(533, 208);
            this.TXT_LAST.Name = "TXT_LAST";
            this.TXT_LAST.Size = new System.Drawing.Size(92, 13);
            this.TXT_LAST.TabIndex = 7;
            this.TXT_LAST.Text = "Seu ultimo acerto:";
            // 
            // Batalha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 529);
            this.Controls.Add(this.TXT_LAST);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTN_DisconectarInGame);
            this.Controls.Add(this.TXT_VEZ);
            this.Controls.Add(this.Grid_Minha);
            this.Controls.Add(this.Grade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Batalha";
            this.Text = "Batalha";
            ((System.ComponentModel.ISupportInitialize)(this.Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Minha)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumerosLetras;
        private System.Windows.Forms.DataGridViewImageColumn A;
        private System.Windows.Forms.DataGridViewImageColumn B;
        private System.Windows.Forms.DataGridViewImageColumn C;
        private System.Windows.Forms.DataGridViewImageColumn D;
        private System.Windows.Forms.DataGridViewImageColumn E;
        private System.Windows.Forms.DataGridViewImageColumn F;
        private System.Windows.Forms.DataGridViewImageColumn G;
        private System.Windows.Forms.DataGridViewImageColumn H;
        private System.Windows.Forms.DataGridViewImageColumn I;
        private System.Windows.Forms.DataGridViewImageColumn J;
        private System.Windows.Forms.DataGridView Grid_Minha;
        private System.Windows.Forms.Timer Ticks;
        private System.Windows.Forms.Label TXT_NOME1battle;
        private System.Windows.Forms.Label TXT_VEZ;
        private System.Windows.Forms.Button BTN_DisconectarInGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TXT_NOMEOP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label TXT_LAST;
    }
}