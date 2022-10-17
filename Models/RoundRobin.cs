namespace SmashTournamentGenerator.Models
{
    public class RoundRobin : Group
    {

        public bool HomeAway { get; set; }

        public RoundRobin(int Competitors)
        {
            GroupSize = Competitors;
        }

        public override void GenerateSchedule()
        {
            int Rounds = (GroupSize % 2 == 0) ? GroupSize - 1 : GroupSize;
            int TotalMatches = ((int)Math.Pow(GroupSize - 1, 2) + GroupSize) / 2;
            if (HomeAway)
            {
                Rounds *= 2;
                TotalMatches *= 2;
            }
            
            for (int i = 0; i < Rounds; i++)
            {
                Bracket.Add(new Matchday(TotalMatches / Rounds));
            }
        }

        public override void SetRank()
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup() //Function to update ranking in groups
        {
            
        }
    }
}
