using System;
using Assets.Scripts.Entities;
using Assets.Scripts.GameMap;
using Assets.Scripts.Map;
using GoRogue;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameBoard : MonoBehaviour
    {
        public Transform PawnHolder;

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
                    var coord = new Coord(currentColumn, currentRow);

                    var cell = map.GetTerrain<Cell>(coord);

                    var cellPrefab = cell is Floor
                        ? TerrainManager.Instance.TestGrassTile
                        : TerrainManager.Instance.TestWallTile;

                    var instance = Instantiate(cellPrefab, new Vector2(currentColumn, currentRow), Quaternion.identity);

                    instance.transform.SetParent(transform);

                    var pawn = map.GetEntity<Pawn>(coord);

                    if (pawn != null)
                    {
                        if (GameManager.Instance.BluePlayer.Team.Pawns.Contains(pawn))
                        {
                            instance = Instantiate(EntityManager.Instance.BlueTeamPawnPrefab, new Vector2(currentColumn, currentRow), Quaternion.identity);
                        }
                        else
                        {
                            instance = Instantiate(EntityManager.Instance.RedTeamPawnPrefab, new Vector2(currentColumn, currentRow), Quaternion.identity);
                        }

                        instance.transform.SetParent(PawnHolder);
                    }

                    var flag = map.GetEntity<Flag>(coord);

                    if (flag == null)
                    {
                        continue;
                    }

                    GameObject flagPrefab;

                    switch (flag.Color)
                    {
                        case TeamColor.Blue:
                            flagPrefab = EntityManager.Instance.BlueFlagPrefab;
                            break;
                        case TeamColor.Red:
                            flagPrefab = EntityManager.Instance.RedFlagPrefab;
                            break;
                        default:
                            Debug.Log("Team flag color invalid or missing!");
                            throw new Exception($@"Team flag color invalid or missing! Color: {flag.Color}");
                    }

                    instance = Instantiate(flagPrefab, new Vector2(currentColumn, currentRow), Quaternion.identity);

                    instance.transform.SetParent(transform);
                }
            }
        }
    }
}
