using System;
using System.Globalization;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Data;
using System.Windows.Media;

namespace SDKSample
{
  //<Snippet2>
  public class MyConverter : IValueConverter
  {
    public object Convert(object o, Type type,
        object parameter, CultureInfo culture)
    {
        DateTime date = (DateTime)o;
        switch (type.Name)
        {
            case "String":
                return date.ToString("F", culture);
            case "Brush":
                return Brushes.Red;
            default:
                return o;
      }
    }
      public object ConvertBack(object o, Type type,
          object parameter, CultureInfo culture)
      {
          return null;
      }
  }
  //</Snippet2>
}
