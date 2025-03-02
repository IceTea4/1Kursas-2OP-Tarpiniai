using System;

namespace _17Sportas
{
	public static class TaskUtils
	{
		public static List<Player> Selection(string city, List<Player> players, List<Team> teams)
		{
			List<Team> teamsByCity = TeamsByCity(city, teams);
            List<Player> selectedPlayers = PlayersSelection(teamsByCity, players);
            List<Player> result = new List<Player>();

            for (int i = 0; i < selectedPlayers.Count; i++)
            {
                for (int j = 0; j < teamsByCity.Count; j++)
                {
                    if (selectedPlayers[i].MatchesPlayed == teamsByCity[j].Matches && selectedPlayers[i].TeamName == teamsByCity[j].TeamName && selectedPlayers[i].Points >= Average(selectedPlayers, i))
                    {
                        result.Add(selectedPlayers[i]);
                    }
                }
            }

            return result;
        }

        private static List<Team> TeamsByCity(string city, List<Team> teams)
		{
            List<Team> teamsByCity = new List<Team>();

            for (int i = 0; i < teams.Count; i++)
            {
                if (city == teams[i].City)
                {
					teamsByCity.Add(teams[i]);
                }
            }

			return teamsByCity;
        }

        private static List<Player> PlayersSelection(List<Team> teams, List<Player> players)
		{
            List<Player> selectedPlayers = new List<Player>();

            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < teams.Count; j++)
                {
                    if (players[i].TeamName == teams[j].TeamName)
                    {
                        selectedPlayers.Add(players[i]);
                        break;
                    }
                }
            }

            return selectedPlayers;
        }

		private static float Average(List<Player> players, int x)
		{
			float result = 0;
            Player player = players[x];
            int i = 0;
            int sum = 0;

            while (i < players.Count)
            {
                if (players[i].TeamName == player.TeamName)
                {
                    sum += players[i].Points;
                    result++;
                }

                i++;
            }

            result = sum / result;

            return result;
		}
	}
}

