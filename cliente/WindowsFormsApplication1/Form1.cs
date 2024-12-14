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
        Thread atender;
        private string nickname;
        private string password;

        private List<string> invitados = new List<string>(4);
        private int nJugador = 0;

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
            ListaConectados.ColumnCount = 1;
            ListaConectados.Columns[0].Name = "Conectados";

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Seleccionar",
                HeaderText = "Invitar",
            };

            ListaConectados.Columns.Add(checkBoxColumn);
            ListaConectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ListaConectados.AllowUserToAddRows = false;
            ListaConectados.Columns[0].ReadOnly = true;     //Conectados no editables
            ListaConectados.Columns[1].ReadOnly = false;
            ListaConectados.Columns[1].Width = 50;

            ChatTable.ColumnCount = 2;
            ChatTable.Columns[0].Name = "Nombre";
            ChatTable.Columns[1].Name = "Mensaje";
            ChatTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ChatTable.AllowUserToAddRows = false;
            ChatTable.Columns[0].Width = 100;
            ChatTable.ClearSelection();

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        private void button_Desconectar_Click(object sender, EventArgs e) // CONSULTA 0 : BOTON DESCONECTAR
        {
            //Mensaje de desconexion
            string mensaje = "0/";
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            atender.Abort();


            // Nos desconectamos
            this.BackColor = Color.IndianRed;
            MessageBox.Show("Desconectado");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            Close();
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
            Form2 f2 = new Form2(nJugador);
            f2.ShowDialog();
        }

        private void button_Baja_Click(object sender, EventArgs e)
        {
            string mensaje = "5/" + nickname + "/" + password; 
            //Enviamos consulta al servidor 
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            button_Desconectar_Click(sender, e);
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
                            ListaConectados.Rows.Clear();
                            int num = Convert.ToInt32(trozos[1]);

                            for (int i = 2; i < num + 2; i++)
                            {
                                ListaConectados.Rows.Add(trozos[i], false);
                            }

                            ListaConectados.ClearSelection();
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
                        DialogResult result = MessageBox.Show(
                            trozos[1] + " te ha invitado a jugar. Eres el jugador " + trozos[2],
                            "OK",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            nJugador = Convert.ToInt32(trozos[2]);

                            mensaje = $"8/OK/{trozos[1]}/{nickname}";
                            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            mensaje = $"8/NO/{trozos[1]}/{nickname}";
                            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                            server.Send(msg);
                        }

                        break;

                    case 7:
                        Invoke(new Action(() =>
                        {
                            ChatTable.Rows.Add(trozos[1], trozos[2]);
                            ChatTable.ClearSelection();
                        }));

                        break;

                    case 8:
                        int nInvitados = Convert.ToInt32(invitados[4]);
                        string players = "";
                        if (trozos[1] == "OK")
                        {
                            if ((nInvitados + 1) == 4)
                            {
                                MessageBox.Show("Todos los invitados han decidido");

                                invitados[4] = "4";
                                mensaje = "9/";
                                int nJugadores = 0;

                                for (int i = 0; i <= 3; i++)
                                {
                                    if (invitados[i] != "NO")
                                    {
                                        players += "/" + invitados[i];
                                        nJugadores++;
                                    }
                                }

                                mensaje += Convert.ToString(nJugadores) + players;
                                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                                server.Send(msg);
                            }
                            else
                            {
                                invitados[4] = Convert.ToString(nInvitados + 1);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (trozos[2] == invitados[i])
                                {
                                    invitados[i] = "NO";
                                }
                            }

                            if ((nInvitados + 1) == 4)
                            {
                                MessageBox.Show("Todos los invitados han decidido");

                                invitados[4] = "4";
                                mensaje = "9/";
                                int nJugadores = 0;

                                for (int i = 0; i <= 3; i++)
                                {
                                    if (invitados[i] != "NO")
                                    {
                                        mensaje += invitados[i] + "/";
                                        nJugadores++;
                                    }
                                }

                                if (nJugadores > 1)
                                {
                                    mensaje += Convert.ToString(nJugadores);
                                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                                    server.Send(msg);
                                }

                                else
                                    MessageBox.Show("Todos han rechazado tu invitacion :(\n No puedes jugar solo :(((");
                            }
                            else
                            {
                                invitados[4] = Convert.ToString(nInvitados + 1);
                            }
                        }

                        break;

                    case 9:
                        Form2 f = new Form2(nJugador);
                        f.ShowDialog();

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
            invitados = new List<string> { "", "", "", "", "" };

            int nInvitados = 0;
            string dest = "";
            string dest2 = "";
            string dest3 = "";
            string reg;
            int res1 = 0;
            int res2 = 0;
            int res3 = 0;
            int res4 = 0;

            foreach (DataGridViewRow row in ListaConectados.Rows)
            {
                if (row.Cells["Seleccionar"].Value != null && Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    nInvitados++;
                }
            }

            if (nInvitados > 3)
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

            Random random = new Random();

            if (nInvitados == 1)
            {
                res1 = random.Next(1, 3);
                res2 = random.Next(1, 3);

                while (res2 == res1)    //Comprovació que els jugadors tinguin el mateix número
                    res2 = random.Next(1, 3);

                reg = $"6/{nInvitados}/{dest}/{nickname}/{res2}";

                invitados[res1 - 1] = nickname;
                invitados[res2 - 1] = dest;

                for (int i = 1; i <= 4; i++)
                {
                    if (i != res1 && i != res2)
                    {
                        res3 = i;
                        invitados[i - 1] = "NO";
                    }
                }
                for (int i = 1; i <= 4; i++)
                {
                    if (i != res1 && i != res2 && i != res3)
                    {
                        res4 = i;
                        invitados[i - 1] = "NO";
                    }
                }

                invitados[4] = "3"; //Amb aquest número sabem quanta gent falta per acceptar la invitació (3 de 4 jugadors perquè falta 1 (el dest) per acceptar)
            }
            else if (nInvitados == 2)
            {
                res1 = random.Next(1, 4);
                res2 = random.Next(1, 4);
                res3 = random.Next(1, 4);

                while (res2 == res1)
                    res2 = random.Next(1, 4);

                while (res3 == res1 || res3 == res2)
                    res3 = random.Next(1, 4);

                reg = $"6/{nInvitados}/{dest}/{dest2}/{nickname}/{res2}/{res3}";

                invitados[res1 - 1] = nickname;
                invitados[res2 - 1] = dest;
                invitados[res3 - 1] = dest2;

                for (int i = 1; i <= 4; i++)
                {
                    if (i != res1 && i != res2 && i != res3)
                    {
                        res4 = i;
                        invitados[i - 1] = "NO";
                    }
                }

                invitados[4] = "2";
            }
            else if (nInvitados == 3)
            {
                res1 = random.Next(1, 5);
                res2 = random.Next(1, 5);
                res3 = random.Next(1, 5);
                res4 = random.Next(1, 5);

                while (res2 == res1)
                    res2 = random.Next(1, 5);

                while (res3 == res1 || res3 == res2)
                    res3 = random.Next(1, 5);

                while (res4 == res1 || res4 == res2 || res4 == res3)
                    res4 = random.Next(1, 5);

                reg = $"6/{nInvitados}/{dest}/{dest2}/{dest3}/{nickname}/{res2}/{res3}/{res4}";

                invitados[res1 - 1] = nickname;
                invitados[res2 - 1] = dest;
                invitados[res3 - 1] = dest2;
                invitados[res4 - 1] = dest3;

                invitados[4] = "1";
            }
            else
            {
                reg = "Error en el proceso";
                return;
            }

            byte[] msg = Encoding.ASCII.GetBytes(reg);
            server.Send(msg);
        }

        private void ChatSendBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ChatTxtBox.Text) && ChatTxtBox.Text.Length < 50)  //Si el missatge és molt llarg, no s'envia bé
            {
                bool found = false;
                string message = ChatTxtBox.Text;
                for (int i = 0; i < ChatTxtBox.Text.Length & !found; i++)
                {
                    if (message[i] == '/')  //No volem que s'envii una barra perquè trencarem el codi
                    {
                        found = true;
                        MessageBox.Show("No se puede usar el caracter '/'");
                    }
                }

                if (!found)
                {
                    string mensaje = "7/" + nickname + "/" + ChatTxtBox.Text;
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    ChatTxtBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Texto vacio o demasiado largo");
            }
        }

        private void ChatTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (!string.IsNullOrEmpty(ChatTxtBox.Text) && ChatTxtBox.Text.Length < 50)  //Si el missatge és molt llarg, no s'envia bé
                {
                    bool found = false;
                    string message = ChatTxtBox.Text;
                    for (int i = 0; i < ChatTxtBox.Text.Length & !found; i++)
                    {
                        if (message[i] == '/')  //No volem que s'envii una barra perquè trencarem el codi
                        {
                            found = true;
                            MessageBox.Show("No se puede usar el caracter '/'");
                        }
                    }

                    if (!found)
                    {
                        string mensaje = "7/" + nickname + "/" + ChatTxtBox.Text;
                        byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        ChatTxtBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Texto vacio o demasiado largo");
                }
            }
        }
    }
}
    

