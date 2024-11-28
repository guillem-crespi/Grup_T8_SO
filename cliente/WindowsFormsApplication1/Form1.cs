using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        DataTable dt = new DataTable();
        Thread atender;
        string nickname;
        string password;

        delegate void DelegadoParaEscribir(string mensaje);

        public Form1(string nickname, string password, Socket server)
        {
            this.nickname = nickname;
            this.password = password;
            this.server = server;
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Conectados");
            ListaConectados.DataSource = dt;
            ListaConectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ListaConectados.ReadOnly = false;
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Seleccionar",
                HeaderText = "Invitar"
            };
            ListaConectados.Columns.Add(checkBoxColumn);
        }

        private void button_Desconectar_Click(object sender, EventArgs e) // CONSULTA 0 : BOTON DESCONECTAR
        {
            //Mensaje de desconexion
            string mensaje = "0/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            atender.Abort();


            // Nos desconectamos
            this.BackColor = Color.Gray;
            MessageBox.Show("Desconectado");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            Close();
        }

        private void ListaCon_Click(object sender, EventArgs e) // CONSULTA 3 : LISTA CONECTADOS
        {
            
            string mensaje = "3/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void button2_Click(object sender, EventArgs e) // BOTON ENVIAR CONSULTA
        {


            if (DimeJugadores.Checked) // CONSUTLA 10 : JUGADORES QUE JUGARON EL DIA INTRODUCIDO POR TECLADO
            {
                string mensaje = "10/" + ConsultaFecha.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            if (DimeGanadores.Checked)  // CONSULTA 11 : JUGADORES QUE GANARON EL DIA INTRODUCIDO PORO TECLADO
            {

                string mensaje = "11/" + ConsultaFecha.Text;
                //Enviamos consulta al servidor 
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (SumaDuracion.Checked) // CONSULTA 12 : Duracion total partidas de un jugador , introduciendo su nombre por teclado
            {
               
                string mensaje = "12/" + ConsultaNombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

        }

        private void button_MatrizJuego_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button_Baja_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + nickname + "/" + password; 
            //Enviamos consulta al servidor 
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void Update_Respuesta_Lbl(string respuesta)
        {
            Respuesta_Lbl.Text = respuesta;
        }

        private void AtenderServidor()
        {
            string mensaje;
            DelegadoParaEscribir delegado;

            while (true)
            {
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);

                switch (codigo)
                {
                    case 3:
                        Invoke(new Action(() =>
                        {
                            dt.Rows.Clear();
                            int num = Convert.ToInt32(trozos[1]);
                            for (int i = 2; i <= num + 2; i++)
                            {
                                dt.Rows.Add(trozos[i]);
                            }
                        }));

                        break;

                    case 5:
                        mensaje = trozos[1];

                        if (mensaje == "ERROR_DB")
                            MessageBox.Show("No se puede dar de baja");
                        else if (mensaje == "DELETED_SUCCESSFUL")
                        {
                            MessageBox.Show("Usuario dado de baja correctamente");

                            //Mensaje de desconexion
                            mensaje = "0/";
                            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                            atender.Abort();


                            // Nos desconectamos
                            this.BackColor = Color.Gray;
                            MessageBox.Show("Desconectado");
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                            Close();
                            Close();
                        }

                        break;

                    case 6:
                        mensaje = trozos[1];

                        MessageBox.Show(mensaje + " te ha invitado a jugar");

                        break;

                    case 10:
                        mensaje = trozos[1];
                        delegado = new DelegadoParaEscribir(Update_Respuesta_Lbl);

                        if (mensaje == "ERROR_DB")
                            Respuesta_Lbl.Invoke(delegado, new object[] { "No hay partidas de ese jugador" });
                        else
                            Respuesta_Lbl.Invoke(delegado, new object[] { "Los jugadores que jugaron ese día son: " + mensaje });

                        break;

                    case 11:
                        mensaje = trozos[1];
                        delegado = new DelegadoParaEscribir(Update_Respuesta_Lbl);

                        if (mensaje == "ERROR_DB")
                            Respuesta_Lbl.Invoke(delegado, new object[] { "No hay partidas de ese jugador" });
                        else
                            Respuesta_Lbl.Invoke(delegado, new object[] { "Los jugadores que ganaron ese día son: " + mensaje });

                        break;

                    case 12:
                        mensaje = trozos[1];
                        delegado = new DelegadoParaEscribir(Update_Respuesta_Lbl);

                        if (mensaje == "ERROR_DB")
                            Respuesta_Lbl.Invoke(delegado, new object[] { "No hay partidas de ese jugador" });
                        else
                            Respuesta_Lbl.Invoke(delegado, new object[] { "La duración total de partidas ganadas es: " + mensaje });

                        break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string mensaje = "0/";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                atender.Abort();
            }
            catch { }
        }
//Invitar
        private void button1_Click(object sender, EventArgs e)
        {
            int invitados = 0;
            string dest = "";
            string dest2 = "";
            string dest3 = "";
            string reg;

            foreach (DataGridViewRow row in ListaConectados.Rows)
            {
                if (row.Cells["Seleccionar"].Value != null && Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    invitados++;
                }
            }

            if (invitados > 3)
            {
                MessageBox.Show("Máximo 3 invitaciones");
                return;
            }

            foreach (DataGridViewRow row in ListaConectados.Rows)
            {
                if (row.Cells["Seleccionar"].Value != null && Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    string playerName = Convert.ToString(row.Cells["Conectados"].Value)?.Trim();
                    if (playerName == nickname)
                    {
                        MessageBox.Show("No te puedes invitar a ti mismo");
                        return;
                    }
                    else if (!string.IsNullOrEmpty(playerName))
                    {
                        if (string.IsNullOrEmpty(dest))
                        {
                            dest = playerName;
                        }
                        else if (string.IsNullOrEmpty(dest2))
                        {
                            dest2 = playerName;
                        }
                        else if (string.IsNullOrEmpty(dest3))
                        {
                            dest3 = playerName;
                        }
                        else
                        {
                            MessageBox.Show("Error en el proceso");
                            return;
                        }
                    }
                }
            }

            if (invitados == 1)
                reg = $"6/{invitados}/{dest}/{nickname}";
            else if (invitados == 2)
                reg = $"6/{invitados}/{dest}/{dest2}/{nickname}";
            else if (invitados == 3)
                reg = $"6/{invitados}/{dest}/{dest2}/{dest3}/{nickname}";
            else {
                reg = "Error en el proceso";
                return;
            }

            MessageBox.Show(reg);

            byte[] msg = Encoding.ASCII.GetBytes(reg);
            server.Send(msg);
        }
    }
}
    

