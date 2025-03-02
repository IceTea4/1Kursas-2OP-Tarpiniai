using System.Text;
using System;
using System.IO;

namespace Namo_Butai
{
	public static class InOutUtils
	{
		public static ButaiRegister ReadButai(string fileName)
		{
            ButaiRegister butai = new ButaiRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int numeris = int.Parse(Values[0]);
                double plotas = double.Parse(Values[1]);
                int kambariuSk = int.Parse(Values[2]);
                double kaina = double.Parse(Values[3]);
                string telefonoNr = Values[4];

                Butas butas = new Butas(numeris, plotas, kambariuSk, kaina, telefonoNr);

                butai.Add(butas);
            }

            return butai;
        }

        public static void PrintButai(ButaiRegister butai)
        {
            if (butai.ButaiCount() == 0)
            {
                Console.WriteLine("Neturime buto atitinkančio jūsų pasirinkimus");
            }
            else
            {
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("| {0,8} | {1,6} | {2,12} | {3,6} | {4,12} |",
               "Buto Nr.", "Plotas", "Kambarių Sk.", "Kaina", "Tlf.Nr.");
                Console.WriteLine(new string('-', 60));
                for (int i = 0; i < butai.ButaiCount(); i++)
                {
                    Butas butas = butai.KurisButas(i);
                    Console.WriteLine("| {0,8} | {1,6} | {2,12} | {3,6} | {4,12} |", butas.Numeris, butas.Plotas, butas.KambariuSk, butas.Kaina, butas.TelefonoNr);
                }
                Console.WriteLine(new string('-', 60));
            }
        }
    }
}

