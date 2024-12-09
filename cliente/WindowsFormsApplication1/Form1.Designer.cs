namespace WindowsFormsApplication1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ConsultaFecha = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChatSendBtn = new System.Windows.Forms.Button();
            this.ChatTxtBox = new System.Windows.Forms.TextBox();
            this.Chat = new System.Windows.Forms.GroupBox();
            this.ChatTable = new System.Windows.Forms.DataGridView();
            this.Respuesta_Lbl = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Chat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaConectados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsultaFecha
            // 
            this.ConsultaFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultaFecha.ForeColor = System.Drawing.Color.Black;
            this.ConsultaFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.ConsultaFecha.Location = new System.Drawing.Point(864, 17);
            this.ConsultaFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsultaFecha.Name = "ConsultaFecha";
            this.ConsultaFecha.Size = new System.Drawing.Size(246, 40);
=======
            this.ConsultaFecha.Location = new System.Drawing.Point(727, 346);
            this.ConsultaFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsultaFecha.Name = "ConsultaFecha";
            this.ConsultaFecha.Size = new System.Drawing.Size(219, 34);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ConsultaFecha.TabIndex = 3;
            // 
            // button2
            // 
<<<<<<< HEAD
            this.button2.BackColor = System.Drawing.Color.Thistle;
            this.button2.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(23, 125);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 58);
=======
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(763, 522);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 48);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button_MatrizJuego);
            this.groupBox1.Controls.Add(this.Respuesta_Lbl);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ListaConectados);
<<<<<<< HEAD
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(407, 112);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1202, 660);
=======
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
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // ChatSendBtn
            // 
<<<<<<< HEAD
            this.ChatSendBtn.BackColor = System.Drawing.Color.Thistle;
            this.ChatSendBtn.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatSendBtn.Location = new System.Drawing.Point(279, 732);
            this.ChatSendBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChatSendBtn.Name = "ChatSendBtn";
            this.ChatSendBtn.Size = new System.Drawing.Size(105, 40);
=======
            this.ChatSendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatSendBtn.Location = new System.Drawing.Point(1548, 534);
            this.ChatSendBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatSendBtn.Name = "ChatSendBtn";
            this.ChatSendBtn.Size = new System.Drawing.Size(91, 36);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ChatSendBtn.TabIndex = 47;
            this.ChatSendBtn.Text = "Enviar";
            this.ChatSendBtn.UseVisualStyleBackColor = false;
            this.ChatSendBtn.Click += new System.EventHandler(this.ChatSendBtn_Click);
            // 
            // ChatTxtBox
            // 
            this.ChatTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatTxtBox.ForeColor = System.Drawing.Color.Black;
            this.ChatTxtBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.ChatTxtBox.Location = new System.Drawing.Point(13, 732);
            this.ChatTxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ChatTxtBox.Name = "ChatTxtBox";
            this.ChatTxtBox.Size = new System.Drawing.Size(258, 40);
=======
            this.ChatTxtBox.Location = new System.Drawing.Point(1068, 534);
            this.ChatTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChatTxtBox.Name = "ChatTxtBox";
            this.ChatTxtBox.Size = new System.Drawing.Size(471, 34);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ChatTxtBox.TabIndex = 46;
            this.ChatTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatTxtBox_KeyPress);
            // 
            // Chat
            // 
            this.Chat.BackColor = System.Drawing.Color.White;
            this.Chat.Controls.Add(this.ChatTable);
            this.Chat.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chat.ForeColor = System.Drawing.SystemColors.ControlText;
<<<<<<< HEAD
            this.Chat.Location = new System.Drawing.Point(13, 112);
            this.Chat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chat.Size = new System.Drawing.Size(371, 592);
=======
            this.Chat.Location = new System.Drawing.Point(1068, 38);
            this.Chat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chat.Name = "Chat";
            this.Chat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chat.Size = new System.Drawing.Size(571, 474);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ChatTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.ChatTable.EnableHeadersVisualStyles = false;
            this.ChatTable.GridColor = System.Drawing.Color.White;
<<<<<<< HEAD
            this.ChatTable.Location = new System.Drawing.Point(9, 29);
            this.ChatTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
=======
            this.ChatTable.Location = new System.Drawing.Point(8, 23);
            this.ChatTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ChatTable.MultiSelect = false;
            this.ChatTable.Name = "ChatTable";
            this.ChatTable.ReadOnly = true;
            this.ChatTable.RowHeadersVisible = false;
            this.ChatTable.RowHeadersWidth = 62;
<<<<<<< HEAD
            this.ChatTable.Size = new System.Drawing.Size(354, 554);
