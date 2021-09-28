// <snippet4>
using System;
using System.IO;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ExampleApplication
{
    public sealed partial class BlankPage : Page
    {
        public BlankPage()
        {
            this.InitializeComponent();
            CreateTestFile();
        }

        private async void CreateTestFile()
        {
            StorageFile newFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("testfile.txt");
            await FileIO.WriteTextAsync(newFile, "example content in file");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (StreamReader reader = new StreamReader(
                await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("testfile.txt")))
            {
                string contents = await reader.ReadToEndAsync();
                DisplayContentsBlock.Text = contents;
            }
        }
    }
}
// </snippet4>
