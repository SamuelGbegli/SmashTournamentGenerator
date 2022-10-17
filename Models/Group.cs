namespace SmashTournamentGenerator.Models
{
    public abstract class Group
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public bool IsComplete { get; set; } // true if all matches are completed
        public int GroupSize { get; set; } // number of competitors in the group
        public List<(GroupCompetitor, int)> Competitors { get; set; } = new List<(GroupCompetitor, int)>(); //Competitors in the group with group position
        public List<(int, Competitor)> Rank { get; set; } = new List<(int, Competitor)>();
        public List<Matchday> Bracket { get; set; } = new List<Matchday>(); //List of matches, grouped into stages

        public abstract void GenerateSchedule();

        public abstract void SetRank();
    }
}
