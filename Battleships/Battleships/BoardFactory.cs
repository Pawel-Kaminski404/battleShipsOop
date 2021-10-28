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