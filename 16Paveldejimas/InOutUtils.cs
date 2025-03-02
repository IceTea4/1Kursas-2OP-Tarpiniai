using System.Text;
using System;
using System.IO;
using System.Collections.Generic;

namespace Paveldejimas
{
    static class InOutUtils
    {
        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                string type = values[0];
                int id = int.Parse(values[1]);
                string name = values[2];
                string breed = values[3];
                DateTime birthDate = DateTime.Parse(values[4]);

                Gender gender;
                Enum.TryParse(values[5], out gender); //tries to convert value to enum

                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "PIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                    default:
                        break; //unknown type
                }
            }

            return animals;
        }
        public static void PrintAnimals(string label, AnimalsContainer animals)
        {
            Console.WriteLine(new string('-', 92));
            Console.WriteLine("| {0,-88} |", label);
            Console.WriteLine(new string('-', 92));
            Console.WriteLine("| {0,-13} | {1,7} | {2,-9} | {3,-13} | {4,-11} | {5,-6} | {6,-11} |",
                "Gyvunas", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Agresyvumas");
            Console.WriteLine(new string('-', 92));

            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                Console.WriteLine(animal.ToString());
            }

            Console.WriteLine(new string ('-', 92));
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }

        public static void PrintAnimalsToCSVFile(string fileName, AnimalsContainer animals)
        {
            List<string> lines = new List<string>();

            lines.Add(String.Format("{0};{1};{2};{3};{4}", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis"));

            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                lines.Add(String.Format("{0};{1};{2};{3};{4}", animal.ID, animal.Name, animal.Breed, animal.BirthDate.ToString("d"), animal.Gender));
            }

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                int id = int.Parse(values[0]);
                DateTime vaccinationDate = DateTime.Parse(values[1]);

                Vaccination v = new Vaccination(id, vaccinationDate);

                Vaccinations.Add(v);
            }

            return Vaccinations;
        }
    }
}
