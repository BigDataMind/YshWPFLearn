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

namespace xStatic成员
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class Wondow1 : Window
	{
		public static string WindowTitle = "山高月小";
		public static string ShowText { get { return "水落石出"; } }
		public Wondow1()
		{
			InitializeComponent();
		}
	}
}
