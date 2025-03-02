using System;

namespace Paveldejimas
{
    public class Vaccination
    {
        public int AnimalId { get; set;}
        public DateTime Date { get; set;}

        public Vaccination(int animalId, DateTime date)
        {
            this.AnimalId = animalId;
            this.Date = date;
        }

        public static bool operator <(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) < 0;
        }

        public static bool operator >(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) > 0;
        }
    }
}
