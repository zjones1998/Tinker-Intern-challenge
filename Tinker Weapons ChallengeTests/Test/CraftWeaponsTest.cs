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
        //Below two test is done by initializing and passing the object  
        [TestMethod()]
        public void AirCraftTest()
        {
            //for AirCraft test by passing the object
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

        //Testing class by instatiating
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
        These test creates list of object which is the copy of the 
        CraftWeaponsDatabase class and checks if they are accurately 
        accessed when neede by the UserView Model class
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
            This Test demonstrate if the inteded weapon has been loaded to the 
            right place of the plane we wanted 
        */
        [TestMethod()]                  
        public void TotalWeaponLoadTest()
        {
            
            int B52 = 185000;       //empty plane weigh
            int LeftWingLoaded = 3 * 7988;  //Gravity weigh added to the Left Wing
            int RightWingLoaded = 30194; //ALCM weigh added to the Right Wing
            int BayLoaded = 0;
            int FuelAdded = 150000;     //fuel weigh added to the plane
            int LoadedPlaneWeight = B52 + LeftWingLoaded + RightWingLoaded + FuelAdded + BayLoaded;     //expected plane weigh ready to take off     

            List<AirCraft> ListCraft = CraftWeaponsDatabase.ReturnCraftList();   // ReturnCraftList
            List<AirWeapons> ListWeapon = CraftWeaponsDatabase.ReturnWeaponList();   // ReturnCraftList
            int weighB52 =  UserViewModel.ReturnTotalWeight();

            Assert.AreEqual(LoadedPlaneWeight, weighB52, "result did not pass");

        }
    }


    
    
}  