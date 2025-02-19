﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GUI_04_02.Helpers
{
	internal class NumberToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double number = double.Parse(value.ToString());
			if (number <= 3)
			{
				return Brushes.Red;
			}
			else if (number <= 5)
			{
				return Brushes.Yellow;
			}
			else
			{
				return Brushes.Green;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
