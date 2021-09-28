using System;
using System.ComponentModel;
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

        private void Show1(object sender, RoutedEventArgs e)
        {
            new Show1Window().ShowDialog();
        }
        private void Show2(object sender, RoutedEventArgs e)
        {
            new Show2Window().ShowDialog();
        }
        private void Show3(object sender, RoutedEventArgs e)
        {
            new Show3Window().ShowDialog();
        }
        private void Show4(object sender, RoutedEventArgs e)
        {
            new Show4Window().ShowDialog();
        }
        private void Show5(object sender, RoutedEventArgs e)
        {
            new Show5Window().ShowDialog();
        }
        private void Show6(object sender, RoutedEventArgs e)
        {
            new Show6Window().ShowDialog();
        }
    }
}
