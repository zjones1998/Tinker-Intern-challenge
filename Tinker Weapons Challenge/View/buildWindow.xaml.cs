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
    }
}
