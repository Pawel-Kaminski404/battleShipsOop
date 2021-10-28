﻿using System;
using System.Collections.Generic;
using Battleships.Players;
using Battleships.UserInterface;

namespace Battleships
{
    public class BoardFactory
    {
        public void ManualPlacement(Display display, Input input, Board board, Player player)
        {
            for (int shipSize = 2; shipSize < 7; shipSize++)
            {
                input.PlaceShip(display, board, player, shipSize);
            }
        }

        public void RandomPlacement(Player player, Board board)
        {

            foreach (ShipType element in (ShipType[])Enum.GetValues(typeof(ShipType)))
            {
                int shipSize = Convert.ToInt32(element);
                List<Square> shipSquares = new List<Square>();

                while (true)
                {
                    (int cordX, int cordY, string direction) = GetRandomLocation(board);
                    shipSquares = GetTheShip(cordX, cordY, board, shipSize, direction);
                    if (shipSquares != null)
                    {
                        break;
                    }
                }
                player.Ships.Add(new Ship(shipSize, shipSquares));
            }


        }
        public List<Square> GetTheShip(int cordX, int cordY, Board board, int shipSize, string direction)
        {
            List<Square> shipList = new List<Square>();
            shipList.Add(board.Ocean[cordX, cordY]);

            if (direction == "vertical")
            {
                for (int i = 0; i < shipSize - 1; i++)
                {
                    if (!AreShipsAround(cordX - i, cordY, direction, board, i))
                    {
                        return null;
                    }
                    shipList.Add(board.Ocean[cordX, cordY]);

                }
                return shipList;

            }
            for (int i = 0; i < shipSize - 1; i++)
            {
                if (cordY - i >= 0 && cordY - i < board.Size)
                {
                    if (!AreShipsAround(cordX, cordY + i, direction, board, i))
                    {
                        return null;
                    }

                    shipList.Add(board.Ocean[cordX, cordY]);
                }

            }
            return shipList;

        }


        public bool CheckIfEmpty(int cordX, int cordY, Board board)
        {
            return board.Ocean[cordX, cordY].SquareStatus == SquareStatuses.Empty;
        }



        public (int x, int y, string direction) GetRandomLocation(Board board)
        {
            while (true)
            {
                Random random = new Random();
                int x = random.Next(0, board.Size);
                int y = random.Next(0, board.Size);
                string direction = (x > y) ? "horizontal" : "vertical";
                if (CheckIfEmpty(x, y, board))
                {
                    return (x, y, direction);
                }
            }

        }

        public bool AreCordsOutsideTheMap(int cordX, int cordY, Board board)
        {
            return ((cordX >= board.Size || cordX < 0) || (cordY >= board.Size || cordY < 0)) ? true : false;
        }

        public bool AreShipsAround(int cordX, int cordY, string direction, Board board, int i)
        {
            if (direction == "horizontal")
            {
                if (!AreCordsOutsideTheMap(cordX, cordY, board))
                {
                    if (!CheckIfEmpty(cordX, cordY, board)) /// góra 
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX - 1, cordY, board))
                {
                    if (!CheckIfEmpty(cordX - 1, cordY, board)) /// góra 
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX, cordY - 1, board) && i == 0)
                {
                    if (!CheckIfEmpty(cordX, cordY - 1, board)) // lewa
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX, cordY + 1, board))
                {
                    if (!CheckIfEmpty(cordX, cordY + 1, board)) // prawa
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX + 1, cordY, board))
                {
                    if (!CheckIfEmpty(cordX + 1, cordY, board)) // dół
                        return false;
                }
                return true;
            }
            else
            {
                if (!AreCordsOutsideTheMap(cordX, cordY, board))
                {
                    if (!CheckIfEmpty(cordX, cordY, board))
                        return false;/// góra 
                }
                if (!AreCordsOutsideTheMap(cordX - 1, cordY, board))
                {
                    if (!CheckIfEmpty(cordX - 1, cordY, board)) /// góra 
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX, cordY - 1, board))
                {
                    if (!CheckIfEmpty(cordX, cordY - 1, board)) // lewa
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX, cordY + 1, board))
                {
                    if (!CheckIfEmpty(cordX, cordY + 1, board)) // prawa
                        return false;
                }
                if (!AreCordsOutsideTheMap(cordX + 1, cordY, board) && i == 0)
                {
                    if (!CheckIfEmpty(cordX + 1, cordY, board)) // dół
                        return false;
                }
                return true;

            }

        }
    }
}

public enum ShipType
{
    Carrier = 2,
    Cruiser,
    Battleship,
    Submarine,
    Destroyer
}

