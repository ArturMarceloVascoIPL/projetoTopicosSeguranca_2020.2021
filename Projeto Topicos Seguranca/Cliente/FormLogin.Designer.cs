﻿
namespace Cliente
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoginRegister = new System.Windows.Forms.Button();
            this.l_label1 = new System.Windows.Forms.Label();
            this.l_label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.radioButtonLogin = new System.Windows.Forms.RadioButton();
            this.radioButtonRegister = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoginRegister
            // 
            this.buttonLoginRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLoginRegister.Location = new System.Drawing.Point(11, 263);
            this.buttonLoginRegister.Name = "buttonLoginRegister";
            this.buttonLoginRegister.Size = new System.Drawing.Size(200, 35);
            this.buttonLoginRegister.TabIndex = 0;
            this.buttonLoginRegister.Text = "Login";
            this.buttonLoginRegister.UseVisualStyleBackColor = true;
            // 
            // l_label1
            // 
            this.l_label1.AutoSize = true;
            this.l_label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_label1.Location = new System.Drawing.Point(12, 11);
            this.l_label1.Name = "l_label1";
            this.l_label1.Size = new System.Drawing.Size(103, 28);
            this.l_label1.TabIndex = 1;
            this.l_label1.Text = "Username:";
            // 
            // l_label2
            // 
            this.l_label2.AutoSize = true;
            this.l_label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_label2.Location = new System.Drawing.Point(12, 76);
            this.l_label2.Name = "l_label2";
            this.l_label2.Size = new System.Drawing.Size(97, 28);
            this.l_label2.TabIndex = 2;
            this.l_label2.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(12, 42);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(200, 23);
            this.textBoxUsername.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(12, 107);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(200, 23);
            this.textBoxPassword.TabIndex = 4;
            // 
            // radioButtonLogin
            // 
            this.radioButtonLogin.AutoSize = true;
            this.radioButtonLogin.Checked = true;
            this.radioButtonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonLogin.Location = new System.Drawing.Point(12, 13);
            this.radioButtonLogin.Name = "radioButtonLogin";
            this.radioButtonLogin.Size = new System.Drawing.Size(67, 25);
            this.radioButtonLogin.TabIndex = 5;
            this.radioButtonLogin.TabStop = true;
            this.radioButtonLogin.Text = "Login";
            this.radioButtonLogin.UseVisualStyleBackColor = true;
            this.radioButtonLogin.CheckedChanged += new System.EventHandler(this.radioButtonLogin_CheckedChanged);
            // 
            // radioButtonRegister
            // 
            this.radioButtonRegister.AutoSize = true;
            this.radioButtonRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonRegister.Location = new System.Drawing.Point(12, 44);
            this.radioButtonRegister.Name = "radioButtonRegister";
            this.radioButtonRegister.Size = new System.Drawing.Size(85, 25);
            this.radioButtonRegister.TabIndex = 6;
            this.radioButtonRegister.Text = "Register";
            this.radioButtonRegister.UseVisualStyleBackColor = true;
            this.radioButtonRegister.CheckedChanged += new System.EventHandler(this.radioButtonRegister_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonRegister);
            this.panel1.Controls.Add(this.radioButtonLogin);
            this.panel1.Location = new System.Drawing.Point(12, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 78);
            this.panel1.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 310);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.l_label2);
            this.Controls.Add(this.l_label1);
            this.Controls.Add(this.buttonLoginRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoginRegister;
        private System.Windows.Forms.Label l_label1;
        private System.Windows.Forms.Label l_label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.RadioButton radioButtonLogin;
        private System.Windows.Forms.RadioButton radioButtonRegister;
        private System.Windows.Forms.Panel panel1;
    }
}

