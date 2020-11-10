using UnityEngine;

namespace Assets.Scripts
{
    public class InputController : MonoBehaviour
    {
        public GameObject PrototypePawnSelectorPrefab;

        private GameObject _pawnSelectorInstance;

        public static InputController Instance;

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GameManager.Instance.SelectNextPawn();
            }
        }

        public GameObject GetPawnSelectorInstance()
        {
            if (_pawnSelectorInstance == null)
            {
                _pawnSelectorInstance = Instantiate(PrototypePawnSelectorPrefab, Vector3.zero, Quaternion.identity);
            }

            return _pawnSelectorInstance;
        }
    }
}
