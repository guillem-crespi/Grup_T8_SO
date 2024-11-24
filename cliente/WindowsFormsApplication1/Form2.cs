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
        
        bool pozo1 = false;
        bool pozo2 = false;
        bool pozo3 = false;
        bool pozo4 = false;
        int Turnos1 = 0;    //Torns de penalització pel jugador 1
        int Turnos2 = 0;    //Torns de penalització pel jugador 2
        int Turnos3 = 0;    //Torns de penalització pel jugador 3
        int Turnos4 = 0;    //Torns de penalització pel jugador 4


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
            bool volverATirar = false;
            int pierdeTurno = 0;
            bool pozo = false;
            bool saltar = true;

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
            {
                nJugador = 1;
            }

            else if (radioButton2.Checked)
            {
                nJugador = 2;
            }

            else if (radioButton3.Checked)
            {
                nJugador = 3;
            }

            else
            {
                nJugador = 4;
            }

            if (posiciones[nJugador - 1] < 31 && (posiciones[nJugador - 1] + suma) >= 31)
            {
                pozo1 = false;
                pozo2 = false;
                pozo3 = false;
                pozo4 = false;
            }

            if (posiciones[nJugador - 1] == 0)
            {
                posiciones[nJugador - 1] += 1;
            }

            posiciones[nJugador - 1] += suma;

            if (posiciones[nJugador - 1] > 63)  //Retrocedir quan s'arriba a la última casella
            {
                posiciones[nJugador - 1] = 2 * 63 - posiciones[nJugador - 1];
            }

            while (posiciones[nJugador - 1] == 26 || posiciones[nJugador - 1] == 53)
            {
                if (posiciones[nJugador - 1] == 26)         //Posició especial: Dados
                {
                    posiciones[nJugador - 1] = posiciones[nJugador - 1] + 26 + suma;
                }

                else if (posiciones[nJugador - 1] == 53)    //Posició especial: Dados
                {
                    posiciones[nJugador - 1] = posiciones[nJugador - 1] + 53 + suma;
                }

                if (posiciones[nJugador - 1] > 63)  //Retrocedir quan s'arriba a la última casella
                {
                    posiciones[nJugador - 1] = 2 * 63 - posiciones[nJugador - 1];
                }
            }

            switch (posiciones[nJugador - 1])       //Posicions especials (Regles del joc -> http://museodeljuego.org/wp-content/uploads/contenidos_0000000699_docu1.pdf)
            {
                case 5:     //De oca a oca
                    posiciones[nJugador - 1] = 9;
                    volverATirar = true;
                    break;
                case 9:     //De oca a oca
                    posiciones[nJugador - 1] = 14;
                    volverATirar = true;
                    break;
                case 14:     //De oca a oca
                    posiciones[nJugador - 1] = 18;
                    volverATirar = true;
                    break;
                case 18:     //De oca a oca
                    posiciones[nJugador - 1] = 23;
                    volverATirar = true;
                    break;
                case 23:     //De oca a oca
                    posiciones[nJugador - 1] = 27;
                    volverATirar = true;
                    break;
                case 27:     //De oca a oca
                    posiciones[nJugador - 1] = 32;
                    volverATirar = true;
                    break;
                case 32:     //De oca a oca
                    posiciones[nJugador - 1] = 36;
                    volverATirar = true;
                    break;
                case 36:     //De oca a oca
                    posiciones[nJugador - 1] = 41;
                    volverATirar = true;
                    break;
                case 41:     //De oca a oca
                    posiciones[nJugador - 1] = 45;
                    volverATirar = true;
                    break;
                case 45:     //De oca a oca
                    posiciones[nJugador - 1] = 50;
                    volverATirar = true;
                    break;
                case 50:     //De oca a oca
                    posiciones[nJugador - 1] = 54;
                    volverATirar = true;
                    break;
                case 54:     //De oca a oca
                    posiciones[nJugador - 1] = 59;
                    volverATirar = true;
                    break;
                case 59:     //De oca a oca
                    posiciones[nJugador - 1] = 63;
                    volverATirar = true;
                    break;
                case 6:     //Puente a puente
                    posiciones[nJugador - 1] = 19;
                    pierdeTurno = 1;
                    break;
                case 12:    //Puente a puente
                    posiciones[nJugador - 1] = 19;
                    pierdeTurno = 1;
                    break;
                case 19:    //Posada
                    pierdeTurno = 1;
                    break;
                case 31:    //Pozo
                    pozo = true;
                    break;
                case 42:    //Laberinto
                    posiciones[nJugador - 1] = 30;
                    break;
                case 52:    //Carcel
                    pierdeTurno = 2;
                    break;
                case 58:    //Muerte
                    posiciones[nJugador - 1] = 0;
                    break;
            }

            if (posiciones[nJugador - 1] > 63)  //Retrocedir quan s'arriba a la última casella
            {
                posiciones[nJugador - 1] = 2 * 63 - posiciones[nJugador - 1];
            }

            if (pierdeTurno > 0)
            {
                if (nJugador == 1)
                {
                    Turnos1 = pierdeTurno;
                }

                else if (nJugador == 2)
                {
                    Turnos2 = pierdeTurno;
                }

                else if (nJugador == 3)
                {
                    Turnos3 = pierdeTurno;
                }

                else
                {
                    Turnos4 = pierdeTurno;
                }
            }

            if (pozo)
            {
                if (nJugador == 1)
                {
                    pozo1 = true;
                }

                else if (nJugador == 2)
                {
                    pozo2 = true;
                }

                else if (nJugador == 3)
                {
                    pozo3 = true;
                }

                else
                {
                    pozo4 = true;
                }
            }

            tablero.Invalidate();

            if (volverATirar)
            {
                if (nJugador == 1)
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }

                else if (nJugador == 2)
                {
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                }

                else if (nJugador == 3)
                {
                    radioButton3.Checked = true;
                    radioButton4.Checked = false;
                }

                else
                {
                    radioButton4.Checked = true;
                    radioButton1.Checked = false;
                }
            }
            else
            {
                if (posiciones[nJugador - 1] == 63)
                    MessageBox.Show("Ha ganado el jugador " + Convert.ToString(nJugador));
                while (saltar)
                {
                    switch (nJugador)
                    {
                        case 1:
                            if (pozo2)
                            {
                                nJugador = 2;
                            }
                            else if (Turnos2 > 0)
                            {
                                nJugador = 2;
                                Turnos2--;
                            }
                            else
                            {
                                saltar = false;
                                radioButton1.Checked = false;
                                radioButton2.Checked = true;
                            }
                            break;
                        case 2:
                            if (pozo3)
                            {
                                nJugador = 3;
                            }
                            else if (Turnos3 > 0)
                            {
                                nJugador = 3;
                                Turnos3--;
                            }
                            else
                            {
                                saltar = false;
                                radioButton2.Checked = false;
                                radioButton3.Checked = true;
                            }
                            break;
                        case 3:
                            if (pozo4)
                            {
                                nJugador = 4;
                            }
                            else if (Turnos4 > 0)
                            {
                                nJugador = 4;
                                Turnos4--;
                            }
                            else
                            {
                                saltar = false;
                                radioButton3.Checked = false;
                                radioButton4.Checked = true;
                            }
                            break;
                        case 4:
                            if (pozo1)
                            {
                                nJugador = 1;
                            }
                            else if (Turnos1 > 0)
                            {
                                nJugador = 1;
                                Turnos1--;
                            }
                            else
                            {
                                saltar = false;
                                radioButton4.Checked = false;
                                radioButton1.Checked = true;
                            }
                            break;
                    }
                }
            }
        }

        private void tablero_Paint(object sender, PaintEventArgs e)
        {
            float res = resolution;
            int[] coord1 = new int[2];
            int[] coord2 = new int[2];
            int[] coord3 = new int[2];
            int[] coord4 = new int[2];

            coord1 = GetCoordinates(casillas, casillasJugador, 1);
            coord2 = GetCoordinates(casillas, casillasJugador, 2);
            coord3 = GetCoordinates(casillas, casillasJugador, 3);
            coord4 = GetCoordinates(casillas, casillasJugador, 4);

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

        private int[] GetCoordinates(List<int> cas, List<int> casJugador, int nJugador)    //Retorna les coordenades dels pixels del tauler
        {
            int pos = posiciones[nJugador - 1];
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
                case 0:     //1000x1000
                    resolution = 1.0f;
                    break;
                    
                case 1:     //900x900
                    resolution = 0.9f;
                    break;

                case 2:     //800x800
                    resolution = 0.8f;
                    break;

                case 3:     //700x700
                    resolution = 0.7f;
                    break;

                case 4:     //600x600
                    resolution = 0.6f;
                    break;

                case 5:     //500x500
                    resolution = 0.5f;
                    break;

                case 6:     //400x400
                    resolution = 0.4f;
                    break;

                case 7:     //300x300
                    resolution = 0.3f;
                    break;
            }

            Form2_Load(sender, e);
        }
    }
}