using System;
using Turistai;

class Program
{
    static void Main(string[] args)
    {
        List<Turistas> visiTuristai = InputOutput.NuskaitykTuristus(@"../../../../Turistai.csv");

        Tasks.SkirimasIslaidoms(visiTuristai);

        //InputOutput.SpausdinkTuristus(visiTuristai);

        //Console.WriteLine();

        //InputOutput.SpausdinkBendrasIslaidas(visiTuristai);

        //Console.WriteLine();

        //InputOutput.SpausdinkTurtingus(visiTuristai);

        string fileName = "Rezultatai.csv";
        InputOutput.SpausdinkTuristusCSVFaile(fileName, visiTuristai);
    }
}
