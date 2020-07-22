using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinker_Weapons_Challenge.ViewModel;

namespace Tinker_Weapons_Challenge.Model
{
    public static class CraftWeaponsDatabase
    {
        public static List<AirCraft> airCraftsList = new List<AirCraft>()          //create list of Air Crafts
        {
            new AirCraft { nameAirCraft = "B-52",initAirCraftWeight = 185000 },  //initializing fuel level is optional
           
             //new AirCraft { nameAirCraft = "B-21", initAirCraftWeight =135600}
        };

        
        
        public static List<AirWeapons> weaponList = new List<AirWeapons>()   //creates list of Air Weapons
        {
            new AirWeapons {name = "Gravity", weaponWeight = 7988},
            new AirWeapons {name = "JASSM", weaponWeight = 24946},
            new AirWeapons {name = "JDAM", weaponWeight = 9722},
            new AirWeapons {name = "MALD", weaponWeight = 7626},
            new AirWeapons {name = "WCMD", weaponWeight = 16324},
            new AirWeapons {name = "CALCM", weaponWeight = 30194},
            new AirWeapons {name = "ALCM", weaponWeight = 30194}

        };

        

        //create new weapons list or new weapons can be added to the above list as well

        public static List<AirCraft> ReturnCraftList()          //returns AirCraft lists
        {
           return airCraftsList;
        }

        public static List<AirWeapons> ReturnWeaponList()          //returns Weapons lists
        {
            return weaponList;
        }




        /*
         We add hear and run the test 
         */

    }
}