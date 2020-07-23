using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Tinker_Weapons_Challenge.ViewModel;

namespace Tinker_Weapons_Challenge.Model.Tests
{

    [TestClass()]
    public class CraftWeaponsTests
    {
        //This will initialize the classes to ensure they set up without crashing.
        [TestMethod()]
        public void SetUpTest()
        {
            AirCraft SetUpAircraft = new AirCraft();
            AirWeapons SetUpAirWeapons = new AirWeapons();
        }

        //Below two tests will be run expanding on the above.
        [TestMethod()]
        public void AirCraftTest()
        {
            //AirCraft class will be set up and information passed in to check the setup was correct.
            AirCraft aircraft = new AirCraft("B-52", 185000, 100000);           
            string actualAirCraft = aircraft.getName();
            string target = "B-52";
            int actualWeight = aircraft.getWeight();
            int targetWeight = 185000;
            int actualFuel = aircraft.getAvailableFuel();
            int targetFuel = 100000;
            Assert.AreEqual(target, actualAirCraft, "Air Craft name is different");
            Assert.AreEqual(actualWeight, targetWeight, "Air Craft Weight do not match");
            Assert.AreEqual(actualFuel, targetFuel, "Fuel is different then expected");

        }           

        //This test will be of AirWeapons with instated data.
        [TestMethod()]
        public void WeaponsTest()
        {
            //check to see if the object initialized will initialized the weight accurately
            AirWeapons gravity = new AirWeapons("Gravity", 7988);           
            string result = gravity.getName();
            string target = "Gravity";
            int resultWeight = gravity.getWeight();
            int actualWeight = 7988;
            Assert.AreEqual(target,result, "Failed the result");
            Assert.AreEqual(resultWeight, actualWeight, "Weight differs");
        }


        /*
        These test creates a list of object which is a copy of the CraftWeaponsDatabase class 
        and checks if they are correctly accessed by the UserView Model class
        */
        [TestMethod()]
        public void AirCraftListTest()        
        {
            List<AirCraft> list = CraftWeaponsDatabase.ReturnCraftList();   // ReturnCraftList
            string result = list[0].getName();
            string target = "B-52";
            Assert.AreEqual(result, target, "they are not equall");

            int result1 = list[0].getWeight();
            int target1 = 185000;
            Assert.AreEqual(result1, target1, "result did not pass");
        }
                        
        /*              
        Checks if the list in the database file is correctly passed
        to ViewModel class 
        */
        [TestMethod()]
        public void WeaponListTest()        
        {
            List<AirWeapons> list = CraftWeaponsDatabase.ReturnWeaponList();   // ReturnCraftList
            string result = list[5].getName();
            string target = "CALCM";
            Assert.AreEqual(result, target, "they are not equall");

            int result1 = list[4].getWeight();
            int target1 = 16324;
            Assert.AreEqual(result1, target1, "result did not pass");
        }


        /*
            This test loads the plane and checks the weight is correct.
        */
        [TestMethod()]                  
        public void TotalWeaponLoadTest()
        { 
            int B52 = 185000;           //empty plane weight
            int LeftWingLoaded = 7988;  //Gravity weight added to the Left Wing
            int RightWingLoaded = 30194; //ALCM weight added to the Right Wing
            int BayLoaded = 0;          //Bay is left empty.
            int FuelAdded = 150000;     //Add fuel to the plane.
            //expected plane weight when loaded
            int LoadedPlaneWeight = B52 + LeftWingLoaded + RightWingLoaded + FuelAdded + BayLoaded;  
            //Return lists
            List<AirCraft> ListCraft = CraftWeaponsDatabase.ReturnCraftList();
            List<AirWeapons> ListWeapon = CraftWeaponsDatabase.ReturnWeaponList();
            int weighB52 =  UserViewModel.ReturnTotalWeight();
            Assert.AreEqual(LoadedPlaneWeight, weighB52, "result did not pass");
        }

        //This will check a value inside the range of the plane, and will require over 100,000 tons of fuel.
        [TestMethod]

        public void TestMethod1()
        {
            Fuel F = new Fuel();
            int distance = 2895;
            //B-52's range.
            int range = 4825;
            //B-52's max amount of fuel.
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
            //This is the minimum amount of fuel the plane can have.
            decimal ExpectedFuel = 100000;
            Assert.AreEqual<decimal>(ExpectedFuel, FuelNeeded);
        }

    }
  
}  