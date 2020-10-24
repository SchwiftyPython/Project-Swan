using System.Collections.Generic;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts
{
    public class TeamStore : MonoBehaviour
    {
        private readonly List<Pawn> _standardTeam = new List<Pawn>
        {
            new Pawn("Tara", 18, 18, 18, 18),
            new Pawn("Rosio", 18, 10, 18, 18),
            new Pawn("Manda", 10, 10, 10, 10),
            new Pawn("Tommie", 1, 1, 1, 1),
            new Pawn("Alex", 18, 9, 1, 9),
            new Pawn("Wesley", 1, 8, 18, 8),
            new Pawn("David", 18, 18, 17, 17),
            new Pawn("Angeline", 17, 18, 17, 16)
        };

        public static TeamStore Instance;

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

        public Team GetStandardTeam(TeamColor color)
        {
            return new Team(color, _standardTeam);
        }

    }
}
