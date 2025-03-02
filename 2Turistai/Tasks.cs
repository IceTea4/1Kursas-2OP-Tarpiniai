using System;
namespace Turistai
{
	public static class Tasks
	{
		public static void SkirimasIslaidoms(List<Turistas> turistas)
		{
			foreach (Turistas narys in turistas)
			{
				narys.pinigai = narys.pinigai / 4;
			}
		}

		public static double SumaVisuIslaidoms(List<Turistas> turistas)
		{
			double suma = 0;

			foreach (Turistas narys in turistas)
			{
				suma += narys.pinigai;
			}

			return suma;
		}

		private static double IeskauDaugiausiosSumos(List<Turistas> turistas)
		{
			double piniguotas = 0;

			foreach (Turistas narys in turistas)
			{
				if (piniguotas < narys.pinigai)
				{
					piniguotas = narys.pinigai;
				}
			}

			return piniguotas;
		}

		public static List<Turistas> RanduTurtingiausiusTuristus(List<Turistas> turistas)
		{
			List<Turistas> turtuolis = new List<Turistas>();
			double piniguotas = IeskauDaugiausiosSumos(turistas);

			foreach (Turistas narys in turistas)
			{
				if (piniguotas == narys.pinigai)
				{
					turtuolis.Add(narys);
				}
			}

			return turtuolis;
		}
	}
}

