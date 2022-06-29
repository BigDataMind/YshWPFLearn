using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Binding01_Basic
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		Student stu;
		public MainWindow()
		{
			InitializeComponent();

			//数据源
			stu = new Student();

			//绑定属性
			Binding binding = new Binding();
			binding.Source = stu;
			binding.Path = new PropertyPath("Name");

			//源与目标连接
			BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			stu.Name += "Name";
		}
	}

	class Student : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				//激发事件
				if (this.PropertyChanged !=null)
				{
					this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}

		
	}

	
}
