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
    // One-way conversion between Luminance and Brush - used to draw text in
    // a color tile using a color that contrasts with the background

    public class LuminanceToBrushConverter : IValueConverter
    {
        object IValueConverter.Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            double luminance = (double)o;
            return (luminance < 0.5) ? Brushes.White : Brushes.Black;
        }

        object IValueConverter.ConvertBack(object o, Type type, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
