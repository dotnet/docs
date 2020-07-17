using System;
using System.Windows;

namespace CSharp
{

    public partial class Show5Window : Window
    {

        public Show5Window()
        {
            InitializeComponent();
        }

        //<SnippetMessageBoxShow5CODE>
        private void ShowMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure message box
            string message = "Hello, MessageBox!";
            string caption = "Caption text";
            MessageBoxButton buttons = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult defaultResult = MessageBoxResult.OK;
            // Show message box
            MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon, defaultResult);
        }
        //</SnippetMessageBoxShow5CODE>
    }
}
