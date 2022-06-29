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
using System.Data.SQLite;

namespace Binding10_ADO.Net对象作Source
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

		/// <summary>
		/// 直接获取table
		/// </summary>
		/// <returns></returns>
		static List<string> GetTable()
		{
			SQLiteConnection connection = new SQLiteConnection(@"DataSource=G:\vsFile\C#\C#笔记\C#应用\WpfCode\Binding10_ADO.Net对象作Source\students.db;version=3");
			connection.Open();
			List<string> names = new List<string>();
			SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Students", connection);
			SQLiteDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				names.Add(reader.GetString(1));
			}
			connection.Close();
			return names;


		}
		private static SqLiteHelper sql;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			sql = new SqLiteHelper(@"DataSource=G:\vsFile\C#\C#笔记\C#应用\WpfCode\Binding10_ADO.Net对象作Source\students.db;version=3");
			SQLiteDataReader reader = sql.ReadFullTable("Students");
			List<string> names = new List<string>();
			while (reader.Read())
			{
				
				names.Add(reader.GetString(reader.GetOrdinal("Name")));
			}

			//this.listBoxStudents.ItemsSource = GetTable();

			this.listBoxStudents.ItemsSource = names;

		}
	}	
}
