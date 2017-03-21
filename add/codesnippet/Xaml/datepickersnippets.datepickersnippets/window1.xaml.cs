using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatePickerSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


        //Snippet 3 in CS and VB.

        // If the text is a valid date, but a part of the 
        // BlackoutDates collection, show a message.
        // If the texxt is not a valid date, thow an exception.
        private void DatePicker_DateValidationError(object sender, 
                        DatePickerDateValidationErrorEventArgs e)
        {
            DateTime newDate;

            if (DateTime.TryParse(e.Text, out newDate))
            {
                if (datePickerWithBlackoutDates.BlackoutDates.Contains(newDate))
                {
                    MessageBox.Show(String.Format("The date, {0}, cannot be selected.", 
                                                   e.Text));
                }
            }
            else
            {
                e.ThrowException = true;
            }
        }

        //Snippet 8 in cs and vb
        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Select a date from the calendar";
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Enter a date or click the calendar";
        }
    }
}
