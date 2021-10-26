using System;

namespace Battleships
{
    public class EasyAiShoot : IShootStrategy
    {
        public void Shoot()
        {
            Random random = new Random(); 
            var boardSize = Board.BoardSize;
            while (true) {
                var firstCoordinate = random.Next(0, boardSize);
                var secondCoordinate = random.Next(0, boardSize);
                Square square = new Square(firstCoordinate, secondCoordinate);
                if (square.SquareStatus.ToString() == "Empty")
                {
                    square.SquareStatus = square.SquareStatuses.Missed;
                }
                else if (square.SquareStatus.ToString() == "Ship")
                {
                    square.SquareStatus = square.SquareStatuses.Hit;
                }
            }



        }
}
}