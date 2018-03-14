using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample {
    public partial class FELoaded {
//<SnippetHandler>
        void OnLoad(object sender, RoutedEventArgs e)
        {
            Button b1 = new Button();
            b1.Content = "New Button";
            root.Children.Add(b1);
            b1.Height = 25;
            b1.Width = 200;
            b1.HorizontalAlignment = HorizontalAlignment.Left;
        }
//</SnippetHandler>
    }
}
