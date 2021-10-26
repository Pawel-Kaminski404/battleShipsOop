using System;

namespace Battleships.Players
{
    public class EasyAIShoot : IShootStrategy
    {
        public void Shoot(Board board)
            {
                Random random = new Random(); 
                var boardSize = board.Size;
                while (true) {
                    var firstCoordinate = random.Next(0, boardSize);
                    var secondCoordinate = random.Next(0, boardSize);
                    var positionTarget = board.Ocean[firstCoordinate, secondCoordinate];
                    if (positionTarget.SquareStatus.ToString() == "Empty")
                    {
                        positionTarget.SquareStatus = SquareStatuses.Missed;
                        break;
                    }
                    if (positionTarget.SquareStatus.ToString() == "Ship")
                    {
                        positionTarget.SquareStatus = SquareStatuses.Hit;
                        break;
                    }
                }
            }
        public override string ToString()
        {
            return "Easy AI";
        }
    }
}