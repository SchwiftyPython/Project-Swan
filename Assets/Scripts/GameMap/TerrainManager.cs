using UnityEngine;

namespace Assets.Scripts.GameMap
{
    public class TerrainManager : MonoBehaviour
    {
        public GameObject TestGrassTile;
        public GameObject TestWallTile;

        public static TerrainManager Instance;

        private void Awake()
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
    }
}
