namespace SkaiciavimoKlase
{
    class Program
    {
        static void Main(string[] args)
        {
            DogsRegister register = InOutUtils.ReadDogs(@"../../../Dogs.csv");

            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(register);

            Console.WriteLine();

            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();

            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo:");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            List<Vaccination> VaccinationData = InOutUtils.ReadVaccinations(@"../../../Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationData);

            Console.WriteLine("Neturintys arba turintys nebegaliojančius skiepus:");
            DogsRegister noVaccination = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogs(noVaccination);

            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            Console.WriteLine();

            DogsRegister FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = "Atrinkti.csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);
        }
    }
}
