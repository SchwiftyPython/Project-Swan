using Assets.Scripts.GameMap;
using Assets.Scripts.Map;
using GoRogue;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameBoard : MonoBehaviour
    {
        public static GameBoard Instance;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void Build()
        {
            var map = GameManager.Instance.CurrentGameMap;

            for (var currentColumn = 0; currentColumn < map.Width; currentColumn++)
            {
                for (var currentRow = 0; currentRow < map.Height; currentRow++)
                {
                    var cell = map.GetTerrain<Cell>(new Coord(currentColumn, currentRow));

                    var prefab = cell is Floor
                        ? TerrainManager.Instance.TestGrassTile
                        : TerrainManager.Instance.TestWallTile;

                    var instance = Instantiate(prefab, new Vector2(currentColumn, currentRow), Quaternion.identity);

                    instance.transform.SetParent(transform);
                }
            }
        }
    }
}
