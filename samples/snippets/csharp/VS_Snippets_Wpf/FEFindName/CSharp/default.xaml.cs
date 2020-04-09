using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class FEFindName {
//<SnippetFind>
        void Find(object sender, RoutedEventArgs e)
        {
            object wantedNode = stackPanel.FindName("dog");
            if (wantedNode is TextBlock)
            {
                // Following executed if Text element was found.
                TextBlock wantedChild = wantedNode as TextBlock;
                wantedChild.Foreground = Brushes.Blue;
            }
        }
//</SnippetFind>
    }
}
