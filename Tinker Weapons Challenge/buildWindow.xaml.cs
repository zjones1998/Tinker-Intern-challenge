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
	public partial class buildWindow : Window
	{
		public string[] fuelWeights { get; set; }
		public string[] weapons { get; set; }
		public int planeWeight = 185000;
		int baseFuel = 150000;
		int maxWeight = 485000;
		private Fuel _fuels = null;
		public decimal distance;
		int GRAVITYWeight = 7988;
		int JASSMWeight = 24946;
		int JDAMWeight = 9722;
		int MALDWeight = 7626;
		int WCMDWeight = 16324;
		int CALCMWeight = 30194;
		int ALCMWeight = 30194;
		Plane B52 = new Plane();
		



		public buildWindow()
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
			
			foreach(string w in weapons)
			{
				leftWingCombo.Items.Add(w);
				rightWingCombo.Items.Add(w);
				bayCombo.Items.Add(w);
			}
				

			DataContext = this;
		}

		private void fuelConfirm(object sender, RoutedEventArgs e)
		{
			int totalWeight = 0;
			if(fuelCombo.SelectedItem == null)
			{
				totalWeight = planeWeight + baseFuel + int.Parse(totalWeaponWeight.Text, NumberStyles.AllowThousands, new CultureInfo("en-au"));
				totalWeightBox.Text= String.Format("{0:n0}", totalWeight);
				
				if(totalWeight > maxWeight)
				{
					clearedOrNoGo.Text = "Current weight excedes max. Remove fuel or weapons";
				}
				else
					clearedOrNoGo.Text = "Cleared for takeoff!";
			}
			else
			{
				totalWeight = planeWeight + baseFuel + int.Parse(fuelCombo.Text, NumberStyles.AllowThousands, new CultureInfo("en-au")) + int.Parse(totalWeaponWeight.Text, NumberStyles.AllowThousands, new CultureInfo("en-au"));
				totalWeightBox.Text = String.Format("{0:n0}", totalWeight);
				if (totalWeight > maxWeight)
				{
					clearedOrNoGo.Text = "Current weight excedes max. Remove fuel or weapons";
				}

				else
					clearedOrNoGo.Text = "Cleared for takeoff!";
			}

			
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			buildWindow bw = new buildWindow();
			bw.Show();
			this.Close();
		}

		private void ExitButton(object sender, RoutedEventArgs e)
		{			
			this.Close();
			MainWindow mw = new MainWindow();
			mw.Show();
		}

		private void WeaponConfirmButton_Click(object sender, RoutedEventArgs e)
		{
			int WeaponWeight = 0;
			int leftWing = 0;
			int rightWing = 0;
			int bayWeight = 0;
			MessageBoxResult result = new MessageBoxResult();
			int nullWeight = int.Parse("0", NumberStyles.AllowThousands, new CultureInfo("en-au"));

			if (bayCombo.Text == "MALD" || bayCombo.Text == "WCMD")
			{
				errorBay.Text = $"Error, {bayCombo.Text} cannot be loaded in the bay.";
			}

			if(leftWingCombo.Text == "Gravity")
				leftWing = GRAVITYWeight; 

			if (rightWingCombo.Text == "Gravity")
				rightWing = GRAVITYWeight;

			if (bayCombo.Text == "Gravity")
				bayWeight = GRAVITYWeight;
			//-----------------------------------------------------
			if (leftWingCombo.Text == "JASSM")
				leftWing = JASSMWeight;

			if (rightWingCombo.Text == "JASSM")
				rightWing = JASSMWeight;

			if (bayCombo.Text == "JASSM")
				bayWeight = JASSMWeight;
			//-----------------------------------------------------
			if (leftWingCombo.Text == "MALD")
				leftWing = MALDWeight;

			if (rightWingCombo.Text == "MALD")
				rightWing = MALDWeight;

			if (bayCombo.Text == "MALD")
			{
				result = MessageBox.Show("Error, cannot be loaded into bay", "Confirmation");
				rightWing = 0;
				leftWing = 0;
				totalWeaponWeight.Text = nullWeight.ToString();
			}
			//-----------------------------------------------------
			if (leftWingCombo.Text == "JDAM")
				leftWing = JDAMWeight;

			if (rightWingCombo.Text == "JDAM")
				rightWing = JDAMWeight;

			if (bayCombo.Text == "JDAM")
				bayWeight = JDAMWeight;
			//-----------------------------------------------------
			if (leftWingCombo.Text == "WCDM")
				leftWing = JDAMWeight;

			if (rightWingCombo.Text == "WCDM")
				rightWing = JDAMWeight;

			if (bayCombo.Text == "WCDM")
			{
				result = MessageBox.Show("Error, cannot be loaded into bay", "Confirmation");
				
				rightWing = 0;
				leftWing = 0;
				totalWeaponWeight.Text = nullWeight.ToString();
			}
			//-----------------------------------------------------
			if (leftWingCombo.Text == "ALCM-CALCM")
				leftWing = ALCMWeight;

			if (rightWingCombo.Text == "ALCM-CALCM")
				rightWing = ALCMWeight;

			if (bayCombo.Text == "ALCM-CALCM")
				bayWeight = ALCMWeight;
			//-----------------------------------------------------
			if (leftWingCombo.Text == "None")
				leftWing = 0;

			if (rightWingCombo.Text == "None")
				rightWing = 0;

			if (bayCombo.Text == "None")
				bayWeight = 0;

			WeaponWeight = rightWing + leftWing + bayWeight;
			totalWeaponWeight.Text = String.Format("{0:n0}", WeaponWeight);
		}

        private void distanceConfirm(object sender, RoutedEventArgs e)
        {
			decimal.TryParse(Distance.Text, out distance);
			if (distance > B52.Range)
			{

			}
			else
			{
				_fuels.fuel_calc(distance, B52.Range, B52.MaxFuel);
			}
		}
    }
}
