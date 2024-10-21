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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("Conectados");
            ListaConectados.DataSource = dt;

        }

        private void button_Conectar_Click(object sender, EventArgs e) // BOTON CONECTAR
        {
            ////Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9010);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
        }

        private void button_Desconectar_Click(object sender, EventArgs e) // CONSULTA 0 : BOTON DESCONECTAR
        {
            //Mensaje de desconexion
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);



            // Nos desconectamos
            this.BackColor = Color.Gray;
            MessageBox.Show("Desconectado");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

      
        private void button_LogIn_Click(object sender, EventArgs e) // CONSULTA 1 : BOTON LOG IN
        {
            string mensaje = "1/" + nickname.Text + "/" + password.Text; // Guarda los datos en un string con el codigo
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor                    
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if (mensaje == "SI")
            {
                MessageBox.Show("Bienvenido/a " + nickname.Text + ". Has iniciado sesión correctamente.");
            }
            else if (mensaje == "NO_USER")
            {
                MessageBox.Show("No estás registrado. Para registrarte, rellena los campos y presiona 'Registrar'.");
            }
            else if (mensaje == "WRONG_PASSWORD")
            {
                MessageBox.Show("Contraseña incorrecta. Por favor, inténtalo de nuevo.");
            }
            else
            {
                MessageBox.Show("Error desconocido. Por favor, intenta de nuevo más tarde.");
            }

        }

        private void button_Registro_Click(object sender, EventArgs e) // CONSULTA 2 : BOTON REGISTRARSE
        {
            string mensaje;
            // Validamos que el nickname y la contraseña tengan más de 3 caracteres
            if ((password.Text.Length > 3) && (nickname.Text.Length > 3))
            {
                // Verificamos que la confirmación de la contraseña coincida con la contraseña 
                if (password.Text == password_conf.Text)
                {
                    // Guarda los datos en un string con el codigo para enviarlo al servidor
                    mensaje = "2/" + nickname.Text + "/" + password.Text;

                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor                    
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    if (mensaje == "0")
                    {
                        MessageBox.Show("Bienvenido/a " + nickname.Text + ". Te has registrado correctamente.");
                    }
                    else if (mensaje == "-1")
                    {
                        MessageBox.Show("Fallo al registrar, intentelo de nuevo.");
                    }
                    else
                    {
                        MessageBox.Show("Error desconocido. Por favor, inténtelo más tarde.");
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña de confirmación no coincide.");
                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario y la contraseña deben tener más de 3 caracteres.");
            }
        }

        private void ListaCon_Click(object sender, EventArgs e) // CONSULTA 3 : LISTA CONECTADOS
        {
            
            string mensaje = "3/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor                    
            byte[] msg2 = new byte[200];
            server.Receive(msg2);

            string mensaje2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] trozos = mensaje2.Split('/');

            int x = 1;
            Invoke(new Action(() =>
            {
                dt.Rows.Clear();
                int num = Convert.ToInt32(trozos[0]);
                for (int i = 0; i <= num; i++)
                {
                    dt.Rows.Add(trozos[x]);
                    x++;
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e) // BOTON ENVIAR CONSULTA
        {


            if (DimeJugadores.Checked) // CONSUTLA 5 : JUGADORES QUE JUGARON EL DIA INTRODUCIDO PORO TECLADO
            {
                string mensaje = "5/" + ConsultaFecha.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                MessageBox.Show(mensaje);
                
                //Recibimos la respuesta del servidor                    
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                if (mensaje == "ERROR_DB")
                    MessageBox.Show("No hay partidas en esa fecha");
                else
                    MessageBox.Show("Los jugadores que jugaron ese día son:" + mensaje);

            }
            if (DimeGanadores.Checked)  // CONSULTA 6 : JUGADORES QUE GANARON EL DIA INTRODUCIDO PORO TECLADO
            {

                string mensaje = "6/" + ConsultaFecha.Text;
                //Enviamos consulta al servidor 
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "ERROR_DB")
                    MessageBox.Show("No hay partidas en esa fecha");
                else
                    MessageBox.Show("Los jugadores que ganaron ese día son:" + mensaje);

            }
            if (SumaDuracion.Checked) // CONSULTA 7 : Duracion total partidas de un jugador , introduciendo su nombre por teclado
            {
               
                string mensaje = "7/" + ConsultaNombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor                    
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                if (mensaje == "ERROR_DB")
                    MessageBox.Show("No hay partidas de ese jugador");
                else
                    MessageBox.Show("La duración total de partidas ganadas es: " + mensaje);

            }

        }

        private void button_MatrizJuego_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
