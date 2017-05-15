using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ContentControlNew
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();

        }


    }

    //<Snippet2>
    public class NumderDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string numberStr = item as string;

            if (numberStr != null)
            {
                int num;
                Window win = Application.Current.MainWindow;

                try
                {
                    num = Convert.ToInt32(numberStr);
                }
                catch
                {
                    return null;
                }

                // Select one of the DataTemplate objects, based on the 
                // value of the selected item in the ComboBox.
                if (num < 5)
                {
                    return win.FindResource("numberTemplate") as DataTemplate;
                }
                else
                {
                    return win.FindResource("largeNumberTemplate") as DataTemplate;

                }
            }

            return null;
        }

    }
    //</Snippet2>
}