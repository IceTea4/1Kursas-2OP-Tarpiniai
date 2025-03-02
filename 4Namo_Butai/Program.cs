using System;

namespace Namo_Butai
{
    public class Program
    {
        static void Main(string[] args)
        {
            ButaiRegister register = InOutUtils.ReadButai(@"../../Butai.csv");

            InOutUtils.PrintButai(register);

            Console.WriteLine();
            Console.WriteLine("Įveskite kiek norite kambarių:");
            int kiek = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite žemiausią norimą aukštą:");
            int nuo = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite aukščiausią norimą aukštą:");
            int iki = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite didžaiusią norimą kainą:");
            int suma = int.Parse(Console.ReadLine());

            Console.WriteLine();
            InOutUtils.PrintButai(register.Atrink(kiek, nuo, iki, suma));
        }
    }
}
