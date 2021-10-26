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
    }
}