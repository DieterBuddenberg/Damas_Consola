using System;

namespace Damas
{
    public class Partida
    {
        private Tablero tablero;
        private Jugador[] jugadores;
        //turno lleva control de quien es el turno y que numero de turno es
        private Turno turno;
        private String ganador;
        private bool estado;

        public Partida(Tablero tablero, Jugador[] jugadores, bool estado)
        {
            this.tablero = tablero;
            this.jugadores = jugadores;
            this.estado = estado;
        }
        //------------métodos----------------
        internal void Iniciar()
        {
            int nTurno = 1;
            int idJugador = 0;
            Console.WriteLine("Se ha iniciado una nueva partida");
            Tablero.PoblarTablero();
            Tablero.DibujarTablero();
            turno = new Turno(nTurno,jugadores[0].Nombre,idJugador);
            Console.ReadKey();
        }
        internal void ContinuarPartida() {
            Console.WriteLine("Turno " + turno.NTurno);
            Console.Write("Jugador: ");
            Console.ForegroundColor = (ConsoleColor) jugadores[turno.IdJugador].Color;
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write(turno.NombreJugador+"\n");
            turno.ComprobarJugadasPosibles(tablero);
            Console.ReadKey();

        }
        //---Propiedades/ get, set
        public Tablero Tablero { get => tablero; set => tablero = value; }
        public Jugador[] Jugadores { get => jugadores; set => jugadores = value; }
        internal Turno Turno { get => turno; set => turno = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}