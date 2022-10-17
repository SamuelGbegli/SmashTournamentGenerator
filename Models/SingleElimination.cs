namespace SmashTournamentGenerator.Models
{
    public class SingleElimination : Group
    {
        public bool IsThirdPlace { get; set; }

        public SingleElimination(int GroupSize, bool ThirdPlaceMatch)
        {
            this.GroupSize = GroupSize;
            IsThirdPlace = ThirdPlaceMatch;
            GenerateSchedule();
        }

       /* Constructor calculates rounds for a single elimination
        * bracket, going backwards
        */
        public override void GenerateSchedule()
        {
            //Part 1: create rounds and populate with matches
            int matches = GroupSize - 1;
            int NumberOfRounds = (int)Math.Ceiling(Math.Log2(matches));
            for (int i = 0; i < NumberOfRounds; i++)
            {
                Matchday Matches = new Matchday((int)Math.Pow(2, i));
                Bracket.Add(Matches);
            }
            //Part 2: connect rounds to each other
            if (Bracket.Count > 1)
            {
                for (int i = 1; i <= Bracket.Count; i++)
                {
                    var PrevRound = Bracket[i];
                    var NextRound = Bracket[i - 1];

                    for (int j = 0; j < PrevRound.Matches.Count; j += 2)
                    {
                        PrevRound.Matches[j].WinnerGoesTo = NextRound.Matches[j / 2];
                        PrevRound.Matches[j].WinnerHome = true;
                        PrevRound.Matches[j + 1].WinnerGoesTo = NextRound.Matches[j / 2];
                    }
                }
            }
            //Part 3: Generate byes
            List<int> Seeds = GetSeeds(GroupSize);
            for (int i = 0; i <= Seeds.Count; i += 2)
            {
                if (Seeds[i + 1] == 0) Bracket.Last().Matches[i / 2].Player2 = Character.Bye();
            }

            //Part 4: add third place match if true
            if (IsThirdPlace)
            {
                Matchday ThirdPlace = new Matchday(1);
                ThirdPlace.Name = "Third place playoff";

                Matchday SemiFinal = Bracket[1];

                SemiFinal.Matches[0].LoserGoesTo = ThirdPlace.Matches[0];
                SemiFinal.Matches[0].LoserHome = true;
                SemiFinal.Matches[1].LoserGoesTo = ThirdPlace.Matches[0];

                Bracket.Add(ThirdPlace);
            }
        }

        public override void SetRank()
        {
            throw new NotImplementedException();
        }

        public List<int> GetSeeds(int Competitors)
        {
            List<int> Seeds = new List<int> { 1 };
            for(int i = 1; i <= Math.Ceiling(Math.Log2(Competitors)); i++)
            {
                List<int> NewSeeds = new List<int>();
                foreach(var item in Seeds)
                {
                    NewSeeds.Add(item);
                    NewSeeds.Add(((int)Math.Pow(2, i) - item + 1) <= Competitors ? (int)Math.Pow(2, i) - item + 1 : 0);
                }
                Seeds = NewSeeds;
            }
            return Seeds;
        }
    }
}
