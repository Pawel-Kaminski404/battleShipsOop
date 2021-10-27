using System;
using Battleships.Players;

namespace Battleships.UserInterface
{
    public class Input
    {
        public int SelectMenuOption(Display display, ref int pointer, string playerOne, string playerTwo)
        {
            while (true)
            {
                display.PrintMenu(ref pointer, playerOne, playerTwo);
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (pointer != 0)
                        {
                            pointer--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer != 3)
                        {
                            pointer++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return pointer;
                }
            }
        }

        public Coordinates SelectPosition(Display display, Board board, Cursor cursor, Player currentPlayer, Player enemyPlayer)
        {
            while (true)
            {
                display.PrintBoard(board, cursor, currentPlayer, enemyPlayer);
                var pressedKey = Console.ReadKey().Key;
                switch (pressedKey)
                {
                    case ConsoleKey.RightArrow:
                        if (cursor.Position.Y + 1 < board.Size)
                        {
                            cursor.MoveRight();
                        }
                        
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursor.Position.Y - 1 >= 0)
                        {
                            cursor.MoveLeft();
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (cursor.Position.X - 1 >= 0)
                        {
                            cursor.MoveUp();
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor.Position.X + 1 < board.Size)
                        {
                            cursor.MoveDown();
                        }
                        break;
                    case ConsoleKey.Enter:
                        return new Coordinates(cursor.Position.X, cursor.Position.Y);
                }
            }
        }
    }
}