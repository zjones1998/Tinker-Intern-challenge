using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinker_Weapons_Challenge.Model
{
    //this class will instantiate the type of Aircraft we need
    //need more to work for MVVM approach with databinding in a ViewModel
    class AirCraft
    {
        string name;        //name of the AirCraft
        int initAirCraftWeight;     //initial weight of the AirCraft
        int fuelWeight;     // fuelWeight loaded
        public AirCraft()       //empty constructor
        {

        }
        public AirCraft(string name, int initAirCraftWeight, int fuelWeight)       // constructor  with parameter
        {
            this.name = name;
            this.initAirCraftWeight = initAirCraftWeight;
        }
    }
}
