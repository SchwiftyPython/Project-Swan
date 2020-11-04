namespace Assets.Scripts
{
    public class Player 
    {
        public string Name { get; private set; }
        public Team Team { get; private set; }

        public Player(string name, Team team)
        {
            Name = name;
            Team = team;
        }
    }
}