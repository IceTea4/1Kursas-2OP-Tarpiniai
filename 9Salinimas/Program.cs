namespace Salinimas
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = @"../../../Duomenys.txt";
            const string CFr = "Rezultatai.txt";

            int length = InOut.LongestLine(CFd);

            InOut.RemoveLine(CFd, CFr, length);
        }
    }
}
