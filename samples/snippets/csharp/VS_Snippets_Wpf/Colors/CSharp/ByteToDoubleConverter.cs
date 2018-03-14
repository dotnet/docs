using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SDKSample
{
    // Two-way conversion between byte and double (TypeConverter for double should provide this)

    public class ByteToDoubleConverter : IValueConverter
    {
        object IValueConverter.Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            return Convert.ChangeType(o, typeof(double));
        }

        object IValueConverter.ConvertBack(object o, Type type, object parameter, CultureInfo culture)
        {
            double d = (double)o;
            return (d < 0.0) ? (byte)0 : (d > 255.0) ? (byte)255 :
              Convert.ChangeType(o, typeof(byte));
        }
    }
}
