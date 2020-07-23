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
    }
}
