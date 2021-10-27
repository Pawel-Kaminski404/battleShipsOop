namespace Battleships
{
    public class Cursor
    {
        public Coordinates Position { get; set; } = new Coordinates(0, 0);

        public void MoveUp()
        {
            Position.X--;
        }

        public void MoveDown()
        {
            Position.X++;
        }

        public void MoveRight()
        {
            Position.Y++;
        }

        public void MoveLeft()
        {
            Position.Y--;
        }
    }
}