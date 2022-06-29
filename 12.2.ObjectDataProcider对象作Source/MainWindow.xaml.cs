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

namespace _12._2.ObjectDataProcider对象作Source
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			ObjectDataProvider odp = new ObjectDataProvider();
			odp.ObjectInstance = new Calculator();
			odp.MethodName = "Add";
			odp.MethodParameters.Add("100");
			odp.MethodParameters.Add("200");
			MessageBox.Show(odp.Data.ToString());
		}
	}

	class Calculator
	{
		public string Add(string arg1,string arg2)
		{
			double x = 0;
			double y = 0;
			double z = 0;
			if (double.TryParse(arg1,out x)&& double.TryParse(arg2,out y))
			{
				z = x + y;
				return z.ToString();
			}
			return "Input Error";
		}
	}
}
