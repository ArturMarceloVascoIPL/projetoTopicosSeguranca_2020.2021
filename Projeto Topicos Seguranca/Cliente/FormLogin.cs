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
        public FormLogin()
        {
            InitializeComponent();

        }

        private void radioButtonLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Login";
            buttonLoginRegister.Text = "Login";
        }

        private void radioButtonRegister_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Register";
            buttonLoginRegister.Text= "Register";
        }
    }
}
