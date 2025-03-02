namespace KomentSalinimas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = @"../../../Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            const string CFa = "Analize.txt";

            InOut.Process(CFd, CFr, CFa);
        }
    }
}
