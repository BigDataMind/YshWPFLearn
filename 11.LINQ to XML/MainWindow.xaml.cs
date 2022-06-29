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
using System.Xml.Linq;

namespace _11.LINQ_to_XML
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
			XDocument xdoc = XDocument.Load(@"G:\vsFile\C#\C#笔记\C#应用\WpfCode\11.LINQ to XML\RawData.xml");

			this.listViewStudents.ItemsSource =
				from element in xdoc.Descendants("Student")
				where element.Attribute("Name").Value.StartsWith("T")
				select new Student()
				{
					Id = int.Parse(element.Attribute("Id").Value),
					Name = element.Attribute("Name").Value,
					Age = int.Parse(element.Attribute("Age").Value)
				};
		}
	}

	class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
