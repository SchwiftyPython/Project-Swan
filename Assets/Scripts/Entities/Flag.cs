using GoRogue;
using GoRogue.GameFramework;

namespace Assets.Scripts.Entities
{
    public class Flag : GameObject
    {
        public TeamColor Color;

        public Flag(Coord position, TeamColor color) : base(position, 1, null, true, true, true)
        {
            Color = color;
        }
    }
}
