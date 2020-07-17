// <snippet6>
using System;
using System.IO;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void ReadFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string line = await sr.ReadToEndAsync();
                    ResultBlock.Text = line;
                }
            }
            catch (FileNotFoundException ex)
            {
                ResultBlock.Text = ex.Message;
            }
        }
    }
}
// </snippet6>