=======
            this.ChatTable.Size = new System.Drawing.Size(555, 443);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ChatTable.TabIndex = 48;
            this.ChatTable.TabStop = false;
            // 
            // Respuesta_Lbl
            // 
            this.Respuesta_Lbl.AutoSize = true;
<<<<<<< HEAD
            this.Respuesta_Lbl.Location = new System.Drawing.Point(292, 675);
            this.Respuesta_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Respuesta_Lbl.Name = "Respuesta_Lbl";
            this.Respuesta_Lbl.Size = new System.Drawing.Size(0, 18);
            this.Respuesta_Lbl.TabIndex = 44;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(696, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 52);
=======
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
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.button1.TabIndex = 42;
            this.button1.Text = "Invitar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_MatrizJuego
            // 
<<<<<<< HEAD
            this.button_MatrizJuego.BackColor = System.Drawing.Color.PaleGreen;
            this.button_MatrizJuego.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_MatrizJuego.Location = new System.Drawing.Point(696, 110);
            this.button_MatrizJuego.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_MatrizJuego.Name = "button_MatrizJuego";
            this.button_MatrizJuego.Size = new System.Drawing.Size(238, 58);
=======
            this.button_MatrizJuego.BackColor = System.Drawing.Color.Lime;
            this.button_MatrizJuego.Location = new System.Drawing.Point(723, 107);
            this.button_MatrizJuego.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_MatrizJuego.Name = "button_MatrizJuego";
            this.button_MatrizJuego.Size = new System.Drawing.Size(243, 89);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.button_MatrizJuego.TabIndex = 39;
            this.button_MatrizJuego.Text = "Empezar a jugar";
            this.button_MatrizJuego.UseVisualStyleBackColor = false;
            this.button_MatrizJuego.Click += new System.EventHandler(this.button_MatrizJuego_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
<<<<<<< HEAD
            this.label6.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(869, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 21);
=======
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(761, 468);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 18);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.label6.TabIndex = 37;
            this.label6.Text = "Introduce un nombre";
            // 
            // ConsultaNombre
            // 
            this.ConsultaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultaNombre.ForeColor = System.Drawing.Color.Black;
            this.ConsultaNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
<<<<<<< HEAD
            this.ConsultaNombre.Location = new System.Drawing.Point(864, 113);
            this.ConsultaNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConsultaNombre.Name = "ConsultaNombre";
            this.ConsultaNombre.Size = new System.Drawing.Size(246, 40);
=======
            this.ConsultaNombre.Location = new System.Drawing.Point(727, 421);
            this.ConsultaNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConsultaNombre.Name = "ConsultaNombre";
            this.ConsultaNombre.Size = new System.Drawing.Size(219, 34);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ConsultaNombre.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
<<<<<<< HEAD
            this.label2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(869, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 21);
=======
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(761, 383);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.label2.TabIndex = 35;
            this.label2.Text = "Introduce una fecha";
            // 
            // DimeGanadores
            // 
            this.DimeGanadores.AutoSize = true;
<<<<<<< HEAD
            this.DimeGanadores.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimeGanadores.Location = new System.Drawing.Point(23, 55);
            this.DimeGanadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DimeGanadores.Name = "DimeGanadores";
            this.DimeGanadores.Size = new System.Drawing.Size(779, 31);
=======
            this.DimeGanadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimeGanadores.Location = new System.Drawing.Point(75, 372);
            this.DimeGanadores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DimeGanadores.Name = "DimeGanadores";
            this.DimeGanadores.Size = new System.Drawing.Size(509, 29);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListaConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListaConectados.DefaultCellStyle = dataGridViewCellStyle5;
            this.ListaConectados.EnableHeadersVisualStyles = false;
<<<<<<< HEAD
            this.ListaConectados.Location = new System.Drawing.Point(84, 48);
            this.ListaConectados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
=======
            this.ListaConectados.Location = new System.Drawing.Point(75, 38);
            this.ListaConectados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ListaConectados.MultiSelect = false;
            this.ListaConectados.Name = "ListaConectados";
            this.ListaConectados.RowHeadersVisible = false;
            this.ListaConectados.RowHeadersWidth = 62;
<<<<<<< HEAD
            this.ListaConectados.Size = new System.Drawing.Size(545, 262);
=======
            this.ListaConectados.Size = new System.Drawing.Size(453, 209);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.ListaConectados.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
<<<<<<< HEAD
            this.label5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(869, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 21);
