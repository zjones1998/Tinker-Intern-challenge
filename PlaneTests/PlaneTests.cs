using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tinker_Weapons_Challenge;

namespace ProgramTests
{
	[TestClass]
	public class PlaneTests
	{
		[TestMethod]
		public void PlaneTest()
		{
			//string planeName, int baseWeight, int maxWeight,
			//int maxFuel, int minFuel, int range, string rWing, int rWingWeight,
			//string lWing, int lWingWeight, string bay, int bayWeight
			Plane b52 = new Plane
			{
				PlaneName = "B-52",
				BaseWeight = 185000,
				MaxWeight = 485000,
				MaxFuel = 300000,
				MinFuel = 150000,
				Range = 8800,
				RWing = "none",
				RWingWeight = 0,
				LWing = "none",
				LWingWeight = 0,
				Bay = "none",
				BayWeight = 0
			};
		}

		[TestMethod]
		public void NameTest()
		{
			Plane test = new Plane();
			test.PlaneName = "B-52";

		}
	}
}
