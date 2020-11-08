using System;
using System.Linq;
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
        public enum GameState
        {
            Start,
            EnterGameBoard,
            PlayerTurn,
            EndTurn,
            EndGame
        }

        public GameState CurrentState { get; set; }

        public GameMap.GameMap CurrentGameMap;

        public Team BlueTeam;
        public Team RedTeam;

        public Player BluePlayer;
        public Player RedPlayer;

        public Player ActivePlayer;

        public MainCamera MainCamera;

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
            switch (CurrentState)
            {
                case GameState.Start:
                    break;
                case GameState.EnterGameBoard:
                    break;
                case GameState.PlayerTurn:
                    break;
                case GameState.EndTurn:
                    NextPlayerTurn();
                    CurrentState = GameState.PlayerTurn;
                    break;
                case GameState.EndGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void EndTurn()
        {
            CurrentState = GameState.EndTurn;

            Debug.Log($@"{ActivePlayer.Team.Color} Team ends turn!");
        }

        private void NextPlayerTurn()
        {
            ActivePlayer = ActivePlayer == BluePlayer ? RedPlayer : BluePlayer;

            MainCamera.Instance.MovePlayerToPawn(ActivePlayer.Team.Pawns.First());

            Debug.Log($@"{ActivePlayer.Team.Color} Team's turn!");
        }
    }
}
