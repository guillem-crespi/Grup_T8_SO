using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private int sumaTotal = 0; // Variable para almacenar la suma total de los dados
        private List<Point> posicionesResaltadas = new List<Point>(); // Lista para almacenar posiciones resaltadas

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)

        {
            // Configurar el DataGridView como un tablero de 7 filas y 9 columnas
            matriz.ColumnCount = 9;
            matriz.RowCount = 7;
            matriz.ColumnHeadersVisible = false;
            matriz.RowHeadersVisible = false;
            matriz.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            matriz.BorderStyle = BorderStyle.None;

            // Tamaño de las celdas
            int cellHeight = 35; // Altura de las filas
            int cellWidth = 55;  // Ancho de las columnas

            // Ajustar el tamaño de las celdas
            for (int i = 0; i < matriz.RowCount; i++)
            {
                matriz.Rows[i].Height = cellHeight; // Altura de las filas
            }
            for (int j = 0; j < matriz.ColumnCount; j++)
            {
                matriz.Columns[j].Width = cellWidth; // Ancho de las columnas
            }

           
            matriz.Location = new Point(200, 50); // Ajustar la ubicación según sea necesario
            matriz.Size = new Size(500, 250); // Ajustar el tamaño total del DataGridView

            //// Añadir la matriz al formulario para que sea visible
            Controls.Add(matriz);

            // Asignar posiciones a cada celda
            AsignarPosiciones();
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

            ResaltarCelda(sumaTotal);
        }


        private void AsignarPosiciones()
        {
           // Point[] posiciones = new Point[63];// Crear un vector de Point para almacenar las posiciones
           // int index = 0;

            for (int rowIndex = 0; rowIndex < 7; rowIndex++)
            {
                for (int colIndex = 0; colIndex < 9; colIndex++)
                {
                   
                    string posicion = $"({rowIndex}, {colIndex})"; // Crear una cadena que representa la posición
                    matriz.Rows[rowIndex].Cells[colIndex].Value = posicion; // Asigna la posición a la celda
                 //   posiciones[index] = new Point(rowIndex, colIndex);
                 //   index++;

                }
            }

         //Opcional: Asignar el DataTable a un DataGridView para visualizar las posiciones
         //myDataGridView.DataSource = posiciones;
        }

        private void ResaltarCelda(int suma)
        {
            // Limpiar las celdas resaltadas previamente
            foreach(DataGridViewRow row in matriz.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White; 
                }
            }

            /// Resaltar celdas en un bucle hasta llegar a la suma acumulada
            for (int i = 1; i <= sumaTotal && i <= 63; i++) //if (suma >= 1 && suma <= 63) 
            {
                int maxCasillas = 63;
                int Casilla = Math.Min(suma, maxCasillas) - 1; // Ajustar para indexar desde 0

                int rowIndex = Casilla / 9; // Determina el índice de fila ejemplo: 10/9=1
                int colIndex = Casilla % 9;  // Determina el índice de columna ejemplo 10%9=1 --> (1,1) posisicon 10

                // Resaltar la celda correspondiente
                if (rowIndex >= 0 && rowIndex < matriz.RowCount && colIndex >= 0 && colIndex < matriz.ColumnCount)
                {
                    matriz.Rows[rowIndex].Cells[colIndex].Style.BackColor = Color.Yellow; // Resalta en color amarillo
                    posicionesResaltadas.Add(new Point(rowIndex, colIndex)); // Guarda la posición resaltada
                }
            }
        }
    }
}