// FROM 

using UnityEngine;

namespace GG.Core.Core
{
	public static class RandomUtility
	{
		public static float GetRandomFloatBetween (float minimum, float maximum, System.Random rand) 
		{
			return (float) (rand.NextDouble () * (maximum - minimum) + minimum);
		}


		public static Color GetRandomSeededColor (System.Random random)
		{
			Color color = new Color ((float) random.NextDouble (), (float) random.NextDouble (), (float) random.NextDouble ());
			return color;
		}
	}
}
