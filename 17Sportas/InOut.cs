using System;
using System.Text;

namespace _17Sportas
{
	public static class InOut
	{
		public static List<Player> ReadPlayers(string fileName)
		{
			List<Player> players = new List<Player>();

			string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

			foreach (string line in lines)
			{
				string[] values = line.Split(';');
				string type = values[0];
				string teamName = values[1];
				string playerName = values[2];
				string playerSurname = values[3];
				DateTime birthday = DateTime.Parse(values[4]);
				int matchesPlayed = int.Parse(values[5]);
				int points = int.Parse(values[6]);

				switch (type)
				{
					case "Krepsinis":
						int recovered = int.Parse(values[7]);
						int passes = int.Parse(values[8]);
						Basketball basketball = new Basketball(teamName, playerName, playerSurname, birthday, matchesPlayed, points, recovered, passes);
						players.Add(basketball);
						break;
					case "Futbolas":
						int yellowCards = int.Parse(values[7]);
						Football football = new Football(teamName, playerName, playerSurname, birthday, matchesPlayed, points, yellowCards);
						players.Add(football);
						break;
					default:
						break;
                }
			}

			return players;
		}

        public static List<Team> ReadTeams(string fileName)
        {
            List<Team> teams = new List<Team>();

            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string teamName = values[0];
                string city = values[1];
                string trainer = values[2];
                int matches = int.Parse(values[3]);

				Team team = new Team(teamName, city, trainer, matches);
				teams.Add(team);
            }

            return teams;
        }

		public static void PrintGoodPlayers(string city, List<Player> players, List<Team> teams)
		{
			List<Player> results = TaskUtils.Selection(city, players, teams);

			for (int i = 0; i < results.Count; i++)
			{
				Console.WriteLine(results[i].PlayerName);
			}
		}
    }
}

