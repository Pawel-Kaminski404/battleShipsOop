using System;
using System.Collections.Generic;

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