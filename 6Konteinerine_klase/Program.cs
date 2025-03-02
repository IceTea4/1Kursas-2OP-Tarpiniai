using System;
using System.Collections.Generic;

namespace Konteinerine_klase
{
    class Program
    {
        static void Main(string[] args)
        {
            DogsContainer container = InOutUtils.ReadDogs(@"../../Dogs.csv");
            DogsContainer copy = new DogsContainer(container);

            //container.Put(container.Get(0), 3);
            //container.Put(container.Get(0), 100);

            //container.Insert(container.Get(0), 0);
            //container.Insert(container.Get(0), 100);

            //container.Remove(container.Get(0));
            //container.RemoveAt(100);

            InOutUtils.PrintDogs("Registro informacija:", container);
            Console.WriteLine();

            container.Sort();
            InOutUtils.PrintDogs("Po rikiavimo:", container);

            Console.WriteLine("Iš viso šunų: {0}", container.Count);
            Console.WriteLine("Patinų: {0}", container.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", container.CountByGender(Gender.Female));
            Console.WriteLine();

            Dog oldest = container.FindOldestDog();
            Console.WriteLine("Seniausias šuo:");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = container.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            List<Vaccination> VaccinationData = InOutUtils.ReadVaccinations(@"../../Vaccinations.csv");
            container.UpdateVaccinationsInfo(VaccinationData);

            Console.WriteLine("Neturintys arba turintys nebegaliojančius skiepus:");
            DogsContainer noVaccination = container.FilterByVaccinationExpired();

            if (noVaccination.Count == 0)
            {
                Console.WriteLine("Visi šunys paskiepyti");
            }
            else
            {
                InOutUtils.PrintDogs("Šunys, kuriems reikia skiepų:", noVaccination);
            }

            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            Console.WriteLine();

            DogsContainer FilteredByBreed = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs("Šunys atrinkti pagal veislę:", FilteredByBreed);

            Console.WriteLine();
            if (noVaccination.Intersect(FilteredByBreed).Count == 0)
            {
                Console.WriteLine("Visi šunys paskiepyti");
            }
            else
            {
                InOutUtils.PrintDogs("Reikia skiepyti (" + selectedBreed + ")", noVaccination.Intersect(FilteredByBreed));
            }

            string fileName = "Atrinkti.csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            Console.WriteLine();
            InOutUtils.PrintDogs("Pradiniai duomenys", copy);
        }
    }
}
