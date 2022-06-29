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
using System.Xml;
using System.Xml.Linq;

namespace _09.XML数据作Source
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
			XmlDocument doc = new XmlDocument();
			doc.Load(@"G:\vsFile\C#\C#笔记\C#应用\WpfCode\09.XML数据作Source\RawData.xml");
			XmlDataProvider xdp = new XmlDataProvider();
			xdp.Document = doc;

			xdp.XPath = @"/StudentList/student";

			this.listViewStudents.DataContext = xdp;
			this.listViewStudents.SetBinding(ListView.ItemsSourceProperty, new Binding());

		}
	}
}
