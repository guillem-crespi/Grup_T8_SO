namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.Resolution_Box = new System.Windows.Forms.ComboBox();
            this.button_Dados = new System.Windows.Forms.Button();
            this.Resultado = new System.Windows.Forms.TextBox();
            this.Resultado2 = new System.Windows.Forms.TextBox();
            this.SumaResultado = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.Resolution_Lbl = new System.Windows.Forms.Label();
            this.Resultado_Lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Resolution_Box
            // 
            this.Resolution_Box.AccessibleName = "Resolution_Box";
            this.Resolution_Box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Resolution_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Resolution_Box.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resolution_Box.FormattingEnabled = true;
            this.Resolution_Box.Items.AddRange(new object[] {
            "1000x1000",
            "900x900",
            "800x800",
            "700x700",
            "600x600",
            "500x500",
            "400x400",
            "300x300"});
            this.Resolution_Box.Location = new System.Drawing.Point(65, 537);
            this.Resolution_Box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Resolution_Box.Name = "Resolution_Box";
            this.Resolution_Box.Size = new System.Drawing.Size(188, 31);
            this.Resolution_Box.TabIndex = 28;
            this.Resolution_Box.Tag = "";
            this.Resolution_Box.SelectedIndexChanged += new System.EventHandler(this.Resolution_Box_SelectedIndexChanged);
            // 
            // button_Dados
            // 
            this.button_Dados.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Dados.Location = new System.Drawing.Point(17, 74);
            this.button_Dados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Dados.Name = "button_Dados";
            this.button_Dados.Size = new System.Drawing.Size(261, 47);
            this.button_Dados.TabIndex = 18;
            this.button_Dados.Text = "Tirar los dados";
            this.button_Dados.UseVisualStyleBackColor = true;
            this.button_Dados.Click += new System.EventHandler(this.button_Dados_Click);
            // 
            // Resultado
            // 
            this.Resultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resultado.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultado.Location = new System.Drawing.Point(87, 143);
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            this.Resultado.Size = new System.Drawing.Size(38, 30);
            this.Resultado.TabIndex = 20;
            // 
            // Resultado2
            // 
            this.Resultado2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resultado2.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultado2.Location = new System.Drawing.Point(153, 143);
            this.Resultado2.Name = "Resultado2";
            this.Resultado2.ReadOnly = true;
            this.Resultado2.Size = new System.Drawing.Size(38, 30);
            this.Resultado2.TabIndex = 21;
            // 
            // SumaResultado
            // 
            this.SumaResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SumaResultado.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumaResultado.Location = new System.Drawing.Point(153, 198);
            this.SumaResultado.Name = "SumaResultado";
            this.SumaResultado.ReadOnly = true;
            this.SumaResultado.Size = new System.Drawing.Size(67, 23);
            this.SumaResultado.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(307, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1667, 1384);
            this.panel1.TabIndex = 23;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(77, 304);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 27);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Jugador 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(77, 335);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(143, 27);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.Text = "Jugador 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Enabled = false;
            this.radioButton3.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(77, 368);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(143, 27);
            this.radioButton3.TabIndex = 26;
            this.radioButton3.Text = "Jugador 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Enabled = false;
            this.radioButton4.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(77, 399);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(143, 27);
            this.radioButton4.TabIndex = 27;
            this.radioButton4.Text = "Jugador 4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // Resolution_Lbl
            // 
            this.Resolution_Lbl.AutoSize = true;
            this.Resolution_Lbl.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resolution_Lbl.Location = new System.Drawing.Point(27, 521);
            this.Resolution_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Resolution_Lbl.Name = "Resolution_Lbl";
            this.Resolution_Lbl.Size = new System.Drawing.Size(226, 23);
            this.Resolution_Lbl.TabIndex = 29;
            this.Resolution_Lbl.Text = "Resolución tablero";
            // 
            // Resultado_Lbl
            // 
            this.Resultado_Lbl.AutoSize = true;
            this.Resultado_Lbl.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultado_Lbl.Location = new System.Drawing.Point(27, 198);
            this.Resultado_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Resultado_Lbl.Name = "Resultado_Lbl";
            this.Resultado_Lbl.Size = new System.Drawing.Size(130, 23);
            this.Resultado_Lbl.TabIndex = 30;
            this.Resultado_Lbl.Text = "Resultado:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1924, 1053);
            this.Controls.Add(this.Resultado_Lbl);
            this.Controls.Add(this.Resolution_Lbl);
            this.Controls.Add(this.Resolution_Box);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.SumaResultado);
            this.Controls.Add(this.Resultado2);
            this.Controls.Add(this.Resultado);
            this.Controls.Add(this.button_Dados);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form2";
            this.Text = "Juego de la oca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Dados;
        private System.Windows.Forms.TextBox Resultado;
        private System.Windows.Forms.TextBox Resultado2;
        private System.Windows.Forms.TextBox SumaResultado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox Resolution_Box;
        private System.Windows.Forms.Label Resolution_Lbl;
        private System.Windows.Forms.Label Resultado_Lbl;
    }
}