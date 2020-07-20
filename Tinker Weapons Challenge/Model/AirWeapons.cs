
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Tinker_Weapons_Challenge.Model
{
    /*
     This class will create different types of weapons depending to its requirements
     */
    public class AirWeapons 
    {
        public string name;        //weapon name
        public int weaponWeight;
        public AirWeapons()        //default constructor
        {

        }
        public AirWeapons(string name, int weaponWeight)     //constructor with parameter
        {
            this.name = name;
            this.weaponWeight = weaponWeight;

        }
        public void setName(string name)    //setter
        {
            this.name = name;
        }

        public string getName()     //getter
        {
            return this.name;
        }

        public void setWeight(int weaponWeight)
        {
            this.weaponWeight = weaponWeight;
        }

        public int getWeight()
        {
            return this.weaponWeight;
        }

    }

}
