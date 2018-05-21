using System;

namespace Damas
{
    public class Partida
    {
        private Tablero tablero;
        private Jugador[] jugadores;

        public Partida(Tablero tablero, Jugador[] jugadores)
        {
            this.tablero = tablero;
            this.jugadores = jugadores;
        }

        internal void iniciar()
        {
            Console.WriteLine("Se ha iniciado una nueva partida");
            tablero.poblarTablero();
            tablero.dibujarTablero();
            Console.ReadKey();
        }
    }
}