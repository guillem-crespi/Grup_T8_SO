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
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 304);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Confirmación de contraseña:";
            // 
            // password_conf
            // 
            this.password_conf.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_conf.Location = new System.Drawing.Point(495, 301);
            this.password_conf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password_conf.Name = "password_conf";
            this.password_conf.Size = new System.Drawing.Size(188, 26);
            this.password_conf.TabIndex = 37;
            // 
            // button_Registro
            // 
            this.button_Registro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Registro.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Registro.Location = new System.Drawing.Point(736, 275);
            this.button_Registro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Registro.Name = "button_Registro";
            this.button_Registro.Size = new System.Drawing.Size(144, 52);
            this.button_Registro.TabIndex = 36;
            this.button_Registro.Text = "Registrarse";
            this.button_Registro.UseVisualStyleBackColor = false;
            this.button_Registro.Click += new System.EventHandler(this.button_Registro_Click);
            // 
            // button_LogIn
            // 
            this.button_LogIn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_LogIn.CausesValidation = false;
            this.button_LogIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_LogIn.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_LogIn.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LogIn.ForeColor = System.Drawing.Color.Black;
            this.button_LogIn.Location = new System.Drawing.Point(736, 201);
            this.button_LogIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(144, 52);
            this.button_LogIn.TabIndex = 35;
            this.button_LogIn.Text = "Log In";
            this.button_LogIn.UseVisualStyleBackColor = false;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(352, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "Contraseña:";
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nick.Location = new System.Drawing.Point(282, 204);
            this.Nick.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(188, 18);
            this.Nick.TabIndex = 33;
            this.Nick.Text = "Nombre de usuario:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(495, 252);
            this.password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(189, 26);
            this.password.TabIndex = 32;
            // 
            // nickname
            // 
            this.nickname.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nickname.Location = new System.Drawing.Point(495, 204);
            this.nickname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(188, 26);
            this.nickname.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(192, 324);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 18);
            this.label4.TabIndex = 39;
            this.label4.Text = "(solo para nuevos usuarios)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumPurple;
            this.label2.Location = new System.Drawing.Point(67, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1081, 63);
            this.label2.TabIndex = 20;
            this.label2.Text = "¡Bienvenido al juego de la OCA!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.imagen;
            this.pictureBox1.ErrorImage = global::WindowsFormsApplication1.Properties.Resources.imagen;
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.imagen;
            this.pictureBox1.Location = new System.Drawing.Point(444, 358);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_conf);
            this.Controls.Add(this.button_Registro);
            this.Controls.Add(this.button_LogIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.password);
            this.Controls.Add(this.nickname);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido al juego de la oca";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.PictureBox pictureBox1;
    }
}