using System;
using System.Collections.Generic;

namespace Battleships
{
    public class Square
    {
        public Coordinates Position { get; }
        
        public Enum SquareStatus { get; set; }

        public Square(int x, int y)
        {
            SquareStatus = SquareStatuses.Empty;
            Position = new Coordinates(x, y);
        }
    }

    public enum SquareStatuses
    {
        Empty,
        Ship,
        Hit,
        Missed,
        Sunk,
        Cursor
    }
}