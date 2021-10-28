using System;
using System.Collections;
using System.Collections.Generic;

namespace Battleships.Players
{
    public class EasyAiShoot : IShootStrategy
    {
        private readonly Stack<Coordinates> _squaresStack = new Stack<Coordinates>();
        
        public EasyAiShoot()
        {
            List<Coordinates> squaresList = new List<Coordinates>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    squaresList.Add(new Coordinates(i, j));
                }
            }
            Shuffle(squaresList);
            foreach (var coords in squaresList)
            {
                _squaresStack.Push(coords);
            }
        }
        public Coordinates GetShotCoordinates(Board board)
        {
            return _squaresStack.Pop();
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