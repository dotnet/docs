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

    // One-way conversion between ColorItem.Source and bool -
    // used to disable editing for builtin colors

    public class SourceToBoolConverter : IValueConverter
    {
        object IValueConverter.Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            ColorItem.Sources source = (ColorItem.Sources)o;
            return (source != ColorItem.Sources.BuiltIn);
        }

        object IValueConverter.ConvertBack(object o, Type type, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
