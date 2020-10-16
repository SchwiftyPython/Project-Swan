using GoRogue;

namespace Assets.Scripts.GameMap
{
    public class GameMap : GoRogue.GameFramework.Map
    {
        public GameMap(int width, int height) : base(width, height, 1, Distance.CHEBYSHEV, 4294967295, 4294967295, 0)
        {
        }
    }
}
