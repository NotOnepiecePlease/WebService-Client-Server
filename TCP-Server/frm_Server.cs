using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TCP_Server
{
    public partial class frm_Server : Form
    {
        private TcpClient Client;
        private TcpListener Listener;
        private StreamReader STR;
        private StreamWriter STW;
        private string Received;
        private string TextToSend;

        public frm_Server()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            //Apenas pegando o IP local e a Porta escolhida e ja deixando setado
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtIPServer.Text = address.ToString();
                }
            }

            txtPortServer.Text = "80";
            //Inicio a instancia do Listener (responsavel por ouvir as conexoes q vao vir)
            Listener = new TcpListener(IPAddress.Any, int.Parse(txtPortServer.Text));
        }

        public void IniciarServer()
        {
            try
            {
                Listener.Start(); //Inicio o Listener
                Client = Listener.AcceptTcpClient(); //Aqui o codigo fica parado aguardando uma conexao de fora, assim que conectar, ele segue adiante
                STR = new StreamReader(Client.GetStream()); //Apos conectado, o codigo inicia o processo de leitura de dados
                STW = new StreamWriter(Client.GetStream()); // e o processo da escrita de dados
                STW.AutoFlush = true; //Libera o buffer para as proximas escritas

                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync(); //Inicia o backgroundWork, responsavel por ficar ouvindo o que o Client vai mandar para ele ler.
                }
                backgroundWorker2.WorkerSupportsCancellation = true; //Permitindo o cancelamento do backworker2 (responsavel pela escrita)
            }
            catch (Exception exception)
            {
                MessageBox.Show($"[btnIniciarServidor]" + exception.Message);
            }
        }

        private void btnIniciarServidor_Click_1(object sender, EventArgs e)
        {
            IniciarServer();
        }

        private void btnEnviarComando_Click(object sender, EventArgs e)
        {
            //Aqui eu escrevo o texto de volta para o Client
            if (txtMessage.Text != "")
            {
                TextToSend = txtMessage.Text;
                backgroundWorker2.RunWorkerAsync(); //Inicio o background2 que é responsavel por escrever de volta
            }

            txtMessage.Text = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Client.Connected) //Inicio o processo de leitura enquanto tem conexao
            {
                try
                {
                    Received = STR.ReadLine(); //Aqui o server para, pois ele espera o Client escrever algo
                    if (Received == null) //Caso o receive seja nulo, significa que nao tem conexao, cancelo a thread e reinicio o servidor
                    {
                        e.Cancel = true;
                        Client.Close();
                        IniciarServer();
                        return;
                    }
                    this.txtScreenTextBox.Invoke(new MethodInvoker(delegate () //Invoke para evitar conflito com a thread, ja que to alterando um componente UI
                    {
                        txtScreenTextBox.AppendText("Client: " + Received + "\n");
                        txtScreenTextBox.AppendText(Environment.NewLine);
                    }));

                    List<string> count = SelectCount(Received); //Pego o comando do Client, e executo no metodo (a query no caso)
                    //string Nome = "";
                    foreach (string nome in count)
                    {
                        STW.WriteAsync(nome); //Escrevo de volta o retorno que o Client pediu
                        //Nome += nome + "\n";
                    }
                    Received = "";
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
            if (Client.Connected) //Verifico se existe uma conexao
            {
                STW.WriteLine(TextToSend); //Escrevo a mensagem de volta para o Client
                this.txtScreenTextBox.Invoke(new MethodInvoker(delegate () //Invoke usado aqui pra nao ter conflito com a thread
                {
                    txtScreenTextBox.AppendText("Eu: " + TextToSend); //Pegando o texto existente no textbox e adicionado os proximos (mantendo um historico)
                    txtScreenTextBox.AppendText(Environment.NewLine); //Pular uma linha
                }));
            }
            else
            {
                MessageBox.Show("Sending Failed"); //Caso nao tenha nenhuma conexao
            }

            backgroundWorker2.CancelAsync(); //Apos escrever eu cancelo a thread, nao preciso escrever nada por hora.
        }

        //Metodo pra buscar a query no banco e retornar para o Client
        public static List<string> SelectCount(string _query)
        {
            try
            {
                string dataSource = "localhost";
                string user = "sa";
                string pass = "123adr";
                string database = "standby_org";

                string connectionString = $"Server={dataSource};Database={database};User Id={user};Password={pass};";

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                using (con)
                {
                    //string query = "select count(*) from tb_clientes";

                    SqlDataAdapter adapter = new SqlDataAdapter(_query, con);
                    SqlDataReader reader = adapter.SelectCommand.ExecuteReader();

                    List<string> listagem = new List<string>();
                    //reader.Read();
                    while (reader.Read())
                    {
                        listagem.Add(reader.GetString(0));
                    }
                    // string qnt = reader.GetInt32(0).ToString();

                    return listagem;
                }
            }
            catch (Exception e)
            {
                List<string> error = new List<string>
                {
                    e.Message
                };
                return error;
                //throw;
            }
        }
    }
}