using Assets.Scripts.Entities;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Team
    {
        private const int MaxTeamSize = 8;

        public TeamColor Color { get; private set; }
        public List<Pawn> Pawns { get; private set; }

        //todo need player property

        public Team(TeamColor color)
        {
            Color = color;
            Pawns = new List<Pawn>();
        }

        public Team(TeamColor color, List<Pawn> pawns)
        {
            Color = color;
            Pawns = pawns;
        }

        public void AddPawn(Pawn newPawn)
        {
            if (Pawns == null || Pawns.Count >= MaxTeamSize)
            {
                return;
            }

            Pawns.Add(newPawn);
        }

        public void RemovePawn(Pawn pawn)
        {
            Pawns?.Remove(pawn);
        }
    }
}
