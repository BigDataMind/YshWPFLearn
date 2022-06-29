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

namespace Binding06_使用DataContext作Source
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑  没有指定Source
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	}

	public class Student
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public int Age { get; set; }
	}
}
