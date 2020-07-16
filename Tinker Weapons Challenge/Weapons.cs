using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinker_Weapons_Challenge.Configuration;

namespace Tinker_Weapons_Challenge
{
	public class Weapons
	{
		public string Weaponname { get; set;}
		public int Weight { get; set; }

		public Weapons(string weaponname, int weight) 
		{
			Weaponname = weaponname;
			Weight = weight;
		}

		public Weapons()
        {
			Weaponname = "DEFAULT_Weaponname";
			Weight = 0;
        }

			
	}
}
