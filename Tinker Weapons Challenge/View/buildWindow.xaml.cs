using System;
using System.Collections.Generic;
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
    }
}
