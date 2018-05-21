namespace Damas
{
    public class Ficha
    {
        private string color;
        private string tipo;
        private int posX;
        private int posY;

        public Ficha()
        {
        }

        public Ficha(string color, string tipo, int posX, int posY)
        {
            this.SetColor(color);
            this.SetTipo(tipo);
            this.SetPosX(posX);
            this.SetPosY(posY);
        }

        public string GetColor()
        {
            return color;
        }

        public void SetColor(string value)
        {
            color = value;
        }

        public string GetTipo()
        {
            return tipo;
        }

        public void SetTipo(string value)
        {
            tipo = value;
        }

        public int GetPosX()
        {
            return posX;
        }

        public void SetPosX(int value)
        {
            posX = value;
        }

        public int GetPosY()
        {
            return posY;
        }

        public void SetPosY(int value)
        {
            posY = value;
        }

    }
}