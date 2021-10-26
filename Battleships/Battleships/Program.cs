using System;

namespace Battleships
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            var board = new Board();
            var cursor = new Cursor();
            board.Ocean[0, 5].SquareStatus = SquareStatuses.Hit;
            board.Ocean[1, 5].SquareStatus = SquareStatuses.Ship;
            board.Ocean[2, 6].SquareStatus = SquareStatuses.Missed;
            board.Ocean[4, 6].SquareStatus = SquareStatuses.Sunk;
            var display = new Display();
            display.PrintBoard(board, cursor);
        }
    }
}