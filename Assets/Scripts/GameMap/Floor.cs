using GoRogue;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Floor : Cell
    {
        public Floor(GameObject texture, Coord position) : base(
            texture, position, true, true)
        {
        }
    }
}
