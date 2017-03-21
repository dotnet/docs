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

        void openDialog_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetWindowShowDialogCODE>
            // Instantiate window
            DialogBox dialogBox = new DialogBox();

            // Show window modally
            // NOTE: Returns only when window is closed
            Nullable<bool> dialogResult = dialogBox.ShowDialog();
            //</SnippetWindowShowDialogCODE>
        }
    }
}