using System;

namespace _17Sportas
{
	public abstract class Player
	{
		public string TeamName { get; set; }
		public string PlayerName { get; set; }
		public string PlayerSurname { get; set; }
		public DateTime Birthday { get; set; }
		public int MatchesPlayed { get; set; }
		public int Points { get; set; }

		public Player(string teamName, string playerName, string playerSurname, DateTime birthday, int matchesPlayed, int points)
		{
			this.TeamName = teamName;
			this.PlayerName = playerName;
			this.PlayerSurname = playerSurname;
			this.Birthday = birthday;
			this.MatchesPlayed = matchesPlayed;
			this.Points = points;
		}
	}
}

