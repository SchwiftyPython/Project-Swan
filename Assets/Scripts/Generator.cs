using Assets.Scripts.GameMap;
using Assets.Scripts.Map;
using GoRogue.MapGeneration;
using GoRogue.MapViews;
using UnityEngine;

namespace Assets.Scripts
{
    public class Generator : MonoBehaviour
    {
        private void Start()
        {
            GenerateTerrain();
        }

        private void GenerateTerrain()
        {
            var terrainMap = new ArrayMap<bool>(200, 100);
            QuickGenerators.GenerateRectangleMap(terrainMap);

            var map = new GameMap.GameMap(terrainMap.Width, terrainMap.Height);

            foreach (var position in terrainMap.Positions())
            {
                if (IsFloor(terrainMap[position]))
                {
                    map.SetTerrain(new Floor(TerrainManager.Instance.TestGrassTile, position));
                }
                else
                {
                    map.SetTerrain(new Wall(TerrainManager.Instance.TestWallTile, position));
                }
            }

            GameManager.Instance.CurrentGameMap = map;
        }

        private static bool IsFloor(bool cellType)
        {
            return cellType;
        }
    }
}
