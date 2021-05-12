using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class FormLogin : Form
    {
        string username = "teste";
        string password = "teste";
        bool isLogin = true;

        public FormLogin()
        {
            InitializeComponent();
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
                if (textBoxUsername.Text == username && textBoxPassword.Text == password)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciais Erradas!");
                }
            }
            else
            {
                MessageBox.Show("Registado(not really, just a test)");
            }
        }
    }
}
