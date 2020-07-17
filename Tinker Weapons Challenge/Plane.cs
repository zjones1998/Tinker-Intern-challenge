using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Tinker_Weapons_Challenge
	{

	public class Plane
	{
		//Basic informatin about the plane.
		public string PlaneName{ get; set; }

		public int BaseWeight{ get; set; }

		public int MaxWeight{ get; set; }

		public int MaxFuel{ get; set; }
		public int MinFuel{ get; set; }

		public int Range { get; set; }

		//This will set the weapon on the right wing and the weight.
		public string RWing { get; set; }

		public int RWingWeight { get; set; }

		//This will set the weapon and weight of the left wing.
		public string LWing { get; set; }

		public int LWingWeight { get; set; }

		//This will set the weapon and weight of the Bay.
		public string Bay { get; set; }

		public int BayWeight { get; set; }

		public Plane(string planeName, int baseWeight, int maxWeight, int maxFuel, int minFuel, int range, string rWing, int rWingWeight,
			string lWing, int lWingWeight, string bay, int bayWeight)
		{
			PlaneName = planeName;
			BaseWeight = baseWeight;
			MaxWeight = maxWeight;
			MaxFuel = maxFuel;
			MinFuel = minFuel;
			Range = range;
			RWing = rWing;
			RWingWeight = rWingWeight;
			LWing = lWing;
			LWingWeight = lWingWeight;
			Bay = bay;
			BayWeight = bayWeight;
		}

	}
}