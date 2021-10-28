﻿namespace Battleships
{
    public class Square
    {
        public Coordinates Position { get; }
        
        public SquareStatuses SquareStatus { get; set; }

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