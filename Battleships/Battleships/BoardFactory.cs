using System;
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