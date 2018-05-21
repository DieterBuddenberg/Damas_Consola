namespace Damas
{
    internal class Turno
    {
        private int nTurno;
        private string nombreJugador;
        private string color;

        public Turno(int nTurno, string nombre, string color)
        {
            this.NTurno = nTurno;
            this.NombreJugador = nombre;
            this.Color = color;
        }

        //---Propiedades/ get, set
        public int NTurno { get => nTurno; set => nTurno = value; }
        public string NombreJugador { get => nombreJugador; set => nombreJugador = value; }
        public string Color { get => color; set => color = value; }
    }
}