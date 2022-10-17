namespace SmashTournamentGenerator.Models
{
    public class GroupCompetitor
    {
        public int ID { get; set; }
        public Competitor Competitor { get; set; } //Competitor in group
        public int Rank { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int WonSD { get; set; } // Wins in sudden death
        public int Drawn { get; set; }
        public int LostSD { get; set; }// Losses in sudden death
        public int Lost { get; set; }
        public int PointsFor { get; set; }
        public int PointsAgainst { get; set; }
        public int Points { get; set; }


        public string Name
        {
            get { return Competitor.Character.Name; }
        }

        public int PointsDifference
        {
            get { return PointsFor - PointsAgainst; }
        }
    }
}
