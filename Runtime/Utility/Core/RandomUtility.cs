// FROM 

using UnityEngine;

namespace GG.Core
{
	public static class RandomUtility
	{
		public static float GetRandomFloatBetween (float minimum, float maximum, System.Random rand) 
		{
			return (float) (rand.NextDouble () * (maximum - minimum) + minimum);
		}

		public static float GetRandomFloatInRange (Vector2 range, System.Random rand) 
		{
			return (float) (rand.NextDouble () * (range.y - range.x) + range.x);
		}

		public static Color GetRandomSeededColor (System.Random random)
		{
			Color color = new Color ((float) random.NextDouble (), (float) random.NextDouble (), (float) random.NextDouble ());
			return color;
		}
	}
}
