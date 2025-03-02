using System.IO;
using System;

namespace Raides
{
	static class InOut
	{
        /** Inputs from the given data file and counts repetition of letters.
         @param fin – name of data file
         @param letters – object having letters and their repetitions*/

        public static List<Raide> ReadRepetitions(string fin, List<Raide> raides)
        {
            using (StreamReader reader = new StreamReader(fin))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    foreach (char s in line)
                    {
                        Raide r = raides.Find(x => x.symbol == s);

                        if (r == null)
                        {
                            continue;
                        }

                        r.Increse();
                    }
                }

                return raides;
            }
        }

        /** Prints repetition of letters using two columns into a given file.
         * @param fout – name of the file for the output
         * @param letters – object having letters and their repetitions */

        public static void PrintRepetitions(string fout, List<Raide> letters)
        {
            using (var writer = File.CreateText(fout))
            {
                foreach (Raide raide in letters)
                {
                    writer.WriteLine("{0, 3:c} {1, 4:d}", raide.symbol, raide.count);
                    Console.WriteLine("{0, 3:c} {1, 4:d}", raide.symbol, raide.count);
                }

                if (letters[0].count == 0)
                {
                    writer.WriteLine("Nera raidziu");
                    Console.WriteLine("Nera raidziu");
                }
                else
                {
                    writer.WriteLine($"Dazniausiai naudojama raide: {letters[0].symbol}");
                    Console.WriteLine($"Dazniausiai naudojama raide: {letters[0].symbol}");
                }
            }
        }
    }
}

