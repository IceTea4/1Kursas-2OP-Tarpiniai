using System;
using System.Collections.Generic;

namespace Paveldejimas
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalsContainer container = InOutUtils.ReadAnimals(@"../../../Animals.csv");
            Register register = new Register(container);
            AnimalsContainer copy = new AnimalsContainer(container);

            //container.Put(container.Get(0), 3);
            //container.Put(container.Get(0), 100);

            //container.Insert(container.Get(0), 0);
            //container.Insert(container.Get(0), 100);

            //container.Remove(container.Get(0));
            //container.RemoveAt(100);

            InOutUtils.PrintAnimals("Registro informacija:", container);
            Console.WriteLine();

            int aggresive = register.CountAggresiveDogs();
            Console.WriteLine($"Agresyvių šunų kiekis: {aggresive}");
            Console.WriteLine();

            container.Sort(new AnimalsComparatorByName());
            InOutUtils.PrintAnimals("Po rikiavimo:", container);
            Console.WriteLine();

            Console.WriteLine("Iš viso gyvunu: {0}", container.Count);
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();

            Animal oldest = register.FindOldestAnimal();
            Console.WriteLine("Seniausias gyvunas:");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Gyvunu veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            List<Vaccination> VaccinationData = InOutUtils.ReadVaccinations(@"../../../Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationData);

            Console.WriteLine("Neturintys arba turintys nebegaliojančius skiepus:");
            AnimalsContainer noVaccination = register.FilterByVaccinationExpired();

            if (noVaccination.Count == 0)
            {
                Console.WriteLine("Visi gyvunai paskiepyti");
            }
            else
            {
                InOutUtils.PrintAnimals("Gyvunai, kuriems reikia skiepų:", noVaccination);
            }

            Console.WriteLine();
            Console.WriteLine("Kokios veislės gyvunus atrinkti?");
            string selectedBreed = Console.ReadLine();
            Console.WriteLine();

            AnimalsContainer FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintAnimals("Gyvunai atrinkti pagal veislę:", FilteredByBreed);

            Console.WriteLine();
            if (noVaccination.Intersect(FilteredByBreed).Count == 0)
            {
                Console.WriteLine("Visi gyvunai paskiepyti");
            }
            else
            {
                InOutUtils.PrintAnimals("Reikia skiepyti (" + selectedBreed + ")", noVaccination.Intersect(FilteredByBreed));
            }

            string fileName = "Atrinkti.csv";
            InOutUtils.PrintAnimalsToCSVFile(fileName, FilteredByBreed);

            Console.WriteLine();
            InOutUtils.PrintAnimals("Pradiniai duomenys", copy);
            Console.WriteLine();

            AnimalsContainer first = new AnimalsContainer(copy);
            AnimalsContainer second = new AnimalsContainer(copy);
            first.Sort(new AnimalsComparatorByNameID());
            second.Sort(new AnimalsComparatorByBirthID());

            InOutUtils.PrintAnimals("Pirmas rūšiavimas", first);
            Console.WriteLine();
            InOutUtils.PrintAnimals("Antras rūšiavimas", second);
        }
    }
}
