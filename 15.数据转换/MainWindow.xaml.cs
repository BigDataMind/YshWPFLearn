using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace _15.数据转换
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

		private void buttonLoad_Click(object sender, RoutedEventArgs e)
		{
			List<Plane> planeList = new List<Plane>()
			{
				new Plane(){Category=Category.Bomber,Name="B-1",State=State.Unknown},
				new Plane(){Category=Category.Bomber,Name="B-2",State=State.Unknown},
				new Plane(){Category=Category.Fighter,Name="F-22",State=State.Unknown},
				new Plane(){Category=Category.Fighter,Name="Su-47",State=State.Unknown},
				new Plane(){Category=Category.Bomber,Name="B-52",State=State.Unknown},
				new Plane(){Category=Category.Fighter,Name="J-10",State=State.Unknown},
			};

			this.listBoxPlane.ItemsSource = planeList;
		}

		private void buttonSave_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			foreach (Plane p in listBoxPlane.Items)
			{
				sb.AppendLine(string.Format("Category={0},Name={1},State={2}", p.Category, p.Name, p.State));
			}
			File.WriteAllText(@"G:\vsFile\C#\Result\PlaneList.txt", sb.ToString()); //绝对路径
		}
	}

	//种类
	public enum Category
	{
		Bomber,
		Fighter
	}

	//状态
	public enum State
	{
		Available,
		Locked,
		Unknown
	}

	//飞机
	public class Plane
	{
		public Category Category { get; set; }
		public string  Name { get; set; }
		public State State { get; set; }
	}

	public class CategoryToSourceConverter : IValueConverter
	{
		//将Category 装换为Uri
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Category c = (Category)value;
			switch (c)
			{
				case Category.Bomber:
					return @"\icon\Bomber.png";
				case Category.Fighter:
					return @"\icon\Fighter.png";
				default:
					return null;
			}
		}

		//不会被调用
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class StateToNullableBoolConverter : IValueConverter
	{
		//将State转换为bool
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			State s = (State)value;
			switch (s)
			{
				case State.Available:
					return false;
				case State.Locked:
					return true;
				case State.Unknown:
				default:
					return null;
			}
		}

		//将bool？转换为State
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool? nb = (bool?)value;
			switch (nb)
			{
				case true:
					return State.Available;
				case false:
					return State.Locked;
				case null:
				default:
					return State.Unknown;
			}
		}
	}
}
