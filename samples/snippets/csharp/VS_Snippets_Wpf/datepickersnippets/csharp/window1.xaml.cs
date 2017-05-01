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

            Snippet1();
            InitializeDatePicker();
        }

        private void Snippet1()
        {
            //<Snippet1>
            DatePicker datePickerFor2009 = new DatePicker();
            datePickerFor2009.SelectedDate = new DateTime(2009, 3, 23);
            datePickerFor2009.DisplayDateStart = new DateTime(2009, 1, 1);
            datePickerFor2009.DisplayDateEnd = new DateTime(2009, 12, 31);
            datePickerFor2009.SelectedDateFormat = DatePickerFormat.Long;
            datePickerFor2009.FirstDayOfWeek = DayOfWeek.Monday;

            // root is a Panel that is defined elsewhere.
            root.Children.Add(datePickerFor2009);
            //</Snippet1>

        }

        private void InitializeDatePicker()
        {

            //<Snippet2>
            DatePicker datePickerWithBlackoutDates = new DatePicker();

            datePickerWithBlackoutDates.DisplayDateStart = new DateTime(2009, 8, 1);
            datePickerWithBlackoutDates.DisplayDateEnd = new DateTime(2009, 8, 31);
            datePickerWithBlackoutDates.SelectedDate = new DateTime(2009, 8, 10);

            datePickerWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 8, 1), new DateTime(2009, 8, 2)));
            datePickerWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 8, 8), new DateTime(2009, 8, 9)));
            datePickerWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 8, 15), new DateTime(2009, 8, 16)));
            datePickerWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 8, 22), new DateTime(2009, 8, 23)));
            datePickerWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 8, 29), new DateTime(2009, 8, 30)));

            datePickerWithBlackoutDates.DateValidationError +=
                new EventHandler<DatePickerDateValidationErrorEventArgs>(DatePicker_DateValidationError);

            // root is a Panel that is defined elsewhere.
            root.Children.Add(datePickerWithBlackoutDates);
            //</Snippet2>

        }

        //<Snippet3>
        // If the text is a valid date, but a part of the 
        // BlackoutDates collection, show a message.
        // If the text is not a valid date, thow an exception.
        private void DatePicker_DateValidationError(object sender,
                        DatePickerDateValidationErrorEventArgs e)
        {
            DateTime newDate;
            DatePicker datePickerObj = sender as DatePicker;

            if (DateTime.TryParse(e.Text, out newDate))
            {
                if (datePickerObj.BlackoutDates.Contains(newDate))
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
        //</Snippet3>

        //<Snippet8>
        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Select a date from the calendar";
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Enter a date or click the calendar";
        }
        //</Snippet8>

        
    }
}
