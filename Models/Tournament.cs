namespace SmashTournamentGenerator.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public bool IsLeague { get; set; } //Determines if tournament is a league
        public List<Competitor> Competitors { get; set; } = new List<Competitor>();//Competitors in a tournament
        public List<(int, Competitor)> Rankings { get; set; } = new List<(int, Competitor)>();//Final tournament rankings
        public Status Status { get; set; }// Tournament status
        public List<Round> Rounds { get; set; } // List of rounds in Tournament
        public List<(int, string)> Tiebreakers { get; set; } = new List<(int, string)>(); //List of match tiebreakers

        public int TotalCompetitors
        {
            get
            {
                int count = 0;
                foreach(var Round in Rounds)
                {
                    count += Round.EnteringRound;
                }
                return count;
            }
        }

        public Tournament()
     {

      }

        public void SetRank()
        {
            //TODO: configure rankings when tournament ends
        }

    }

    

    public enum Status
    {
        AddRounds,
        AddCompetitors,
        InProgress,
        Complete
    }
}
