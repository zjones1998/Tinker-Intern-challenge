using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Tinker_Weapons_Challenge;

namespace Tinker_Weapons_Challenge.Configuration 
{
    public class WeaponsList
    {
        private List<Weapons> weaponsList;
        
        public WeaponsList()
        {
            weaponsList.Add(new Weapons { Weaponname = "Gravity", Weight = 7988 });
            weaponsList.Add(new Weapons { Weaponname = "JASSM", Weight = 24946 });
            weaponsList.Add(new Weapons { Weaponname = "JDAM", Weight = 9722 });
            weaponsList.Add(new Weapons { Weaponname = "MALD", Weight = 7626 });
            weaponsList.Add(new Weapons { Weaponname = "WCMD", Weight = 16324 });
            weaponsList.Add(new Weapons { Weaponname = "CALCM", Weight = 30194 });
            weaponsList.Add(new Weapons { Weaponname = "ALCM", Weight = 30194 });

        }
       
    }
}
