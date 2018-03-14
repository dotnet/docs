// <SnippetBasicBorderCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class BasicBorderExample : Page
    {
        public BasicBorderExample()
        {

            TextBox myTextBox = new TextBox();

            // Put some initial text in the TextBox.
            myTextBox.Text = "TextBox with a black Border around it";

            // Create a Border
            Border myBorder = new Border();
            myBorder.BorderThickness = new Thickness(20);
            myBorder.BorderBrush = Brushes.Black;

            // Add TextBox to the Border.
            myBorder.Child = myTextBox;
            // myStackPanel.Children.Add(myTextBox);
            this.Content = myBorder; 
        }
    }
}
// </SnippetBasicBorderCodeExampleWholePage>