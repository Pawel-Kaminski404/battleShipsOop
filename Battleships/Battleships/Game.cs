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
        

        public Game(Player playerOne, Player playerTwo)
        {
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _currentPlayer = _playerOne;
            _enemyPlayer = _playerTwo;
        }

        public void Play(Display display, Input input)
        {
            SetUpGame();
            while (true)
            {
                Round(display, input);
            }
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
                boardFactory.ManualPlacement(board);
            }
            else
            {
                boardFactory.RandomPlacement(player, board);
            }
        }

        private void Round(Display display, Input input)
        {
            bool wasShotSuccessful = false;
            while (!wasShotSuccessful)
            {
                Board enemyBoard = _currentPlayer == _playerOne ? _playerTwoBoard : _playerOneBoard;
                Cursor currentPlayerCursor = _currentPlayer == _playerOne ? _playerOneCursor : _playerTwoCursor;
                var shotCords = GetShotCoordinates(display, input, enemyBoard, currentPlayerCursor);
                wasShotSuccessful = _currentPlayer.TryShooting(shotCords, enemyBoard);    
            }
            SwapPlayers();
        }

        Coordinates GetShotCoordinates(Display display, Input input, Board enemyBoard, Cursor cursor)
        {
            if (_currentPlayer.Name != "Computer")
            {
                return input.SelectPosition(display, enemyBoard, cursor, _currentPlayer, _enemyPlayer);
            }
            return _currentPlayer.GetAiShotCoordinates(enemyBoard);Ga
            
        }
        
        private bool CheckIfGameEnds(Player player)
        {
            return player.Ships.Count == 0;
        }

        public void SwapPlayers()
        {
            (_currentPlayer, _enemyPlayer) = (_enemyPlayer, _currentPlayer);
        }
    }
}