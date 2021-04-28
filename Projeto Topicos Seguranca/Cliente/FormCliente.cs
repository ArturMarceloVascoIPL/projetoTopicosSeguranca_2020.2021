using EI.SI;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Cliente
{
    public partial class FormCliente : Form
    {
        private const int PORT = 2000; // Variavel que define a PORTA do cliente, tem de ser igual ao do servidor

        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient tcpClient;

        public FormCliente()
        {
            InitializeComponent();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT); // Instancia o endPoint com a PORT

            tcpClient = new TcpClient(); // Instancia o cliente TCP
            tcpClient.Connect(endPoint); // Conecta o cliente pelo EndPoint

            networkStream = tcpClient.GetStream();

            protocolSI = new ProtocolSI();
        }

        private void Enviar_Click(object sender, EventArgs e)
        {
            string msg = textBoxMensagens.Text;

            if (String.IsNullOrWhiteSpace(msg)) // Verifica se a mensagem está vazia
            {
                // Avisa o utilizador que não pode mandar uma mensagem vazia
                MessageBox.Show("Tem de inserir uma mensagem!", "Mensagem Necessária!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBoxMensagens.Clear(); // Limpa a caixa de texto
                listBoxChat.Items.Add($"You: {msg}"); // Apresenta a mensagem no "chat"

                byte[] packet = protocolSI.Make(ProtocolSICmdType.DATA, msg); // Guarda a mensagem e o tipo do protocolo num array de bytes

                networkStream.Write(packet, 0, packet.Length); // Insere o packet na Stream

                while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Ler o buffer enquanto espera pelo ack(acknowledge)
                }
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            fechaPrograma();
        }

        /* 
         * Funcao fechaPrograma:
         * Funcao com o objetivo de confirmar com o utilizador se este quer sair do programa
         * e caso confirme que sim, enviar a mensagem de EOT ao servidor, fechar os servicos
         * e fechar o formulario. 
         */
        private void fechaPrograma()
        {
            var response = MessageBox.Show("Quer mesmo sair?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT); // Guarda uma mensagem tipo EOT(End Of Transmission) no array de bytes

                networkStream.Write(eot, 0, eot.Length); // Insere o eot na Stream
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                networkStream.Close(); // Fecha o servico da Stream
                tcpClient.Close(); // Encerra o cliente TCP
                this.Close(); // Fecha o formulario
            }
        }
    }
}
