namespace Raides
{
	class Raide
	{
		public char symbol { get; }
		public int count { get; private set; }

		public Raide(char symbol)
		{
			this.symbol = symbol;
			this.count = 0;
		}

		public void Increse()
		{
			count++;
		}
	}
}

