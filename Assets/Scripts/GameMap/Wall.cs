using GoRogue;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Wall : Cell
    {
        public Wall(GameObject texture, Coord position) : base(texture, position, false, false)
        {
        }
    }
}
