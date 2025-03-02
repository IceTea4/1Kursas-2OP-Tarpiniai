using System;

namespace Paveldejimas
{
	public abstract class Animal
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastVaccinationDate { get; set; }

        public Animal(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public abstract bool RequiresVaccination { get; }

        public override bool Equals(object other)
        {
            return this.ID == ((Animal)other).ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public int CompareTo(Animal other)
        {
            int result = this.Breed.CompareTo(other.Breed);

            if (result == 0)
            {
                return this.Gender.CompareTo(other.Gender);
            }

            return result;
        }

        public override string ToString()
        {
            return String.Format("| {0,7} | {1,-9} | {2,-13} | {3,-11:yyyy-MM-dd} | {4,-6} |", this.ID, this.Name, this.Breed, this.BirthDate, this.Gender);
        }
    }
}

