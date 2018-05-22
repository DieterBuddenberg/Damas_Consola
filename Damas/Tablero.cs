using System;
using System.Collections.Generic;
using System.Linq;

namespace Damas
{
    public class Tablero
    {
        private int dimX;
        private int dimY;
        private Ficha[] fichas;
        private int contadorCasillasDisponibles;
        private string[,] casillas =new string[8,8];
        
        



        public Tablero(int dimX, int dimY, Ficha[] fichas)
        {
            this.DimX = dimX;
            this.DimY = dimY;
            this.Fichas = fichas;
            casillas = new String[dimX, dimY];
        }

        //métodos
        internal void PoblarTablero() {
            //j=X   ,i = Y 
            contadorCasillasDisponibles = 0;
            for (int i = 0;i<dimY;i++) {
                for (int j = 0; j < dimX; j++) {
                    casillas[j, i] = "   ";
                    contadorCasillasDisponibles=contadorCasillasDisponibles + 1;


                }
                
            }
            
            for (int k = 0; k < Fichas.Length; k++)
            {
                if((Fichas[k].PosX - 1)>=0)
                {

                    casillas[ Fichas[k].PosX- 1, Fichas[k].PosY- 1] =" "+Fichas[k].Tipo+ " ,"+Fichas[k].Color;

                    if (Fichas[k].PosX >= 0) {
                    contadorCasillasDisponibles = contadorCasillasDisponibles - 1;

                    }

                }
            }

        }
        internal void BuscarFichaComida() {
            for (int i = 0; i < fichas.Length;i++) {
                if (fichas[i].FichaComida.Split(',').Length>1) {
                    for (int k = 0; k < fichas.Length; k++) {
                        if (fichas[k].PosX == int.Parse(fichas[i].FichaComida.Split(',')[0])&& fichas[k].PosY == int.Parse(fichas[i].FichaComida.Split(',')[1])) {
                            fichas[k].PosX = -1;
                        }
                    }
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

        internal void SeleccionarFicha(int color)
        {
            string[] letras = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", };
            int contadorFichas = 1 ;
            List<string> opciones = new List<string>();


            for (int i = 0; i < fichas.Length; i++) {
                if (Fichas[i].Color.Equals(color.ToString()) && fichas[i].MovimientosPosibles.Count >= 1) {
                    
                    Console.WriteLine((contadorFichas+") "+letras[Fichas[i].PosX-1]+Fichas[i].PosY));
                    opciones.Add(i+","+letras[Fichas[i].PosX - 1] + Fichas[i].PosY);
                    contadorFichas = contadorFichas + 1;
                    
                }
            }
            string mensaje = null;
            int opcionSeleccionada=0;
            bool estadoSeleccion = true;
            while (estadoSeleccion) {


                int.TryParse(Console.ReadLine(), out opcionSeleccionada);

                if (opcionSeleccionada > 0 && opcionSeleccionada <= opciones.Count) {
                    mensaje = "ha seleccionado la ficha en la posicion " + opciones[opcionSeleccionada - 1].Split(',')[1];
                    estadoSeleccion = false;
                    Console.WriteLine(mensaje);
                    fichas[int.Parse(opciones[opcionSeleccionada - 1].Split(',')[0])].MoverFicha();
                }
                else {
                    mensaje = "Selección no valída, intente nuevamente";
                    estadoSeleccion = true;
                    Console.WriteLine(mensaje);
                }
                
            }
            
        }

        internal void CalcularCasillasPosibles()
        {
            List<string> casillasDisponibles = new List<string>();
            string[,] casillasPosibles = new string[8, 4];
            string[] listaAuxiliar = new string[32];
            String[] colu = new String[] { "1", "2", "3", "4", "5", "6", "7", "8" };
            int cont = 0;
            for (int f = 0; f < 8; f++)
            {
                if (f % 2 == 0)
                {
                    cont = 1;
                    for (int g = 0; g < 4; g++)
                    {
                        casillasPosibles[f, g] = colu[f] +","+ cont.ToString();
                        cont = cont + 2;
                    }
                }
                else
                {
                    cont = 2;
                    for (int g = 0; g < 4; g++)
                    {
                        casillasPosibles[f, g] = colu[f] +","+cont.ToString();
                        cont = cont + 2;
                    }
                }
            }
            //aquí se descartan las casillas ya ocupadas por fichas
            
            
            int contX = 0;
            for (int x = 0; x < 8; x++)
            {
                
                for (int y = 0; y < 4; y++)
                {
                    listaAuxiliar[contX] = casillasPosibles[x, y];
                    
                    contX=contX + 1;
                }
            }
            
                for(int j = 0; j < listaAuxiliar.Length; j++) {
                    string comparador = casillas[int.Parse(listaAuxiliar[j].Split(',')[0]) - 1, int.Parse(listaAuxiliar[j].Split(',')[1]) - 1].Split(',')[0].Trim();
                    if (!comparador.Equals("o".Trim())&&!casillasDisponibles.Contains(listaAuxiliar[j]))
                    {
                        casillasDisponibles.Add(listaAuxiliar[j]);
                        
                    }//if
                
                }//for
            //refrescar fichas

            for (int i = 0; i < fichas.Length; i++) {
                fichas[i].MovimientosPosibles = new List<string>();
            }

            //se revisa la posibilidad de comer una 

            for (int i = 0; i < fichas.Length; i++)
            {

                for(int j = 0; j < fichas.Length; j++)
                {
                    //vertical derecha arriba
                    bool comprobarColor = fichas[i].Color.Equals(fichas[j].Color);
                    if (!comprobarColor) {
                        bool comprobarPosicionVerticalDerecha = ((fichas[i].PosX + 1 == fichas[j].PosX) && (fichas[i].PosY + 1 == fichas[j].PosY));
                        if (comprobarPosicionVerticalDerecha) {
                       
                            for (int l = 0; l < casillasDisponibles.Count; l++)
                            {
                                string posicionFichas = (fichas[j].PosX + 1) + "," + (fichas[j].PosY + 1);
                                if (casillasDisponibles[l].Trim().ToUpper().Equals(posicionFichas.Trim().ToUpper())) {
                                    fichas[i].MovimientosPosibles.Add((Fichas[j].PosX+1)+","+(Fichas[j].PosY+1)+","+"c");
                                }//if
                            }//for
                        }//if
                        //vertical izquierda arriba
                        bool comprobarPosicionVerticalIzquierda = ((fichas[i].PosX - 1 == fichas[j].PosX) && (fichas[i].PosY + 1 == fichas[j].PosY));
                        if (comprobarPosicionVerticalIzquierda)
                        {

                            for (int l = 0; l < casillasDisponibles.Count; l++)
                            {
                                string posicionFichas = (fichas[j].PosX - 1) + "," + (fichas[j].PosY + 1);
                                if (casillasDisponibles[l].Trim().ToUpper().Equals(posicionFichas.Trim().ToUpper()))
                                {
                                    fichas[i].MovimientosPosibles.Add((Fichas[j].PosX - 1) + "," + (Fichas[j].PosY + 1) + "," + "c");
                                }//if
                            }//for
                        }//if
                        //vertical izquierda abajo
                        bool comprobarPosicionVerticalIzquierdaAbajo = ((fichas[i].PosX - 1 == fichas[j].PosX) && (fichas[i].PosY - 1 == fichas[j].PosY));
                        if (comprobarPosicionVerticalIzquierdaAbajo)
                        {

                            for (int l = 0; l < casillasDisponibles.Count; l++)
                            {
                                string posicionFichas = (fichas[j].PosX - 1) + "," + (fichas[j].PosY - 1);
                                if (casillasDisponibles[l].Trim().ToUpper().Equals(posicionFichas.Trim().ToUpper()))
                                {
                                    fichas[i].MovimientosPosibles.Add((Fichas[j].PosX - 1) + "," + (Fichas[j].PosY - 1) + "," + "c");
                                }//if
                            }//for
                        }//if
                        //vertical derecha abajo
                        bool comprobarPosicionVerticalDerechaAbajo = ((fichas[i].PosX + 1 == fichas[j].PosX) && (fichas[i].PosY - 1 == fichas[j].PosY));
                        if (comprobarPosicionVerticalDerechaAbajo)
                        {

                            for (int l = 0; l < casillasDisponibles.Count; l++)
                            {
                                string posicionFichas = (fichas[j].PosX + 1) + "," + (fichas[j].PosY - 1);
                                if (casillasDisponibles[l].Trim().ToUpper().Equals(posicionFichas.Trim().ToUpper()))
                                {
                                    fichas[i].MovimientosPosibles.Add((Fichas[j].PosX + 1) + "," + (Fichas[j].PosY - 1) + "," + "c");
                                }//if
                            }//for
                        }//if
                    }//if

                    

                }//for
                
            }//for

            //-----------------------------------------

            //se le carga las movidas posibles a cada ficha
            for (int i = 0; i < casillasDisponibles.Count; i++) {
                
                for (int j = 0; j < fichas.Length; j++) {
                    

                    bool dama = !fichas[j].Tipo.Trim().Equals("o");
                    bool comprobarColor = int.Parse(fichas[j].Color) == 15;
                    if ((comprobarColor||dama)&&fichas[j].PosX + 1 == int.Parse(casillasDisponibles[i].Split(',')[0]) && fichas[j].PosY + 1 == int.Parse(casillasDisponibles[i].Split(',')[1])) {
                        fichas[j].MovimientosPosibles.Add(casillasDisponibles[i]);
                        
                    }
                    if ((comprobarColor||dama)&&fichas[j].PosX - 1 == int.Parse(casillasDisponibles[i].Split(',')[0]) && fichas[j].PosY + 1 == int.Parse(casillasDisponibles[i].Split(',')[1]))
                    {
                        fichas[j].MovimientosPosibles.Add(casillasDisponibles[i]);
                        
                    }
                    if ((!comprobarColor||dama)&&fichas[j].PosX - 1 == int.Parse(casillasDisponibles[i].Split(',')[0]) && fichas[j].PosY - 1 == int.Parse(casillasDisponibles[i].Split(',')[1]))
                    {
                        fichas[j].MovimientosPosibles.Add(casillasDisponibles[i]);
                        
                    }
                    if ((!comprobarColor||dama) && fichas[j].PosX + 1 == int.Parse(casillasDisponibles[i].Split(',')[0]) && fichas[j].PosY - 1 == int.Parse(casillasDisponibles[i].Split(',')[1]))
                    {
                        fichas[j].MovimientosPosibles.Add(casillasDisponibles[i]);

                    }
                }
                

            }
           
        }



        //---Propiedades/ get, set
        public int DimX { get => dimX; set => dimX = value; }

        public int DimY { get => dimY; set => dimY = value; }
        public Ficha[] Fichas { get => fichas; set => fichas = value; }
    }
}