using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void newWindowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetWindowShowCODE>
            // Initialize window
            Window window = new Window();

            // Show window modelessly
            // NOTE: Returns without waiting for window to close
            window.Show();
            //</SnippetWindowShowCODE>
        }
    }
}