using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Players;

namespace Battleships.UserInterface
{
    public class Display
    {
        public void PrintMenu(ref int pointer, string playerOne, string playerTwo)
        {
            Console.Clear();
            Console.WriteLine(" -- BattleShips Schleswig-Holstein Edition-- ");
            Console.WriteLine(pointer == 0 ? "> Start <" : "  Start  ");
            Console.Write(pointer == 1 ? "> Player 1 < " : "  Player 1   ");
            Console.WriteLine(playerOne);
            Console.Write(pointer == 2 ? "> Player 2 < " : "  Player 2   ");
            Console.WriteLine(playerTwo);
            Console.WriteLine(pointer == 3 ? "> Exit <" : "  Exit  ");
        }

        private readonly Dictionary<string, ConsoleColor> _colors = new()
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

        public void PrintBoard(Board board, Player currentPlayer, Cursor cursor = null, Player enemyPlayer = null)
        {
            Console.Clear();
            Console.WriteLine();
            PrintBoardHeader(board.Size);
            for (int row = 0; row < board.Size; row++)
            {
                PrintGameBoardRow(board, row, cursor, false, 1, currentPlayer, enemyPlayer);
                PrintGameBoardRow(board, row, cursor, true, 2, currentPlayer, enemyPlayer);
                PrintGameBoardRow(board, row, cursor, false, 3, currentPlayer, enemyPlayer);
                PrintHorizontalSeparator();
            }
            PrintHorizontalSeparator();
        }

        private void PrintBoardHeader(int boardSize)
        {
            PrintHorizontalSeparator();
            Console.Write(GetIndent(CellWidth + 1));
            PrintVerticalSeparator();
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.ForegroundColor = _colors["borderForegroundColor"];
            for (int i = 0; i < boardSize; i++)
            {
                char letter = (char) ('A' + i);
                Console.Write(GetIndent(5));
                Console.Write(letter);
                Console.Write(GetIndent(3));
            }

            PrintVerticalSeparator(4);
            Console.WriteLine();


        }

        private void PrintHorizontalSeparator()
        {
            const int boardWidth = 96;
            Console.Write(GetIndent(CellWidth + 1));
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.Write(GetIndent(boardWidth));
            Console.BackgroundColor = _colors["mainBackgroundColor"];
            Console.WriteLine();
        }

        private void PrintVerticalSeparator(int multiplier = 2)
        {
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.Write(GetIndent(multiplier));
            Console.BackgroundColor = _colors["mainBackgroundColor"];
        }

        private void PrintGameBoardRow(Board board, int row, Cursor cursor, bool isRowCountNeeded, int printRowNum, Player currentPlayer, Player enemyPlayer)
        {
            Console.Write(GetIndent(CellWidth + 1));
            Console.BackgroundColor = _colors["boardSeparatorColor"];
            Console.ForegroundColor = _colors["borderForegroundColor"];
            if (isRowCountNeeded)
            {
                string rowCountString = row < board.Size-1 ? $"  {row + 1} " : $" {row + 1} ";
                Console.Write(rowCountString);    
            }
            else
            {
                Console.Write(GetIndent(4));
            }
            for (int col = 0; col < board.Size; col++)
            {
                Console.ForegroundColor = _colors["cellMainForegroundColor"];
                var square = board.Ocean[row, col];
                var squareStatus = square.SquareStatus;
                if (cursor is not null)
                {
                    squareStatus = square.Position.X == cursor.Position.X && square.Position.Y == cursor.Position.Y ? SquareStatuses.Cursor : square.SquareStatus;    
                }
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
                        if (enemyPlayer is null)
                        {
                            Console.BackgroundColor = _colors["boardShipCellColor"];    
                        }
                        else
                        {
                            Console.BackgroundColor = _colors["boardEmptyCellColor"];
                        }
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
            PrintVerticalSeparator();
            if (row is 3 or 4 or 5)
            {
                PrintGameInfo(row, printRowNum, currentPlayer, enemyPlayer);
            }
            Console.WriteLine();
        }

        private void PrintGameInfo(int row, int printRowNum, Player currentPlayer, Player enemyPlayer)
        {
            Console.Write(GetIndent(20));
            Console.ForegroundColor = ConsoleColor.White;
            Dictionary<ShipTypes, int> currentPlayerShipCount = currentPlayer.GetShipCount();
            Dictionary<ShipTypes, int> enemyPlayerShipCount = new();
            if (enemyPlayer is not null)
            {
                enemyPlayerShipCount = enemyPlayer.GetShipCount();
            }
            switch (row, printRowNum)
            {
                case (3, 2):
                    Console.Write($"{currentPlayer.Name} turn");
                    break;
                case (4, 1):
                    Console.Write("Your ships:");
                    break;
                case (4, 2):
                    Console.Write($"Carrier: {currentPlayerShipCount[ShipTypes.Carrier]}  Cruiser: {currentPlayerShipCount[ShipTypes.Cruiser]}  Battleship: {currentPlayerShipCount[ShipTypes.Battleship]}");
                    break;
                case (4, 3):
                    Console.Write($"Submarine: {currentPlayerShipCount[ShipTypes.Submarine]}  Destroyer: {currentPlayerShipCount[ShipTypes.Destroyer]}");
                    break;
                case (5, 1):
                    if (enemyPlayer is not null)
                    {
                        Console.Write($"{enemyPlayer.Name} left ships:");
                    }
                    break;
                case (5, 2):
                    if (enemyPlayer is not null)
                    {
                        Console.Write(
                            $"Carrier: {enemyPlayerShipCount[ShipTypes.Carrier]}  Cruiser: {enemyPlayerShipCount[ShipTypes.Cruiser]}  Battleship: {enemyPlayerShipCount[ShipTypes.Battleship]}");
                    }
                    break;
                case (5, 3):
                    if (enemyPlayer is not null)
                    {
                        Console.Write(
                            $"Submarine: {enemyPlayerShipCount[ShipTypes.Submarine]}  Destroyer: {enemyPlayerShipCount[ShipTypes.Destroyer]}");
                    }
                    else
                    {
                        Console.Write("Press R to rotate ship");
                    }
                    break;
            }
        }

        private string GetIndent(int multiplier)
        {
            const string indent = " ";
            return string.Concat(Enumerable.Repeat(indent, multiplier));
        }
    }
}