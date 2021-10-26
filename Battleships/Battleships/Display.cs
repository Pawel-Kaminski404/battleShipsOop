using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Battleships
{
    public class Display
    {
        private Dictionary<string, ConsoleColor> _colors = new()
        {
            {"mainBackgroundColor", ConsoleColor.Black},
            {"boardEmptyCellColor", ConsoleColor.White},
            {"boardShipCellColor", ConsoleColor.DarkGreen},
            {"boardHitCellColor", ConsoleColor.Yellow},
            {"boardSunkCellColor", ConsoleColor.DarkRed},
            {"boardSeparatorColor", ConsoleColor.DarkGray},
            {"borderForegroundColor", ConsoleColor.White},
            {"cellMainForegroundColor", ConsoleColor.DarkGray},
            {"cellMissedForegroundColor", ConsoleColor.DarkCyan},
            {"cellCursorColor", ConsoleColor.DarkYellow}
        };

        private const int CellWidth = 7;

        public void PrintBoard(Board board, Cursor cursor)
        {
            Console.WriteLine();
            PrintBoardHeader(board.Size);
            for (int row = 0; row < board.Size; row++)
            {
                PrintGameBoardRow(board, row, false, cursor);
                PrintGameBoardRow(board, row, true, cursor);
                PrintGameBoardRow(board, row, false, cursor);
                PrintHorizontalSeparator();
                Console.WriteLine();
            }
            PrintHorizontalSeparator();
            
        }

        private void PrintBoardHeader(int boardSize)
        {
            PrintHorizontalSeparator();
            Console.WriteLine();
            Console.Write(GetIndent(8));
            PrintVerticalSeparator(1);
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.ForegroundColor = _colors["borderForegroundColor"];
            for (int i = 0; i < boardSize; i++)
            {
                char letter = (char) ('A' + i);
                Console.Write(GetIndent(5));
                Console.Write(letter);
                Console.Write(GetIndent(3));
            }

            PrintVerticalSeparator(3);
            Console.WriteLine();


        }

        private void PrintHorizontalSeparator()
        {
            const int boardWidth = 94;
            Console.Write(GetIndent(8));
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.Write(GetIndent(boardWidth));
            Console.BackgroundColor = _colors["mainBackgroundColor"];
        }

        private void PrintVerticalSeparator(int multiplier = 2)
        {
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.Write(GetIndent(multiplier));
            Console.BackgroundColor = _colors["mainBackgroundColor"];
        }

        private void PrintGameBoardRow(Board board, int row, bool isRowCountNeeded, Cursor cursor)
        {
            Console.Write(GetIndent(8));
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.ForegroundColor = _colors["borderForegroundColor"];
            if (isRowCountNeeded)
            {
                string rowCountString = row < board.Size-1 ? $" {row + 1} " : $"{row + 1} ";
                Console.Write(rowCountString);    
            }
            else
            {
                Console.Write(GetIndent(3));
            }
            for (int col = 0; col < board.Size; col++)
            {
                Console.ForegroundColor = _colors["cellMainForegroundColor"];
                var square = board.Ocean[row, col];
                var squareStatus = square.Position.X == cursor.Position.X && square.Position.Y == cursor.Position.Y ? SquareStatuses.Cursor : square.SquareStatus;
                switch (squareStatus)
                {
                    case SquareStatuses.Cursor:
                        Console.ForegroundColor = _colors["cellCursorColor"];
                        Console.BackgroundColor = _colors["boardEmptyCellColor"];
                        Console.Write(isRowCountNeeded ? "██   ██" : "███████");
                        break;
                    case SquareStatuses.Empty:
                        Console.BackgroundColor = _colors["boardEmptyCellColor"];
                        Console.Write(GetIndent(CellWidth));
                        break;
                    case SquareStatuses.Ship:
                        Console.BackgroundColor = _colors["boardShipCellColor"];
                        Console.Write(GetIndent(CellWidth));
                        break;
                    case SquareStatuses.Hit:
                        Console.BackgroundColor = _colors["boardHitCellColor"];
                        Console.Write(GetIndent(CellWidth));
                        break;
                    case SquareStatuses.Sunk:
                        Console.BackgroundColor = _colors["boardSunkCellColor"];
                        Console.Write(GetIndent(CellWidth));
                        break;
                    case SquareStatuses.Missed:
                        Console.BackgroundColor = _colors["boardSeparatorColor"];
                        Console.ForegroundColor = _colors["cellMissedForegroundColor"];
                        Console.Write(isRowCountNeeded ? "  ███  " : "██   ██");
                        break;
                }
                PrintVerticalSeparator();
            }
            PrintVerticalSeparator(1);
            Console.WriteLine();
        }
        
        private string GetIndent(int multiplier)
        {
            const string indent = " ";
            return string.Concat(Enumerable.Repeat(indent, multiplier));
        }
    }
}