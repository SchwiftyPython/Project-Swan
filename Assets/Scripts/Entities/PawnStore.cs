using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class PawnStore : MonoBehaviour
    {
        public static PawnStore Instance;

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

    }
}
