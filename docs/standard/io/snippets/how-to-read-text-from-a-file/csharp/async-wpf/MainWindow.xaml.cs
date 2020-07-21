using System;
using System.IO;
using System.Windows;

namespace TextFiles
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

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    string fileContent = await sr.ReadToEndAsync();
                    ResultBlock.Text = fileContent;
                }
            }
            catch (FileNotFoundException ex)
            {
                ResultBlock.Text = ex.Message;
            }
        }
    }
}
