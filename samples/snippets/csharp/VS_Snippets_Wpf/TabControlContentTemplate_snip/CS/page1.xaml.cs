using System;
using System.Windows;
using System.Windows.Controls;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TabControl
{


    public partial class Page1 : Window
    {
        public Page1()
            : base()
        {
            InitializeComponent(); 
        }

    }

    public class DateTimeDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DateTime)
            {
                DateTime date = (DateTime)item;
                DateTime year2000 = new DateTime(2000, 1, 1);

                Window win = Application.Current.MainWindow;

                if (date < year2000)
                {
                    return win.FindResource("lateDate") as DataTemplate;
                }
                else
                {
                    return win.FindResource("earlyDate") as DataTemplate;

                }
            }

            return null;
        }

    }


}
