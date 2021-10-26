using System;
using Battleships.UserInterface;
using Battleships.Players;

namespace Battleships
{
    public class GameMode
    {
        public int _pointer = 0;
        public (string, string) SetGameMode(Display display, Input input)
        {
            string playerOneStrategy = "Player";
            string playerTwoStrategy = "Player";
            int option;
            bool rulesAreSet = false;
            while (!rulesAreSet)
            {
                Console.Clear();
                display.PrintMenu(ref _pointer, playerOneStrategy, playerTwoStrategy);
                option = input.SelectMenuOption(display, ref _pointer, playerOneStrategy, playerTwoStrategy);
                switch (option)
                {
                    case 0:
                        rulesAreSet = true;
                        break;
                    case 1:
                        playerOneStrategy = ChangeShootStrategy(playerOneStrategy);
                        break;
                    case 2:
                        playerTwoStrategy = ChangeShootStrategy(playerTwoStrategy);
                        break;
                    case 3:
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
            return (playerOneStrategy, playerTwoStrategy);
        }

        private string ChangeShootStrategy(string currentStrategy)
        {
            if (currentStrategy == "Player")
            {
                return "Easy AI";
            }
            else if (currentStrategy == "Easy AI")
            {
                return "Normal AI";
            }
            else if (currentStrategy == "Normal AI")
            {
                return "Hard AI";
            }
            else if (currentStrategy == "Hard AI")
            {
                return "Player";
            }
            else
            {
                return "error";
            }
        }
    }
}