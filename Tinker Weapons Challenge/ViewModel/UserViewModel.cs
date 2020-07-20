using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tinker_Weapons_Challenge.Model;

namespace Tinker_Weapons_Challenge.ViewModel
{
    //This class will function as data binding between View and Model 
    //It will interact as the interface between user response to interface
    //and database behind the system
    public class UserViewModel : INotifyPropertyChanged
    {
        //notifying the property changed
        public event PropertyChangedEventHandler PropertyChanged;  

        //holds command interface/behavior for that button
        private ICommand _GravityCommand;
        private ICommand _JassmCommand;

        private string _LeftWingWeapon = null;      //holds the string returned by its property
        private int _LeftWingQt = 0;                //holds the number of weapon quantity selected
        private int TotalWeight = 0;                //holds the total weight of the plane
        private bool _LeftWingSelected = false;     //will hold the flag for the leftwing button


        //create a new list to store weapons object
        List<AirWeapons> weaponList = CraftWeaponsDatabase.ReturnWeaponList();

        //holds the property for the leftwing button
        //returns if the button is selected then true else false
        public bool BtnLeftWingSelected
        {
            get { return _LeftWingSelected; }

            set 
            {
                _LeftWingSelected = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BtnLeftWingSelected)));
            }
        }


        //creates/initialises command
        public UserViewModel()
        {
            _GravityCommand = new RelayCommand(o => true, o => AddGravityWeapon());
            _JassmCommand = new RelayCommand(o => true, o => AddJassmWeapon());
        }


        //returns the command to the button
        public ICommand GravityCommand { get { return _GravityCommand; } } 

        public void AddGravityWeapon()
        {
            if(BtnLeftWingSelected)
            {
                if(LeftWingWeapon != "Gravity")
                {
                    LeftWingWeapon = weaponList[0].getName();
                    LeftWingQt = 1;
                }
                else
                {
                    LeftWingQt += 1;
                }
                
            }
        }


        //returns the command to the button
        public ICommand JassmCommand { get { return _JassmCommand; } }
        public void AddJassmWeapon()
        {
            if (BtnLeftWingSelected)
            {
                if (LeftWingWeapon != "JASSM")
                {
                    LeftWingWeapon = weaponList[1].getName();
                    LeftWingQt = 1;
                }
                else
                {
                    LeftWingQt += 1;
                }

            }
        }

        //setting up property for the LeftWingWeapon text box
        public string LeftWingWeapon
        {
            get { return _LeftWingWeapon; }
            
            set 
            {
                this._LeftWingWeapon = value;
                System.Diagnostics.Debug.WriteLine(_LeftWingWeapon);
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftWingWeapon"));
            }
        }

        //setting up property for the LeftWingQuantity text box
        public int LeftWingQt
        {
            get { return _LeftWingQt; }

            set
            {
                this._LeftWingQt = value;
                System.Diagnostics.Debug.WriteLine(_LeftWingQt);
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftWingQt"));
            }
        }
    }
}
