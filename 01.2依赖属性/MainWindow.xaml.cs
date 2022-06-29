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

namespace _01._2依赖属性
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
			stu = new Student();
			stu.SetBinding(Student.NameProperty,new Binding("Text") { Source=textBox1});
			textBox2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source=stu});
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(stu.GetValue(Student.NameProperty).ToString());
		}
	}

	public class Student : DependencyObject
	{
		//CLR属性包装器
		public string  Name 
		{ 
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}

		//依赖属性
		public static readonly DependencyProperty NameProperty =
			DependencyProperty.Register("Name", typeof(string), typeof(Student));

		//SetBinding包装
		public BindingExpressionBase SetBinding(DependencyProperty dp,BindingBase binding)
		{
			return BindingOperations.SetBinding(this, dp, binding);
		}
		//prodp 自动生成依赖属性声明
	}
}
