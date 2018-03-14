using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class FEMarginProgrammatic {
//<SnippetHandler>
        void OnClick(object sender, RoutedEventArgs e)
        {
            // Get the current value of the property.
            Thickness marginThickness = btn1.Margin;
            // If the current leftlength value of margin is set to 10 then change it to a new value.
            // Otherwise change it back to 10.
            if(marginThickness.Left == 10)
            {
                 btn1.Margin = new Thickness(60);
            } else {
                 btn1.Margin = new Thickness(10);
            }
        }
//</SnippetHandler>
    }
}
