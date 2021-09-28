using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
namespace SDKSample
{
    public partial class TextBoxExample : Page
    {
        public TextBoxExample()
        {
            // <SnippetTextBoxCodeExampleInline1>
            StackPanel myStackPanel = new StackPanel();

            //Create TextBox
            TextBox myTextBox = new TextBox();
            myTextBox.Width = 200;

            // Put some initial text in the TextBox.
            myTextBox.Text = "Initial text in TextBox";

            // Set the maximum characters a user can manually type
            // into the TextBox.
            myTextBox.MaxLength = 500;
            myTextBox.MinLines = 1;

            // Set the maximum number of lines the TextBox will expand to
            // accomidate text. Note: This does not constrain the amount of
            // text that can be typed. To do that, use the MaxLength property.
            myTextBox.MaxLines = 5;

            // The text typed into the box is aligned in the center.
            myTextBox.TextAlignment = TextAlignment.Center;

            // When the text reaches the edge of the box, go to the next line.
            myTextBox.TextWrapping = TextWrapping.Wrap;

            myStackPanel.Children.Add(myTextBox);
            this.Content = myStackPanel;
            // </SnippetTextBoxCodeExampleInline1>
        }
    }
}