﻿namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ConsultaFecha = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChatSendBtn = new System.Windows.Forms.Button();
            this.ChatTxtBox = new System.Windows.Forms.TextBox();
            this.Chat = new System.Windows.Forms.GroupBox();
            this.ChatTable = new System.Windows.Forms.DataGridView();
            this.Respuesta_Lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_MatrizJuego = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ConsultaNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DimeGanadores = new System.Windows.Forms.RadioButton();
            this.ListaConectados = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.SumaDuracion = new System.Windows.Forms.RadioButton();
            this.DimeJugadores = new System.Windows.Forms.RadioButton();
            this.button_Baja = new System.Windows.Forms.Button();
            this.button_Desconectar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsultaFecha
            // 
            this.ConsultaFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultaFecha.ForeColor = System.Drawing.Color.Black;
            this.ConsultaFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConsultaFecha.Location = new System.Drawing.Point(727, 346);
            this.ConsultaFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsultaFecha.Name = "ConsultaFecha";
            this.ConsultaFecha.Size = new System.Drawing.Size(219, 34);
            this.ConsultaFecha.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(763, 522);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 48);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.ChatSendBtn);
            this.groupBox1.Controls.Add(this.ChatTxtBox);
            this.groupBox1.Controls.Add(this.Chat);
            this.groupBox1.Controls.Add(this.Respuesta_Lbl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button_MatrizJuego);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ConsultaNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DimeGanadores);
            this.groupBox1.Controls.Add(this.ListaConectados);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.SumaDuracion);
            this.groupBox1.Controls.Add(this.DimeJugadores);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ConsultaFecha);
            this.groupBox1.Location = new System.Drawing.Point(16, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1676, 623);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // ChatSendBtn
            // 
            this.ChatSendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatSendBtn.Location = new System.Drawing.Point(1548, 534);
            this.ChatSendBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatSendBtn.Name = "ChatSendBtn";
            this.ChatSendBtn.Size = new System.Drawing.Size(91, 36);
            this.ChatSendBtn.TabIndex = 47;
            this.ChatSendBtn.Text = "Enviar";
            this.ChatSendBtn.UseVisualStyleBackColor = true;
            this.ChatSendBtn.Click += new System.EventHandler(this.ChatSendBtn_Click);
            // 
            // ChatTxtBox
            // 
            this.ChatTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatTxtBox.ForeColor = System.Drawing.Color.Black;
            this.ChatTxtBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChatTxtBox.Location = new System.Drawing.Point(1068, 534);
            this.ChatTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatTxtBox.Name = "ChatTxtBox";
            this.ChatTxtBox.Size = new System.Drawing.Size(471, 34);
            this.ChatTxtBox.TabIndex = 46;
            this.ChatTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatTxtBox_KeyPress);
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.White;
            this.Chat.Controls.Add(this.ChatTable);
            this.Chat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Chat.Location = new System.Drawing.Point(1068, 38);
            this.Chat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chat.Size = new System.Drawing.Size(571, 474);
            this.Chat.TabIndex = 45;
            this.Chat.TabStop = false;
            this.Chat.Text = "Chat";
            // 
            // ChatTable
            // 
            this.ChatTable.AllowUserToAddRows = false;
            this.ChatTable.AllowUserToDeleteRows = false;
            this.ChatTable.AllowUserToResizeColumns = false;
            this.ChatTable.AllowUserToResizeRows = false;
            this.ChatTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ChatTable.BackgroundColor = System.Drawing.Color.White;
            this.ChatTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ChatTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ChatTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.ChatTable.EnableHeadersVisualStyles = false;
            this.ChatTable.GridColor = System.Drawing.Color.White;
            this.ChatTable.Location = new System.Drawing.Point(8, 23);
            this.ChatTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatTable.MultiSelect = false;
            this.ChatTable.Name = "ChatTable";
            this.ChatTable.ReadOnly = true;
            this.ChatTable.RowHeadersVisible = false;
            this.ChatTable.RowHeadersWidth = 62;
            this.ChatTable.Size = new System.Drawing.Size(555, 443);
            this.ChatTable.TabIndex = 48;
            this.ChatTable.TabStop = false;
            // 
            // Respuesta_Lbl
            // 
            this.Respuesta_Lbl.AutoSize = true;
            this.Respuesta_Lbl.Location = new System.Drawing.Point(260, 540);
            this.Respuesta_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Respuesta_Lbl.Name = "Respuesta_Lbl";
            this.Respuesta_Lbl.Size = new System.Drawing.Size(0, 16);
            this.Respuesta_Lbl.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 470);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Respuesta:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 255);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 42);
            this.button1.TabIndex = 42;
            this.button1.Text = "Invitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_MatrizJuego
            // 
            this.button_MatrizJuego.BackColor = System.Drawing.Color.Lime;
            this.button_MatrizJuego.Location = new System.Drawing.Point(723, 107);
            this.button_MatrizJuego.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_MatrizJuego.Name = "button_MatrizJuego";
            this.button_MatrizJuego.Size = new System.Drawing.Size(243, 89);
            this.button_MatrizJuego.TabIndex = 39;
            this.button_MatrizJuego.Text = "Empezar a jugar";
            this.button_MatrizJuego.UseVisualStyleBackColor = false;
            this.button_MatrizJuego.Click += new System.EventHandler(this.button_MatrizJuego_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(761, 468);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 18);
            this.label6.TabIndex = 37;
            this.label6.Text = "Introduce un nombre";
            // 
            // ConsultaNombre
            // 
            this.ConsultaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultaNombre.ForeColor = System.Drawing.Color.Black;
            this.ConsultaNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConsultaNombre.Location = new System.Drawing.Point(727, 421);
            this.ConsultaNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsultaNombre.Name = "ConsultaNombre";
            this.ConsultaNombre.Size = new System.Drawing.Size(219, 34);
            this.ConsultaNombre.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(761, 383);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Introduce una fecha";
            // 
            // DimeGanadores
            // 
            this.DimeGanadores.AutoSize = true;
            this.DimeGanadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimeGanadores.Location = new System.Drawing.Point(75, 372);
            this.DimeGanadores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DimeGanadores.Name = "DimeGanadores";
            this.DimeGanadores.Size = new System.Drawing.Size(509, 29);
            this.DimeGanadores.TabIndex = 34;
            this.DimeGanadores.TabStop = true;
            this.DimeGanadores.Text = "Dime que ganadores jugaron este día (introduce fecha)";
            this.DimeGanadores.UseVisualStyleBackColor = true;
            // 
            // ListaConectados
            // 
            this.ListaConectados.AllowUserToAddRows = false;
            this.ListaConectados.AllowUserToDeleteRows = false;
            this.ListaConectados.AllowUserToResizeColumns = false;
            this.ListaConectados.AllowUserToResizeRows = false;
            this.ListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaConectados.DefaultCellStyle = dataGridViewCellStyle3;
            this.ListaConectados.EnableHeadersVisualStyles = false;
            this.ListaConectados.Location = new System.Drawing.Point(75, 38);
            this.ListaConectados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListaConectados.MultiSelect = false;
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.RowHeadersVisible = false;
            this.ListaConectados.RowHeadersWidth = 62;
            this.ListaConectados.Size = new System.Drawing.Size(453, 209);
            this.ListaConectados.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(745, 399);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Formato: (DD-MM-AAAA)";
            // 
            // SumaDuracion
            // 
            this.SumaDuracion.AutoSize = true;
            this.SumaDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumaDuracion.Location = new System.Drawing.Point(75, 395);
            this.SumaDuracion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SumaDuracion.Name = "SumaDuracion";
            this.SumaDuracion.Size = new System.Drawing.Size(477, 29);
            this.SumaDuracion.TabIndex = 18;
            this.SumaDuracion.TabStop = true;
            this.SumaDuracion.Text = "Duración total partidas ganadas (introduce nombre)";
            this.SumaDuracion.UseVisualStyleBackColor = true;
            // 
            // DimeJugadores
            // 
            this.DimeJugadores.AutoSize = true;
            this.DimeJugadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimeJugadores.Location = new System.Drawing.Point(75, 346);
            this.DimeJugadores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DimeJugadores.Name = "DimeJugadores";
            this.DimeJugadores.Size = new System.Drawing.Size(502, 29);
            this.DimeJugadores.TabIndex = 8;
            this.DimeJugadores.TabStop = true;
            this.DimeJugadores.Text = "Dime que jugadores jugaron este día (introduce fecha)";
            this.DimeJugadores.UseVisualStyleBackColor = true;
            // 
            // button_Baja
            // 
            this.button_Baja.Location = new System.Drawing.Point(16, 757);
            this.button_Baja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Baja.Name = "button_Baja";
            this.button_Baja.Size = new System.Drawing.Size(139, 46);
            this.button_Baja.TabIndex = 41;
            this.button_Baja.Text = "Darse de Baja";
            this.button_Baja.UseVisualStyleBackColor = true;
            this.button_Baja.Click += new System.EventHandler(this.button_Baja_Click);
            // 
            // button_Desconectar
            // 
            this.button_Desconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_Desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Desconectar.Location = new System.Drawing.Point(16, 15);
            this.button_Desconectar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.Size = new System.Drawing.Size(212, 47);
            this.button_Desconectar.TabIndex = 11;
            this.button_Desconectar.Text = "Desconectar";
            this.button_Desconectar.UseVisualStyleBackColor = false;
            this.button_Desconectar.Click += new System.EventHandler(this.button_Desconectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 847);
            this.Controls.Add(this.button_Desconectar);
            this.Controls.Add(this.button_Baja);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Chat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChatTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox ConsultaFecha;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DimeJugadores;
        private System.Windows.Forms.RadioButton SumaDuracion;
        private System.Windows.Forms.Button button_Desconectar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView ListaConectados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton DimeGanadores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ConsultaNombre;
        private System.Windows.Forms.Button button_MatrizJuego;
        private System.Windows.Forms.Button button_Baja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Respuesta_Lbl;
        private System.Windows.Forms.Button ChatSendBtn;
        private System.Windows.Forms.TextBox ChatTxtBox;
        private System.Windows.Forms.GroupBox Chat;
        private System.Windows.Forms.DataGridView ChatTable;
    }
}

