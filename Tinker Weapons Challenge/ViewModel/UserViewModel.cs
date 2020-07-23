using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
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
		private ICommand _JdamCommand;
		private ICommand _MaldCommand;
		private ICommand _WcmdCommand;
		private ICommand _CalcmCommand;
		private ICommand _AlcmCommand;

		//holds the string returned by its property
		private string _LeftWingWeapon = "  Select Weapon";
		private string _RightWingWeapon = "  Select Weapon";
		private string _BayWeapon = "  Select Weapon";

		//holds the number of weapon quantity selected
		private int _LeftWingQt = 0;
		private int _RightWingQt = 0;
		private int _BayQt = 0;

		//holds the total weight of the plane
		private int _RightWingWeaponWeight = 0;
		private int _LeftWingWeaponWeight = 0;
		private int _BayWeaponWeight = 0;
		private int _TotalWeight = 0;
		//private int _AvailableFuel = 0;
		private string _FuelFromTB = null;
		private int _LeftWingWeight = 0;
		private int _RightWingWeight = 0;
		private int _BayWeight = 0;




		//will hold the flag for the leftwing button
		private bool _LeftWingSelected = false;
		private bool _RightWingSelected = false;
		private bool _BaySelected = false;


		//create a new list to store Craft and Weapons object
		List<AirWeapons> WeaponList = CraftWeaponsDatabase.ReturnWeaponList();
		List<AirCraft> CraftList = CraftWeaponsDatabase.ReturnCraftList();

		//creates/initialises command
		public UserViewModel()
		{
			_GravityCommand = new RelayCommand(o => true, o => AddGravityWeapon());
			_JassmCommand = new RelayCommand(o => true, o => AddJassmWeapon());
			_JdamCommand = new RelayCommand(o => true, o => AddJdamWeapon());
			_MaldCommand = new RelayCommand(o => true, o => AddMaldWeapon());
			_WcmdCommand = new RelayCommand(o => true, o => AddWcmdWeapon());
			_CalcmCommand = new RelayCommand(o => true, o => AddCalcmWeapon());
			_AlcmCommand = new RelayCommand(o => true, o => AddAlcmWeapon());

		}


		//holds the property for the Bay button
		public bool BtnBaySelected
		{
			get { return _BaySelected; }

			set
			{
				if (value)
				{
					BtnLeftWingSelected = false;
					BtnRightWingSelected = false;
					MessageBoxResult result = MessageBox.Show("Bay has been selected for Loading Weapon. Proceed to select.", "MESSAGE");
				}
				this._BaySelected = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BtnBaySelected)));
			}
		}

		//setting up the property for the Bay Weapon text box
		public string BayWeapon
		{
			get { return _BayWeapon; }
			set
			{
				this._BayWeapon = value;
				System.Diagnostics.Debug.WriteLine(_BayWeapon); /**/
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BayWeapon")); /**/
			}

		}

		//setting up the property for the Bay quantity text box
		public int BayWt
		{
			get { return _BayWeight; }

			set
			{
				this._BayWeight = value;
				System.Diagnostics.Debug.WriteLine(_BayWeight); 
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BayWt)));
			}
		}

		public static object UpdateTotalWeight(int v1, int v2, int v3, int fuelAdded)
		{
			throw new NotImplementedException();
		}

		//holds the property for the leftwing button
		//returns if the button is selected then true else false
		public bool BtnLeftWingSelected
		{
			get
			{
				return _LeftWingSelected;
			}

			set
			{
				if (value)
				{
					BtnBaySelected = false;
					BtnRightWingSelected = false;
					MessageBoxResult result = MessageBox.Show("Left Wing has been selected for Loading Weapon. Proceed to select.", "MESSAGE");
				}
				_LeftWingSelected = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BtnLeftWingSelected)));
			}
		}

		//setting up property for the LeftWingWeapon text box
		public string LeftWingWeapon
		{
			get
			{
				return _LeftWingWeapon;
			}

			set
			{
				this._LeftWingWeapon = value;
				System.Diagnostics.Debug.WriteLine(_LeftWingWeapon);
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LeftWingWeapon"));
			}
		}

		//setting up property for the LeftWingQuantity text box
		public int LeftWingWt
		{
			get { return _LeftWingWeight; }

			set
			{
				this._LeftWingWeight = value;
				System.Diagnostics.Debug.WriteLine(_LeftWingWeight); /**/
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftWingWt))); /**/
			}
		}

		//holds the property for the leftwing button
		//returns if the button is selected then true else false
		public bool BtnRightWingSelected
		{
			get
			{
				return _RightWingSelected;
			}

			set
			{
				if (value)
				{
					BtnBaySelected = false;
					BtnLeftWingSelected = false;
					MessageBoxResult result = MessageBox.Show("Right Wing has been selected for loading Weapon. Proceed to select.", "MESSAGE");
				}

				_RightWingSelected = value;
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BtnRightWingSelected)));
			}

		}


		public string RightWingWeapon
		{
			get { return _RightWingWeapon; }

			set
			{
				this._RightWingWeapon = value;
				System.Diagnostics.Debug.WriteLine(_RightWingWeapon);
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RightWingWeapon"));
			}
		}

		public int RightWingWt
		{
			get { return _RightWingWeight; }
			set
			{
				this._RightWingWeight = value;
				System.Diagnostics.Debug.WriteLine(_RightWingWeight); /**/
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RightWingWt))); 
			}
		}

		//returns the command to the button
		public ICommand AlcmCommand { get { return _AlcmCommand; } }
		public void AddAlcmWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "ALCM")
				{
					LeftWingWeapon = WeaponList[6].getName();   //returns the name of weapon
					LeftWingWt = WeaponList[6].getWeight();
				}
				//else
				//{
				//    LeftWingQt += 1;
				//}
				_LeftWingWeaponWeight = WeaponList[6].getWeight();  //calculates weight

			}
			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "ALCM")
				{
					RightWingWeapon = WeaponList[6].getName();
					RightWingWt = WeaponList[6].getWeight();
				}
				//else
				//{
				//    RightWingQt += 1;
				//}
				_RightWingWeaponWeight = WeaponList[6].getWeight();
			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "ALCM")
				{
					BayWeapon = WeaponList[6].getName();
					BayWt = WeaponList[6].getWeight();
				}
				//else
				//{
				//    BayQt += 1;
				//}
				_BayWeaponWeight = WeaponList[6].getWeight();
			}
			UpdateTotalWeight();
		}

		//returns the command to the button
		public ICommand CalcmCommand { get { return _CalcmCommand; } }
		public void AddCalcmWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "CALCM")
				{
					LeftWingWeapon = WeaponList[5].getName();
					LeftWingWt = WeaponList[5].getWeight();
				}
				//else
				//{
				//    LeftWingQt += 1;
				//}
				_LeftWingWeaponWeight = WeaponList[5].getWeight();
			}
			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "CALCM")
				{
					RightWingWeapon = WeaponList[5].getName();
					RightWingWt = WeaponList[5].getWeight();
				}
				//else
				// {
				//    RightWingQt += 1;
				//}
				_RightWingWeaponWeight = WeaponList[5].getWeight();
			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "CALCM")
				{
					BayWeapon = WeaponList[5].getName();
					BayWt = WeaponList[5].getWeight();
				}
				//else
				//{
				//    BayQt += 1;
				//}
				_BayWeaponWeight = WeaponList[5].getWeight();
			}
			UpdateTotalWeight();
		}
		//returns the command to the button
		public ICommand WcmdCommand { get { return _WcmdCommand; } }
		public void AddWcmdWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "WCMD")
				{
					LeftWingWeapon = WeaponList[4].getName();
					LeftWingWt = WeaponList[4].getWeight();
				}
				//else
				//{
				//    LeftWingQt += 1;
				//}
				_LeftWingWeaponWeight = WeaponList[4].getWeight();

			}
			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "WCMD")
				{
					RightWingWeapon = WeaponList[4].getName();
					RightWingWt = WeaponList[4].getWeight();
				}
				//else
				//{
				//    RightWingQt += 1;
				//}
				_RightWingWeaponWeight = WeaponList[4].getWeight();
			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "WCMD")
				{
					MessageBoxResult warning = MessageBox.Show("WCMD can not be loaded in Bay.", "WARNING");
				}
			}
			UpdateTotalWeight();
		}
		//returns the command to the button
		public ICommand MaldCommand { get { return _MaldCommand; } }
		public void AddMaldWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "MALD")
				{
					LeftWingWeapon = WeaponList[3].getName();
					LeftWingWt = WeaponList[3].getWeight();
				}
				//else
				//{
				//    LeftWingQt += 1;
				//}
				_LeftWingWeaponWeight = WeaponList[3].getWeight();
			}
			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "MALD")
				{
					RightWingWeapon = WeaponList[3].getName();
					RightWingWt = WeaponList[3].getWeight();
				}
				//else
				//{
				//   RightWingQt += 1;
				//}
				_RightWingWeaponWeight = WeaponList[3].getWeight();
			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "MALD")
				{
					MessageBoxResult warning = MessageBox.Show("MALD can not be loaded in Bay.", "WARNING");
				}
			}
			UpdateTotalWeight();
		}

		//returns the command to the button
		public ICommand JdamCommand { get { return _JdamCommand; } }
		public void AddJdamWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "JDAM")
				{
					LeftWingWeapon = WeaponList[2].getName();
					LeftWingWt = WeaponList[2].getWeight();
				}
				// else
				//{
				//    LeftWingQt += 1;
				//}
				_LeftWingWeaponWeight = WeaponList[2].getWeight();

			}
			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "JDAM")
				{
					RightWingWeapon = WeaponList[2].getName();
					RightWingWt = WeaponList[2].getWeight();
				}
				//else
				//{
				//    RightWingQt += 1;
				//}
				_RightWingWeaponWeight = WeaponList[2].getWeight();

			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "JDAM")
				{
					BayWeapon = WeaponList[2].getName();
					BayWt = WeaponList[2].getWeight();
				}
				//else
				//{
				//    BayQt += 1;
				//}
				_BayWeaponWeight = WeaponList[2].getWeight();
			}
			UpdateTotalWeight();
		}

		//returns the command to the button
		public ICommand GravityCommand { get { return _GravityCommand; } }

		public void AddGravityWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "Gravity")
				{
					LeftWingWeapon = WeaponList[0].getName();
					LeftWingWt = WeaponList[0].getWeight();
				}
				// else
				// {
				//    LeftWingQt = 1;
				//}
				_LeftWingWeaponWeight = WeaponList[0].getWeight();

			}
			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "Gravity")
				{
					RightWingWeapon = WeaponList[0].getName();
					RightWingWt = WeaponList[0].getWeight();
				}
				// else
				// {
				//  RightWingQt = 1;
				//}
				_RightWingWeaponWeight = WeaponList[0].getWeight();

			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "Gravity")
				{
					BayWeapon = WeaponList[0].getName();
					BayWt = WeaponList[0].getWeight();
				}
				//else
				//{
				// BayQt = 1;
				// }
				_BayWeaponWeight = WeaponList[0].getWeight();
			}
			UpdateTotalWeight();
		}


		//returns the command to the button
		public ICommand JassmCommand { get { return _JassmCommand; } }
		public void AddJassmWeapon()
		{
			if (BtnLeftWingSelected)
			{
				if (LeftWingWeapon != "JASSM")
				{
					LeftWingWeapon = WeaponList[1].getName();
					LeftWingWt = WeaponList[1].getWeight();
				}
				//else
				//{
				//    LeftWingQt += 1;
				//}
				_LeftWingWeaponWeight = WeaponList[1].getWeight();
			}

			if (BtnRightWingSelected)
			{
				if (RightWingWeapon != "JASSM")
				{
					RightWingWeapon = WeaponList[1].getName();
					RightWingWt = WeaponList[1].getWeight();
				}
				//else
				//{
				//   RightWingQt += 1;
				//}
				_RightWingWeaponWeight = WeaponList[1].getWeight();

			}
			if (BtnBaySelected)
			{
				if (BayWeapon != "JASSM")
				{
					BayWeapon = WeaponList[1].getName();
					BayWt = WeaponList[1].getWeight();

				}
				//else
				//{
				// BayQt += 1;

				//}
				_BayWeaponWeight = WeaponList[1].getWeight();
			}
			UpdateTotalWeight();
		}

		//set property for the Total Weight for Air Craft to take of
		public int TotalWeight
		{
			get { return _TotalWeight; }

			set
			{
				this._TotalWeight = value;
				System.Diagnostics.Debug.WriteLine(_TotalWeight);
				this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalWeight"));
			}

		}


		//Calculates/Updates Total Weight loaded of the plane for takeoff
		public void UpdateTotalWeight()
		{
			TotalWeight = _LeftWingWeaponWeight + _RightWingWeaponWeight + _BayWeaponWeight + CraftList[0].getWeight();
			if (TotalWeight > 485000)
			{
				MessageBoxResult warning = MessageBox.Show("EXCEEDS MAXIMUM WEIGHT!!!", "ALERT");
				LeftWingWt = 0;
				RightWingWt = 0;
				BayWt = 0;
				TotalWeight = 0;
			}
		}

		//Only to check if our method above calculates accuratel 
		//this can be commented if not running Unit Test
		public static int ReturnTotalWeight()
		{
			int result = (CraftWeaponsDatabase.airCraftsList[0].getWeight() + (CraftWeaponsDatabase.weaponList[0].getWeight())
				 + 150000 + CraftWeaponsDatabase.weaponList[6].getWeight() + 0);
			return result;

		}


	}
}
