using System;
using System.Text;

namespace Salinimas
{
	public class InOut
	{
        /** Finds the ordinal number of the longest line.
         * @param fin – name of data file
         * returns the ordinal number of the longest line*/
        public static int LongestLine(string fin)
        {
            int length = 0;

            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > length)
                    {
                        length = line.Length;
                    }

                    lineNo++;
                }
            }

            return length;
        }

        /** Removes the line of the given ordinal number.
         * @param fin – name of data file
         * @param fout – name of result file
         * @param No – the ordinal number of the longest line */
        public static void RemoveLine(string fin, string fout, int length)
        {
            Console.Write("Ilgiausios eilutes nr.: ");

            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;
                int x = 0;

                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (length != line.Length)
                        {
                            writer.WriteLine(line);
                        }
                        else
                        {
                            Console.Write(lineNo + 1);
                            x++;
                        }

                        lineNo++;
                    }
                }

                if (x == 0)
                {
                    Console.Write("Nera tokiu eiluciu");
                }
            }
        }
    }
}

