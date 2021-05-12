
namespace Cliente
{
    partial class FormCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCliente));
            this.textBoxMensagens = new System.Windows.Forms.TextBox();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonFicheiros = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxMensagens
            // 
            this.textBoxMensagens.Location = new System.Drawing.Point(35, 449);
            this.textBoxMensagens.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMensagens.Name = "textBoxMensagens";
            this.textBoxMensagens.Size = new System.Drawing.Size(607, 29);
            this.textBoxMensagens.TabIndex = 1;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(190)))), ((int)(((byte)(65)))));
            this.buttonEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnviar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEnviar.ForeColor = System.Drawing.Color.White;
            this.buttonEnviar.Location = new System.Drawing.Point(82, 486);
            this.buttonEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(231, 42);
            this.buttonEnviar.TabIndex = 2;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = false;
            this.buttonEnviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // buttonFicheiros
            // 
            this.buttonFicheiros.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFicheiros.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFicheiros.Image = ((System.Drawing.Image)(resources.GetObject("buttonFicheiros.Image")));
            this.buttonFicheiros.Location = new System.Drawing.Point(35, 486);
            this.buttonFicheiros.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFicheiros.Name = "buttonFicheiros";
            this.buttonFicheiros.Size = new System.Drawing.Size(39, 42);
            this.buttonFicheiros.TabIndex = 3;
            this.buttonFicheiros.UseVisualStyleBackColor = false;
            // 
            // buttonSair
            // 
            this.buttonSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.buttonSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSair.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSair.ForeColor = System.Drawing.Color.White;
            this.buttonSair.Location = new System.Drawing.Point(411, 486);
            this.buttonSair.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(231, 42);
            this.buttonSair.TabIndex = 4;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = false;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // listBoxChat
            // 
            this.listBoxChat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.ItemHeight = 28;
            this.listBoxChat.Location = new System.Drawing.Point(35, 17);
            this.listBoxChat.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxChat.Size = new System.Drawing.Size(607, 424);
            this.listBoxChat.TabIndex = 5;
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 547);
            this.Controls.Add(this.listBoxChat);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonFicheiros);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.textBoxMensagens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCliente_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMensagens;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonFicheiros;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.ListBox listBoxChat;
    }
}
