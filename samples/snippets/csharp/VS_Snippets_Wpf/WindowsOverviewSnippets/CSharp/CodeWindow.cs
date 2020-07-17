using System;
using System.Windows.Controls;
using System.Windows;

namespace WindowsOverviewSnippetsCSharp
{
    public class CodeWindow : Window { }
}
namespace WindowsOverviewSnippetsCSharp.CodeWindow2
{
    public class CodeWindow : Window
    {
        public CodeWindow()
        {
            // Configure window
            this.Title = "Window";
            this.Width = 800;
            this.Height = 600;

            // Add content to the client area
            Button button = new Button();
            button.Content = "Window Content";
            button.Click += button_Click;
            this.Content = button;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button was clicked.");
        }
    }
}