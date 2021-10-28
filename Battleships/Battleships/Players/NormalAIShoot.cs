using System;
using System.Collections.Generic;

namespace Battleships.Players
{
    public class NormalAiShoot : IShootStrategy
    {
        public Coordinates GetShotCoordinates(Board board)
        {
            var rng = new Random();
            for (int i = 0; i < board.Ocean.GetLength(0); i++)
            {
                for (int j = 0; j < board.Ocean.GetLength(0); j++)
                {
                    if (board.Ocean[j, i].SquareStatus == SquareStatuses.Hit)
                    {
                        List<(int, int)> targets = new();
                        if (j + 1 < 10 && board.Ocean[j + 1, i].SquareStatus != SquareStatuses.Missed)

                        {
                            targets.Add((j + 1, i));
                        }
                        if (i + 1 < 10 && board.Ocean[j, i + 1].SquareStatus != SquareStatuses.Missed)
                        {
                            targets.Add((j, i + 1));
                        }
                        if (j - 1 >= 0 && board.Ocean[j - 1, i].SquareStatus != SquareStatuses.Missed)
                        {
                            targets.Add((j - 1, i));
                        }
                        if (i - 1 >= 0 && board.Ocean[j, i - 1].SquareStatus != SquareStatuses.Missed)
                        {
                            targets.Add((j, i - 1));
                        }
                        if (j + 1 < 10 && board.Ocean[j + 1, i].SquareStatus == SquareStatuses.Hit)
                        {
                            targets.Remove((j, i + 1));
                            targets.Remove((j, i - 1));
                            targets.Remove((j + 1, i));
                        }
                        if (j - 1 >= 0 && board.Ocean[j - 1, i].SquareStatus == SquareStatuses.Hit)
                        {
                            targets.Remove((j, i + 1));
                            targets.Remove((j, i - 1));
                            targets.Remove((j - 1, i));
                        }
                        if (i + 1 < 10 && board.Ocean[j, i + 1].SquareStatus == SquareStatuses.Hit)
                        {
                            targets.Remove((j + 1, i));
                            targets.Remove((j - 1, i));
                            targets.Remove((j, i + 1));
                        }
                        if (i - 1 >= 0 && board.Ocean[j, i - 1].SquareStatus == SquareStatuses.Hit)
                        {
                            targets.Remove((j + 1, i));
                            targets.Remove((j - 1, i));
                            targets.Remove((j, i - 1));
                        }
                        if (targets.Count != 0)
                        {
                            int inx = rng.Next(targets.Count);
                            return new Coordinates(targets[inx].Item1, targets[inx].Item2);
                        }
                    }
                }
            }
            int row;
            int col;
            for (int i = 0; i < 10000; i++)
            {
                row = rng.Next(10);
                col = rng.Next(10);
                if (!(board.Ocean[row, col].SquareStatus == SquareStatuses.Hit ||
                      board.Ocean[row, col].SquareStatus == SquareStatuses.Sunk ||
                      board.Ocean[row, col].SquareStatus == SquareStatuses.Missed))
                {
                    return new Coordinates(row, col);
                }
            }

            //to do
            return new Coordinates(1, 2);
        }
    }
}