using System.Windows;
using System.Windows.Controls;

namespace SDKSample {
    public partial class RoutedEventSource {
//<SnippetHandler>
        void HandleClick(object sender, RoutedEventArgs e)
        {
            // You must cast the sender object as a Button element, or at least as FrameworkElement, to set Width
            Button srcButton = e.Source as Button;
			srcButton.Width = 200;
        }
//</SnippetHandler>
    }
}