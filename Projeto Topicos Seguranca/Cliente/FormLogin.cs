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

        private const int SALTSIZE = 8;
        private const int NUMBER_OF_ITERATIONS = 1000;

        byte[] salt;
        byte[] saltHash;
        byte[] password;

        private const int PORT = 2000; // Variavel que define a PORTA do cliente, tem de ser igual ao do servidor

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

        

        private void buttonLoginRegister_Click(object sender, EventArgs e)
        {
            if (isLogin == true)
            {
                //if (textBoxUsername.Text == username && textBoxPassword.Text == password)
                //{
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Credenciais Erradas!");
                //}

            }
            else
            {
                if(!String.IsNullOrWhiteSpace(textBoxUsername.Text) || !String.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    byte[] username = Encoding.UTF8.GetBytes(textBoxUsername.Text);

                    password = Encoding.UTF8.GetBytes(textBoxPassword.Text);
                    salt = GenerateSalt(SALTSIZE);//mudar para servidor

                    saltHash = GenerateSaltedHash(password, salt);//mudar apra servidor


                    byte[] packet = protocolSI.Make(ProtocolSICmdType.USER_OPTION_1, username); // Guarda a mensagem e o tipo do protocolo num array de bytes

                    networkStream.Write(packet, 0, packet.Length); // Insere o packet na Stream

                    while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                    {
                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Ler o buffer enquanto espera pelo ack(acknowledge)
                    }

                    byte[] packet = protocolSI.Make(ProtocolSICmdType.USER_OPTION_2, password); // Guarda a mensagem e o tipo do protocolo num array de bytes

                    networkStream.Write(packet, 0, packet.Length); // Insere o packet na Stream

                    while (protocolSI.GetCmdType() != ProtocolSICmdType.ACK)
                    {
                        networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length); // Ler o buffer enquanto espera pelo ack(acknowledge)
                    }

                }
                

                MessageBox.Show("just a test");
            }
        }

        private static byte[] GenerateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return buff;
        }

        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(plainText, salt, NUMBER_OF_ITERATIONS);
            return rfc2898.GetBytes(32);
        }

    }
}
