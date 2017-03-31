using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;


namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {}

    public class myDateCollection :
            ObservableCollection<DateTime>
    {
        public myDateCollection()
        {
            Add(new DateTime(2005, 1, 1));
            Add(new DateTime(2004, 8, 1));
            Add(new DateTime(2003, 12, 4));
            Add(new DateTime(2004, 2, 18));
            Add(new DateTime(2004, 6, 30));
        }
    }
    }
