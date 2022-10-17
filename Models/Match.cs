namespace SmashTournamentGenerator.Models
{
    public class Match
    {
        public int ID { get; set; }
        public Character? Player1 { get; set; } = null;
        public Character? Player2 { get; set; } = null;
        public int P1Score { get; set; }
        public int P2Score { get; set; }
        public CharacterResult BonusKO { get; set; } = CharacterResult.Neither; //Determines winner if K.O.s are tied and Falls are different
        public CharacterResult SuddenDeath { get; set; } = CharacterResult.Neither; //Determines winner if match goes to sudden death
        public string Stage { get; set; } = "";
        public int MatchdayPosition { get; set; } //Position of match in matchday
        public DateOnly ScheduledDate { get; set; } //When user sets the matct to take place
        public DateTime Timestamp { get; set; } //Set when user submits a score
        public bool IsComplete { get; set; } //set when a match's scores are saved
        public bool IsKnockout { get; set; } //If true, P1Score and P2Score must be different values, or BonusKO or SuddenDeath cannot be 0
        public decimal Odds { get; set; } //Calculated "probability" of P1 winning over P2
        public Match? WinnerGoesTo { get; set; } = null; //Match the winner goes to next; single elimination and double elimination only
        public Match? LoserGoesTo { get; set; } = null; //Match the loser goes to next; single elimination and double elimination only
        public bool WinnerHome { get; set; } //Winner goes to position 1 of the next match if true, 2 if false
        public bool LoserHome { get; set; } //Winner goes to position 1 of the next match if true, 2 if false

        public Match()
        {

        }

        public Character GetWinner()
        {
            if (Player2 is null) return Player1;
            if (P1Score > P2Score) return Player1;
            if (P2Score > P1Score) return Player2;
            if (P1Score == P2Score)
            {
                if (BonusKO == CharacterResult.Player1) return Player1;
                if (BonusKO == CharacterResult.Player2) return Player2;
                if (SuddenDeath == CharacterResult.Player1) return Player1;
                if (SuddenDeath == CharacterResult.Player2) return Player2;
            }
            return null;
        }

        public Character GetLoser()
        {
            if (P1Score < P2Score) return Player1;
            if (P2Score < P1Score) return Player2;
            if (P1Score == P2Score)
            {
                if (BonusKO == CharacterResult.Player1) return Player2;
                if (BonusKO == CharacterResult.Player2) return Player1;
                if (SuddenDeath == CharacterResult.Player1) return Player2;
                if (SuddenDeath == CharacterResult.Player2) return Player1;
            }
            return null;
        }

        public void SetMatch(int Score1, int Score2, CharacterResult BonusKO, CharacterResult SuddenDeath)
        {
            P1Score = Score1;
            P2Score = Score2;
            this.BonusKO = BonusKO;
            this.SuddenDeath = SuddenDeath;

            if (IsKnockout)
            {
                if(WinnerGoesTo is not null)
                {
                    if (WinnerHome) WinnerGoesTo.Player1 = GetWinner();
                    else WinnerGoesTo.Player2 = GetWinner();
                }
                if (LoserGoesTo is not null)
                {
                    if (LoserHome) LoserGoesTo.Player1 = GetWinner();
                    else LoserGoesTo.Player2 = GetWinner();
                }
            }

            IsComplete = true;
        }

    }
    public enum CharacterResult //Used for determining winners based on Bonus KOs or Sudden Death
    {
        Neither,
        Player1,
        Player2
    }
}
