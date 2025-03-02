using System;

namespace _17Sportas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = InOut.ReadPlayers(@"../../../Zaidejai.txt");
            List<Team> teams = InOut.ReadTeams(@"../../../Komandos.txt");

            Console.WriteLine("Pasirinkite miestą:");
            string city = Console.ReadLine();
            Console.WriteLine();

            InOut.PrintGoodPlayers(city, players, teams);
        }
    }
}
