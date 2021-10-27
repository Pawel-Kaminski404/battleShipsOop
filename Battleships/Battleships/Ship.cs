using System;
using System.Collections.Generic;

namespace Battleships
{
    public class Ship
    {
        public List<Square> OccupiedFields { get; set; }

        public Ship(List<Square> shipList)
        {
            OccupiedFields = shipList;
        }
    }
}