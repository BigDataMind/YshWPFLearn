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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemsControl族控件
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonVictor_Click(object sender, RoutedEventArgs e)
		{
			Button btn = sender as Button;
			DependencyObject level1 = VisualTreeHelper.GetParent(btn);
			DependencyObject level2 = VisualTreeHelper.GetParent(level1);
			DependencyObject level3 = VisualTreeHelper.GetParent(level2) ;
			MessageBox.Show(level3.GetType().ToString());
		}
	}
}
