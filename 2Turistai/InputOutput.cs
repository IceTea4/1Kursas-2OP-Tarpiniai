using System;
using System.IO;
using System.Text;

namespace Turistai
{
	public static class InputOutput
	{
		public static List<Turistas> NuskaitykTuristus(string fileName)
		{
			List<Turistas> turistas = new List<Turistas>();
			string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

			foreach (string line in lines)
			{
				turistas.Add(NuskaitykTurista(line));
			}

			return turistas;
		}

		private static Turistas NuskaitykTurista(string line)
		{
            string[] value = line.Split(';');
            string vardas = value[0];
            string pavarde = value[1];
            double pinigai = double.Parse(value[2]);

            return new Turistas(vardas, pavarde, pinigai);
        }

		public static void SpausdinkTuristus(List<Turistas> turistas)
		{
			foreach (Turistas member in turistas)
			{
				Console.WriteLine("Vardas: {0,-10}; Pavarde: {1,-15}; Pinigai islaidoms: {2}", member.vardas, member.pavarde, member.pinigai);
			}
		}

		public static void SpausdinkTurtingus(List<Turistas> turistas)
		{
			List<Turistas> turtuolis = Tasks.RanduTurtingiausiusTuristus(turistas);
			Console.WriteLine("Daugiausiai pinigų skyrė išlaidoms:");
			SpausdinkTuristus(turtuolis);
		}

		public static void SpausdinkBendrasIslaidas(List<Turistas> turistas)
		{
            Console.WriteLine("Iš viso bendros grupės išlaidoms bus surinkta: {0}", Tasks.SumaVisuIslaidoms(turistas));
        }

		public static void SpausdinkTuristusCSVFaile(string fileName, List<Turistas> turistas)
		{
			string[] lines = new string[turistas.Count + 1];
			lines[0] = String.Format("{0};{1}", "Suma: ", Tasks.SumaVisuIslaidoms(turistas));
            List<Turistas> turtuolis = Tasks.RanduTurtingiausiusTuristus(turistas);

            for (int i = 0; i < turtuolis.Count; i++)
			{
				lines[i + 1] = String.Format("{0};{1};{2}", turtuolis[i].vardas, turtuolis[i].pavarde, turtuolis[i].pinigai);
			}
			File.WriteAllLines(fileName, lines, Encoding.UTF8);

		}
    }
}

