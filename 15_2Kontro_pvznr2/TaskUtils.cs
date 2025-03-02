using System.Text;
using System.Text.RegularExpressions;

namespace _2Kontro_pvznr2
{
	public class TaskUtils
	{
		public static bool UppercaseLettersOnly(string line)
		{
			string tempLine = line.ToUpper();

			if (tempLine == line)
			{
				return true;
			}

			return false;
		}

		public static int NumberOfUppercaseLetters(string line)
		{
			int count = 0;
			string tempLine = line.ToUpper();

			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] == tempLine[i])
				{
					count++;
				}
			}

			return count;
		}

		public static string FindWord1InLine(string line, string punctuation)
		{
			var regex = $"([^{punctuation}]+)([{punctuation}]*)";
			string res = "";

			foreach (Match match in Regex.Matches(line, regex))
			{
				string full = match.Value;
				string word = match.Groups[1].Value;
				string punct = match.Groups[2].Value;

				if (UppercaseLettersOnly(word))
				{
					res = full;
				}
			}

			return res;
		}

        public static string FindWord2InLine(string line, string punctuation)
		{
			string shortest = line;
			string res = "";
			var regex = $"([^{punctuation}]+)([{punctuation}]*)";

			foreach (Match match in Regex.Matches(line, regex))
			{
                string full = match.Value;
                string word = match.Groups[1].Value;
                string punct = match.Groups[2].Value;

                if (shortest.Length > match.Length && NumberOfUppercaseLetters(word) == 0)
				{
					shortest = word;
					res = full;
				}
			}

			return res;
        }

		public static string EditLine(string line, string punctuation, string word)
		{
            var regex = $"([^{punctuation}]+)([{punctuation}]*)";
			string resLine = "";

            foreach (Match match in Regex.Matches(line, regex))
            {
                string full = match.Value;
                string onlyWord = match.Groups[1].Value;
                string punct = match.Groups[2].Value;

				if (full == word)
				{
					resLine = full + line.Remove(match.Index, match.Length);
				}
            }

			return resLine;
        }

		public static void PerformTasksW(string fd, string fr)
		{
			using (StreamReader reader = new StreamReader(fd, Encoding.UTF8))
			{
				string line = "";
				string punctuation = "";
				int numberOfLine = 1;
				string shortWord = "";
				string shortest = "";
				int res = 0;

				using (var writer = File.CreateText(fr))
				{
					punctuation = reader.ReadLine();

					while ((line = reader.ReadLine()) != null)
					{
						string word = FindWord1InLine(line, punctuation);

						if (word != "")
						{
							writer.WriteLine(EditLine(line, punctuation, word));
						}
						else
						{
							writer.WriteLine(line);
						}

						string[] temp = Regex.Split(FindWord2InLine(line, punctuation), "[" + punctuation + "]");

                        if ((temp[0] != "" && shortWord == "") || (temp[0] != "" && shortest.Length < temp[0].Length))
						{
							shortest = temp[0];
                            shortWord = FindWord2InLine(line, punctuation);
							res = numberOfLine;
						}

						numberOfLine++;
					}

					if (shortWord == "")
					{
                        writer.WriteLine(NumberOfUppercaseLetters(line));
                    }
					else
					{
						writer.WriteLine(shortWord + " " + res);
					}
				}
			}
		}
    }
}

