using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Battleships.Players;
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
            Random random = new Random();
            foreach (ShipType element in (ShipType[]) Enum.GetValues(typeof(ShipType)))
            {
                int shipLength = Convert.ToInt32(element);
                string direction;
                List<Square> shipSquares = new List<Square>();
                for (int j = 0; j < shipLength; j++)
                {
                    while (true)
                    {
                        int cordX = random.Next(0, board.Size);
                        int cordY = random.Next(0, board.Size);
                        int z = random.Next(1, 3);
                        if (IsEmpty(cordX, cordY, board))
                        {
                            if (z == 1)
                            {
                                direction = "up";
                            }
                            else
                            {
                                direction = "right";
                            }

                            shipSquares = ValidateCollision(cordX, cordY, board, shipLength, direction);
                            if (shipSquares != null)
                            {
                                break;
                            }
                        }
                    }
                    player.Ships.Add(new Ship(shipLength));
                    
                }
            }
        }
        public bool IsEmpty(int x, int y, Board board)
        {
            return (board.Ocean[x, y].SquareStatus == SquareStatuses.Empty);
        }

        public List<Square> ValidateCollision(int cordX, int cordY, Board board, int shipSize, string direction)
        {
            List<Square> shipList = new List<Square>();
                if (direction == "up")
                {
                    for (int i = 0; i < shipSize - 1; i++)
                    {
                        if (cordX - i >= 0 && cordX - i < board.Size)
                        {
                            if (!IsEmpty(cordX - i, cordY, board)
                                || !CheckIfShipsAround(cordX - i, cordY, board, direction, i))
                            {
                                return null;
                            }

                            shipList.Add(board.Ocean[cordX, cordY]);
                        }
                    }
                    return shipList;
                }

                for (int i = 0; i < shipSize - 1; i++)
                {
                    if (cordY - i >= 0 && cordY - i < board.Size)
                    {
                        if (!IsEmpty(cordX, cordY + i, board)
                            || CheckIfShipsAround(cordX, cordY + i, board, direction, i))
                        {
                            return null;
                        }

                        shipList.Add(board.Ocean[cordX, cordY]);
                    }
                }
                return shipList;
        }

        public bool CheckIfShipsAround(int cordX, int cordY, Board board, string direction, int itemNumber)
        {
            if (direction == "up")
            {
                if (itemNumber == 0)
                {
                    if (!IsEmpty(cordX + 1,cordY, board))
                    {
                        return true;
                    }
                }
                else if (!IsEmpty(cordX, cordY + 1, board)
                         || !IsEmpty(cordX, cordY - 1, board)
                         || !IsEmpty(cordX - 1, cordY, board))
                {
                    return true;
                }

                return false;
            }

            if (itemNumber == 0)
            {
                if (board.Ocean[cordX, cordY - 1].SquareStatus != SquareStatuses.Empty)
                {
                    return true;
                }
            }
            else if (!IsEmpty(cordX + 1, cordY, board)
                     || !IsEmpty(cordX - 1, cordY, board)
                     || !IsEmpty(cordX, cordY + 1, board))
            {
                return true;
            }

            return false;
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
}