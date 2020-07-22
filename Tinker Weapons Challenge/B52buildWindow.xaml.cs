using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tinker_Weapons_Challenge.Configuration;

namespace Tinker_Weapons_Challenge
{

	/// <summary>
	/// Interaction logic for buildWindow.xaml
	/// </summary>
	public partial class B52buildWindow : Window
	{
		//public string[] fuelWeights { get; set; }
		//public string[] weapons { get; set; }
		private Fuel _fuels = null;
		public decimal distance;

		int WeaponWeight;
		//private int leftWing;
		//private int rightWing;
		//private int bayWeight;
		string imagePath;
		int nullWeight = int.Parse("0", NumberStyles.AllowThousands, new CultureInfo("en-au"));

		//Set up the Plane and Weapon Classes that will be needed.
		Plane B52 = new Plane();
		Weapons Gravity = new Weapons();
		Weapons Jassm= new Weapons();
		Weapons Jdam = new Weapons();
		Weapons Mald = new Weapons();
		Weapons Wcmd = new Weapons();
		Weapons Calcm = new Weapons();
		Weapons Alcm = new Weapons();


		public B52buildWindow()
		{
			InitializeComponent();
			//Assign values for plane and weapons.
			B52.PlaneName = "B52";
			B52.BaseWeight = 185000;
			B52.MaxWeight = 485000;
			B52.Range = 4825;
			B52.MinFuel = 100000;
			B52.MaxFuel = 300000;
			Gravity.WeaponName = "Gravity";
			Gravity.Weight = 7988;
			Jassm.WeaponName = "JASSM";
			Jassm.Weight = 24946;
			Jdam.WeaponName = "JDAM";
			Jdam.Weight = 9722;
			Mald.WeaponName = "MALD";
			Mald.Weight = 7626;
			Wcmd.WeaponName = "WCMD";
			Wcmd.Weight = 16324;
			Calcm.WeaponName = "CALCM";
			Calcm.Weight = 30194;
			Alcm.WeaponName = "ALCM";
			Alcm.Weight = 30194;

			//fuelWeights = new string[] {"0", "100,000", "150,000", "200,000" };
			//weapons = new string[] { "None", "Gravity", "JASSM", "JDAM", "MALD", "ALCM-CALCM" };


			DataContext = this;
		}

		private void fuelConfirm(object sender, RoutedEventArgs e)
		{
			int totalWeight = 0;
			if(fuelCombo.SelectedItem == null)
			{
				totalWeight = B52.BaseWeight + B52.MinFuel + int.Parse(totalWeaponWeight.Text, NumberStyles.AllowThousands, new CultureInfo("en-au"));
				totalWeightBox.Text= String.Format("{0:n0}", totalWeight);
				
				if(totalWeight > B52.MaxWeight)
				{
					clearedOrNoGo.Text = "Current weight excedes max. Remove fuel or weapons";
				}
				else
					clearedOrNoGo.Text = "Cleared for takeoff!";
			}
			else
			{
				totalWeight = B52.BaseWeight + B52.MinFuel + int.Parse(fuelCombo.Text, NumberStyles.AllowThousands, new CultureInfo("en-au")) + int.Parse(totalWeaponWeight.Text, NumberStyles.AllowThousands, new CultureInfo("en-au"));
				totalWeightBox.Text = String.Format("{0:n0}", totalWeight);
				if (totalWeight > B52.MaxWeight)
				{
					clearedOrNoGo.Text = "Current weight excedes max. Remove fuel or weapons";
				}

				else
					clearedOrNoGo.Text = "Cleared for takeoff!";
			}
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			B52buildWindow bw = new B52buildWindow();
			bw.Show();
			this.Close();
		}

		private void ExitButton(object sender, RoutedEventArgs e)
		{			
			this.Close();
		}
		private void HomeButton(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}

		private void WeaponConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			WeaponWeight = calcWeaponWeight(B52.RWingWeight, B52.LWingWeight, B52.BayWeight);
			if (WeaponWeight == 0)
				totalWeaponWeight.Text = "No weapons loaded.";
			else
				totalWeaponWeight.Text = String.Format("{0:n0}", WeaponWeight);
		}

