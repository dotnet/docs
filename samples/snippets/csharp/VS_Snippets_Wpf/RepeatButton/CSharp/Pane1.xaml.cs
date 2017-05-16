using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace RepeatButtons
{
    public partial class Pane1 : DockPanel
    {

        //<Snippet2>
        void Increase(object sender, RoutedEventArgs e)
        {
            Int32 Num = Convert.ToInt32(valueText.Text);

            valueText.Text = ((Num + 1).ToString());
        }

        void Decrease(object sender, RoutedEventArgs e)
        {
            Int32 Num = Convert.ToInt32(valueText.Text);

            valueText.Text = ((Num - 1).ToString());
        }
        //</Snippet2>
    }
}