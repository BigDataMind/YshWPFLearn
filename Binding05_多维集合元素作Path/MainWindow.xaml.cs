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

namespace Binding05_多维集合元素作Path
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			List<City> cities = new List<City>()
			{
				new City() {Name ="成都"}
			};
			List<Province> provinces = new List<Province>()
			{
				new Province(){ Name = "四川", CityList=cities}
			};

			List<Country> countryList = new List<Country>()
			{
				new Country(){Name = "中国", ProvinceList= provinces}
			};
			


			this.textBox1.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source = countryList });
			this.textBox2.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/Name") { Source = countryList });
			this.textBox3.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/CityList/Name") { Source = countryList });
		}
	}

	class City
	{
		public string Name { get; set; }
	}

	class Province
	{
		public string Name { get; set; }
		public List<City> CityList { get; set; }
	}

	class Country
	{
		public string Name { get; set; }
		public List<Province> ProvinceList { get; set; }
	}
}
