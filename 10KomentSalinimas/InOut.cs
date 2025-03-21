﻿using System.IO;
using System.Text;

namespace KomentSalinimas
{
    public class InOut
    {
        /** Reads, removes comments and prints to two files.
        @param fin – name of data file
        @param fout – name of result file
        @param finfo – name of informative file */
        public static void Process(string fin, string fout, string finfo)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);

            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    bool flag = false;

                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string newLine;

                            flag = TaskUtils.RemovesComments(line, flag, out newLine);

                            if (line.Length > newLine.Length)
                            {
                                writerI.WriteLine(line);
                            }
                            if (newLine.Length > 0)
                            {
                                writerF.WriteLine(newLine);
                            }
                        }
                        else
                        {
                            writerF.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
