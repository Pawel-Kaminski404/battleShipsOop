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
            (string, string) strategies = gameMode.SetGameMode(display, input);
            var game = new Game(CreatePlayer(strategies.Item1), CreatePlayer(strategies.Item2));
            game.Play();
        }

        private Player CreatePlayer(string strategy)
        {
            switch (strategy)
            {
                case "Player":
                    return new Player(new PlayerShoot());
                case "Easy AI":
                    return new Player(new EasyAIShoot());
                case "Normal AI":
                    return new Player(new NormalAIShoot());
                case "Hard AI":
                    return new Player(new HardAIShoot());
                default:
                    return new Player(new PlayerShoot());
                    break;
            }
        }
    }
}