using System.Collections.Generic;
using System.Linq;
using Battleships.UserInterface;

namespace Battleships.Players
{
    public class Player
    {
        private IShootStrategy _aiShootStrategy;

        public bool TryShooting(Coordinates shotCords, Board enemyBoard)
        {
            var targetSquare = enemyBoard.Ocean[shotCords.X, shotCords.Y];
            if (targetSquare.SquareStatus is SquareStatuses.Empty)
            {
                targetSquare.SquareStatus = SquareStatuses.Missed;
                return true;
            }
            if (targetSquare.SquareStatus is SquareStatuses.Ship)
            {
                targetSquare.SquareStatus = SquareStatuses.Hit;
                //CheckIfShipDestroyed(enemyBoard, targetSquare);
                return true;
            }

            return false;
        }

        public Coordinates GetAiShotCoordinates(Board board)
        {
            return _aiShootStrategy.GetShotCoordinates(board);
        }
        public string Name { get; set; }
        public List<Ship> Ships { get; set; } = new ();

        public Player(string name, IShootStrategy strategy = null)
        {
            Name = name;
            _aiShootStrategy = strategy;
        }

        public Dictionary<ShipTypes, int> GetShipCount()
        {
            Dictionary<ShipTypes, int> shipCount = new()
            {
                {ShipTypes.Carrier, Ships.Any(ship => ship.ShipType == ShipTypes.Carrier) ? 1 : 0},
                {ShipTypes.Cruiser, Ships.Any(ship => ship.ShipType == ShipTypes.Cruiser) ? 1 : 0},
                {ShipTypes.Battleship, Ships.Any(ship=>ship.ShipType == ShipTypes.Battleship) ? 1 : 0},
                {ShipTypes.Submarine, Ships.Any(ship=>ship.ShipType == ShipTypes.Submarine) ? 1 : 0},
                {ShipTypes.Destroyer, Ships.Any(ship=>ship.ShipType == ShipTypes.Destroyer) ? 1 : 0}
            };
            return shipCount;
        }

        public IShootStrategy GetAiShootStrategy()
        {
            return _aiShootStrategy;
        }
    }
}