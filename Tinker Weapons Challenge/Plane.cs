using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Tinker_Weapons_Challenge
	{

	public class Plane
	{

		public string PlaneName{ get; set; }

		public int BaseWeight{ get; set; }

		public int MaxWeight{ get; set; }

		public int MaxFuel{ get; set; }
		public int MinFuel{ get; set; }

		public Plane(string planeName, int baseWeight, int maxWeight, int maxFuel, int minFuel)
		{
			PlaneName = planeName;
			BaseWeight = baseWeight;
			MaxWeight = maxWeight;
			MaxFuel = maxFuel;
			MinFuel = minFuel;
		}

	}
}