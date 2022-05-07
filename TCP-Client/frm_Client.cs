using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TCP_Client
{
    public partial class frm_Client : Form
    {
        private TcpClient client;
        //private TcpClient client = new TcpClient();

        private TcpListener listener;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string TextToSend;
        private string ipToConnect;

        public frm_Client()
        {
            InitializeComponent();

            backgroundWorker1.WorkerSupportsCancellation = true;
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    //txtIPServer.Text = address.ToString();
                    ipToConnect = address.ToString();
                }
            }
        }

        private void btnConectarServidor_Click(object sender, EventArgs e)
        {
            ConectarServer();
        }

        public void IniciarServer()
        {
            try
            {
                //TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(txtPortServer.Text));
                listener.Start();
                client = listener.AcceptTcpClient();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream());
                STW.AutoFlush = true;
                //backgroundWorker1.CancelAsync();
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                backgroundWorker2.WorkerSupportsCancellation = true;
                //MessageBox.Show("Conectado!");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"[btnIniciarServidor]" + exception.Message);
            }
        }

        public void ConectarServer()
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ipToConnect), int.Parse("80"));
            client.Connect(IpEnd);

            try
            {
                txtScreenTextBox.AppendText("Connect to Server");
                txtScreenTextBox.AppendText(Environment.NewLine);
                STW = new StreamWriter(client.GetStream());
                STR = new StreamReader(client.GetStream());
                STW.AutoFlush = true;

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }

                // backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"[ConectarServer]" + exception.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = STR.ReadLine();
                    if (recieve == null)
                    {
                        e.Cancel = true;
                        client.Close();
                        IniciarServer();
                        return;
                    }
                    this.txtScreenTextBox.Invoke(new MethodInvoker(delegate ()
                    {
                        txtScreenTextBox.AppendText("Server: " + recieve + "\n");
                        txtScreenTextBox.AppendText(Environment.NewLine);
                    }));
                    recieve = "";
                }
                catch (Exception exception)
                {
                    //MessageBox.Show($"[backg1]" + exception.Message);
                    IniciarServer();
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                this.txtScreenTextBox.Invoke(new MethodInvoker(delegate ()
                {
                    txtScreenTextBox.AppendText("Eu: " + TextToSend + "\n");
                    txtScreenTextBox.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                MessageBox.Show("Sending Failed");
            }

            backgroundWorker2.CancelAsync();
        }

        private void btnEnviarComando_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                TextToSend = txtMessage.Text;
                backgroundWorker2.RunWorkerAsync();
            }

            txtMessage.Text = "";
        }

        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            IniciarServer();
        }

        private void frm_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            //client.Close();
            try
            {
                STW.WriteLine("Conexao Perdida");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Servidor Fechado, Sem Resposta!");
            }
        }
    }
}