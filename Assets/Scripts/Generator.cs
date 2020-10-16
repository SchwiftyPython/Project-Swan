using System;
using Assets.Scripts.Map;
using GoRogue;
using GoRogue.MapGeneration;
using GoRogue.MapViews;
using UnityEngine;

namespace Assets.Scripts
{
    public class Generator : MonoBehaviour
    {
        private void Start()
        {
            var terrainMap = new ArrayMap<bool>(200, 100);
            QuickGenerators.GenerateRectangleMap(terrainMap);

            var map = new Map.GameMap(terrainMap.Width, terrainMap.Height);

            foreach (var position in terrainMap.Positions())
            {
                if (IsFloor(terrainMap[position]))
                {
                    //todo get floor prefab
                    map.SetTerrain(new Floor(, position));
                }
                else
                {
                    //todo get wall prefab
                    map.SetTerrain(new Wall(, position));
                }
            }
        }

        private static bool IsFloor(bool cellType)
        {
            return cellType;
        }
    }
}
