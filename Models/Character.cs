using System.Diagnostics.CodeAnalysis;

namespace SmashTournamentGenerator.Models
{
    public class Character
    {
        public int ID { get; private set; } // id to identify character
        public string Name { get; private set; } = ""; // Name of character
        public string Franchise { get; private set; } = ""; // Character franchise
        public int Rank { get; private set; } // Character
        public int Points { get; private set; } // Points used for rankings
        public char LeagueTier { get; private set; }
        public char LeagueRank { get; private set; } // Rank in League

        public Character()
        {

        }

        // Changes rank of character
        public void UpdateRank(int Rank) 
        {
            this.Rank = Rank;
        }

        // Changes character's ranking points
        public void UpdatePoints(int AddPoints)
        {
            Points += AddPoints;
        }

        // Changes league of character
        public void UpdateLeagueTier(char NewLeague)
        {
            LeagueTier = NewLeague;
        }

        // Changes league rank of character
        public void UpdateLeagueRank(char NewLeague)
        {
            LeagueTier = NewLeague;
        }


        //Generates a bye for single and double elimination tournaments
        public static Character Bye()
        {
            return new Character { Name = "Bye" };
        }

    }
}
