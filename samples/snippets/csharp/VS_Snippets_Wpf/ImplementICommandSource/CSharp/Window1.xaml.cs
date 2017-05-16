using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Globalization;

namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public static RoutedCommand FontUpdateCommand = new RoutedCommand();

        public Window1()
        {
            InitializeComponent();
        }

        // The ExecutedRoutedEvent Handler
        // If the command target is the TextBox, changes the fontsize to that
        // Of the value passed in through the Command Parameter
        private void SliderUpdateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TextBox source = sender as TextBox;
           
            if (source != null)
            {
                if (e.Parameter != null)
                {
                    try
                    {
                        if ((int)e.Parameter > 0 && (int)e.Parameter <= 60)
                        {
                            source.FontSize = (int)e.Parameter;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("in Command \n Parameter: " + e.Parameter);
                    }

                }
            }
        }

        // The CanExecuteRoutedEvent Handler
        // If the Command Source is a TextBox, then set CanExecute to ture;
        // Otherwise, set it to false
        private void SliderUpdateCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            TextBox source = sender as TextBox;

            if (source != null)
            {
                if (source.IsReadOnly)
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute = true;
                }

            }
        }

        // If the Readonly Box is checked, we need to force the CommandManager
        // To raise the RequerySuggested event.  This will cause the Command Source
        // To query the command to see if it can execute or not.
        private void OnReadOnlyChecked(object sender, RoutedEventArgs e)
        {
            if (txtBoxTarget != null)
            {
                txtBoxTarget.IsReadOnly = true;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        // If the Readonly Box is checked, we need to force the CommandManager
        // To raise the RequerySuggested event.  This will cause the Command Source
        // To query the command to see if it can execute or not.
        private void OnReadOnlyUnChecked(object sender, RoutedEventArgs e)
        {
            if (txtBoxTarget != null)
            {
                txtBoxTarget.IsReadOnly = false;
                this.UpdateLayout();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        // CanExecute handler for the IncreaseSamll and DescreaseSmall commands.
        // Disables the command sources if the Slider is disabled.  
        private void IncreaseDecreaseCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Slider target = e.Source as Slider;
            if (target != null)
            {
                if (target.IsEnabled == true)
                {
                    e.CanExecute = true;
                    e.Handled = true;
                }
                else
                {
                    e.CanExecute = false;
                    e.Handled = true;
                }
            }
        }
    }


    // Converter to convert the Slider value property to an int.
    [ValueConversion(typeof(double), typeof(int))]
    public class FontStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fontSize = (string)value;
            int intFont;

            try
            {
                intFont = Int32.Parse(fontSize);
                return intFont;
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    
    // Converter to convert the Slider value property to an int.
    [ValueConversion(typeof(double), typeof(int))]
    public class FontDoubleValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double fontSize = (double)value;
            return (int)fontSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}