using UnityEngine;

namespace Assets.Scripts
{
    public enum TeamColor
    {
        Blue,
        Red
    }

    public class GameManager : MonoBehaviour
    {
        public GameMap.GameMap CurrentGameMap;

        public Team BlueTeam;
        public Team RedTeam;

        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
        
        }
    }
}
