namespace Battleships
{
    public class Board
    {
        public Square[,] Ocean { get; }
        
        public const int BoardSize = 10;

        public Board()
        {
            Ocean = new Square[BoardSize, BoardSize];
            PopulateOcean();
        }

        private void PopulateOcean()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Ocean[i, j] = new Square(i, j);
                }
            }
        }
    }
}