﻿using System;
using System.Collections.Generic;
using Battleships.Players;

namespace Battleships.UserInterface
{
    public class Input
    {
        public int SelectMenuOption(Display display, ref int pointer, string playerOne, string playerTwo)
        {
            while (true)
            {
                display.PrintMenu(ref pointer, playerOne, playerTwo);
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (pointer != 0)
                        {
                            pointer--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer != 3)
                        {
                            pointer++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return pointer;
                }
            }
        }

        public Coordinates SelectPosition(Display display, Board board, Cursor cursor, Player currentPlayer, Player enemyPlayer)
        {
            while (true)
            {
                display.PrintBoard(board, cursor, currentPlayer, enemyPlayer);
                var pressedKey = Console.ReadKey().Key;
                switch (pressedKey)
                {
                    case ConsoleKey.RightArrow:
                        if (cursor.Position.Y + 1 < board.Size)
                        {
                            cursor.MoveRight();
                        }

                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursor.Position.Y - 1 >= 0)
                        {
                            cursor.MoveLeft();
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (cursor.Position.X - 1 >= 0)
                        {
                            cursor.MoveUp();
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor.Position.X + 1 < board.Size)
                        {
                            cursor.MoveDown();
                        }
                        break;
                    case ConsoleKey.Enter:
                        return new Coordinates(cursor.Position.X, cursor.Position.Y);
                }
            }
        }

