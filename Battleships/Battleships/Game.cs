using Battleships.Players;
using Battleships.UserInterface;

namespace Battleships
{
    public class Game
    {
        private readonly Player _playerOne;

        private readonly Player _playerTwo;

        private Player _currentPlayer;

        private Player _enemyPlayer;

        private readonly Board _playerOneBoard = new ();

        private readonly Board _playerTwoBoard = new ();

        private Cursor _playerOneCursor = new ();

        private Cursor _playerTwoCursor = new ();

        private readonly Display _display;

        private readonly Input _input;
        

        public Game(Player playerOne, Player playerTwo, Display display, Input input)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _currentPlayer = _playerOne;
            _enemyPlayer = _playerTwo;
            _display = display;
            _input = input;
        }

        public void Play()
        {
            SetUpGame();
            while (true)
            {
                var roundResult = Round();
                if (roundResult == RoundResults.GameOver)
                {
                    break;
                }
                SwapPlayers();
            }

            _display.PrintGameResult(_currentPlayer);
        }

        private void SetUpGame()
        {
            PlaceShips(_playerOne, _playerOneBoard);
            PlaceShips(_playerTwo, _playerTwoBoard);
        }
        private void PlaceShips(Player player, Board board)
        {
            BoardFactory boardFactory = new BoardFactory();
            if (player.GetAiShootStrategy() is null)
            {
                boardFactory.ManualPlacement(_display, _input, board, player);
            }
            else
            {
                boardFactory.RandomPlacement(player, board);
            }
        }

        private RoundResults Round()
        {
            bool wasShotSuccessful = false;
            while (!wasShotSuccessful)
            {
                Board enemyBoard = _currentPlayer == _playerOne ? _playerTwoBoard : _playerOneBoard;
                Cursor currentPlayerCursor = _currentPlayer == _playerOne ? _playerOneCursor : _playerTwoCursor;
                var shotCords = GetShotCoordinates(enemyBoard, currentPlayerCursor);
                wasShotSuccessful = _currentPlayer.TryShooting(shotCords, enemyBoard, _enemyPlayer);
                if (CheckIfGameEnds(_enemyPlayer))
                {
                    return RoundResults.GameOver;
                }
            }

            return RoundResults.GameNotOver;
        }

        Coordinates GetShotCoordinates(Board enemyBoard, Cursor cursor)
        {
            if (_currentPlayer.Name != "Computer")
            {
                return _input.SelectPosition(_display, enemyBoard, cursor, _currentPlayer, _enemyPlayer);
            }
            return _currentPlayer.GetAiShotCoordinates(enemyBoard);
            
        }
        
        private bool CheckIfGameEnds(Player player)
        {
            return player.Ships.Count == 0;
        }

        private void SwapPlayers()
        {
            (_currentPlayer, _enemyPlayer) = (_enemyPlayer, _currentPlayer);
        }
    }

    enum RoundResults
    {
        GameOver,
        GameNotOver
    }
}