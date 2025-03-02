namespace Palindromai
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = @"../../../Duomenys.txt";
            string punctuation = "\\s,.;:!?()\\-";

            Console.WriteLine("Palindromai: {0, 3:d}", TaskUtils.Process(CFd, punctuation));
        }
    }
}