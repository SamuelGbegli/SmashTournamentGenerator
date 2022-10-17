namespace SmashTournamentGenerator.Models
{
    public class DoubleElimination : Group
    {
        public List<Matchday> LoserBracket { get; set; } = new List<Matchday>();
        public Final Final { get; set; }

        public DoubleElimination(int Competitors)
        {
            
        }

        public override void GenerateSchedule()
        {
            throw new NotImplementedException();
        }

        public override void SetRank()
        {
            throw new NotImplementedException();
        }
    }

    public enum Final
    {
        OneTwoFinal,
        SingleFinal,
        NoFinal
    }
}
