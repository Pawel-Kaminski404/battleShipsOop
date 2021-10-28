using System;
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
                //wyjebać jak naprawicie
                boardFactory.ManualPlacement(_display, _input, board, player);
                // odkomentować jak naprawicie
                //boardFactory.RandomPlacement(player, board);
            }
        }

        private RoundResults Round()
        {
            RoundResults shotResult = RoundResults.WrongShot;
            while (true)
            {
                Board enemyBoard = _currentPlayer == _playerOne ? _playerTwoBoard : _playerOneBoard;
                Cursor currentPlayerCursor = _currentPlayer == _playerOne ? _playerOneCursor : _playerTwoCursor;
                var shotCords = GetShotCoordinates(enemyBoard, currentPlayerCursor, shotResult);
                shotResult = _currentPlayer.TryShooting(shotCords, enemyBoard, _enemyPlayer);
                if (shotResult == RoundResults.ShipMissed)
                {
                    _display.PrintBoard(enemyBoard, _currentPlayer, enemyPlayer: _enemyPlayer, shotResult:shotResult);
                    Console.ReadKey();
                    break;
                }
                if (CheckIfGameEnds(_enemyPlayer))
                {
                    return RoundResults.GameOver;
                }
                if (!(_currentPlayer.GetAiShootStrategy() == null))
                {
                    _display.PrintBoard(enemyBoard, _currentPlayer);
                    System.Console.ReadKey();
                    break;
                }
            }
            return RoundResults.GameNotOver;
        }

        Coordinates GetShotCoordinates(Board enemyBoard, Cursor cursor, RoundResults shotResult)
        {
            if (_currentPlayer.Name != "Computer")
            {
                return _input.SelectPosition(_display, enemyBoard, cursor, _currentPlayer, _enemyPlayer, shotResult);
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

    public enum RoundResults
    {
        GameOver,
        GameNotOver,
        ShipMissed,
        ShipHit,
        ShipSunk,
        WrongShot
    }
}