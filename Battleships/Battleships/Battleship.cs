using System;
using Battleships.UserInterface;
using Battleships.Players;

namespace Battleships
{
    public class Battleship
    {
        public void Run()
        {
            Console.CursorVisible = false;
            while (true)
            {
                var display = new Display();
                var input = new Input();
                var gameMode = new GameMode();
                var (player1, player2) = gameMode.SetGameMode(display, input);
                var game = new Game(CreatePlayer(player1, 1), CreatePlayer(player2, 2), display, input);
                game.Play();    
            }
        }

        private Player CreatePlayer(string strategy, int playerNum)
        {
            return strategy switch
            {
                "Player" => new Player(playerNum == 1 ? "Player 1" : "Player 2"),
                "Easy AI" => new Player("Computer", new EasyAiShoot()),
                "Normal AI" => new Player("Computer", new NormalAiShoot()),
                "Hard AI" => new Player("Computer", new HardAiShoot())
            };
        }
    }
}