using Battleships.UserInterface;

namespace Battleships.Players
{
    public interface IShootStrategy
    { 
        Coordinates GetShotCoordinates(Board board);
    }
}