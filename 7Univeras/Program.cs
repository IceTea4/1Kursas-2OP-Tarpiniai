using System;

namespace Univeras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FacultyRegister register = InOutput.ReadStudents(@"../../../Studentai.csv");

            InOutput.PrintSutents("Registro informacija:", register);
            Console.WriteLine();

            register.students.Sort();
            InOutput.PrintSutents("Surusiuoti duomenys:", register);
        }
    }
}
