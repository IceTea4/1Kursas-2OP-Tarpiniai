namespace _4._6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = @"../../../Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            const string CFa = "Analize.txt";
            const string vowels = "AEIYOUaeiyouĄąĘęĖėĮįŲųŪū";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };

            TaskUtils.Process(CFd, CFr, CFa, punctuation, vowels);
        }
    }
}

