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


            for (int i = 0; i < MovimientosPosibles.Count; i++)
            {
                if ( MovimientosPosibles.Count >= 1)
                {
                    if (MovimientosPosibles[i].Split(',').Length>2)
                    {
                        Console.WriteLine(contadorFichas + ") " + "Comer Moviendose a "+letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                        opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                        this.ComerFicha(int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1, (int.Parse(MovimientosPosibles[i].Split(',')[1]) - 1));
                    }
                    else{
                        Console.WriteLine(contadorFichas + ") " + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                        opciones.Add(i + ";" + letras[int.Parse(MovimientosPosibles[i].Split(',')[0]) - 1] + MovimientosPosibles[i].Split(',')[1]);
                        
                    }
                    contadorFichas = contadorFichas + 1;

                }
            }
            //-----Generar menu de seleccion
            string mensaje = null;
            int opcionSeleccionada = 0;
            bool estadoSeleccion = true;
            while (estadoSeleccion)
            {


                int.TryParse(Console.ReadLine(), out opcionSeleccionada);

                if (opcionSeleccionada > 0 && opcionSeleccionada <= opciones.Count)
                {
                    mensaje = "ha seleccionado mover a la posicion " + opciones[opcionSeleccionada - 1].Split(';')[1];
                    posX =int.Parse(MovimientosPosibles[int.Parse(opciones[opcionSeleccionada - 1].Split(';')[0])].Split(',')[0]);
                    posY = int.Parse(MovimientosPosibles[int.Parse(opciones[opcionSeleccionada - 1].Split(';')[0])].Split(',')[1]);

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
        internal void ComerFicha(int x,int y) {
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