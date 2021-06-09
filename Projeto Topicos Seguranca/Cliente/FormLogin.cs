using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Sockets;
using EI.SI;
using System.Net;

namespace Cliente
{
    public partial class FormLogin : Form
    {

        bool isLogin = true;

        private const int PORT = 2000; // Variavel que define a PORTA do cliente, tem de ser igual ao do servidor

        FormCliente formCliente;
        NetworkStream networkStream;
        ProtocolSI protocolSI;
        TcpClient tcpClient;

        public FormLogin()
        {
            InitializeComponent();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT); // Instancia o endPoint com a PORT

            tcpClient = new TcpClient(); // Instancia o cliente TCP
            tcpClient.Connect(endPoint); // Conecta o cliente pelo EndPoint

            networkStream = tcpClient.GetStream();
            protocolSI = new ProtocolSI();
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

        private void radioButtonLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Login";
            buttonLoginRegister.Text = "Login";
            isLogin = true;
        }

        private void radioButtonRegister_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Register";
            buttonLoginRegister.Text = "Register";
            isLogin = false;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            fechaPrograma();
        }

        // 'Enter' faz login/registo
        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonLoginRegister.PerformClick();
            }
        }

        // 'Enter' faz login/registo
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonLoginRegister.PerformClick();
            }
        }

        #endregion

        private void buttonLoginRegister_Click(object sender, EventArgs e)
        {
            if (isLogin == true)
            {
                string msg = "";

                byte[] option1 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_1, textBoxUsername.Text);

                networkStream.Write(option1, 0, option1.Length);

                while (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
                {
                    networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                }

                byte[] option3 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_3, textBoxPassword.Text);

                networkStream.Write(option3, 0, option3.Length);

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

                if (!String.IsNullOrWhiteSpace(msg))
                {
                    MessageBox.Show(msg, "Login.");
                }

                formCliente = new FormCliente(networkStream, protocolSI, tcpClient);
                this.Hide();
                formCliente.ShowDialog();
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(textBoxUsername.Text) || !String.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    string msg = "";

                    byte[] option1 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_1, textBoxUsername.Text);

                    networkStream.Write(option1, 0, option1.Length);

                    while (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
                    {
                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                    }

                    byte[] option2 = protocolSI.Make(ProtocolSICmdType.USER_OPTION_2, textBoxPassword.Text);

                    networkStream.Write(option2, 0, option2.Length);

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

                    if (!String.IsNullOrWhiteSpace(msg))
                    {
                        MessageBox.Show(msg, "Registo.");
                    }

                    formCliente = new FormCliente(networkStream, protocolSI, tcpClient);
                    this.Hide();
                    formCliente.ShowDialog();
                }
            }
        }
    }
}
