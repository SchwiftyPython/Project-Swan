using System;
using Assets.Scripts.Entities;
using Assets.Scripts.GameMap;
using Assets.Scripts.Map;
using GoRogue;
using GoRogue.MapGeneration;
using GoRogue.MapViews;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Generator : MonoBehaviour
    {
        public static readonly (int, int) BlueTeamFlagRangeX = (4, 25);
        public static readonly (int, int) RedTeamFlagRangeX = (176, 196);

        public static readonly (int, int) BlueTeamPawnRangeX = (1, 95);
        public static readonly (int, int) RedTeamPawnRangeX = (105, 199);

        public void Generate()
        {
            GenerateTerrain();
            PlaceFlags();
            GenerateSimpleTeams();
            PlacePawns();

            //todo remove after prototype
            GameBoard.Instance.Build();
            GameManager.Instance.ActivePlayer = GameManager.Instance.BluePlayer;
            GameManager.Instance.CurrentState = GameManager.GameState.PlayerTurn;
        }

        private void GenerateTerrain()
        {
            var terrainMap = new ArrayMap<bool>(200, 100);
            QuickGenerators.GenerateRectangleMap(terrainMap);

            var map = new GameMap.GameMap(terrainMap.Width, terrainMap.Height);

            foreach (var position in terrainMap.Positions())
            {
                if (IsFloor(terrainMap[position]))
                {
                    map.SetTerrain(new Floor(TerrainManager.Instance.TestGrassTile, position));
                }
                else
                {
                    map.SetTerrain(new Wall(TerrainManager.Instance.TestWallTile, position));
                }
            }

            GameManager.Instance.CurrentGameMap = map;
        }

        private void PlaceFlags()
        {
            var map = GameManager.Instance.CurrentGameMap;

            var blueFlagLocation = new Coord(Random.Range(BlueTeamFlagRangeX.Item1, BlueTeamFlagRangeX.Item2),Random.Range(4, map.Height));

            var blueFlag = new Flag(blueFlagLocation, TeamColor.Blue);

            if (map.AddEntity(blueFlag))
            {
                Debug.Log("Added blue flag to map!");
            }
            else
            {
                Debug.Log("Failed to add blue flag to map!");
            }

            Debug.Log($"Coord: ({blueFlagLocation})");

            var redFlagLocation = new Coord(Random.Range(RedTeamFlagRangeX.Item1, RedTeamFlagRangeX.Item2),Random.Range(4, map.Height));

            var redFlag = new Flag(redFlagLocation, TeamColor.Red);

            if (map.AddEntity(redFlag))
            {
                Debug.Log("Added red flag to map!");
            }
            else
            {
                Debug.Log("Failed to add red flag to map!");
            }

            Debug.Log($"Coord: ({redFlagLocation})");
        }

        private static bool IsFloor(bool cellType)
        {
            return cellType;
        }

        private void GenerateSimpleTeams()
        {
            var blueTeam = TeamStore.Instance.GetStandardTeam(TeamColor.Blue);

            GameManager.Instance.BluePlayer = new Player("Brian", blueTeam);

            var redTeam = TeamStore.Instance.GetStandardTeam(TeamColor.Red);

            GameManager.Instance.RedPlayer = new Player("Kyla", redTeam);
        }

        private void PlacePawns()
        {
            const int maxTries = 3;

            var map = GameManager.Instance.CurrentGameMap;

            foreach (var pawn in GameManager.Instance.BluePlayer.Team.Pawns)
            {
                var placed = false;
                var numTries = 0;
                while (!placed && numTries < maxTries)
                {
                    pawn.Position = new Coord(Random.Range(BlueTeamPawnRangeX.Item1, BlueTeamPawnRangeX.Item2),
                        Random.Range(1, map.Height));

                    placed = map.AddEntity(pawn);

                    numTries++;
                }

                if (placed)
                {
                    Debug.Log($"Blue {pawn.Name} placed at: {pawn.Position}");
                }
                else
                {
                    Debug.Log($"Blue {pawn.Name} failed to place. Last try at: {pawn.Position}");
                }
            }

            foreach (var pawn in GameManager.Instance.RedPlayer.Team.Pawns)
            {
                var placed = false;
                var numTries = 0;
                while (!placed && numTries < maxTries)
                {
                    pawn.Position = new Coord(Random.Range(RedTeamPawnRangeX.Item1, RedTeamPawnRangeX.Item2),
                        Random.Range(1, map.Height));

                    placed = map.AddEntity(pawn);

                    numTries++;
                }

                if (placed)
                {
                    Debug.Log($"Red {pawn.Name} placed at: {pawn.Position}");
                }
                else
                {
                    Debug.Log($"Red {pawn.Name} failed to place. Last try at: {pawn.Position}");
                }
            }
        }
    }
}
