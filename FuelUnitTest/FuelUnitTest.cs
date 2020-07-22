using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tinker_Weapons_Challenge;

namespace FuelUnitTest
{
    [TestClass]
    public class FuelTest
    {
        //This will check a value inside the range of the plane, and will require over 100,000 tons of fuel.
        [TestMethod]
       
        public void TestMethod1()
        {
            Fuel F = new Fuel();
            int distance = 2895;
            int range = 4825;
            int maxFuel = 300000;
            decimal FuelNeeded = F.fuel_calc(distance, range, maxFuel);
            decimal ExpectedFuel = 180000;
            Assert.AreEqual<decimal>(ExpectedFuel, FuelNeeded);
        }

        //This will check the minimum value of fuel will be correctly set as 100,000.
        [TestMethod]
        public void TestMethod2()
        {
            Fuel F = new Fuel();
            int distance = 0;
            int range = 4825;
            int maxFuel = 300000;
            decimal FuelNeeded = F.fuel_calc(distance, range, maxFuel);
            decimal ExpectedFuel = 100000;
            Assert.AreEqual<decimal>(ExpectedFuel, FuelNeeded);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            Plane Test = new Plane();
            Test.PlaneName = "Test";
            string ActualName = Test.PlaneName;
            string ExpectedName = "Test";
            Assert.AreEqual<string>(ExpectedName, ActualName);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int RWingTest = 5000;
            int LWingTest = 5000;
            int BTest = 5000;
            int actualWeight = calcWeaponWeight(RWingTest, LWingTest, BTest);
            expectedWeight = 15000;
            Assert.AreEqual<int>(actualWeight, expectedWeight);
        }
    }
}
