namespace Namo_Butai
{
	public class Butas
	{
		public int Numeris { get; set; }
		public int KambariuSk { get; set; }
		public double Plotas { get; set; }
		public double Kaina { get; set; }
		public string TelefonoNr { get; set; }

		public Butas(int numeris, double plotas, int kambariuSk, double kaina, string telefonoNr)
		{
			this.Numeris = numeris;
			this.Plotas = plotas;
            this.KambariuSk = kambariuSk;
            this.Kaina = kaina;
			this.TelefonoNr = telefonoNr;
		}
	}
}

