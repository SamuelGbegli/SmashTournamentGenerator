namespace SmashTournamentGenerator.Models
{
    public class Matchday
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public List<Match> Matches { get; set; } = new List<Match>(); //List of matches in the matchday

        public Matchday()
        {

        }

        public Matchday(int matches)
        {
            for (int i = 0; i < matches; i++) Matches.Add(new Match());
        }

        public Matchday(int matches, bool isKnockout)
        {
            for (int i = 0; i < matches; i++) Matches.Add(new Match { IsKnockout = isKnockout});
        }
    }
}
