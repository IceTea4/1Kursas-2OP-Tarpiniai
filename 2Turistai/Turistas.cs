using System;

namespace Turistai
{
	public class Turistas
	{
		public string vardas { get; }
		public string pavarde { get; }
		public double pinigai { get; set; }

        public Turistas(string vardas, string pavarde, double pinigai)
        {
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.pinigai = pinigai;
        }
    }
}

