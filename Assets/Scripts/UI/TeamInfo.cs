using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TeamInfo : MonoBehaviour
    {
        private const int MaxPerRow = 4;

        private List<GameObject> _pawnInfos;

        public GameObject PawnInfoPrefab;

        public Transform TopRow;
        public Transform BottomRow;

        private void Start()
        {
            //todo enable once we get scenes broken out
            //Populate();
        }

        public void Populate()
        {
            //todo clear current pawn Info objects

            _pawnInfos = new List<GameObject>();

            var currentPawns = GameManager.Instance.ActivePlayer.Team.Pawns;

            foreach (var pawn in currentPawns)
            {
                var pawnInfo = Instantiate(PawnInfoPrefab, new Vector3(0, 0), Quaternion.identity);

                _pawnInfos.Add(pawnInfo);

                if (_pawnInfos.Count <= MaxPerRow)
                {
                    pawnInfo.transform.SetParent(TopRow);
                }
                else
                {
                    pawnInfo.transform.SetParent(BottomRow);
                }

                //todo set sprite image on button

                //todo set sprite info on button

                var movementPointLabel = pawnInfo.GetComponentInChildren<TextMeshProUGUI>();

                movementPointLabel.text = pawn.MovementPerTurn.ToString();
            }
        }
    
    }
}
