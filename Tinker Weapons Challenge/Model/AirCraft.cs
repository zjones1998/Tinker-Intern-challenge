using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinker_Weapons_Challenge.Model
{
    //this class will instantiate the type of Aircraft we need
    //need more to work for MVVM approach with databinding in a ViewModel
    public class AirCraft
    {
        public string nameAirCraft;        //name of the AirCraft
        public int initAirCraftWeight;     //initial weight of the AirCraft
        public int availableFuel = 0;     // fuelWeight loaded
        public AirCraft()       //empty constructor
        {

        }
        public AirCraft(string nameAirCraft, int initAirCraftWeight, int availableFuel)       // constructor  with parameter
        {
            this.nameAirCraft = nameAirCraft;
            this.initAirCraftWeight = initAirCraftWeight;
            this.availableFuel = availableFuel;
        }

        public void setName(string nameAirCraft)
        {
            this.nameAirCraft = nameAirCraft;
        }

        public string getName()
        {
            return this.nameAirCraft;
        }

        public void setWeight(int initAirCraftWeight)
        {
            this.initAirCraftWeight = initAirCraftWeight;
        }

        public int getWeight()
        {
            return this.initAirCraftWeight;
        }

        public void setAvailableFuel(int availableFuel)
        {
            this.availableFuel = availableFuel;
        }

        public int getAvailableFuel()
        {
           return this.availableFuel;
        }


        //public int calculatTotalWeight(string airCraftWeight, )
       // {

       // }
    }
}
