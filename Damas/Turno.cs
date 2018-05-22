using System;

namespace Damas
{
    internal class Turno
    {
        private int nTurno;
        private string nombreJugador;
        private int idJugador;

        public Turno(int nTurno, string nombreJugador, int idJugador)
        {
            this.nTurno = nTurno;
            this.nombreJugador = nombreJugador;
            this.idJugador = idJugador;
        }



        //---Propiedades/ get, set
        public int NTurno { get => nTurno; set => nTurno = value; }
        public string NombreJugador { get => nombreJugador; set => nombreJugador = value; }
        public int IdJugador { get => idJugador; set => idJugador = value; }

        internal void ComprobarJugadasPosibles(Tablero tablero)
        {
            tablero.CalcularCasillasPosibles();
        }
    }
}