using System;

namespace _17Sportas
{
	public class Basketball : Player
	{
		public int Recovered { get; set; }
		public int Passes { get; set; }

		public Basketball(string teamName, string playerName, string playerSurname, DateTime birthday,
			int matchesPlayed, int points, int recovered, int passes) : base(teamName, playerName, playerSurname, birthday, matchesPlayed, points)
		{
			this.Recovered = recovered;
			this.Passes = passes;
		}
	}
}

