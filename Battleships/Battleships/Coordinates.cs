namespace Battleships
{
    public class Coordinates
    {
        public int X { get; set; }
        
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"Coordinates X={X} Y={Y}";
        }
    }
}