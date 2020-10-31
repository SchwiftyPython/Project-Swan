using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class EntityManager : MonoBehaviour
    {
        public GameObject BlueFlagPrefab;
        public GameObject RedFlagPrefab;

        public GameObject BlueTeamPawnPrefab;
        public GameObject RedTeamPawnPrefab;

        public static EntityManager Instance;

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
    }
}
