using System;
using Battleships.Players;

namespace Battleships.UserInterface
{
    public class Input
    {
        public int SelectMenuOption(Display display, ref int pointer, string playerOne, string playerTwo)
        {
            ConsoleKey key;
            while (true)
            {
                Console.Clear();
                display.PrintMenu(ref pointer, playerOne, playerTwo);
                key = Console.ReadKey().Key;
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

        public Coordinates SelectPosition(Display display, Board board, Cursor cursor)
        {
            ConsoleKeyInfo _Key;
            while (true)
            {
                Console.Clear();
                display.PrintBoard(board, cursor);
                _Key = Console.ReadKey();
                switch (_Key.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (cursor.Position.X + 1 < 10)
                        {
                            cursor.MoveRight();
                        }

                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursor.Position.X - 1 >= 0)
                        {
                            cursor.MoveLeft();
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (cursor.Position.Y - 1 >= 0)
                        {
                            cursor.MoveUp();
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor.Position.Y + 1 < 10)
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