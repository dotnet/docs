using System;
using System.Windows;

namespace CSharp
{

    public partial class Show2Window : Window
    {

        public Show2Window()
        {
            InitializeComponent();
        }

        //<SnippetMessageBoxShow2CODE>
        private void ShowMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure message box
            string message = "Message text";
            string caption = "Caption text";
            // Show message box
            MessageBoxResult result = MessageBox.Show(message, caption);
        }
        //</SnippetMessageBoxShow2CODE>
    }
}
