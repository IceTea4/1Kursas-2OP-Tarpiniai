namespace Raides
{
    class Program
    {
        static void Main (string[] args)
        {
            const string CFd = @"../../../Duomenys.txt";
            const string CFr = "Rezultatai.txt";

            List<Raide> letters = InOut.ReadRepetitions(CFd, AbecelesRaides());

            letters.Sort((x, y) => y.count.CompareTo(x.count));

            InOut.PrintRepetitions(CFr, letters);
        }

        private static List<Raide> DidziosiosRaides()
        {
            List<Raide> raides = new List<Raide>();

            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                Raide r = new Raide(ch);

                raides.Add(r);
            }

            return raides;
        }

        private static List<Raide> MazosiosRaides()
        {
            List<Raide> raides = DidziosiosRaides();

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                Raide r = new Raide(ch);

                raides.Add(r);
            }

            return raides;
        }

        public static List<Raide> AbecelesRaides()
        {
            List<Raide> raides = MazosiosRaides();
            char[] symb = { 'Ą', 'Č', 'Ę', 'Ė', 'Į', 'Š', 'Ų', 'Ū', 'Ž', 'ą', 'č', 'ę', 'ė', 'į', 'š', 'ų', 'ū', 'ž' };

            foreach (char ch in symb)
            {
                Raide r = new Raide(ch);

                raides.Add(r);
            }

            return raides;
        }
    }
}

