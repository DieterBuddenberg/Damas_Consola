namespace Damas
{
    public class Jugador
    {
        private string nombre;
        private string color;

        public Jugador(string v1, string v2)
        {
            this.SetNombre(v1);
            this.SetColor(v2);
        }

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string value)
        {
            color = value;
        }
    }
}