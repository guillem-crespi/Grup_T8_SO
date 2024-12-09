namespace WindowsFormsApplication1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.password_conf = new System.Windows.Forms.TextBox();
            this.button_Registro = new System.Windows.Forms.Button();
            this.button_LogIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Nick = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 250);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Confirmacion de Contraseña:";
            // 
            // password_conf
            // 
            this.password_conf.Location = new System.Drawing.Point(443, 247);
            this.password_conf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password_conf.Name = "password_conf";
            this.password_conf.Size = new System.Drawing.Size(168, 22);
            this.password_conf.TabIndex = 37;
            // 
            // button_Registro
            // 
            this.button_Registro.Location = new System.Drawing.Point(728, 229);
            this.button_Registro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Registro.Name = "button_Registro";
            this.button_Registro.Size = new System.Drawing.Size(128, 42);
            this.button_Registro.TabIndex = 36;
            this.button_Registro.Text = "Registrarse";
            this.button_Registro.UseVisualStyleBackColor = true;
            this.button_Registro.Click += new System.EventHandler(this.button_Registro_Click);
            // 
            // button_LogIn
            // 
            this.button_LogIn.Location = new System.Drawing.Point(728, 175);
            this.button_LogIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(128, 42);
            this.button_LogIn.TabIndex = 35;
            this.button_LogIn.Text = "Log In";
            this.button_LogIn.UseVisualStyleBackColor = true;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 212);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Contraseña:";
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(279, 170);
            this.Nick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(113, 16);
            this.Nick.TabIndex = 33;
            this.Nick.Text = "Nombre_Usuario:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(444, 208);
            this.password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(167, 22);
            this.password.TabIndex = 32;
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(443, 167);
            this.nickname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(168, 22);
            this.nickname.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 266);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "(solo para registrarse)";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_conf);
            this.Controls.Add(this.button_Registro);
            this.Controls.Add(this.button_LogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.password);
            this.Controls.Add(this.nickname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_conf;
        private System.Windows.Forms.Button button_Registro;
        private System.Windows.Forms.Button button_LogIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Nick;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.Label label4;
    }
}