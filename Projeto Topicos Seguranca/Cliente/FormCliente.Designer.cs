
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
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxMensagens = new System.Windows.Forms.TextBox();
            this.Enviar = new System.Windows.Forms.Button();
            this.buttonFicheiros = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Location = new System.Drawing.Point(27, 22);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.Size = new System.Drawing.Size(473, 311);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxMensagens
            // 
            this.textBoxMensagens.Location = new System.Drawing.Point(27, 339);
            this.textBoxMensagens.Name = "textBoxMensagens";
            this.textBoxMensagens.Size = new System.Drawing.Size(473, 23);
            this.textBoxMensagens.TabIndex = 1;
            // 
            // Enviar
            // 
            this.Enviar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Enviar.Location = new System.Drawing.Point(63, 370);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(180, 30);
            this.Enviar.TabIndex = 2;
            this.Enviar.Text = "Enviar";
            this.Enviar.UseVisualStyleBackColor = true;
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
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 405);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonFicheiros);
            this.Controls.Add(this.Enviar);
            this.Controls.Add(this.textBoxMensagens);
            this.Controls.Add(this.richTextBoxChat);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxMensagens;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.Button buttonFicheiros;
        private System.Windows.Forms.Button buttonSair;
    }
}