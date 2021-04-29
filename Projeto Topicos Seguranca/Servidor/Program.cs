using EI.SI;
using System;
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
        }
    }
}
