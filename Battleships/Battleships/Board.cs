namespace Battleships
{
    public class Board
    {
        public Square[,] Ocean { get; }
        public int Size = 10;

        public Board()
        {
            Ocean = new Square[Size, Size];
            PopulateOcean();
        }

        private void PopulateOcean()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Ocean[i, j] = new Square(i, j);
                }
            }
        }
    }
}