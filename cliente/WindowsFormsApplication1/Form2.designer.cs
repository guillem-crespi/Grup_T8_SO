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
            ((System.ComponentModel.ISupportInitialize)(this.matriz)).BeginInit();
            this.SuspendLayout();
            // 
            // matriz
            // 
            this.matriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matriz.Location = new System.Drawing.Point(404, 169);
            this.matriz.Name = "matriz";
            this.matriz.RowHeadersWidth = 62;
            this.matriz.RowTemplate.Height = 28;
            this.matriz.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.matriz.Size = new System.Drawing.Size(496, 253);
            this.matriz.TabIndex = 0;
            // 
            // button_Dados
            // 
            this.button_Dados.Location = new System.Drawing.Point(78, 152);
            this.button_Dados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Dados.Name = "button_Dados";
            this.button_Dados.Size = new System.Drawing.Size(172, 52);
            this.button_Dados.TabIndex = 18;
            this.button_Dados.Text = "Tirar los dados";
            this.button_Dados.UseVisualStyleBackColor = true;
            this.button_Dados.Click += new System.EventHandler(this.button_Dados_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 19;
            // 
            // Resultado
            // 
            this.Resultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resultado.Location = new System.Drawing.Point(104, 235);
            this.Resultado.Name = "Resultado";
            this.Resultado.Size = new System.Drawing.Size(33, 26);
            this.Resultado.TabIndex = 20;
            // 
            // Resultado2
            // 
            this.Resultado2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Resultado2.Location = new System.Drawing.Point(171, 235);
            this.Resultado2.Name = "Resultado2";
            this.Resultado2.Size = new System.Drawing.Size(33, 26);
            this.Resultado2.TabIndex = 21;
            // 
            // SumaResultado
            // 
            this.SumaResultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SumaResultado.Location = new System.Drawing.Point(125, 277);
            this.SumaResultado.Name = "SumaResultado";
            this.SumaResultado.Size = new System.Drawing.Size(60, 19);
            this.SumaResultado.TabIndex = 22;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 693);
            this.Controls.Add(this.SumaResultado);
            this.Controls.Add(this.Resultado2);
            this.Controls.Add(this.Resultado);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Dados);
            this.Controls.Add(this.matriz);
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
    }
}