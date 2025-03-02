using System.Text.RegularExpressions;

namespace _4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = @"../../Duomenys.txt";
            const string CFr = "Rezultatai.txt";

            string punctuation = "[\\s\\n.,!?:;()\t']*";
            string remove = "ima";

            TaskUtils.Process(CFd, CFr, punctuation, remove);
        }
    }
}
