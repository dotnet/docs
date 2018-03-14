// <snippet6>
using System;
using System.Windows;
using System.IO;

namespace WpfApplication
{
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
                    String line = await sr.ReadToEndAsync();
                    ResultBlock.Text = line;
                }
            }
            catch (Exception ex)
            {
                ResultBlock.Text = "Could not read the file";
            }
        }
    }
}
// </snippet6>
