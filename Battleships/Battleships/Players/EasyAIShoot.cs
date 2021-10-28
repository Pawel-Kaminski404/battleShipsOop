using System;
using System.Collections;
using System.Collections.Generic;

namespace Battleships.Players
{
    public class EasyAiShoot : IShootStrategy
    { 
        private readonly List<Square> _squaresList = new List<Square>();
        public Coordinates GetShotCoordinates(Board board)
        {
            Stack<Square> squaresStack = new Stack<Square>();
            foreach (Square square in board.Ocean)
            {
                _squaresList.Add(square);
            }
            Shuffle(_squaresList);
            foreach (var square in _squaresList)
            {
                squaresStack.Push(square);
            }
            var squareCoordinates = squaresStack.Pop();
            return new Coordinates(squareCoordinates.Position.X, squareCoordinates.Position.Y);
        }
        public static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int num = random.Next(list.Count);
                (list[i], list[num]) = (list[num], list[i]);
            }
            
        }

    }
}