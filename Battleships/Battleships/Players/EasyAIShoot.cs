using System;

namespace Battleships.Players
{
    public class EasyAiShoot : IShootStrategy
    {
        private readonly Random _random = new ();
        
        public Coordinates GetShotCoordinates(Board board)
        {
            var boardSize = board.Size;
            var firstCoordinate = _random.Next(0, boardSize);
            var secondCoordinate = _random.Next(0, boardSize);
            return new Coordinates(firstCoordinate, secondCoordinate);
        }
    }
}