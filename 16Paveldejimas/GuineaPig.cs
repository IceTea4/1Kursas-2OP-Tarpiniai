using System;

namespace Paveldejimas
{
	public class GuineaPig : Animal
	{
        public GuineaPig(int id, string name, string breed, DateTime birthDate, Gender gender) : base(id, name, breed, birthDate, gender)
        {
        }

        public override string ToString()
        {
            return String.Format($"| {"Jūrų kiaulytė",-7} {base.ToString()} {"---",-11} |");
        }

        public override bool RequiresVaccination
        {
            get
            {
                return false;
            }
        }
    }
}

