﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Cursor
    {
        public Coordinates Position { get; set; } = new Coordinates(0, 0);

        public void MoveUp()
        {
            Position.Y--;
        }

        public void MoveDown()
        {
            Position.Y++;
        }

        public void MoveRight()
        {
            Position.X++;
        }

        public void MoveLeft()
        {
            Position.X--;
        }
    }
}