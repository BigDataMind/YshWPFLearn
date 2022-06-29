using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace _14.数据校验
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Binding binding = new Binding("Value")
			{
				Source = this.slider1
			};
			binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
			RangeVaildationRule rvr = new RangeVaildationRule();
			rvr.ValidatesOnTargetUpdated = true; //Source数据校验
			binding.ValidationRules.Add(rvr);
			this.textBox1.SetBinding(TextBox.TextProperty, binding);
		}
	}

	//数据校验
	public class RangeVaildationRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			double d = 0;
			if (double.TryParse(value.ToString(),out d))
			{
				if (d >=0 && d<=100)
				{
					return new ValidationResult(true, null);
				}
			}
			return new ValidationResult(false, "Validation Failed");
		}
	}
}
