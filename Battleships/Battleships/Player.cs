using System.Collections.Generic;

namespace Battleships
{
    public class Player 
    {
        public IShootStrategy ShootingStrategy {get;set;}
        public List<Ship> Ships { get; set; }

        public Player(IShootStrategy strategy)
        {
            Ships = new List<Ship>();

            ShootingStrategy = strategy;
        }
  
    }
}