namespace Univeras
{
    public class Studentas
    {
        public string surname { get; }
        public string name { get; }
        public string group { get; }
        public int[] notes { get; }
        private decimal average { get; }

        public Studentas(string surname, string name, string group, int[] notes)
        {
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.notes = notes;
            this.average = Average();
        }

        private decimal Average()
        {
            decimal avg = 0;

            foreach (int note in notes)
            {
                avg += note;
            }

            return avg / notes.Length;
        }

        public int CompareTo(Studentas other)
        {
            int avg = this.average.CompareTo(other.average);
            if (avg != 0)
            {
                return avg;
            }
            else
            {
                return other.surname.CompareTo(this.surname);
            }
        }

        public string NotesToString()
        {
            string marks = "";

            foreach (int note in notes)
            {
                marks += String.Format($"{note,3}");
            }

            return marks;
        }
    }
}
