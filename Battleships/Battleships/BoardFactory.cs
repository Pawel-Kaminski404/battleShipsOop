﻿using Battleships.Players;

namespace Battleships
{
    public class BoardFactory
    {


        public void ManualPlacement(Player player, Board board)
        {
            //Not implemented
        }

        public void RandomPlacement(Player player, Board board)
        {
            //Not implemented
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