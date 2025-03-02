using System;

namespace Paveldejimas
{
	class AnimalsComparatorByNameID : AnimalsComparator
	{
		public override int Compare(Animal a, Animal b)
		{
            int result = a.Name.CompareTo(b.Name);

            if (result == 0)
            {
                return a.ID.CompareTo(b.ID);
            }

            return result;
        }
	}
}

