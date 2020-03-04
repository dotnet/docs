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
    public class NumberDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NumberTemplate { get; set; }
        public DataTemplate LargeNumberTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // Null value can be passed by IDE designer
            if (item == null) return null;

            var num = Convert.ToInt32((string)item);
            
            // Select one of the DataTemplate objects, based on the 
            // value of the selected item in the ComboBox.
            if (num < 5)
            {
                return NumberTemplate;
            }
            else
            {
                return LargeNumberTemplate;
            }
        }
    }
    //</Snippet2>
}