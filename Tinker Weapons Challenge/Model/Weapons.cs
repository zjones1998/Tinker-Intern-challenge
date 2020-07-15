using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tinker_Weapons_Challenge.Model
{
    /*
     This class will create different types of weapons depending to its requirements
     */
    class Weapons 
    {
        string name;
        int weaponWeight;
        public Weapons()        //default constructor
        {

        }
        public Weapons(string name)     //constructor with parameter
        {
            this.name = name;

        }
        public void setName(string name)    //setter
        {
            this.name = name;
        }

        public string getName()     //getter
        {
            return this.name;
        }

        public void setWeight(string name) //initialise weight of the weapon
        {
            if (name == "GRAVITY")
            {
                this.weaponWeight = 7988;
            }
            if (name == "JASM")
            {
                this.weaponWeight = 24946;
            }
            if (name == "JDAM")
            {
                this.weaponWeight = 9722;
            }
            if (name == "MALD")
            {
                this.weaponWeight = 7626;
            }
            if (name == "WCMD")
            {
                this.weaponWeight = 16324;
            }
            if (name == "CALCM" || name == "ALCM")
            {
                this.weaponWeight = 30194;
            }
        }
    }
}
