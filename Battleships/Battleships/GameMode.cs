﻿using System;
using Battleships.UserInterface;

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
                        display.PrintInstructions();
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                }
            }
            return (playerOneStrategy, playerTwoStrategy);
        }

        private string ChangeShootStrategy(string currentStrategy)
        {
            return currentStrategy switch
            {
                "Player" => "Easy AI",
                "Easy AI" => "Normal AI",
                "Normal AI" => "Hard AI",
                "Hard AI" => "Player",
                _ => "error"
            };
        }
    }
}