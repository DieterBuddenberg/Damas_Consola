using System;
using System.Collections.Generic;

namespace Damas
{
    public class Ficha
    {
        private string color;
        private string tipo;
        private int posX;
        private int posY;
        private string fichaComida=" ";
        List<string> movimientosPosibles = new List<string>();

        public Ficha(string color, string tipo, int posX, int posY)
        {
            this.Color = color;
            this.Tipo = tipo;
            this.PosX = posX;
            this.PosY = posY;
            
        }
        //métodos
        internal void coronar()
        {
            tipo="¤";
        }
        internal void MoverFicha()
        {
            Console.WriteLine("seleccione donde desea mover su ficha");
            string[] letras = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", };

            int contadorFichas = 1;
            List<string> opciones = new List<string>();
            bool comprobarColor = false;
            bool dama = false;

            for (int i = 0; i < MovimientosPosibles.Count; i++)
            {
                if ( MovimientosPosibles.Count >= 1)
                {
                    comprobarColor = int.Parse(Color) == 15;
                    dama = tipo.Trim().Equals("¤".Trim());
                    if (MovimientosPosibles[i].Split(',').Length>2)
                    {
                        if ((comprobarColor||dama) && (int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1) > posX && (int.Parse(MovimientosPosibles[i].Split(',')[1]) - 1) > posY)

                        {
                            int auxX, auxY;
                            auxX = int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1;
                            auxY = (int.Parse(MovimientosPosibles[i].Split(',')[1]) - 1);

                            Console.WriteLine(contadorFichas + ") " + "Comer Moviendose a " + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                            opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1] + ";" + auxX + ":" + auxY);
                            contadorFichas = contadorFichas + 1;
                        }//if
                        else {
                            if ((comprobarColor || dama) && (int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1)<posX && (int.Parse(MovimientosPosibles[i].Split(',')[1]) -1) > posY)
                            {
                                int auxX, auxY;
                                auxX = int.Parse(MovimientosPosibles[i].Split(',')[0]) + 1;
                                auxY = int.Parse(MovimientosPosibles[i].Split(',')[1]) - 1;

                                Console.WriteLine(contadorFichas + ") " + "Comer Moviendose a " + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                            opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1] + ";" + auxX + ":" + auxY);
                                contadorFichas = contadorFichas + 1;

                            }//if
                        }//else
                        //-----------------------------------------hacia abajo-------------------------------------------
                        if ((!comprobarColor || dama) && (int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1) > posX && (int.Parse(MovimientosPosibles[i].Split(',')[1]) - 1) < posY)

                        {
                            int auxX = (int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1);
                            int auxY = (int.Parse(MovimientosPosibles[i].Split(',')[1]) + 1);
                            Console.WriteLine(contadorFichas + ") " + "Comer Moviendose a " + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                            opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1] + ";" + auxX + ":" + auxY);
                            contadorFichas = contadorFichas + 1;


                        }//if
                        else
                        {
                            if ((!comprobarColor || dama) && (int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1) < posX && (int.Parse(MovimientosPosibles[i].Split(',')[1]) - 1) < posY)
                            {
                                int auxX, auxY;
                                auxX = int.Parse(MovimientosPosibles[i].Split(',')[0]) + 1;
                                auxY = int.Parse(MovimientosPosibles[i].Split(',')[1]) + 1;
                                Console.WriteLine(contadorFichas + ") " + "Comer Moviendose a " + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                                opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]+";"+auxX+":"+auxY);

                                contadorFichas = contadorFichas + 1;

                            }//if
                        }//else
                        //-----------------------------------------------------------------------------------------------

                    }
                    else{
                        Console.WriteLine(contadorFichas + ") " + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                        opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                        contadorFichas = contadorFichas + 1;
                    }
                    

                }
            }
            //-----Generar menu de seleccion
            string mensaje = null;
            int opcionSeleccionada = 0;
            bool estadoSeleccion = true;
            while (estadoSeleccion&&opciones.Count>0)
            {


                int.TryParse(Console.ReadLine(), out opcionSeleccionada);

                if (opcionSeleccionada > 0 && opcionSeleccionada <= opciones.Count)
                {
                    mensaje = "ha seleccionado mover a la posicion " + opciones[opcionSeleccionada - 1].Split(';')[1];
                    posX =int.Parse(MovimientosPosibles[int.Parse(opciones[opcionSeleccionada - 1].Split(';')[0])].Split(',')[0]);
                    posY = int.Parse(MovimientosPosibles[int.Parse(opciones[opcionSeleccionada - 1].Split(';')[0])].Split(',')[1]);
                    if (opciones[opcionSeleccionada - 1].Split(';').Length > 2) {
                        int x = int.Parse(opciones[opcionSeleccionada - 1].Split(';')[2].Split(':')[0]);
                        int y = int.Parse(opciones[opcionSeleccionada - 1].Split(';')[2].Split(':')[1]);
                        this.ComerFicha(x,y);
                    }
                    estadoSeleccion = false;
                    
                }
                else
                {
                    mensaje = "Selección no valída, intente nuevamente";
                    estadoSeleccion = true;
                }
                Console.WriteLine(mensaje);
            }
            if (PosY == 8 || PosY == 1) {
                this.coronar();
            }
        }
        internal void ComerFicha(int x,int y ) {
            fichaComida = x + "," + y;

        }
        //---Propiedades/ get, set
        public string Color { get => color; set => color = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        public List<string> MovimientosPosibles { get => movimientosPosibles; set => movimientosPosibles = value; }
        public string FichaComida { get => fichaComida; set => fichaComida = value; }
    }
}