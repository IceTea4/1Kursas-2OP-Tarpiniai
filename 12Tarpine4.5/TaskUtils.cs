using System.Text;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace _4._5
{
	public class TaskUtils
	{
        /** Reads file and adds given surname to the given name.
        @param fin – name of data file
        @param fout – name of result file
        @param punctuation – punctuation marks to separate words
        @param name – word to find
        @param surname – given word to add */
        public static void Process(string fin, string fout, string punctuation,
       string remove)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);

            using (var writer = File.CreateText(fout))
            {
                foreach (string line in lines)
                {
                    string rmv = "\\b" + remove + "\\b" + punctuation;

                    writer.WriteLine(Regex.Replace(line, rmv, ""));
                }
            }
        }
    }
}

