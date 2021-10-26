using System.Collections.Generic;

namespace Battleships.Players
{
    public class Player
    {
        private IShootStrategy iShootStrategy = new PlayerShoot();

        public List<Ship> Ships { get; set; } = new List<Ship>();

        public Player(IShootStrategy strategy)
        {
            iShootStrategy = strategy;
        }

        public void ChangeShootStrategy()
        {
            if (iShootStrategy is PlayerShoot)
            {
                iShootStrategy = new EasyAIShoot();
            }
            else if (iShootStrategy is EasyAIShoot)
            {
                iShootStrategy = new NormalAIShoot();
            }
            else if (iShootStrategy is NormalAIShoot)
            {
                iShootStrategy = new HardAIShoot();
            }
            else if (iShootStrategy is HardAIShoot)
            {
                iShootStrategy = new PlayerShoot();
            }
        }

        public IShootStrategy GetShootStrategy()
        {
            return iShootStrategy;
        }
    }
}