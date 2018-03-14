// <snippet3>
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            string filename = @"c:\Users\exampleuser\Documents\userinputlog.txt";
           
            byte[] result = uniencoding.GetBytes(UserInput.Text);
            
            using (FileStream SourceStream = File.Open(filename, FileMode.OpenOrCreate))
            {
                SourceStream.Seek(0, SeekOrigin.End);
                await SourceStream.WriteAsync(result, 0, result.Length);
            }
        }
    }
}
// </snippet3>
