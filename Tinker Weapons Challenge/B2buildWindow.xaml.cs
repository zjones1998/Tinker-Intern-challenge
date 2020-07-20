using System;
using System.Collections.Generic;
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

namespace Tinker_Weapons_Challenge
{
	/// <summary>
	/// Interaction logic for B2buildWindow.xaml
	/// </summary>
	public partial class B2buildWindow : Window
	{

		Plane b2Bomber = new Plane();
		public B2buildWindow()
		{
			InitializeComponent();
			b2Bomber.PlaneName = "B2 Bomber";

		}

		private void HomeButton(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Close();
		}
	}
}
