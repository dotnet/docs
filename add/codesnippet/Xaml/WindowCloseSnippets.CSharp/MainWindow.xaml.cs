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
        //<SnippetWindowCloseCODEBEHIND>
        void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Close this window
            this.Close();
        }
        //</SnippetWindowCloseCODEBEHIND>
    }
}