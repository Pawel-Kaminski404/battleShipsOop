using System;
using Battleships.Players;

namespace Battleships.UserInterface
{
    public class Display
    {
        public void PrintMenu(ref int pointer, string playerOne, string playerTwo)
        {
            Console.WriteLine(" -- BattleShips Schleswig-Holstein Edition-- ");
            Console.WriteLine(pointer == 0 ? "> Start <" : "  Start  ");
            Console.Write(pointer == 1 ? "> Player 1 < " : "  Player 1   ");
            Console.WriteLine(playerOne);
            Console.Write(pointer == 2 ? "> Player 2 < " : "  Player 2   ");
            Console.WriteLine(playerTwo);
            Console.WriteLine(pointer == 3 ? "> Exit <" : "  Exit  ");
        }
    }
}