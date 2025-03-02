using System.Collections.Generic;
using System.Linq;

namespace Namo_Butai
{
	public class ButaiRegister
	{
		private List<Butas> visiButai;

		public ButaiRegister()
		{
			visiButai = new List<Butas>();
		}

		public ButaiRegister(List<Butas> butai)
		{
			visiButai = new List<Butas>();

			foreach (Butas butas in butai)
			{
				this.visiButai.Add(butas);
			}
		}

		public void Add(Butas butas)
		{
			visiButai.Add(butas);
		}

		public int ButaiCount()
		{
			return this.visiButai.Count();
		}

		public Butas KurisButas(int number)
		{
			return visiButai[number];
		}

        public ButaiRegister Atrink(int kiek, int nuo, int iki, int suma)
		{
			ButaiRegister atrinkti = new ButaiRegister();
			int aukstas = 0, x =  0;

			foreach (Butas butas in this.visiButai)
			{
				if (butas.Numeris > 27)
				{
					if (butas.Numeris % 27 == 0)
					{
                        aukstas = butas.Numeris / 3;

                        while (aukstas > 9)
                        {
                            aukstas -= 9;
                        }
                    }
					else
					{
                        aukstas = (butas.Numeris - 27 * (butas.Numeris / 27)) / 3 + 1;
                    }
                }
				else if (butas.Numeris % 3 == 0)
				{
					aukstas = butas.Numeris / 3;
				}
				else
				{
					aukstas = butas.Numeris / 3 + 1;
				}

				if (aukstas > 9)
				{
					aukstas = aukstas - 9 * (aukstas / 9);
				}

                if ((kiek == butas.KambariuSk) && (suma >= butas.Kaina) && (nuo <= aukstas) && (aukstas <= iki))
                {
					atrinkti.Add(butas);
                }
            }
			return atrinkti;
		}
    }
}

