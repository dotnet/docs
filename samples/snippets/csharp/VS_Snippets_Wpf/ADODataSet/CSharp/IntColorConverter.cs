using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;

namespace SDKSample
{
    public class IntColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int numValue = (int)value;
            if (numValue < 350)
                return System.Windows.Media.Brushes.Green;
            else
                return System.Windows.Media.Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
