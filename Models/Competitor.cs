namespace SmashTournamentGenerator.Models
{
    public class Competitor
    {
        public int ID { get; set; } //Competitor id
        public Character Character { get; set; }
        public Round? Round { get; set; } //Latest round the competitor reaches
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
            get { return Character.Name; }
        }

        public int PointsDifference
        {
            get { return PointsFor - PointsAgainst; }
        }

        public Competitor(Character character)
        {
            Character = character;
        }

        
    }
}
