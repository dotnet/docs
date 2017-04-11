using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace ObjectDataProviderSample
{
    public class DoubleToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            string strValue = value as string;
            if (strValue != null)
            {
                double result;
                bool converted = Double.TryParse(strValue, out result);
                if (converted)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
