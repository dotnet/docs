using System;
using System.Windows;

namespace CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void showDialog_Click(object sender, RoutedEventArgs e)
        {
            DialogBox dialogBox = new DialogBox();
            Nullable<bool> dialogResult = dialogBox.ShowDialog();
            MessageBox.Show(dialogResult.ToString());
        }
    }
}