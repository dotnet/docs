// <SnippetStackPanelExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    public partial class StackpanelExample : Page
    {
        public StackpanelExample()
        {
            // Create two buttons
            Button myButton1 = new Button();
            myButton1.Content = "Button 1";
            Button myButton2 = new Button();
            myButton2.Content = "Button 2";

            // Create a StackPanel
            StackPanel myStackPanel = new StackPanel();

            // Add the buttons to the StackPanel
            myStackPanel.Children.Add(myButton1);
            myStackPanel.Children.Add(myButton2);

            this.Content = myStackPanel;
        }
    }
}
// </SnippetStackPanelExampleWholePage>