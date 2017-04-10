using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            int exitCode = (this.successRadioButton.IsChecked == true ? 0 : 1);
            Application.Current.Shutdown(exitCode);

            //<SnippetAppExitCODE>
            // Shutdown and return a non-default exit code
            Application.Current.Shutdown(-1);
            //</SnippetAppExitCODE>
        }
    }
}