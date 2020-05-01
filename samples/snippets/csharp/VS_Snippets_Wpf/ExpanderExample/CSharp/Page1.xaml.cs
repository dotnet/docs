using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpanderDirectionExample
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : Page
    {
        // To use PageLoaded put Loaded="PageLoaded" in root element of .xaml file.
        // private void PageLoaded(object sender, EventArgs e) {}
        // Sample event handler:
        //<Snippet3>
        private void ChangeExpandDirection(object sender, RoutedEventArgs e)
        {
            if ((Boolean)ExpandDown.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Down;
            else if ((Boolean)ExpandUp.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Up;
            else if ((Boolean)ExpandLeft.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Left;
            else if ((Boolean)ExpandRight.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Right;

            //Expand myExpander so it is easier to see the effect of changing
            //the ExpandDirection property for My Expander
            myExpander.IsExpanded = true;
        }
        //</Snippet3>
    }
}