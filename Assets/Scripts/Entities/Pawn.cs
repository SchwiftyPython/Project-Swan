using GoRogue.GameFramework;

namespace Assets.Scripts.Entities
{
    public class Pawn : GameObject
    {
        public string Name { get; private set; }

        public int Agility { get; private set; }
        public int MovementPerTurn { get; private set; }
        public int Stealth { get; private set; }
        public int Vision { get; private set; }

        public bool IsCaptured { get; private set; }

        public int MovementRemaining { get; private set; }

        //todo stance
        //todo sprite prefab

        public UnityEngine.GameObject SpriteInstance { get; private set; }

        public Pawn(string name, int agility, int movement, int stealth, int vision) : base((-1,-1), 1, null, false, false, true)
        {
            Name = name;
            Agility = agility;
            MovementPerTurn = movement;
            MovementRemaining = MovementPerTurn;
            Stealth = stealth;
            Vision = vision;
            IsCaptured = false;
        }

        public void SetSpriteInstance(UnityEngine.GameObject instance)
        {
            SpriteInstance = instance;
        }

        //todo methods: Movement, CapturePlayer, CaptureFlag, ChangeStance
    }
}