        public void PlaceShip(Display display, Board board, Player player, int shipSize)
        {
            bool directionHorizontal = true;
            List<Coordinates> cordsList = new List<Coordinates>();
            for (int i = 0; i < shipSize; i++)
            {
                board.Ocean[0, i].SquareStatus = SquareStatuses.Ship;
                cordsList.Add(new Coordinates(i, 0));
            }

            ConsoleKeyInfo _Key;
            bool placementDone = false;
            while (!placementDone)
            {
                foreach (var ship in player.Ships)
                {
                    foreach (var square in ship.OccupiedFields)
                    {
                        board.Ocean[square.Position.Y, square.Position.X].SquareStatus = SquareStatuses.Ship;
                    }
                }

                Console.Clear();
                display.PrintBoard(board, new Cursor());
                _Key = Console.ReadKey();
                bool outOfRange;
                switch (_Key.Key)
                {
                    case ConsoleKey.RightArrow:
                        outOfRange = false;
                        foreach (var item in cordsList)
                        {
                            if (item.X + 1 >= 10)
                            {
                                outOfRange = true;
                            }
                        }
                        if (!outOfRange)
                        {
                            MoveShip(board, cordsList, 1, 0);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        outOfRange = false;
                        foreach (var item in cordsList)
                        {
                            if (item.X - 1 < 0)
                            {
                                outOfRange = true;
                            }
                        }
                        if (!outOfRange)
                        {
                            MoveShip(board, cordsList, -1, 0);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        outOfRange = false;
                        foreach (var item in cordsList)
                        {
                            if (item.Y - 1 < 0)
                            {
                                outOfRange = true;
                            }
                        }
                        if (!outOfRange)
                        {
                            MoveShip(board, cordsList, 0, -1);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        outOfRange = false;
                        foreach (var item in cordsList)
                        {
                            if (item.Y + 1 >= 10)
                            {
                                outOfRange = true;
                            }
                        }
                        if (!outOfRange)
                        {
                            MoveShip(board, cordsList, 0, 1);
                        }
                        break;
                    case ConsoleKey.R:
                        directionHorizontal = TryToRotateShip(board, directionHorizontal, cordsList);
                        break;
                    case ConsoleKey.Enter:
                        placementDone = TryToPlaceShip(board, player, cordsList, placementDone);
                        break;
                }
            }
        }

        private static bool TryToRotateShip(Board board, bool directionHorizontal, List<Coordinates> cordsList)
        {
            List<Coordinates> toAdd2 = new List<Coordinates>();
            List<Coordinates> toRemove2 = new List<Coordinates>();
            int range = cordsList.Count;
            if (directionHorizontal)
            {
                if (cordsList[0].Y + cordsList.Count - 1 < 10)
                {
                    for (int i = 1; i < range; i++)
                    {
                        toRemove2.Add(cordsList[i]);
                        toAdd2.Add(new Coordinates(cordsList[0].X, cordsList[0].Y + i));
                    }
                    foreach (var item in toRemove2)
                    {
                        board.Ocean[item.Y, item.X].SquareStatus = SquareStatuses.Empty;
                        cordsList.Remove(item);
                    }
                    foreach (var item in toAdd2)
                    {
                        board.Ocean[item.Y, item.X].SquareStatus = SquareStatuses.Ship;
                        cordsList.Add(item);
                    }
                    directionHorizontal = !directionHorizontal;
                }
            }
            else
            {
                if (cordsList[0].X + cordsList.Count - 1 < 10)
                {
                    for (int i = 1; i < range; i++)
                    {
                        toRemove2.Add(cordsList[i]);
                        toAdd2.Add(new Coordinates(cordsList[0].X + i, cordsList[0].Y));
                    }
                    foreach (var item in toRemove2)
                    {
                        board.Ocean[item.Y, item.X].SquareStatus = SquareStatuses.Empty;
                        cordsList.Remove(item);
                    }
                    foreach (var item in toAdd2)
                    {
                        board.Ocean[item.Y, item.X].SquareStatus = SquareStatuses.Ship;
                        cordsList.Add(item);
                    }
                    directionHorizontal = !directionHorizontal;
                }
            }

            return directionHorizontal;
        }

        private bool TryToPlaceShip(Board board, Player player, List<Coordinates> cordsList, bool placementDone)
        {
            bool canBePlaced = true;
            foreach (var ship in player.Ships)
            {
                foreach (var square in ship.OccupiedFields)
                {
                    foreach (var cords in cordsList)
                    {
                        if (square.Position.X == cords.X && square.Position.Y == cords.Y)
                        {
                            canBePlaced = false;
                            break;
                        }
                    }
                }
            }
            List<Coordinates> allNeighbours = GetAllNeighbours(cordsList);
            foreach (var neighbour in allNeighbours)
            {
                if (board.Ocean[neighbour.Y, neighbour.X].SquareStatus == SquareStatuses.Ship)
                {
                    canBePlaced = false;
                    break;
                }
            }

            if (canBePlaced)
            {
                var ship = new Ship();
                foreach (var item in cordsList)
                {
                    ship.OccupiedFields.Add(board.Ocean[item.X, item.Y]);
                }
                player.Ships.Add(ship);
                placementDone = true;
            }

            return placementDone;
        }

        private static void MoveShip(Board board, List<Coordinates> cordsList, int deltaX, int deltaY)
        {
            List<Coordinates> toRemove = new List<Coordinates>();
            List<Coordinates> toAdd = new List<Coordinates>();
            foreach (var item in cordsList)
            {
                toAdd.Add(new Coordinates(item.X + deltaX, item.Y + deltaY));
                toRemove.Add(item);
            }
            foreach (var item in toRemove)
            {
                board.Ocean[item.Y, item.X].SquareStatus = SquareStatuses.Empty;
                cordsList.Remove(item);
            }
            foreach (var item in toAdd)
            {
                board.Ocean[item.Y, item.X].SquareStatus = SquareStatuses.Ship;
                cordsList.Add(item);
            }
        }

        private List<Coordinates> GetAllNeighbours(List<Coordinates> cords)
        {
            List<(int, int)> allNeighbours = new List<(int, int)>();
            foreach (var pos in cords)
            {
                if (pos.Y - 1 >= 0)
                {
                    allNeighbours.Add((pos.Y - 1, pos.X));
                }
                if (pos.X - 1 >= 0)
                {
                    allNeighbours.Add((pos.Y, pos.X - 1));
                }
                if (pos.Y + 1 < 10)
                {
                    allNeighbours.Add((pos.Y + 1, pos.X));
                }
                if (pos.X + 1 < 10)
                {
                    allNeighbours.Add((pos.Y, pos.X + 1));
                }
            }
            foreach (var pos in cords)
            {
                allNeighbours.RemoveAll(tup => tup.Item1 == pos.Y && tup.Item2 == pos.X);
            }

            List<Coordinates> output = new List<Coordinates>();
            foreach (var item in allNeighbours)
            {
                output.Add(new Coordinates(item.Item2, item.Item1));
            }

            return output;
        }
    }
}