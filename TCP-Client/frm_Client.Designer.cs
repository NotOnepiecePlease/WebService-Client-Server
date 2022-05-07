
namespace TCP_Client
{
    partial class frm_Client
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
            this.txtScreenTextBox = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnEnviarComando = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btnConectarServidor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtScreenTextBox
            // 
            this.txtScreenTextBox.Location = new System.Drawing.Point(20, 50);
            this.txtScreenTextBox.Multiline = true;
            this.txtScreenTextBox.Name = "txtScreenTextBox";
            this.txtScreenTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScreenTextBox.Size = new System.Drawing.Size(497, 178);
            this.txtScreenTextBox.TabIndex = 4;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(23, 234);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(413, 42);
            this.txtMessage.TabIndex = 5;
            // 
            // btnEnviarComando
            // 
            this.btnEnviarComando.Location = new System.Drawing.Point(442, 234);
            this.btnEnviarComando.Name = "btnEnviarComando";
            this.btnEnviarComando.Size = new System.Drawing.Size(75, 42);
            this.btnEnviarComando.TabIndex = 6;
            this.btnEnviarComando.Text = "Enviar";
            this.btnEnviarComando.UseVisualStyleBackColor = true;
            this.btnEnviarComando.Click += new System.EventHandler(this.btnEnviarComando_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // btnConectarServidor
            // 
            this.btnConectarServidor.Location = new System.Drawing.Point(140, 11);
            this.btnConectarServidor.Name = "btnConectarServidor";
            this.btnConectarServidor.Size = new System.Drawing.Size(257, 33);
            this.btnConectarServidor.TabIndex = 11;
            this.btnConectarServidor.Text = "Conectar";
            this.btnConectarServidor.UseVisualStyleBackColor = true;
            this.btnConectarServidor.Click += new System.EventHandler(this.btnConectarServidor_Click);
            // 
            // frm_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 292);
            this.Controls.Add(this.btnConectarServidor);
            this.Controls.Add(this.btnEnviarComando);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtScreenTextBox);
            this.Name = "frm_Client";
            this.ShowIcon = false;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Client_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtScreenTextBox;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEnviarComando;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btnConectarServidor;
    }
}

