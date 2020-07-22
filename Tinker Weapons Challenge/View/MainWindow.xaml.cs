using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tinker_Weapons_Challenge
{
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();

		}

		private void ExitButton(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ButtonToB52DesignWindow(object sender, RoutedEventArgs e)
		{
			buildWindow bw = new buildWindow();
			bw.Show();
			this.Close();
		}

		private void B2Design(object sender, RoutedEventArgs e)
		{
			B2buildWindow b2bw = new B2buildWindow();
			b2bw.Show();
			this.Close();
		}
	}
}
