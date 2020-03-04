// <snippet6>
using System;
using System.IO;
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
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile newFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("testfile3.txt");
            
            using (StreamWriter writer = new StreamWriter(await newFile.OpenStreamForWriteAsync()))
            {
                await writer.WriteLineAsync("new entry");
                await writer.WriteLineAsync(UserText.Text);
            }
        }

        private async void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile openedFile = await ApplicationData.Current.LocalFolder.GetFileAsync("testfile3.txt");
            using (StreamReader reader = new StreamReader(await openedFile.OpenStreamForReadAsync()))
            {
                Results.Text = await reader.ReadToEndAsync();
            }
        }
    }
}
// </snippet6>