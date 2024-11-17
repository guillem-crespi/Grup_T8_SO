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
            this.label1.Location = new System.Drawing.Point(173, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Confirmacion de Contraseña:";
            // 
            // password_conf
            // 
            this.password_conf.Location = new System.Drawing.Point(332, 201);
            this.password_conf.Name = "password_conf";
            this.password_conf.Size = new System.Drawing.Size(127, 20);
            this.password_conf.TabIndex = 37;
            // 
            // button_Registro
            // 
            this.button_Registro.Location = new System.Drawing.Point(546, 186);
            this.button_Registro.Name = "button_Registro";
            this.button_Registro.Size = new System.Drawing.Size(96, 34);
            this.button_Registro.TabIndex = 36;
            this.button_Registro.Text = "Registrarse";
            this.button_Registro.UseVisualStyleBackColor = true;
            this.button_Registro.Click += new System.EventHandler(this.button_Registro_Click);
            // 
            // button_LogIn
            // 
            this.button_LogIn.Location = new System.Drawing.Point(546, 142);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(96, 34);
            this.button_LogIn.TabIndex = 35;
            this.button_LogIn.Text = "Log In";
            this.button_LogIn.UseVisualStyleBackColor = true;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Contraseña:";
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(209, 138);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(89, 13);
            this.Nick.TabIndex = 33;
            this.Nick.Text = "Nombre_Usuario:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(333, 169);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(126, 20);
            this.password.TabIndex = 32;
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(332, 136);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(127, 20);
            this.nickname.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "(solo para registrarse)";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_conf);
            this.Controls.Add(this.button_Registro);
            this.Controls.Add(this.button_LogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.password);
            this.Controls.Add(this.nickname);
            this.Name = "Form3";
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