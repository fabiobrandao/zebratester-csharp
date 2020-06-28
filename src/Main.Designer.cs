namespace ZebraTester
{
    partial class Main
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblZplData = new System.Windows.Forms.Label();
            this.txbZplData = new System.Windows.Forms.TextBox();
            this.txbQtd = new System.Windows.Forms.TextBox();
            this.lblQtd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(189, 172);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txbIP
            // 
            this.txbIP.Location = new System.Drawing.Point(72, 10);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(192, 20);
            this.txbIP.TabIndex = 1;
            this.txbIP.Text = "192.168.2.100";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(13, 13);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(53, 13);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "Printer IP:";
            // 
            // lblZplData
            // 
            this.lblZplData.AutoSize = true;
            this.lblZplData.Location = new System.Drawing.Point(13, 45);
            this.lblZplData.Name = "lblZplData";
            this.lblZplData.Size = new System.Drawing.Size(56, 13);
            this.lblZplData.TabIndex = 3;
            this.lblZplData.Text = "ZPL Data:";
            // 
            // txbZplData
            // 
            this.txbZplData.Location = new System.Drawing.Point(13, 61);
            this.txbZplData.Multiline = true;
            this.txbZplData.Name = "txbZplData";
            this.txbZplData.Size = new System.Drawing.Size(251, 83);
            this.txbZplData.TabIndex = 4;
            this.txbZplData.Text = "^XA^FO20,20^A0N,25,25^FDThis is a ZPL test.^FS^XZ";
            // 
            // txbQtd
            // 
            this.txbQtd.Location = new System.Drawing.Point(13, 172);
            this.txbQtd.Name = "txbQtd";
            this.txbQtd.Size = new System.Drawing.Size(46, 20);
            this.txbQtd.TabIndex = 5;
            this.txbQtd.Text = "1";
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Location = new System.Drawing.Point(10, 156);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(49, 13);
            this.lblQtd.TabIndex = 6;
            this.lblQtd.Text = "Quantity:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 207);
            this.Controls.Add(this.lblQtd);
            this.Controls.Add(this.txbQtd);
            this.Controls.Add(this.txbZplData);
            this.Controls.Add(this.lblZplData);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txbIP);
            this.Controls.Add(this.btnPrint);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zebra Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblZplData;
        private System.Windows.Forms.TextBox txbZplData;
        private System.Windows.Forms.TextBox txbQtd;
        private System.Windows.Forms.Label lblQtd;
    }
}

