using System;
using Battleships.UserInterface;

namespace Battleships
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            var battleship = new Battleship();
            battleship.Run();
        }
    }
}