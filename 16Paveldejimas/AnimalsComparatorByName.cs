using System;

namespace Paveldejimas
{
	class AnimalsComparatorByName : AnimalsComparator
	{
		public override int Compare(Animal a, Animal b)
		{
			return a.Name.CompareTo(b.Name);
		}
	}
}
