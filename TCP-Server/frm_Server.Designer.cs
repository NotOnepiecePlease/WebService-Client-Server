
namespace TCP_Server
{
    partial class frm_Server
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPortServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviarComando = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtScreenTextBox = new System.Windows.Forms.TextBox();
            this.btnIniciarServidor = new System.Windows.Forms.Button();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 30);
            this.label3.TabIndex = 24;
            this.label3.Text = "PORTA:";
            // 
            // txtPortServer
            // 
            this.txtPortServer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortServer.Location = new System.Drawing.Point(343, 22);
            this.txtPortServer.Name = "txtPortServer";
            this.txtPortServer.Size = new System.Drawing.Size(85, 33);
            this.txtPortServer.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 30);
            this.label2.TabIndex = 22;
            this.label2.Text = "IP:";
            // 
            // btnEnviarComando
            // 
            this.btnEnviarComando.Location = new System.Drawing.Point(434, 261);
            this.btnEnviarComando.Name = "btnEnviarComando";
            this.btnEnviarComando.Size = new System.Drawing.Size(75, 42);
            this.btnEnviarComando.TabIndex = 21;
            this.btnEnviarComando.Text = "Enviar";
            this.btnEnviarComando.UseVisualStyleBackColor = true;
            this.btnEnviarComando.Click += new System.EventHandler(this.btnEnviarComando_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(15, 261);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(413, 42);
            this.txtMessage.TabIndex = 20;
            // 
            // txtScreenTextBox
            // 
            this.txtScreenTextBox.Location = new System.Drawing.Point(12, 73);
            this.txtScreenTextBox.Multiline = true;
            this.txtScreenTextBox.Name = "txtScreenTextBox";
            this.txtScreenTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtScreenTextBox.Size = new System.Drawing.Size(497, 178);
            this.txtScreenTextBox.TabIndex = 19;
            // 
            // btnIniciarServidor
            // 
            this.btnIniciarServidor.Location = new System.Drawing.Point(434, 22);
            this.btnIniciarServidor.Name = "btnIniciarServidor";
            this.btnIniciarServidor.Size = new System.Drawing.Size(75, 34);
            this.btnIniciarServidor.TabIndex = 18;
            this.btnIniciarServidor.Text = "Iniciar Server";
            this.btnIniciarServidor.UseVisualStyleBackColor = true;
            this.btnIniciarServidor.Click += new System.EventHandler(this.btnIniciarServidor_Click_1);
            // 
            // txtIPServer
            // 
            this.txtIPServer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPServer.Location = new System.Drawing.Point(64, 22);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(159, 33);
            this.txtIPServer.TabIndex = 17;
            // 
            // frm_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(524, 313);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnviarComando);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtScreenTextBox);
            this.Controls.Add(this.btnIniciarServidor);
            this.Controls.Add(this.txtIPServer);
            this.Name = "frm_Server";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPortServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviarComando;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtScreenTextBox;
        private System.Windows.Forms.Button btnIniciarServidor;
        private System.Windows.Forms.TextBox txtIPServer;
    }
}

