using System;
namespace _17Sportas
{
	public class Football : Player
	{
		public int YellowCards { get; set; }

		public Football(string teamName, string playerName, string playerSurname, DateTime birthday,
			int matchesPlayed, int points, int yellowCards) : base(teamName, playerName, playerSurname, birthday, matchesPlayed, points)
		{
			this.YellowCards = yellowCards;
		}
	}
}

