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
    public partial class Form3 : Form
    {
        Socket server;
        string mensaje;

        public Form3()
        {
            InitializeComponent();
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            ////Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50086);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                BackColor = Color.Green;
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            mensaje = "1/" + nickname.Text + "/" + password.Text; // Guarda los datos en un string con el codigo
            // Enviamos al servidor el nombre tecleado
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor                    
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if (mensaje == "LOGIN_SUCCESSFUL")
            {
                MessageBox.Show("Bienvenido/a " + nickname.Text + ". Has iniciado sesión correctamente.");
                Form f = new Form1(nickname.Text, password.Text, server);
                Hide();
                f.ShowDialog();
                BackColor = Color.Gray;
                Show();
            }
            else
            {
                if (mensaje == "NO_USER")
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

                //Mensaje de desconexion
                mensaje = "0/";
                msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
        }

        private void button_Registro_Click(object sender, EventArgs e)
        {
            byte[] msg;
            ////Creamos un IPEndPoint con el ip del servidor y puerto del servidor al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50086);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                BackColor = Color.Green;
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            if ((password.Text.Length > 3) && (nickname.Text.Length > 3))
            {
                // Verificamos que la confirmación de la contraseña coincida con la contraseña 
                if (password.Text == password_conf.Text)
                {
                    // Guarda los datos en un string con el codigo para enviarlo al servidor
                    mensaje = "2/" + nickname.Text + "/" + password.Text;

                    // Enviamos al servidor el nombre tecleado
                    msg = Encoding.ASCII.GetBytes(mensaje);
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

            //Mensaje de desconexion
            mensaje = "0/";
            msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
