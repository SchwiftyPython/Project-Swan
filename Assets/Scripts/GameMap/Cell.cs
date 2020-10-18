using GoRogue;
using GoRogue.GameFramework;

namespace Assets.Scripts.Map
{
    public class Cell : GameObject
    {
        private string _prefabName;
        private UnityEngine.GameObject _prefabTexture;

        public Cell(UnityEngine.GameObject texture, Coord position, bool isWalkable, bool isTransparent) : base(position, 0, null, true,
            isWalkable, isTransparent)
        {
            _prefabTexture = texture;
            _prefabName = texture.name;
        }
    }
}
