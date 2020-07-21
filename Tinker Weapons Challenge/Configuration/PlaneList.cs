﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Tinker_Weapons_Challenge;

namespace Tinker_Weapons_Challenge.Configuration
{
    public class PlaneList
    {
        public List<Plane> planeList { get;  set; }
        public Plane B52 { get; set; }

        public PlaneList()
        {
            planeList.Add(new Plane { PlaneName = "B-52", BaseWeight = 185000, MaxWeight = 485000, MaxFuel = 300000, MinFuel = 100000, 
                Range = 4825}) ;
        }

    }
}