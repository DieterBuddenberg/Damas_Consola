namespace Damas
{
    public class Jugador
    {
        private string nombre;
        private int color;
    

        public Jugador(string nombre, int color)
        {
            this.Nombre = nombre;
            this.Color = color;
        }


        //---Propiedades/ get, set
        public string Nombre { get => nombre; set => nombre = value; }
        public int Color { get => color; set => color = value; }
    }
}