namespace BatalhaNaval
{
    partial class Aguarde
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
            this.TXT_AGUARDE = new System.Windows.Forms.Label();
            this.BTN_ABORTAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TXT_AGUARDE
            // 
            this.TXT_AGUARDE.AutoSize = true;
            this.TXT_AGUARDE.Location = new System.Drawing.Point(42, 35);
            this.TXT_AGUARDE.Name = "TXT_AGUARDE";
            this.TXT_AGUARDE.Size = new System.Drawing.Size(128, 13);
            this.TXT_AGUARDE.TabIndex = 0;
            this.TXT_AGUARDE.Text = "Waiting for another player";
            this.TXT_AGUARDE.UseWaitCursor = true;
            // 
            // BTN_ABORTAR
            // 
            this.BTN_ABORTAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_ABORTAR.Location = new System.Drawing.Point(71, 65);
            this.BTN_ABORTAR.Name = "BTN_ABORTAR";
            this.BTN_ABORTAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_ABORTAR.TabIndex = 1;
            this.BTN_ABORTAR.Text = "Abort";
            this.BTN_ABORTAR.UseVisualStyleBackColor = true;
            this.BTN_ABORTAR.UseWaitCursor = true;
            // 
            // Aguarde
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_ABORTAR;
            this.ClientSize = new System.Drawing.Size(217, 110);
            this.Controls.Add(this.BTN_ABORTAR);
            this.Controls.Add(this.TXT_AGUARDE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Aguarde";
            this.Text = "Waiting for another player";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TXT_AGUARDE;
        private System.Windows.Forms.Button BTN_ABORTAR;
    }
}