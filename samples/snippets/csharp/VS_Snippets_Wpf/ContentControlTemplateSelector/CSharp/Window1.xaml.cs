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
        public DataTemplate NumberTemplate { get; set; }
        public DataTemplate LargeNumberTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //null value will be used in design mode
            if (item == null) return null;

            if (!(item is string numberStr))
                throw new ArgumentNullException(nameof(item),
                    "This TemplateSelector can be used to format strings only");

            int num;
            try
            {
                num = Convert.ToInt32(numberStr);
            }
            catch (FormatException formatException)
            {
                throw new FormatException(
                    "All strings must be convertible to numbers only", formatException);
            }

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