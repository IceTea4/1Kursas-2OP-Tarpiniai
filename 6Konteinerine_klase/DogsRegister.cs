using System.Collections.Generic;
using System;

namespace Konteinerine_klase
{
    public class DogsRegister
    {
        /*
        private List<Dog> AllDogs;
        
        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }

        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }

        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public Dog WhichDog(int number)
        {
            return AllDogs[number];
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public Dog FindOldestDog(string breed)
        {
            DogsRegister Filtered = this.FilterByBreed(breed);
            return Filtered.FindOldestDog();
        }

        public Dog FindOldestDog()
        {
            Dog oldest = this.AllDogs[0];
            for (int i = 1; i < this.DogsCount(); i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, this.AllDogs[i].BirthDate) > 0)
                {
                    oldest = this.AllDogs[i];
                }
            }
            return oldest;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public DogsRegister FilterByBreed(string breed)
        {
            DogsRegister Filtered = new DogsRegister();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed))
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);

                if (dog == null)
                {
                    continue;
                }

                if (vaccination > dog.LastVaccinationDate)
                {
                    dog.LastVaccinationDate = vaccination.Date;
                }
            }
        }

        public DogsRegister FilterByVaccinationExpired()
        {
            DogsRegister noVaccination = new DogsRegister();

            foreach (Dog dog in this.AllDogs)
            {
                if (dog.RequiresVaccination)
                {
                    noVaccination.Add(dog);
                }
            }
            return noVaccination;
        }

        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
        */
    }
}
