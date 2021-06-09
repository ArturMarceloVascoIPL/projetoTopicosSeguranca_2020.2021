using EI.SI;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class FormCliente : Form
    {
        private const int PORT = 2000; // Variavel que define a PORTA do cliente, tem de ser igual ao do servidor

        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient tcpClient;

        public FormCliente(NetworkStream ns, ProtocolSI psi, TcpClient tcp)
        {
            this.networkStream = ns;
            this.protocolSI = psi;
            this.tcpClient = tcp;

            InitializeComponent();
        }

        #region Funcoes

        /* 
         * Funcao fechaPrograma:
         * Funcao com o objetivo de confirmar com o utilizador se este quer sair do programa
         * e caso confirme que sim, enviar a mensagem de EOT ao servidor, fechar os servicos
         * e fechar o formulario. 
         */
        private bool fechaPrograma()
        {
            var response = MessageBox.Show("Quer mesmo sair?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                byte[] eot = protocolSI.Make(ProtocolSICmdType.EOT); // Guarda uma mensagem tipo EOT(End Of Transmission) no array de bytes

                networkStream.Write(eot, 0, eot.Length); // Insere o eot na Stream
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                networkStream.Close(); // Fecha o servico da Stream
                tcpClient.Close(); // Encerra o cliente TCP
                Environment.Exit(Environment.ExitCode);// Limpa a memória e fecha a thread

                return false; // Retorna false para o formulario continuar a fechar
            }
            else
            {
                return true; // Retorna true para cancelar o fecho do formulario
            }
        }

        #endregion

        #region MiscEvents

        private void FormCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = fechaPrograma(); // Recebe true ou false dependendo da resposta do utilizador na funcao
        }

        //Enter envia a mensagem
        private void textBoxMensagens_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonEnviar.PerformClick();
            }
        }

        #endregion

        private void Enviar_Click(object sender, EventArgs e)
        {
            string msg = "";

            byte[] userData = protocolSI.Make(ProtocolSICmdType.DATA, textBoxMensagem.Text);

            networkStream.Write(userData, 0, userData.Length);

            while (true)
            {
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
                {
                    break;
                }
                else if (protocolSI.GetCmdType() == ProtocolSICmdType.DATA)
                {
                    msg = msg + protocolSI.GetStringFromData();
                }
            }

            listBoxChat.Items.Insert(0, $"Cliente: {textBoxMensagem.Text}");
            textBoxMensagem.Clear();

            if (!String.IsNullOrWhiteSpace(msg))
            {
                listBoxChat.Items.Insert(0, $"Server: {msg}");
            }
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulario, iniciando o evento formClosing
        }

        private void panelFicheiros_Click(object sender, EventArgs e)
        {
            var filePath = openFileDialog.FileName;
        }
    }
}
