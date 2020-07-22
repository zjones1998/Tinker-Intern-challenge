using System;
using System.IO;
using System.Windows;
using Tinker_Weapons_Challenge.ViewModel;


namespace Tinker_Weapons_Challenge
{

	/// <summary>
	/// Interaction logic for buildWindow.xaml
	/// </summary>
	public partial class buildWindow : Window
	{
		
		

		public buildWindow()
		{
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
			addRecord("Gravity", "MALD", "Gravity", 23000, 100000, 100, 100, "planeSaveFile.txt");
		}

		public static void addRecord(string left, string bay, string right, int totalWeight, int leftWeight, int bayWeight, int rightWeight, string filepath)
		{
			try
			{
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
				{
					file.WriteLine(left + "," + bay + "," + right + "," + totalWeight.ToString() + "," + leftWeight.ToString() + "," + rightWeight.ToString());
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
