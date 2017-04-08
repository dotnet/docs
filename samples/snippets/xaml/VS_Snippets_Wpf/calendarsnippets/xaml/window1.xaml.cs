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

namespace CalendarSnippets_Xaml
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

        private void Calendar_DisplayModeChanged(object sender, 
                                                 CalendarModeChangedEventArgs e)
        {
            Calendar calObj = sender as Calendar;

            calObj.DisplayMode = CalendarMode.Year;
        }

        private void calendar1_Loaded(object sender, RoutedEventArgs e)
        {
            Calendar cal = sender as Calendar;
            cal.BlackoutDates.AddDatesInPast();
        }
    }
}
