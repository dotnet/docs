
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
 
    public partial class DetectSelectedTextExample : Page
    {

        void ChangeSelectedText(object sender, RoutedEventArgs e)
        {
            TextSelection currentSelection = richTB.Selection;
            currentSelection.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Yellow); 
        }
    }
}
