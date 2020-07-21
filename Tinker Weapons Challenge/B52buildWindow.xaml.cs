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
		public string[] fuelWeights { get; set; }
		public string[] weapons { get; set; }
		private Fuel _fuels = null;
		public decimal distance;

		int WeaponWeight;
		private int leftWing;
		private int rightWing;
		private int bayWeight;
		string imagePath;
		int nullWeight = int.Parse("0", NumberStyles.AllowThousands, new CultureInfo("en-au"));


		Plane B52 = new Plane();
		



		public B52buildWindow()
		{
			InitializeComponent();

			B52.PlaneName = "B52";
			B52.BaseWeight = 185000;
			B52.MaxWeight = 485000;
			B52.Range = 4825;
			B52.MinFuel = 100000;
			B52.MaxFuel = 300000;
			fuelWeights = new string[] {"0", "100,000", "150,000", "200,000" };
			weapons = new string[] { "None", "Gravity", "JASSM", "JDAM", "MALD", "ALCM-CALCM" };
			
			/*
			foreach(string w in weapons)
			{
				leftWingCombo.Items.Add(w);
				rightWingCombo.Items.Add(w);
				//bayCombo.Items.Add(w);
			}
			*/

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
			WeaponWeight = calcWeaponWeight(rightWing, leftWing, bayWeight);
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
					leftWing = leftChoice(finalPath);
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
					rightWing = rightChoice(finalPath);
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
					bayWeight = bayChoice(finalPath);
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
			// Make a new weapon that will be used to make the weapon name and weight for combobox.
			Weapons w = new Weapons();

			if (weaponName.Equals("Gravity"))
			{
				w = new Weapons("Gravity", 7988);
				leftWing = w.getWeight();
				LeftWeaponChoice.Text = weaponName;
			}

			//-----------------------------------------------------
			if (weaponName.Equals("JASSM"))
			{
				w = new Weapons("JASSM", 24946);
				leftWing = w.getWeight();
				LeftWeaponChoice.Text = weaponName;
			}

			//-----------------------------------------------------
			if (weaponName.Equals("MALD"))
			{
				w = new Weapons("MALD", 7626);
				leftWing = w.getWeight();
				LeftWeaponChoice.Text = weaponName;
			}


			//-----------------------------------------------------
			if (weaponName.Equals("JDAM"))
			{
				w = new Weapons("JDAM", 9722);
				leftWing = w.getWeight();
				LeftWeaponChoice.Text = weaponName;
			}

			//-----------------------------------------------------
			if (weaponName.Equals("WCMD"))
			{
				w = new Weapons("WCMD", 16324);
				leftWing = w.getWeight();
				LeftWeaponChoice.Text = weaponName;
			}


			//-----------------------------------------------------
			if (weaponName.Equals("ALCM-CALCM"))
			{
				w = new Weapons("ALCM-CALCM", 30194);
				leftWing = w.getWeight();
				LeftWeaponChoice.Text = weaponName;
			}


			//-----------------------------------------------------
			// Checks for no selection or "none" choice
			if (weaponName.Equals(null))
				leftWing = 0;


			// calculate total weapon weights. 
			//WeaponWeight = rightWing + leftWing + bayWeight;
			//totalWeaponWeight.Text = String.Format("{0:n0}", WeaponWeight);
			return leftWing;
		}

		public int rightChoice(string weaponName)
		{
			Weapons w = new Weapons();
			int rightWing = 0;
			if (weaponName.Equals("None"))
				rightWing = 0;

			if (weaponName.Equals("ALCM-CALCM"))
			{
				w = new Weapons("ALCM-CALCM", 30194);
				rightWing = w.getWeight();
				RightWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("WCMD"))
			{
				w = new Weapons("WCMD", 30194);
				rightWing = w.getWeight();
				RightWeaponChoice.Text = w.getName();
			}


			if (weaponName.Equals("MALD"))
			{
				w = new Weapons("MALD", 30194);
				rightWing = w.getWeight();
				RightWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("JASSM"))
			{
				w = new Weapons("JASSM", 24946);
				rightWing = w.getWeight();
				RightWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("JDAM"))
			{
				w = new Weapons("JDAM", 9722);
				rightWing = w.getWeight();
				RightWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("Gravity"))
			{
				w = new Weapons("Gravity", 7988);
				rightWing = w.getWeight();
				RightWeaponChoice.Text = weaponName;

			}
			return rightWing;
		}


		public int bayChoice(string weaponName)
		{
			Weapons w = new Weapons();
			MessageBoxResult result = new MessageBoxResult();
			int bayWeight = 0;
			if (weaponName.Equals("None"))
				bayWeight = 0;

			if (weaponName.Equals("ALCM-CALCM"))
			{
				w = new Weapons("ALCM-CALCM", 30194);
				bayWeight = w.getWeight();
				bayWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("WCMD"))
			{
				// error handling for  MALD that can't be loaded into bay.
				result = MessageBox.Show("Error, cannot be loaded into bay", "Confirmation");
				rightWing = 0;
				leftWing = 0;
				totalWeaponWeight.Text = nullWeight.ToString();
			}


			if (weaponName.Equals("MALD"))
			{
				// error handling for  MALD that can't be loaded into bay.
				result = MessageBox.Show("Error, cannot be loaded into bay", "Confirmation");
				rightWing = 0;
				leftWing = 0;
				totalWeaponWeight.Text = nullWeight.ToString();
			}

			if (weaponName.Equals("JASSM"))
			{
				w = new Weapons("JASSM", 24946);
				bayWeight = w.getWeight();
				bayWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("JDAM"))
			{
				w = new Weapons("JDAM", 9722);
				bayWeight = w.getWeight();
				bayWeaponChoice.Text = weaponName;
			}

			if (weaponName.Equals("Gravity"))
			{
				w = new Weapons("Gravity", 7988);
				bayWeight = w.getWeight();
				bayWeaponChoice.Text = weaponName;
			}
			return bayWeight;
		}

		public int calcWeaponWeight(int rightWeight, int leftWeight, int backWeight)
		{
			return rightWeight + leftWeight + backWeight;
		}
	}

}
