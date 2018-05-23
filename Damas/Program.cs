using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damas

{
    class Program
    {
        static void Main(string[] args)
        {
            
            Program Damas = new Program();
            Ficha[] fichas;
            Jugador [] jugadores = new Jugador[]{new Jugador("Blanco",15),new Jugador("Rojo",4) };
            Tablero tablero;
            Partida partida;
            bool estadoJuego = true;
            while(estadoJuego)
            {
                switch (Damas.Menu())
                {
                    case 1:
                        //la variable estado define si la partida esta en curso(true) o terminó (false)
                        bool estado = true;
                        String tipo = "o";
                        int dimX = 8;
                        int dimY = 8;
                        int nFichas = 24;
                        int[] posX = new int[] { 1, 3, 5, 7, 2, 4, 6, 8, 1, 3, 5, 7, 2, 4, 6, 8, 1, 3, 5, 7, 2, 4, 6, 8 };
                        int[] posY = new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8 };
                        fichas = new Ficha[24];
                        //color 4 = rojo oscuro - color 15 = blanco - color 12 = rojo 
                        for (int i = 0; i < nFichas; i++)
                        {
                            String color = "4";
                            if (i < (fichas.Length / 2))
                            {
                                color = "15";
                            }
                            fichas[i] = new Ficha(color, tipo, posX[i], posY[i]);
                        }
                        tablero = new Tablero(dimX, dimY, fichas);
                        partida = new Partida(tablero, jugadores, estado);
                        partida.Iniciar();
                        while (partida.Estado)
                        {
                            partida.ContinuarPartida();
                        }

                        Console.WriteLine("Ganador de la partida: Participante " + partida.Ganador.ToString() );

                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("hasta luego!");
                        estadoJuego = false;
                        break;
                }
            }
           
        }
        //--------------menu--------------
        public int Menu() {
            int seleccion = -1;
            string[] opciones = new string[]{ ".-Iniciar Partida",".-Consultar resultado última partida", ".-Cerrar" };
            while (seleccion<0||seleccion>opciones.Length) {
                for (int i = 0; i < opciones.Length; i++) {
                   
                    Console.WriteLine((i + 1) + opciones[i]);
                }
                String seleccionAux = Console.ReadLine();
                // lo siguiente se utiliza para comprobar si es una selección en el formato adecuado
                try {
                    seleccion = int.Parse(seleccionAux);
                } catch (Exception e) {
                    Console.WriteLine(e);
                    seleccion = -1;
                }
            }
            return seleccion;
        }
    }
}
