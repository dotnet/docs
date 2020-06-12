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
    //<Snippet4>
    public class MyConverter : IValueConverter
    {
        public object Convert(
          object o,
          Type type,
          object parameter,
          CultureInfo culture)
        {
            DateTime date = (DateTime)o;
            switch (culture.TwoLetterISOLanguageName)
            {
                case "en":
                    switch (type.Name)
                    {
                        case "String":
                            return "Today is " + date.ToString("F", culture);
                        case "Brush":
                            return Brushes.Blue;
                    }
                    break;
                case "es":
                    switch (type.Name)
                    {
                        case "String":
                            return "Hoy es " + date.ToString("F", culture);
                        case "Brush":
                            return Brushes.Orange;
                    }
                    break;
                case "de":
                    switch (type.Name)
                    {
                        case "String":
                            return "Heute ist " + date.ToString("F", culture);
                        case "Brush":
                            return Brushes.Green;
                    }
                    break;
                case "fr":
                    switch (type.Name)
                    {
                        case "String":
                            return "Aujourd'hui est " + date.ToString("F", culture);
                        case "Brush":
                            return Brushes.Red;
                    }
                    break;
            }
            return null;
        }

        public object ConvertBack(
          object o,
          Type type,
          object parameter,
          CultureInfo culture)
        {
            return null;
        }
    }
    //</Snippet4>
}