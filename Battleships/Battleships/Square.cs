using System;
using System.Collections.Generic;

namespace Battleships
{
    public class Square
    {
        private Coordinates Position { get; }
        
        public Enum SquareStatus { get; set; }

        public Square(int x, int y)
        {
            SquareStatus = SquareStatuses.Empty;
            Position = new Coordinates(x, y);
        }

        public char GetCharacter()
        {
            return this.SquareStatus switch
            {
                SquareStatuses.Empty => _squareChars["empty"],
                SquareStatuses.Ship => _squareChars["ship"],
                SquareStatuses.Hit => _squareChars["hit"],
                SquareStatuses.Missed => _squareChars["missed"]
            };
        }

        private readonly Dictionary<string, char> _squareChars = new()
        {
            {"empty", 'E'},
            {"ship", 'S'},
            {"hit", 'H'},
            {"missed", 'M'}
        };
    }

    public enum SquareStatuses
    {
        Empty,
        Ship,
        Hit,
        Missed
    }
}