namespace Damas
{
    public class Jugador
    {
        private string nombre;
        private string color;

        public Jugador(string nombre, string color)
        {
            this.Nombre = nombre;
            this.Color = color;
        }

        //---Propiedades/ get, set
        public string Nombre { get => nombre; set => nombre = value; }
        public string Color { get => color; set => color = value; }
    }
}