using System;
using System.Collections.Generic;

namespace Paveldejimas
{
    class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        private int Capacity;

        public AnimalsContainer(int capacity = 16) //parameter with default value
        {
            this.animals = new Animal[capacity];
            this.Capacity = capacity;
        }

        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }

            this.animals[this.Count++] = animal;
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }

        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }
        }

        public void Put(Animal animal, int index)
        {
            if (index >= 0 && index < this.Capacity)
            {
                this.animals[index] = animal;
            }
        }

        public void Insert(Animal animal, int index)
        {
            if (index >= 0 && index < this.Capacity)
            {
                if (this.Count + 1 > Capacity)
                {
                    this.EnsureCapacity(this.Count * 2);
                }

                for (int i = this.Count; i > index + 1; i--)
                {
                    this.animals[i] = this.animals[i - 1];
                }

                this.animals[index] = animal;
                this.Count++;
            }
        }

        public void Remove(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i] == animal)
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
                    this.animals[j - 1] = animals[j];
                }

                this.Count--;
            }
        }

        public void Sort()
        {
            Sort(new AnimalsComparator());
        }

        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];

                    if (comparator.Compare(a, b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public AnimalsContainer(AnimalsContainer container) : this(container.Capacity) //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();

            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];

                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }

            return result;
        }
    }
}
