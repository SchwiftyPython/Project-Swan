using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PawnInfoButton : MonoBehaviour
    {
        private Pawn _pawn;

        public void SetPawn(Pawn pawn)
        {
            _pawn = pawn;
        }

        public void OnClick()
        {
            SelectPawn();
        }

        private void SelectPawn()
        {
            GameManager.Instance.SelectPawn(_pawn);
        }

        private void DisplayPawnInfo()
        {
            //todo
        }
    }
}
