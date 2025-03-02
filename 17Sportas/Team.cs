using System;

namespace _17Sportas
{
	public class Team
	{
		public string TeamName { get; set; }
		public string City { get; set; }
		public string Trainer { get; set; }
		public int Matches { get; set; }

		public Team(string teamName, string city, string trainer, int matches)
		{
			this.TeamName = teamName;
			this.City = city;
			this.Trainer = trainer;
			this.Matches = matches;
		}
	}
}

