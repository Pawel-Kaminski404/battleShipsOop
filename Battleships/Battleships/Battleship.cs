using System;
using System.Collections.Generic;
using Battleships.UserInterface;
using Battleships.Players;

namespace Battleships
{
    public class Battleship
    {
        private Display display { get; set; } = new Display();

        private Input input { get; set; } = new Input();

        public void Run()
        {
            var gameMode = new GameMode();
            var (player1, player2) = gameMode.SetGameMode(display, input);
            var game = new Game(CreatePlayer(player1), CreatePlayer(player2));
            game.Play(display, input);

            //test ustawiania
            //Cursor cursor = new Cursor();
            //var board = new Board();
            //var player = new Player(new PlayerShoot());
            //while (true)
            //{
            //    for (int i = 2; i < 6; i++)
            //    {
            //        input.PlaceShip(display, board, player, i);

            //    }
            //}
        }

        private Player CreatePlayer(string strategy)
        {
            return strategy switch
            {
                "Player" => new Player(new PlayerShoot()),
                "Easy AI" => new Player(new EasyAIShoot()),
                "Normal AI" => new Player(new NormalAIShoot()),
                "Hard AI" => new Player(new HardAIShoot()),
                _ => new Player(new PlayerShoot())
            };
        }
    }
}