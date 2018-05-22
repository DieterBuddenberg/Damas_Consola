namespace Damas
{
    public class Ficha
    {
        private string color;
        private string tipo;
        private int posX;
        private int posY;
        private string[] movimientosPosibles;

        public Ficha(string color, string tipo, int posX, int posY)
        {
            this.Color = color;
            this.Tipo = tipo;
            this.PosX = posX;
            this.PosY = posY;
            
        }

        //---Propiedades/ get, set
        public string Color { get => color; set => color = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        public string[] MovimientosPosibles { get => movimientosPosibles; set => movimientosPosibles = value; }
    }
}