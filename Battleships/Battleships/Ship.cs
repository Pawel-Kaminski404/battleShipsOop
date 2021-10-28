using System.Collections.Generic;
using Battleships.Players;

namespace Battleships
{
    public class Ship
    {
        public List<Square> OccupiedFields { get; }
        
        public ShipTypes ShipType { get; }
        
        public Ship(int shipSize)
        {
            OccupiedFields = new List<Square>();
            ShipType = shipSize switch
            {
                2 => ShipTypes.Carrier,
                3 => ShipTypes.Cruiser,
                4 => ShipTypes.Battleship,
                5 => ShipTypes.Submarine,
                6 => ShipTypes.Destroyer,
            };
        }

        public Ship(int shipSize,List<Square> lista)
        {
            OccupiedFields = new List<Square>();
            OccupiedFields = lista;
            ShipType = shipSize switch
            {
                2 => ShipTypes.Carrier,
                3 => ShipTypes.Cruiser,
                4 => ShipTypes.Battleship,
                5 => ShipTypes.Submarine,
                6 => ShipTypes.Destroyer,
            };
        }
        public void TrySinkingShip(Player enemy)
        {
            if (CheckIfShipDestroyed())
            {
                SunkShip(enemy);
            }
        }

        private bool CheckIfShipDestroyed()
        {
            foreach (var square in OccupiedFields)
            {
                if (square.SquareStatus == SquareStatuses.Ship)
                {
                    return false;
                }
            }
            return true;
        }
        private void SunkShip(Player enemy)
        {
            foreach (var square in OccupiedFields)
            {
                square.SquareStatus = SquareStatuses.Sunk;
            }
            enemy.Ships.Remove(this);
        }
    }
    public enum ShipTypes
    {
        Carrier = 2,
        Cruiser,
        Battleship,
        Submarine,
        Destroyer
    }
}