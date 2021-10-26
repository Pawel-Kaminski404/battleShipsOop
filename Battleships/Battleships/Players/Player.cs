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
            switch (iShootStrategy)
            {
                case PlayerShoot:
                    iShootStrategy = new EasyAIShoot();
                    break;
                case EasyAIShoot:
                    iShootStrategy = new NormalAIShoot();
                    break;
                case NormalAIShoot:
                    iShootStrategy = new HardAIShoot();
                    break;
                case HardAIShoot:
                    iShootStrategy = new PlayerShoot();
                    break;
            }
        }

        public IShootStrategy GetShootStrategy()
        {
            return iShootStrategy;
        }
    }
}