=======
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(745, 399);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 18);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.label5.TabIndex = 31;
            this.label5.Text = "Formato: (DD-MM-AAAA)";
            // 
            // SumaDuracion
            // 
            this.SumaDuracion.AutoSize = true;
<<<<<<< HEAD
            this.SumaDuracion.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumaDuracion.Location = new System.Drawing.Point(23, 83);
            this.SumaDuracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SumaDuracion.Name = "SumaDuracion";
            this.SumaDuracion.Size = new System.Drawing.Size(737, 31);
=======
            this.SumaDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SumaDuracion.Location = new System.Drawing.Point(75, 395);
            this.SumaDuracion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SumaDuracion.Name = "SumaDuracion";
            this.SumaDuracion.Size = new System.Drawing.Size(477, 29);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.SumaDuracion.TabIndex = 18;
            this.SumaDuracion.TabStop = true;
            this.SumaDuracion.Text = "Duración total partidas ganadas (introduce nombre)";
            this.SumaDuracion.UseVisualStyleBackColor = true;
            // 
            // DimeJugadores
            // 
            this.DimeJugadores.AutoSize = true;
<<<<<<< HEAD
            this.DimeJugadores.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimeJugadores.Location = new System.Drawing.Point(23, 29);
            this.DimeJugadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DimeJugadores.Name = "DimeJugadores";
            this.DimeJugadores.Size = new System.Drawing.Size(779, 31);
=======
            this.DimeJugadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimeJugadores.Location = new System.Drawing.Point(75, 346);
            this.DimeJugadores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DimeJugadores.Name = "DimeJugadores";
            this.DimeJugadores.Size = new System.Drawing.Size(502, 29);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.DimeJugadores.TabIndex = 8;
            this.DimeJugadores.TabStop = true;
            this.DimeJugadores.Text = "Dime que jugadores jugaron este día (introduce fecha)";
            this.DimeJugadores.UseVisualStyleBackColor = true;
            // 
            // button_Baja
            // 
<<<<<<< HEAD
            this.button_Baja.BackColor = System.Drawing.Color.IndianRed;
            this.button_Baja.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Baja.Location = new System.Drawing.Point(1103, 14);
            this.button_Baja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Baja.Name = "button_Baja";
            this.button_Baja.Size = new System.Drawing.Size(238, 58);
=======
            this.button_Baja.Location = new System.Drawing.Point(16, 757);
            this.button_Baja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Baja.Name = "button_Baja";
            this.button_Baja.Size = new System.Drawing.Size(139, 46);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.button_Baja.TabIndex = 41;
            this.button_Baja.Text = "Darse de Baja";
            this.button_Baja.UseVisualStyleBackColor = false;
            this.button_Baja.Click += new System.EventHandler(this.button_Baja_Click);
            // 
            // button_Desconectar
            // 
<<<<<<< HEAD
            this.button_Desconectar.BackColor = System.Drawing.Color.IndianRed;
            this.button_Desconectar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Desconectar.Location = new System.Drawing.Point(1371, 14);
            this.button_Desconectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.Size = new System.Drawing.Size(238, 58);
=======
            this.button_Desconectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_Desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Desconectar.Location = new System.Drawing.Point(16, 15);
            this.button_Desconectar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.Size = new System.Drawing.Size(212, 47);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.button_Desconectar.TabIndex = 11;
            this.button_Desconectar.Text = "Desconectar";
            this.button_Desconectar.UseVisualStyleBackColor = false;
            this.button_Desconectar.Click += new System.EventHandler(this.button_Desconectar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ConsultaFecha);
            this.groupBox2.Controls.Add(this.DimeJugadores);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ConsultaNombre);
            this.groupBox2.Controls.Add(this.DimeGanadores);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.SumaDuracion);
            this.groupBox2.Location = new System.Drawing.Point(35, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1117, 220);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consultas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Respuesta:";
            // 
            // Form1
            // 
<<<<<<< HEAD
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(1647, 813);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1711, 847);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
            this.Controls.Add(this.button_Desconectar);
            this.Controls.Add(this.ChatSendBtn);
            this.Controls.Add(this.button_Baja);
            this.Controls.Add(this.ChatTxtBox);
            this.Controls.Add(this.groupBox1);
<<<<<<< HEAD
            this.Controls.Add(this.Chat);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
=======
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
>>>>>>> b06640767190d45b5f33aadbc6274bb04ae28d24
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label Respuesta_Lbl;
        private System.Windows.Forms.Button ChatSendBtn;
        private System.Windows.Forms.TextBox ChatTxtBox;
        private System.Windows.Forms.GroupBox Chat;
        private System.Windows.Forms.DataGridView ChatTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}

