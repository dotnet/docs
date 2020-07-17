using System;
using System.ComponentModel;
using System.Windows;

namespace XAML
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool wasExplicitlyShutdown;

        void goodbyeWorldButton_Click(object sender, RoutedEventArgs e)
        {
            this.wasExplicitlyShutdown = true;
            Application.Current.Shutdown();
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!this.wasExplicitlyShutdown)
            {
                MessageBox.Show("You didn't press the button to explicitly shutdown! The application will just keep running.");
            }
        }
    }
}