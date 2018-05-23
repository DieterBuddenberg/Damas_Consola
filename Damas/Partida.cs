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
            
            Tablero.CalcularCasillasPosibles();
            turno = new Turno(nTurno,jugadores[0].Nombre,idJugador);
            
            Console.ReadKey();
        }
        internal void ContinuarPartida() {

            tablero.CalcularCasillasPosibles();
            Console.Clear();
            Tablero.DibujarTablero();
            Console.WriteLine("Turno " + turno.NTurno);
            turno.NombreJugador = jugadores[turno.IdJugador].Nombre;
            Console.Write("Jugador: ");
            Console.ForegroundColor = (ConsoleColor) jugadores[turno.IdJugador].Color;
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write(turno.NombreJugador+"\n");
            
            Console.WriteLine("seleccione ficha a mover");
            tablero.SeleccionarFicha(jugadores[turno.IdJugador].Color);
            Tablero.BuscarFichaComida();
            Tablero.PoblarTablero();
            Tablero.DibujarTablero();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            turno.NTurno = turno.NTurno+1;
            if (turno.IdJugador == 0)
            {
                turno.IdJugador = 1;
            }
            else {
                turno.IdJugador = 0;

            }
            ganador = FinalizarPartida();
            

        }
        internal String FinalizarPartida() {
            int vicB = 0, vicR = 0;
            String victoria = null;
            for (int i = 0; i < Tablero.Fichas.Length; i++)
            {
                if (Tablero.Fichas[i].Color.Equals("15") && Tablero.Fichas[i].PosX.Equals(-1))
                {
                    vicB++;
                    if(vicB > 11)
                    {
                        victoria = jugadores[1].Nombre.ToString() ; // "15";
                        estado = false;
                    }
                }
                if(Tablero.Fichas[i].Color.Equals("4") && Tablero.Fichas[i].PosX.Equals(-1))
                {
                    vicR++;
                    if (vicR > 11)
                    {
                        victoria = jugadores[0].Nombre.ToString(); // "4";
                        estado = false;
                    }
                }
            }
            return victoria;
        }

        //---Propiedades/ get, set
        public Tablero Tablero { get => tablero; set => tablero = value; }
        public Jugador[] Jugadores { get => jugadores; set => jugadores = value; }
        internal Turno Turno { get => turno; set => turno = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}