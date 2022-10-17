namespace SmashTournamentGenerator.Models
{
    public class Round
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public bool IsComplete { get; set; } // is true if all matches are complete
        public RoundType RoundType { get; set; } //Type of round
        public List<Competitor> Competitors { get; set; } = new List<Competitor>();
        public int TotalCompetitors { get; set; } //Number of competitors in this round
        public int EnteringRound { get; set; } //Number of competitors entering the touramrnt in this round
        public List<Group> Groups { get; set; } = new List<Group>();//Groups in the round
        public int NumberOfGroups { get; set; }
        public List<(int, Competitor)> Rank { get; set; } = new List<(int, Competitor)>();
        public List<(int, Round)> AdvancesTo { get; set; } = new List<(int, Round)>();//List of where highest ranked characters progress to
        public List<(Tournament, Round, int, int)> QualifiesFor { get; set; } = new List<(Tournament, Round, int, int)>();//List of which tournament characters automatically progress to
    
        public Round()
        {

        }
    }

    public enum RoundType
    {
        SingleElimination,
        DoubleElimination,
        RoundRobin
    }
}
