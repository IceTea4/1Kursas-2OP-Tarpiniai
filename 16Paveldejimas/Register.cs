using System.Collections.Generic;
using System;

namespace Paveldejimas
{
    class Register
    {
        private AnimalsContainer allAnimals;

        public Register()
        {
            allAnimals = new AnimalsContainer();
        }

        public Register(AnimalsContainer animals)
        {
            allAnimals = new AnimalsContainer(animals.Count);

            for  (int i = 0; i < animals.Count; i++)
            {
                Animal animal = animals.Get(i);
                allAnimals.Add(animal);
            }
        }

        public void Add(Animal animal)
        {
            allAnimals.Add(animal);
        }

        public int AnimalsCount()
        {
            return this.allAnimals.Count;
        }

        public Animal GetAnimal(int number)
        {
            return allAnimals.Get(number);
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < this.AnimalsCount(); i++)
            {
                if (this.GetAnimal(i).Gender.Equals(gender))
                {
                    count++;
                }
            }

            return count;
        }

        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < this.AnimalsCount(); i++)
            {
                Animal animal = this.GetAnimal(i);

                if (animal.Breed.Equals(breed))
                {
                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }

        public Animal FindOldestAnimal()
        {
            return this.FindOldestAnimal(this.allAnimals);
        }

        public Animal FindOldesAnimal(string breed)
        {
            AnimalsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestAnimal(Filtered);
        }

        public Animal FindOldestAnimal(AnimalsContainer animals)
        {
            Animal oldest = this.GetAnimal(0);

            for (int i = 1; i < this.AnimalsCount(); i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, this.GetAnimal(i).BirthDate) > 0)
                {
                    oldest = this.GetAnimal(i);
                }
            }
            return oldest;
        }

        private Animal FindAnimalByID(int ID)
        {
            for (int i = 0; i < this.AnimalsCount(); i++)
            {
                if (this.GetAnimal(i).ID == ID)
                {
                    return this.GetAnimal(i);
                }
            }
            return null;
        }

        public AnimalsContainer FilterByVaccinationExpired()
        {
            AnimalsContainer noVaccination = new AnimalsContainer();

            for (int i = 0; i < this.AnimalsCount(); i++)
            {
                if (this.GetAnimal(i).RequiresVaccination)
                {
                    noVaccination.Add(this.GetAnimal(i));
                }
            }
            return noVaccination;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindAnimalByID(vaccination.AnimalId);

                if (animal == null)
                {
                    continue;
                }

                if (vaccination > animal.LastVaccinationDate)
                {
                    animal.LastVaccinationDate = vaccination.Date;
                }
            }
        }

        public bool Contains(Animal animal)
        {
            return allAnimals.Contains(animal);
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.AnimalsCount(); i++)
            {
                string breed = this.GetAnimal(i).Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public int CountAggresiveDogs()
        {
            int count = 0;

            for (int i = 0; i < this.AnimalsCount(); i++)
            {
                Animal animal = this.GetAnimal(i);

                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
