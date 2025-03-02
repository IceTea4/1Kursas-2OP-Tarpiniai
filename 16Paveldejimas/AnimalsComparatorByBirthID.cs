using System;

namespace Paveldejimas
{
	class AnimalsComparatorByBirthID : AnimalsComparator
	{
        public override int Compare(Animal a, Animal b)
        {
            int result = a.BirthDate.CompareTo(b.BirthDate);

            if (result == 0)
            {
                return a.ID.CompareTo(b.ID);
            }

            return result;
        }
    }
}

