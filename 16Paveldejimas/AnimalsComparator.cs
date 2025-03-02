using System;

namespace Paveldejimas
{
	public class AnimalsComparator
	{
		public virtual int Compare(Animal a, Animal b)
		{
			return a.CompareTo(b);
		}
	}
}
