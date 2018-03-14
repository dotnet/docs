using System.Windows;
using System.Windows.Controls;

namespace SDKSample {
//<SnippetHandler>
    public partial class RoutedEventAddRemoveHandler {
        void MakeButton(object sender, RoutedEventArgs e)
        {
            Button b2 = new Button();
            b2.Content = "New Button";
            // Associate event handler to the button. You can remove the event 
            // handler using "-=" syntax rather than "+=".
            b2.Click  += new RoutedEventHandler(Onb2Click);
            root.Children.Insert(root.Children.Count, b2);
            DockPanel.SetDock(b2, Dock.Top);
            text1.Text = "Now click the second button...";
            b1.IsEnabled = false;
        }
        void Onb2Click(object sender, RoutedEventArgs e)
        {
            text1.Text = "New Button (b2) Was Clicked!!";
        }
//</SnippetHandler>
    }
}