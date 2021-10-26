using Battleships.Players;
using Battleships.UserInterface;

namespace Battleships
{
    public class Game
    {
        private Player PlayerOne { get; set; }

        private Player PlayerTwo { get; set; }

        public Game(Player playerOne, Player playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public void Play(Display display, Input input)
        {
            var board = new Board();
            var cursor = new Cursor();
            //display.PrintBoard(board, cursor);
            input.SelectPosition(display, board, cursor);

        }

        private void PlaceShips(Player player, Board board)
        {
            BoardFactory boardFactory = new BoardFactory();
            if (player.GetShootStrategy() is PlayerShoot)
            {
                boardFactory.ManualPlacement(player, board);
            }
            else
            {
                boardFactory.RandomPlacement(player, board);
            }
        }

        public bool CheckIfGameEnds(Player player)
        {
            return player.Ships.Count == 0;
        }
    }
}