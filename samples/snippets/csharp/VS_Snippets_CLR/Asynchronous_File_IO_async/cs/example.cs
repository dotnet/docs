//<snippet1>
using System;
using System.Threading.Tasks;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string startDirectory = @"c:\Users\exampleuser\start";
            string endDirectory = @"c:\Users\exampleuser\end";

            foreach (string filename in Directory.EnumerateFiles(startDirectory))
            {
                using (FileStream sourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream destinationStream = File.Create(Path.Combine(endDirectory, Path.GetFileName(filename))))
                    {
                        await sourceStream.CopyToAsync(destinationStream);
                    }
                }
            }
        }
    }
}
//</snippet1>
