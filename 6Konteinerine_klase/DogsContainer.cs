using System;
using System.Collections.Generic;

namespace Konteinerine_klase
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        private int Capacity;

        public DogsContainer(int capacity = 16) //parameter with default value
        {
            this.dogs = new Dog[capacity];
            this.Capacity = capacity;
        }

        public DogsContainer(DogsContainer container) : this(container.Capacity) //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }

        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }

            this.dogs[this.Count++] = dog;
        }

        public Dog Get(int index)
        {
            return this.dogs[index];
        }

        public void Put(Dog dog, int index)
        {
            if (index >= 0 &&  index < this.Capacity)
            {
                this.dogs[index] = dog;
            }
        }

        public void Insert(Dog dog, int index)
        {
            if (index >= 0 && index < this.Capacity)
            {
                if (this.Count + 1 > Capacity)
                {
                    this.EnsureCapacity(this.Count * 2);
                }

                for (int i = this.Count; i > index + 1; i--)
                {
                    this.dogs[i] = this.dogs[i - 1];
                }

                this.dogs[index] = dog;
                this.Count++;
            }
        }

        public void Remove(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i] == dog)
                {
                    this.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < this.Capacity)
            {
                for (int j = index + 1; j < this.Count; j++)
                {
                    this.dogs[j - 1] = dogs[j];
                }

                this.Count--;
            }
        }

        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            bool flag = true;

            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();

            for (int i = 0; i < this.Count; i++)
            {
                Dog current = this.dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;

            for  (int i = 0; i < this.Count; i++)
            {
                if (Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }

            /*
            foreach (Dog dog in this.dogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            */

            return count;
        }

        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return Filtered.FindOldestDog();
        }

        public Dog FindOldestDog()
        {
            Dog oldest = this.dogs[0];
            for (int i = 1; i < this.Count; i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, this.dogs[i].BirthDate) > 0)
                {
                    oldest = this.dogs[i];
                }
            }
            return oldest;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();

            for (int i = 0; i < Count; i++)
            {
                string breed = Get(i).Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }

            /*
            foreach (Dog dog in this.dogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            */

            return Breeds;
        }

        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();

            for (int i = 0; i < Count; i++)
            {
                if (Get(i).Breed.Equals(breed))
                {
                    Filtered.Add(Get(i));
                }
            }

            /*
            foreach (Dog dog in this.dogs)
            {
                if (dog.Breed.Equals(breed))
                {
                    Filtered.Add(dog);
                }
            }
            */

            return Filtered;
        }

        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Get(i).ID == ID)
                {
                    return Get(i);
                }
            }

            /*
            foreach (Dog dog in this.dogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            */

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

        public DogsContainer FilterByVaccinationExpired()
        {
            DogsContainer noVaccination = new DogsContainer();

            for (int i = 0; i < Count; i++)
            {
                if (Get(i).RequiresVaccination)
                {
                    noVaccination.Add(Get(i));
                }
            }

            /*
            foreach (Dog dog in this.dogs)
            {
                if (dog.RequiresVaccination)
                {
                    noVaccination.Add(dog);
                }
            }
            */

            return noVaccination;
        }
    }
}
