using EI.SI;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Servidor
{
    class Program
    {
        private const int PORT = 2000; // Variavel que defina a PORTA do servidor

        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT); // Instancia o endPoint com a PORT
            TcpListener tcpListener = new TcpListener(endPoint); // Instancia um TCP Listener com o endPoint

            tcpListener.Start(); // Liga o servico do Listener

            Console.WriteLine("Server READY\n* * * * * * *");
            int clientCounter = 0;

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient(); // Aceita e liga os clientes "apanhados" pelo Listener

                clientCounter++;

                Console.WriteLine($"Client {clientCounter} connected");

                ClientHandler clientHandler = new ClientHandler(tcpClient, clientCounter);
                clientHandler.Handle();
            }
        }

        public class ClientHandler
        {
            private TcpClient tcpClient;
            private int clientID;

            public ClientHandler(TcpClient tcpClient, int clientID)
            {
                this.tcpClient = tcpClient;
                this.clientID = clientID;
            }

            public void Handle()
            {
                Thread thread1 = new Thread(threadHandler1);
                thread1.Start();
            }

            public void threadHandler1()
            {
                ProtocolSI protocolSI = new ProtocolSI();

                NetworkStream networkStream = this.tcpClient.GetStream();

                while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT)
                {
                    try
                    {
                        int bytesRead = networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Guarda o numero de bytes lidos
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"Cliente {clientID} perdeu a ligação ao servidor\n*Erro - {error.Message}");                        
                    }

                    byte[] ack = protocolSI.Make(ProtocolSICmdType.ACK); // Guarda uma mensagem tipo ACK(Acknowlodge) no array de bytes

                    switch (protocolSI.GetCmdType())
                    {
                        case ProtocolSICmdType.DATA:
                            Console.WriteLine($"Client {clientID}: " + protocolSI.GetStringFromData());

                            networkStream.Write(ack, 0, ack.Length); // Insere o ack na Stream

                            byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, "recebido"); // Guarda a mensagem e o tipo do protocolo num array de bytes

                            networkStream.Write(packet, 0, packet.Length); // Insere o packet na Stream

                            while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                            {
                                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Ler o buffer enquanto espera pelo ack(acknowledge)
                            }
                            break;

                        case ProtocolSICmdType.USER_OPTION_1:
                            Console.WriteLine($"username: {protocolSI.GetStringFromData()}");
                            networkStream.Write(ack, 0, ack.Length); // Insere o ack na Stream

                            Console.WriteLine($"saltHash: {protocolSI.GetStringFromData()}");
                            networkStream.Write(ack, 0, ack.Length); // Insere o ack na Stream

                            Console.WriteLine($"salt: {protocolSI.GetStringFromData()}");
                            networkStream.Write(ack, 0, ack.Length); // Insere o ack na Stream
                            break;


                        case ProtocolSICmdType.EOT:
                            Console.WriteLine($"Client {clientID} has disconnected");

                            networkStream.Write(ack, 0, ack.Length); // Insere o ack na Stream
                            break;


                    }
                }

                networkStream.Close(); // Fecha o servico da Stream
                tcpClient.Close(); // Encerra o cliente TCP
            }

            private void Register(string username, byte[] saltedPasswordHash, byte[] salt)
            {
                SqlConnection conn = null;

                try
                {
                    // Configurar ligação à Base de Dados
                    conn = new SqlConnection();
                    conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mrace\OneDrive\Ambiente de Trabalho\TS\ProjetoTS\projetoTopicosSeguranca_2020.2021\Projeto Topicos Seguranca\Servidor\DatabaseTS.mdf;Integrated Security=True");

                    // Abrir ligação à Base de Dados
                    conn.Open();

                    // Declaração dos parâmetros do comando SQL
                    SqlParameter paramUsername = new SqlParameter("@username", username);
                    SqlParameter paramPassHash = new SqlParameter("@saltedPasswordHash", saltedPasswordHash);
                    SqlParameter paramSalt = new SqlParameter("@salt", salt);

                    // Declaração do comando SQL
                    String sql = "INSERT INTO Users (Username, SaltedPasswordHash, Salt) VALUES (@username,@saltedPasswordHash,@salt)";

                    // Prepara comando SQL para ser executado na Base de Dados
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Introduzir valores aos parâmentros registados no comando SQL
                    cmd.Parameters.Add(paramUsername);
                    cmd.Parameters.Add(paramPassHash);
                    cmd.Parameters.Add(paramSalt);

                    // Executar comando SQL
                    int lines = cmd.ExecuteNonQuery();

                    // Fechar ligação
                    conn.Close();
                    if (lines == 0)
                    {
                        // Se forem devolvidas 0 linhas alteradas então o não foi executado com sucesso
                        throw new Exception("Error while inserting an user");
                    }
                }
                catch (Exception e)
                {

                    throw new Exception("Error while inserting an user:" + e.Message);
                }
            }
        }
    }
}
