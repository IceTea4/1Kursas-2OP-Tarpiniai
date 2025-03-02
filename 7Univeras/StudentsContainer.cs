using System;

namespace Univeras
{
    public class StudentsContainer
    {
        private Studentas[] students;
        public int Count { get; set; }
        private int Capacity;

        public StudentsContainer(int capacity = 16)
        {
            this.students = new Studentas[capacity];
            this.Capacity = capacity;
        }

        private void EnsureCapacity(int minimum)
        {
            if (minimum > this.Capacity)
            {
                Studentas[] temp = new Studentas[minimum];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.students[i];
                }

                this.Capacity = minimum;
                this.students = temp;
            }
        }

        public void Add(Studentas student)
        {
            if (this.Contains(student))
            {
                return;
            }

            if (this.Count == this.Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }

            this.students[this.Count++] = student;
        }

        public Studentas Get(int index)
        {
            return this.students[index];
        }

        public bool Contains(Studentas student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.students[i].Equals(student))
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
                    Studentas one = this.students[i];
                    Studentas two = this.students[i + 1];
                    if (one.CompareTo(two) < 0)
                    {
                        this.students[i] = two;
                        this.students[i + 1] = one;
                        flag = true;
                    }
                }
            }
        }
    }
}
