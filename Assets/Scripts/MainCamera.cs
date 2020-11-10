using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainCamera : MonoBehaviour
    {
        public static MainCamera Instance;

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

        public void MovePlayerToPawn(Pawn target)
        {
            transform.localPosition = new Vector3(target.SpriteInstance.transform.position.x, target.SpriteInstance.transform.position.y, -10);
        }
    }
}
