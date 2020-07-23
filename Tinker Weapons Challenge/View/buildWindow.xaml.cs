using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using Tinker_Weapons_Challenge.Model;
using Tinker_Weapons_Challenge.ViewModel;


namespace Tinker_Weapons_Challenge
{

	/// <summary>
	/// Interaction logic for buildWindow.xaml
	/// </summary>
	public partial class buildWindow : Window
	{


		int baywt;
		int leftwt;
		int rightwt;

		public buildWindow()
		{
			/*
			DataContext is the main object that is now bound to the View model
			this will help binding of any attributes in View with the ViewModel properties
			*/
			DataContext = new UserViewModel();
			InitializeComponent();
		}

        private void btnLtWing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
			UserViewModel vm = (UserViewModel)DataContext;
			MessageBox.Show(this, "B-52 Ready To Take Off");
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
			MessageBoxResult result = MessageBox.Show("Fuel Has Been Added", "NOTIFICATION");
        }
    

		private void ExitButton(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ResetButton(object sender, RoutedEventArgs e)
		{
			buildWindow bw = new buildWindow();
			bw.Show();
			this.Close();
		}

		private void SaveButton(object sender, RoutedEventArgs e)
		{
			int baywt = int.Parse(wtTxtBay.Text);
			int leftwt = int.Parse(wtTxtLtW.Text);
			int rightwt = int.Parse(wtTxtRtW.Text);

			AirWeapons left = new AirWeapons(txtLtWeapon.Text, leftwt);
			AirWeapons right = new AirWeapons(txtRtWeapon.Text, rightwt);
			AirWeapons bay = new AirWeapons(txtBay.Text, baywt);

			if (txtLtWeapon.Text.Equals("Select Weapon"))
				left = new AirWeapons("none", 0);

			else if (txtRtWeapon.Text.Equals("Select Weapon"))
				right = new AirWeapons("none", 0);

			else if (txtBay.Text.Equals("Select Weapon"))
				bay = new AirWeapons("none", 0);

			else
			{
				left = new AirWeapons(txtLtWeapon.Text, leftwt);
				right = new AirWeapons(txtRtWeapon.Text, rightwt);
				bay = new AirWeapons(txtBay.Text, baywt);
			}

			int total = left.getWeight() + bay.getWeight() + right.getWeight();

			addRecord(left.getName(), bay.getName(), right.getName(),total ,leftwt, baywt, rightwt, "planeSaveFile.txt");
			MessageBox.Show("File has been saved!", "File Confirm");
		}

		public static void addRecord(string left, string bay, string right, int totalWeight, int leftWeight, int bayWeight, int rightWeight, string filepath)
		{
			try
			{
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
				{
					file.WriteLine(left + "," + bay + "," + right + "," + totalWeight.ToString() + "," + leftWeight.ToString() + "," + bayWeight.ToString() + "," + rightWeight.ToString());
				}
			}
			catch(Exception ex)
			{
				throw new ApplicationException("Didn't load right : ", ex);
			}
		}

		private void HomeButton(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}


		
	}

}