        private void distanceConfirm(object sender, RoutedEventArgs e)
        {
			MessageBoxResult result = new MessageBoxResult();
			decimal.TryParse(Distance.Text, out distance);
			if (distance > B52.Range)
			{
				result = MessageBox.Show($"Error, {B52.PlaneName} does not have enough range", "Confirmation");
			}
			else
			{
				result = MessageBox.Show($"Error, {B52.PlaneName} does  have enough range", "Confirmation");
				
				
				
				// Currently Fuel calc breaks program, so I commented it out.
				//_fuels.fuel_calc(distance, B52.Range, B52.MaxFuel);
			}
		}

		// This deasls woth the drag and drop functions
		private void Weapon_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			imagePath = ((Image)sender).Source.ToString();
			DragDrop.DoDragDrop((DependencyObject)sender, ((Image)sender).Source, DragDropEffects.Copy);
		}

		private void Left_Drop(object sender, DragEventArgs e)
		{
			Weapons w = new Weapons();
			foreach (var format in e.Data.GetFormats())
			{
				ImageSource imageSource = e.Data.GetData(format) as ImageSource;
				if (imageSource != null)
				{
					Canvas canvas = new Canvas();
					Image img = new Image();
					//img.Height = 50;
					img.Width = 110;
					img.Stretch = Stretch.Uniform;
					img.Source = imageSource;
					((Canvas)sender).Children.Add(img);
					Canvas.SetTop(img, 0);
					Canvas.SetLeft(img, 0);
					string finalPath = null;
					finalPath = System.IO.Path.GetFileNameWithoutExtension(imagePath);

					//MessageBox.Show(finalPath);
					//w = new Weapons(finalPath, w.getWeight());
					B52.LWing = leftChoice(finalPath);
				}
			}
		}

		private void Right_Drop(object sender, DragEventArgs e)
		{
			Weapons w = new Weapons();
			foreach (var format in e.Data.GetFormats())
			{
				ImageSource imageSource = e.Data.GetData(format) as ImageSource;
				if (imageSource != null)
				{
					Canvas canvas = new Canvas();
					Image img = new Image();
					//img.Height = 50;
					img.Width = 110;
					img.Stretch = Stretch.Uniform;
					img.Source = imageSource;
					((Canvas)sender).Children.Add(img);
					Canvas.SetTop(img, 0);
					Canvas.SetLeft(img, 0);
					string finalPath = null;
					finalPath = System.IO.Path.GetFileNameWithoutExtension(imagePath);

					//MessageBox.Show(finalPath);
					//w = new Weapons(finalPath, w.getWeight());
					B52.RWing = rightChoice(finalPath);
				}
			}
		}
		private void bay_Drop(object sender, DragEventArgs e)
		{
			Weapons w = new Weapons();
			foreach (var format in e.Data.GetFormats())
			{
				ImageSource imageSource = e.Data.GetData(format) as ImageSource;
				if (imageSource != null)
				{
					Canvas canvas = new Canvas();
					Image img = new Image();
					//img.Height = 50;
					img.Width = 110;
					img.Stretch = Stretch.Uniform;
					img.Source = imageSource;
					((Canvas)sender).Children.Add(img);
					Canvas.SetTop(img, 0);
					Canvas.SetLeft(img, 0);
					string finalPath = null;
					finalPath = System.IO.Path.GetFileNameWithoutExtension(imagePath);

					//MessageBox.Show(finalPath);
					//w = new Weapons(finalPath, w.getWeight());
					B52.BayWeight = bayChoice(finalPath);
				}
			}
		}

		private void Distance_GotFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = (TextBox)sender;
			tb.Text = string.Empty;
			tb.GotFocus -= Distance_GotFocus;
		}

		// ====================================
		// This function allows the user to choose 
		// which missile/weapon to use for the 
		// combobox. Removed the code from 
		// the WeaponConfirm button
		//=====================================
		public int leftChoice(string weaponName)
		{
			B52.LWingWeight = 0;
			if (B52.LWing.Equals(Gravity.WeaponName))
			{
				B52.LWingWeight = Gravity.Weight;
			}

			//-----------------------------------------------------
			if (B52.LWing.Equals(Jassm.WeaponName))
			{
				B52.LWingWeight = Jassm.Weight;
			}

			//-----------------------------------------------------
			if (B52.LWing.Equals(Mald.WeaponName))
			{
				B52.LWingWeight = Mald.Weight;
			}


			//-----------------------------------------------------
			if (B52.LWing.Equals(Jdam.WeaponName))
			{
				B52.LWingWeight = Jassm.Weight;
			}

			//-----------------------------------------------------
			if (B52.LWing.Equals(Wcmd.WeaponName))
			{
				B52.LWingWeight = Wcmd.Weight;
			}


			//-----------------------------------------------------
			if (B52.LWing.Equals(Alcm.WeaponName))
			{
				B52.LWingWeight = Alcm.Weight;
			}

			if (B52.LWing.Equals(Calcm.WeaponName))
			{
				B52.LWingWeight = Alcm.Weight;
			}

			//-----------------------------------------------------
			// Checks for no selection or "none" choice
			else B52.LWingWeight = 0;

			LeftWeaponChoice.Text = B52.LWing ;
					
			// calculate total weapon weights. 
			//WeaponWeight = rightWing + leftWing + bayWeight;
			//totalWeaponWeight.Text = String.Format("{0:n0}", WeaponWeight);
			return B52.LWingWeight;
		}

		public int rightChoice(string weaponName)
		{
			B52.RWingWeight = 0;

			if (B52.RWing.Equals(Gravity.WeaponName))
			{
				B52.RWingWeight = Gravity.Weight;
			}

			//-----------------------------------------------------
			if (B52.RWing.Equals(Jassm.WeaponName))
			{
				B52.RWingWeight = Jassm.Weight;
			}

			//-----------------------------------------------------
			if (B52.RWing.Equals(Mald.WeaponName))
			{
				B52.RWingWeight = Mald.Weight;
			}


			//-----------------------------------------------------
			if (B52.RWing.Equals(Jdam.WeaponName))
			{
				B52.RWingWeight = Jdam.Weight;
			}

			//-----------------------------------------------------
			if (B52.RWing.Equals(Wcmd.WeaponName))
			{
				B52.RWingWeight = Wcmd.Weight;
			}

			//-----------------------------------------------------
			if (B52.RWing.Equals(Alcm.WeaponName))
			{
				B52.RWingWeight = Alcm.Weight;
			}

			if (B52.RWing.Equals(Calcm.WeaponName))
			{
				B52.RWingWeight = Alcm.Weight;
			}

            else
            {
				B52.RWingWeight = 0;
            }

			RightWeaponChoice.Text = B52.RWing;
			return B52.RWingWeight;
		}


		public int bayChoice(string weaponName)
		{
			MessageBoxResult result = new MessageBoxResult();

			if (B52.Bay.Equals("ALCM-CALCM"))
			{
				B52.BayWeight = Alcm.Weight;
				bayWeaponChoice.Text = B52.Bay;
			}

			if (B52.Bay.Equals(Wcmd.WeaponName))
			{
				// error handling for  WCMD that can't be loaded into bay.
				result = MessageBox.Show("Error, cannot be loaded into bay", "Confirmation");
				B52.RWingWeight = 0;
				B52.LWingWeight = 0;
				totalWeaponWeight.Text = nullWeight.ToString();
			}


			if (B52.Bay.Equals(Mald.WeaponName))
			{
				// error handling for  MALD that can't be loaded into bay.
				result = MessageBox.Show("Error, cannot be loaded into bay", "Confirmation");
				B52.RWingWeight = 0;
				B52.LWingWeight = 0;
				totalWeaponWeight.Text = nullWeight.ToString();
			}

			if (B52.Bay.Equals(Jassm.WeaponName))
			{
				B52.BayWeight = Jassm.Weight;
				bayWeaponChoice.Text = B52.Bay;
			}

			if (B52.Bay.Equals(Jdam.WeaponName))
			{
				B52.BayWeight = Jdam.Weight;
				bayWeaponChoice.Text = weaponName;
			}

			if (B52.Bay.Equals(Gravity.WeaponName))
			{
				B52.BayWeight = Gravity.Weight;
				bayWeaponChoice.Text = weaponName;
			}
			return B52.BayWeight;
		}

		public int calcWeaponWeight(int rightWeight, int leftWeight, int backWeight)
		{
			return rightWeight + leftWeight + backWeight;
		}
	}

}
