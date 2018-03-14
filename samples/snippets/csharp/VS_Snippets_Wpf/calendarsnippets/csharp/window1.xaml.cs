using System;
using System.Windows;
using System.Windows.Controls;

namespace CalendarSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //<Snippet1>

            //<Snippet2>
            // Create a Calendar that displays 1/10/2009
            // through 4/18/2009.
            Calendar basicCalendar = new Calendar();
            basicCalendar.DisplayDateStart = new DateTime(2009, 1, 10);
            basicCalendar.DisplayDateEnd = new DateTime(2009, 4, 18);
            basicCalendar.DisplayDate = new DateTime(2009, 3, 15);
            basicCalendar.SelectedDate = new DateTime(2009, 2, 15);

            // root is a Panel that is defined elswhere.
            root.Children.Add(basicCalendar);
            //</Snippet2>

            //<Snippet3>
            // Create a Calendar that displays dates through
            // Januarary 31, 2009 and has dates that are not selectable.
            Calendar calendarWithBlackoutDates = new Calendar();
            calendarWithBlackoutDates.IsTodayHighlighted = false;
            calendarWithBlackoutDates.DisplayDate = new DateTime(2009, 1, 1);
            calendarWithBlackoutDates.DisplayDateEnd = new DateTime(2009, 1, 31);
            calendarWithBlackoutDates.SelectionMode = CalendarSelectionMode.MultipleRange;
          
            // Add the dates that are not selectable.
            calendarWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 1, 2), new DateTime(2009, 1, 4)));
            calendarWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 1, 9)));
            calendarWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 1, 16)));
            calendarWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 1, 23), new DateTime(2009, 1, 25)));
            calendarWithBlackoutDates.BlackoutDates.Add(
                new CalendarDateRange(new DateTime(2009, 1, 30)));

            // Add the selected dates.
            calendarWithBlackoutDates.SelectedDates.Add(
                new DateTime(2009, 1, 5));
            calendarWithBlackoutDates.SelectedDates.AddRange(
                new DateTime(2009, 1, 12), new DateTime(2009, 1, 15));
            calendarWithBlackoutDates.SelectedDates.Add(
                new DateTime(2009, 1, 27));

            // root is a Panel that is defined elswhere.
            root.Children.Add(calendarWithBlackoutDates);
            //</Snippet3>

            //</Snippet1>

            //<Snippet4>
            Calendar yearCalendar = new Calendar();
            yearCalendar.DisplayMode = CalendarMode.Year;
            yearCalendar.DisplayModeChanged +=
                new EventHandler<CalendarModeChangedEventArgs>(Calendar_DisplayModeChanged);

            // root is a Panel that is defined elswhere.
            root.Children.Add(yearCalendar);
            //</Snippet4>

        }

        //<Snippet5>
        private void Calendar_DisplayModeChanged(object sender,
                                                 CalendarModeChangedEventArgs e)
        {
            Calendar calObj = sender as Calendar;

            calObj.DisplayMode = CalendarMode.Year;
        }
        //</Snippet5>

        //<Snippet7>
        private void calendar1_Loaded(object sender, RoutedEventArgs e)
        {
            Calendar cal = sender as Calendar;
            cal.BlackoutDates.AddDatesInPast();
        }
        //</Snippet7>

    }
}
