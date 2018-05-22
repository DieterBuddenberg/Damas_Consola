using System;

namespace Damas
{
    public class Tablero
    {
        private int dimX;
        private int dimY;
        private Ficha[] fichas;
        private String[,] casillas =new String[8,8];
        private String[,] movimientos = new String[8, 4];

        internal void Movimientos()
        {
            String[] colu = new String[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            int cont = 0;
            for (int f = 0; f < 8; f++)
            {
                if (f % 2 == 0)
                {
                    cont = 1;
                    for (int g = 0; g < 4; g++)
                    {
                        movimientos[f, g] = colu[f] + cont.ToString();
                        cont = cont + 2;
                    }
                }
                else
                {
                    cont = 2;
                    for (int g = 0; g < 4; g++)
                    {
                        movimientos[f, g] = colu[f] + cont.ToString();
                        cont = cont + 2;
                    }
                }
            }
        }

        public Tablero(int dimX, int dimY, Ficha[] fichas)
        {
            this.DimX = dimX;
            this.DimY = dimY;
            this.Fichas = fichas;
            casillas = new String[dimX, dimY];
        }
        internal void PoblarTablero() {
            //j=X   ,i = Y 
            for (int i = 0;i<dimY;i++) {
                for (int j = 0; j < dimX; j++) {
                    casillas[j, i] = "   ";
                    
                }
                
            }
            
            for (int k = 0; k < Fichas.Length; k++)
            {
                casillas[ Fichas[k].PosX- 1, Fichas[k].PosY- 1] =" "+Fichas[k].Tipo+ " ,"+Fichas[k].Color;

            }

        }
        //----método posiblemente malo
        internal void ComprobarTablero()
        {
            bool movX=false;
            bool movY=false;
            string[] coordenadas= new string[fichas.Length];
            for (int i=0;i<fichas.Length;i++) {

                 movX = false;
                 movY = false;
                for (int j = 0; j < fichas.Length; j++) {
                    
                }
                
            }
        }

        internal void DibujarTablero()
        {
            
            //color 0 = negro   - color 7 = gris
            int[] color = { 3, 0 };
            string[] columna = new string[] {"   A "," B "," C "," D "," E "," F "," G "," H "};
            string[] fila = new string[] { "1 ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 " };
            
            //auxiliar usado para variar el color de cada casilla
            int aux = 0;

            for (int i =-1; i < dimY; i++)
            {
                
                for (int j = -1; j<=dimX; j++)
                {   //enumera las filas
                    if ((j < 0||j>8) && i!=8&&i!=-1)
                    {
                        Console.BackgroundColor = (ConsoleColor)0;
                        Console.ForegroundColor = (ConsoleColor)15;

                        Console.Write(fila[7-i]);
                    }
                    else
                    {
                        if (i < 8 && i>-1)
                        {
                            
                            if (((((i + 1) % 2) > 0) && j==7))
                            {
                                aux = 1;
                            }
                            else {
                                if (j == 7) {
                                    aux = 0;
                                }
                               
                            }
                            Console.BackgroundColor = (ConsoleColor)color[aux];

                            //se ubican las piezas
                            if (!(j > 7)) {
                                if (casillas[j, 7-i].Split(',').Length > 1)
                                {
                                    Console.ForegroundColor=(ConsoleColor)int.Parse(casillas[j, 7-i].Split(',')[1]);
                                    Console.Write(casillas[j, 7-i].Split(',')[0]);
                                }
                                else {
                                    Console.Write(casillas[j, 7-i]);
                                }
                                
                            }
                            

                            if (aux == 1)
                            {
                                aux = 0;
                            }
                            else
                            {
                                aux = 1;
                            }

                        }
                        else {
                            if (i==-1&&j>=0&&j<8)
                            {
                                Console.ForegroundColor = (ConsoleColor)15;
                                Console.Write(columna[j]);
                            }
                            
                        }
                       
                    }
                }

                Console.Write("\n");
            }
            
        }




        //---Propiedades/ get, set
        public int DimX { get => dimX; set => dimX = value; }

        public int DimY { get => dimY; set => dimY = value; }
        public Ficha[] Fichas { get => fichas; set => fichas = value; }
    }
}