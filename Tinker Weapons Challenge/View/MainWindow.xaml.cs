using System.Windows;

namespace Tinker_Weapons_Challenge
{
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();

		}

		private void buttonToDesignWindow(object sender, RoutedEventArgs e)
		{
			buildWindow bw = new buildWindow();
			bw.Show();
			this.Close();
		}
	}
}
