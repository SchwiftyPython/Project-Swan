using System;
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
        }

        private void NextPlayerTurn()
        {
            ActivePlayer = ActivePlayer == BluePlayer ? RedPlayer : BluePlayer;

            Debug.Log($@"{ActivePlayer.Team.Color} Team's Turn!");
        }
    }
}
