//<SnippetCodeWindow>
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    public class CodeWindow : Window
    {
        public CodeWindow()
        {
            this.Title = "WPF Window with Button";

            // Create button
            Button button = new Button();
            button.Content = "Click Me!";

            // Add button to window
            this.Content = button;

            // Register event handler with button click event
            button.Click += new RoutedEventHandler(button_Click);
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Show message box when button is clicked
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}
//</SnippetCodeWindow>