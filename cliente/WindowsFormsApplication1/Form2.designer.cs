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
            this.matriz = new System.Windows.Forms.DataGridView();
            this.button_Dados = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Resultado = new System.Windows.Forms.TextBox();
            this.Resultado2 = new System.Windows.Forms.TextBox();
            this.SumaResultado = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.matriz)).BeginInit();
            this.SuspendLayout();
            // 
            // matriz
            // 
            this.matriz.AllowUserToAddRows = false;
            this.matriz.AllowUserToDeleteRows = false;
            this.matriz.AllowUserToResizeColumns = false;
            this.matriz.AllowUserToResizeRows = false;
            this.matriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matriz.ColumnHeadersVisible = false;
            this.matriz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.matriz.Location = new System.Drawing.Point(20, 200);
            this.matriz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.matriz.MultiSelect = false;
            this.matriz.Name = "matriz";
            this.matriz.ReadOnly = true;
            this.matriz.RowHeadersVisible = false;
            this.matriz.RowHeadersWidth = 62;
            this.matriz.RowTemplate.Height = 28;
            this.matriz.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.matriz.Size = new System.Drawing.Size(331, 164);
            this.matriz.TabIndex = 0;
            // 
            // button_Dados
            // 
            this.button_Dados.Location = new System.Drawing.Point(52, 99);
            this.button_Dados.Name = "button_Dados";
            this.button_Dados.Size = new System.Drawing.Size(115, 34);
            this.button_Dados.TabIndex = 18;
            this.button_Dados.Text = "Tirar los dados";
            this.button_Dados.UseVisualStyleBackColor = true;
            this.button_Dados.Click += new System.EventHandler(this.button_Dados_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 20);
            this.textBox1.TabIndex = 19;
            // 
            // Resultado
            // 
            this.Resultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resultado.Location = new System.Drawing.Point(69, 153);
            this.Resultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            this.Resultado.Size = new System.Drawing.Size(23, 20);
            this.Resultado.TabIndex = 20;
            // 
            // Resultado2
            // 
            this.Resultado2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resultado2.Location = new System.Drawing.Point(114, 153);
            this.Resultado2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Resultado2.Name = "Resultado2";
            this.Resultado2.ReadOnly = true;
            this.Resultado2.Size = new System.Drawing.Size(23, 20);
            this.Resultado2.TabIndex = 21;
            // 
            // SumaResultado
            // 
            this.SumaResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SumaResultado.Location = new System.Drawing.Point(83, 180);
            this.SumaResultado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SumaResultado.Name = "SumaResultado";
            this.SumaResultado.ReadOnly = true;
            this.SumaResultado.Size = new System.Drawing.Size(40, 13);
            this.SumaResultado.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(464, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 900);
            this.panel1.TabIndex = 23;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(52, 496);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Jugador 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(52, 519);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 17);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.Text = "Jugador 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(52, 542);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 17);
            this.radioButton3.TabIndex = 26;
            this.radioButton3.Text = "Jugador 3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(52, 565);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 17);
            this.radioButton4.TabIndex = 27;
            this.radioButton4.Text = "Jugador 4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1155, 765);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.matriz);
            this.Controls.Add(this.SumaResultado);
            this.Controls.Add(this.Resultado2);
            this.Controls.Add(this.Resultado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Dados);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.matriz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView matriz;
        private System.Windows.Forms.Button button_Dados;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Resultado;
        private System.Windows.Forms.TextBox Resultado2;
        private System.Windows.Forms.TextBox SumaResultado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
    }
}