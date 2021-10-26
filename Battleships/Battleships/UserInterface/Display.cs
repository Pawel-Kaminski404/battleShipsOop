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

        public void PrintBoard(Board board, Cursor cursor)
        {
            for (int i = 0; i < 10; i++)
            {
                //Console.Write(GetIndent(3));
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    if (cursor.Position.Y == i && cursor.Position.X == j)
                    {
                        Console.Write("C");
                    }
                    else
                    {
                        Console.Write(board.Ocean[i, j].GetCharacter());
                    }
                    Console.Write(" | ");
                }

                Console.WriteLine();
            }
        }
    }
}