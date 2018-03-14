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
using System.Collections.ObjectModel;

namespace DataGrid_TemplateColumn
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            ObservableCollection<DateInfo> myDates = new ObservableCollection<DateInfo>();

            myDates.Add(new DateInfo(new DateTime(1999, 3, 23)));
            myDates.Add(new DateInfo(new DateTime(1945, 7, 14)));
            myDates.Add(new DateInfo(new DateTime(2005, 9, 2)));
            myDates.Add(new DateInfo(new DateTime(1899, 1, 8)));
            myDates.Add(new DateInfo(new DateTime(1983, 6, 20)));

            DG1.DataContext = myDates;
        }
    }

    public class DateInfo
    {
        public DateInfo()
        {
        }

        public DateInfo(DateTime date)
        {
            PublishDate = date;
        }

        public DateTime PublishDate { get; set; }

    }
}
