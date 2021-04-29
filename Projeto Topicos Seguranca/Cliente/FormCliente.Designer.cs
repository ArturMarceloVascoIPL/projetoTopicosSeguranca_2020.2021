
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
            this.textBoxMensagens.Location = new System.Drawing.Point(27, 339);
            this.textBoxMensagens.Name = "textBoxMensagens";
            this.textBoxMensagens.Size = new System.Drawing.Size(473, 23);
            this.textBoxMensagens.TabIndex = 1;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEnviar.Location = new System.Drawing.Point(63, 370);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(180, 30);
            this.buttonEnviar.TabIndex = 2;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // buttonFicheiros
            // 
            this.buttonFicheiros.Image = ((System.Drawing.Image)(resources.GetObject("buttonFicheiros.Image")));
            this.buttonFicheiros.Location = new System.Drawing.Point(27, 370);
            this.buttonFicheiros.Name = "buttonFicheiros";
            this.buttonFicheiros.Size = new System.Drawing.Size(30, 30);
            this.buttonFicheiros.TabIndex = 3;
            this.buttonFicheiros.UseVisualStyleBackColor = true;
            // 
            // buttonSair
            // 
            this.buttonSair.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSair.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonSair.Location = new System.Drawing.Point(320, 370);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(180, 30);
            this.buttonSair.TabIndex = 4;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // listBoxChat
            // 
            this.listBoxChat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.ItemHeight = 21;
            this.listBoxChat.Location = new System.Drawing.Point(27, 12);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxChat.Size = new System.Drawing.Size(473, 319);
            this.listBoxChat.TabIndex = 5;
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 405);
            this.Controls.Add(this.listBoxChat);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonFicheiros);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.textBoxMensagens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCliente";
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