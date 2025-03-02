using System.Text;
using System.Text.RegularExpressions;

namespace _2Kontro_pvz
{
    public class TaskUtils
    {
        public static bool NoDigits(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (Char.IsDigit(line[i])) //isiminti
                {
                    return false;
                }
            }

            return true;
        }

        public static int NumberDifferentVowelsInLine(string line)
        {
            int count = 0;
            string vowels = "aeiyouąęėįųū";
            string newvowels = "";
            line = line.ToLower();

            for (int i = 0; i < line.Length; i++)
            {
                if (vowels.Contains(line[i]) && !newvowels.Contains(line[i])) //isimint
                {
                    count++;
                    newvowels += line[i];
                }
            }

            return count;
        }

        public static string FindWord1Line(string line, string punctuation)
        {
            string theWord = "";
            string result = "";

            var regex = $"([^{punctuation}]+)([{punctuation}]*)"; //isimint

            foreach (Match match in Regex.Matches(line, regex)) //isimint
            {
                string withPunktuation = match.Value; //isimint
                string wordOnly = match.Groups[1].Value; //isimint
                string onlyPunctuation = match.Groups[2].Value; //isimint

                if (NumberDifferentVowelsInLine(wordOnly) == 3 && wordOnly.Length > theWord.Length)
                {
                    theWord = wordOnly;
                    result = withPunktuation;
                }
            }

            return result;
        }

        public static string EditLine(string line, string punctuation, string word)
        {
            string newLine = "";

            var regex = $"([^{punctuation}]+)([{punctuation}]*)";

            foreach (Match match in Regex.Matches(line, regex))
            {
                string withPunktuation = match.Value;
                string wordOnly = match.Groups[1].Value;
                string onlyPunctuation = match.Groups[2].Value;

                if (withPunktuation == word)
                {
                    newLine = withPunktuation + line.Remove(match.Index, match.Length); //isimint
                }
            }

            return newLine;
        }

        public static string FindWord2Line(string line, string punctuation)
        {
            string lastNoDigitWord = "";

            var regex = $"([^{punctuation}]+)([{punctuation}]*)";

            foreach (Match match in Regex.Matches(line, regex))
            {
                string withpunctuation = match.Value;
                string wordOnly = match.Groups[1].Value;
                string onlyPunctuation = match.Groups[2].Value;

                if (NoDigits(wordOnly))
                {
                    lastNoDigitWord = withpunctuation;
                }
            }

            return lastNoDigitWord;
        }

        public static void PerformTask(string fd, string fr)
        {
            using (StreamReader reader = new StreamReader(fd, Encoding.UTF8)) //isimint
            {
                string line;
                string punctuation = "";

                using (var writer = File.CreateText(fr)) //isimint
                {
                    punctuation = reader.ReadLine();

                    while ((line = reader.ReadLine()) != null) //isimint
                    {
                        string word = FindWord1Line(line, punctuation);

                        if (word == "")
                        {
                            writer.WriteLine(line);
                        }
                        else
                        {
                            writer.WriteLine(EditLine(line, punctuation, word));
                        }

                        string newWord = FindWord2Line(line, punctuation);

                        if (newWord != "")
                        {
                            string[] res = Regex.Split(newWord, "[" + punctuation + "]"); //isimint

                            writer.WriteLine(res[0]);
                        }
                    }
                }
            }
        }
    }
}
