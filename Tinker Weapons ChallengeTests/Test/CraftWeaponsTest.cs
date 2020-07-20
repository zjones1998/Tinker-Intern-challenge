using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tinker_Weapons_Challenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinker_Weapons_Challenge.Model.Tests
{
    [TestClass()]
    public class CraftWeaponsTests
    {
        //Testing class by instantiating
        [TestMethod()]
        public void AirCraftTest()
        {
            AirCraft aircraft = new AirCraft("B-52", 185000, 100000);           //for AirCraft
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

        //Testing class by instatiating
        [TestMethod()]
        public void WeaponsTest()
        {
            AirWeapons gravity = new AirWeapons("Gravity", 7988);           //check to see if the object initialized will initialized the weight accurately
            string result = gravity.getName();
            string target = "Gravity";
            int resultWeight = gravity.getWeight();
            int actualWeight = 7988;
            Assert.AreEqual(target,result, "Failed the result");
            Assert.AreEqual(resultWeight, actualWeight, "Weight differs");
        }

        [TestMethod()]
        public void AirCraftListTest()        //test if the list we created in initialized to correct 
        {
            List<AirCraft> list = CraftWeaponsDatabase.ReturnCraftList();   // ReturnCraftList
            string result = list[0].getName();
            string target = "B-52";
            Assert.AreEqual(result, target, "they are not equall");

            int result1 = list[1].getWeight();
            int target1 = 135600;
            Assert.AreEqual(result1, target1, "result did not pass");
        }


        [TestMethod()]
        public void WeaponListTest()        //test if the list we created in initialized to correct 
        {
            List<AirWeapons> list = CraftWeaponsDatabase.ReturnWeaponList();   // ReturnCraftList
            string result = list[5].getName();
            string target = "CALCM";
            Assert.AreEqual(result, target, "they are not equall");

            int result1 = list[4].getWeight();
            int target1 = 16324;
            Assert.AreEqual(result1, target1, "result did not pass");
        }
    }
}