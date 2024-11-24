using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private int sumaTotal = 0;  // Variable para almacenar la suma total de los dados
        PictureBox tablero = new PictureBox();  //Imatge del tauler
        private List<int> casillas = new List<int>();
        private List<int> casillasJugador = new List<int>();
        private List<int> posiciones = new List<int>(new int[] { 0, 0, 0, 0 });
        private int nJugador;    //Numero de jugador (1, 2, 3 o 4)
        private float resolution = 1.0f;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Creació del tauler
            tablero.ClientSize = new Size((int)(resolution*1000), (int)(resolution*1000));
            tablero.Location = new Point(0, 0);
            tablero.SizeMode = PictureBoxSizeMode.StretchImage;
            tablero.Image = Image.FromFile("Oca.jpg");
            panel1.Controls.Add(tablero);

            //Definicio dels punts en els que es pintaran les peces
            casillas = new List<int>(new int[] {   50, 50, 355, 438, 525, 606, 695, 777, 858,
                                            855, 775, 697, 615, 530, 443, 357, 275, 198, 110,
                                            850, 775, 698, 615, 530, 443, 356, 270, 190, 111,
                                            114, 195, 275, 357, 444, 530, 612, 688,
                                            110, 195, 270, 355, 438, 525, 606, 687,
                                            687, 615, 531, 444, 369, 279,
                                            685, 615, 530, 444, 365, 278,
                                            276, 355, 444, 524,
                                            275, 350, 500 });   //Pixels en un tauler de 1000x1000

            for (int i = 0; i < casillas.Count; i++)
            {
                casillas[i] = (int)(casillas[i] * resolution);
            }

            casillasJugador = new List<int>(new int[] { 920, 963, 960, 10, 2, 795, 792, 173, 170, 627 });

            for (int i = 0;i < casillasJugador.Count; i++)
            {
                casillasJugador[i] = (int)(casillasJugador[i] * resolution);
            }

            tablero.Paint += new PaintEventHandler(tablero_Paint);  //Funció per pintar la imatge
        }

        private void button_Dados_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Genera dos número aleatorio entre 1 y 6
            int resultado = random.Next(1, 7); 
            int resultado2 = random.Next(1, 7);
            Resultado.Text = resultado.ToString(); 
            Resultado2.Text = resultado2.ToString();

            // Suma de los dos resultados
            int suma = resultado + resultado2;
            sumaTotal += suma;
            SumaResultado.Text = suma.ToString();

            if (radioButton1.Checked)
                nJugador = 1;

            else if (radioButton2.Checked)
                nJugador = 2;
            
            else if (radioButton3.Checked)
                nJugador = 3;
            
            else
                nJugador = 4;

            switch (nJugador)
            {
                case 1:
                    if (posiciones[0] == 0)
                    {
                        posiciones[0] += 1;
                    }

                    posiciones[0] += suma;

                    if (posiciones[0] > 63)
                    {
                        posiciones[0] = 2 * 63 - posiciones[0];
                    }

                    break;

                case 2:
                    if (posiciones[1] == 0)
                    {
                        posiciones[1] += 1;
                    }

                    posiciones[1] += suma;

                    if (posiciones[1] > 63)
                    {
                        posiciones[1] = 2 * 63 - posiciones[1];
                    }

                    break;

                case 3:
                    if (posiciones[2] == 0)
                    {
                        posiciones[2] += 1;
                    }

                    posiciones[2] += suma;

                    if (posiciones[2] > 63)
                    {
                        posiciones[2] = 2 * 63 - posiciones[2];
                    }

                    break;

                case 4:
                    if (posiciones[3] == 0)
                    {
                        posiciones[3] += 1;
                    }

                    posiciones[3] += suma;

                    if (posiciones[3] > 63)
                    {
                        posiciones[3] = 2 * 63 - posiciones[3];
                    }

                    break;
            }

            tablero.Invalidate();
        }

        private void tablero_Paint(object sender, PaintEventArgs e)
        {
            float res = resolution;
            int[] coord1 = new int[2];
            int[] coord2 = new int[2];
            int[] coord3 = new int[2];
            int[] coord4 = new int[2];

            coord1 = GetCoordinates(posiciones[0], casillas, casillasJugador, 1);
            coord2 = GetCoordinates(posiciones[1], casillas, casillasJugador, 2);
            coord3 = GetCoordinates(posiciones[2], casillas, casillasJugador, 3);
            coord4 = GetCoordinates(posiciones[3], casillas, casillasJugador, 4);

            Graphics g = e.Graphics;

            RectangleF pieza1 = new RectangleF(coord1[0], coord1[1], (int)(35 * res), (int)(35 * res));
            RectangleF pieza2 = new RectangleF(coord2[0], coord2[1], (int)(35 * res), (int)(35 * res));
            RectangleF pieza3 = new RectangleF(coord3[0], coord3[1], (int)(35 * res), (int)(35 * res));
            RectangleF pieza4 = new RectangleF(coord4[0], coord4[1], (int)(35 * res), (int)(35 * res));

            SolidBrush myBrush1 = new SolidBrush(Color.Red); //Interior de color
            SolidBrush myBrush2 = new SolidBrush(Color.Blue);
            SolidBrush myBrush3 = new SolidBrush(Color.Green);
            SolidBrush myBrush4 = new SolidBrush(Color.Yellow);

            g.FillEllipse(myBrush1, pieza1);
            g.FillEllipse(myBrush2, pieza2);
            g.FillEllipse(myBrush3, pieza3);
            g.FillEllipse(myBrush4, pieza4);

            Pen myPen = new Pen(Color.Black);   //Contorn negre
            g.DrawEllipse(myPen, pieza1);
            g.DrawEllipse(myPen, pieza2);
            g.DrawEllipse(myPen, pieza3);
            g.DrawEllipse(myPen, pieza4);

            myBrush1.Dispose();
            myBrush2.Dispose();
            myBrush3.Dispose();
            myBrush4.Dispose();
            myPen.Dispose();
        }

        private int[] GetCoordinates(int pos, List<int> cas, List<int> casJugador, int nJugador)    //Retorna les coordenades dels pixels del tauler
        {
            float res = resolution;
            int[] coords = new int[2];  //x i y de les fitxes
            int separacion = (int)(35 * res * (nJugador - 1)); 

            if (pos == 0)
            {
                coords[0] = cas[pos] * nJugador;
                coords[1] = casJugador[0];
            }
            else if (pos >= 1 && pos <= 7)
            {
                coords[0] = cas[pos];
                coords[1] = casJugador[1] - separacion;
            }
            else if (pos == 8)
            {
                coords[0] = (int)(cas[pos] - 10 * res * (nJugador - 1));
                coords[1] = casJugador[1] - separacion;
            }
            else if (pos == 9)
            {
                coords[0] = casJugador[2] - separacion;
                coords[1] = (int)(cas[pos] - 10 * res * (nJugador - 1));
            }
            else if (pos >= 10 && pos <= 17)
            {
                coords[0] = casJugador[2] - separacion;
                coords[1] = cas[pos];
            }
            else if (pos == 18)
            {
                coords[0] = casJugador[2] - separacion;
                coords[1] = (int)(cas[pos] + 10 * res * (nJugador - 1));
            }
            else if (pos == 19)
            {
                coords[0] = (int)(cas[pos] - 10 * res * (nJugador - 1));
                coords[1] = casJugador[3] + separacion;
            }
            else if (pos >= 20 && pos <= 27)
            {
                coords[0] = cas[pos];
                coords[1] = casJugador[3] + separacion;
            }
            else if (pos == 28)
            {
                coords[0] = (int)(cas[pos] + 10 * res * (nJugador - 1));
                coords[1] = casJugador[3] + separacion;
            }
            else if (pos == 29)
            {
                coords[0] = casJugador[4] + separacion;
                coords[1] = (int)(cas[pos] + 10 * res * (nJugador - 1));
            }
            else if (pos >= 30 && pos <= 35)
            {
                coords[0] = casJugador[4] + separacion;
                coords[1] = cas[pos];
            }
            else if (pos == 36)
            {
                coords[0] = casJugador[4] + separacion;
                coords[1] = (int)(cas[pos] - 10 * res * (nJugador - 1));
            }
            else if (pos == 37)
            {
                coords[0] = (int)(cas[pos] + 10 * res * (nJugador - 1));
                coords[1] = casJugador[5] - separacion;
            }
            else if (pos >= 38 && pos <= 43)
            {
                coords[0] = cas[pos];
                coords[1] = casJugador[5] - separacion;
            }
            else if (pos == 44)
            {
                coords[0] = (int)(cas[pos] - 10 * res * (nJugador - 1));
                coords[1] = casJugador[5] - separacion;
            }
            else if (pos == 45)
            {
                coords[0] = casJugador[6] - separacion;
                coords[1] = (int)(cas[pos] - 10 * res * (nJugador - 1));
            }
            else if (pos >= 46 && pos <= 49)
            {
                coords[0] = casJugador[6] - separacion;
                coords[1] = cas[pos];
            }
            else if (pos == 50)
            {
                coords[0] = casJugador[6] - separacion;
                coords[1] = (int)(cas[pos] + 10 * res * (nJugador - 1));
            }
            else if (pos == 51)
            {
                coords[0] = (int)(cas[pos] - 10 * res * (nJugador - 1));
                coords[1] = casJugador[7] + separacion;
            }
            else if (pos >= 52 && pos <= 55)
            {
                coords[0] = cas[pos];
                coords[1] = casJugador[7] + separacion;
            }
            else if (pos == 56)
            {
                coords[0] = (int)(cas[pos] + 10 * res * (nJugador - 1));
                coords[1] = casJugador[7] + separacion;
            }
            else if (pos == 57)
            {
                coords[0] = casJugador[8] + separacion;
                coords[1] = (int)(cas[pos] + 10 * res * (nJugador - 1));
            }
            else if (pos >= 58 && pos <= 59)
            {
                coords[0] = casJugador[8] + separacion;
                coords[1] = cas[pos];
            }
            else if (pos == 60)
            {
                coords[0] = casJugador[8] + separacion;
                coords[1] = (int)(cas[pos] - 10 * res * (nJugador - 1));
            }
            else if (pos == 61)
            {
                coords[0] = (int)(cas[pos] + 10 * res * (nJugador - 1));
                coords[1] = casJugador[9] - separacion;
            }
            else if (pos >= 62)
            {
                coords[0] = cas[pos];
                coords[1] = casJugador[9] - separacion;
            }

            return coords;
        }

        private void Resolution_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Resolution_Box.SelectedIndex)
            {
                case 0:
                    resolution = 1.0f;
                    break;

                case 1:
                    resolution = 0.9f;
                    break;

                case 2:
                    resolution = 0.8f;
                    break;

                case 3:
                    resolution = 0.7f;
                    break;

                case 4:
                    resolution = 0.6f;
                    break;

                case 5:
                    resolution = 0.5f;
                    break;

                case 6:
                    resolution = 0.4f;
                    break;

                case 7:
                    resolution = 0.3f;
                    break;
            }

            Form2_Load(sender, e);
        }
    }
}