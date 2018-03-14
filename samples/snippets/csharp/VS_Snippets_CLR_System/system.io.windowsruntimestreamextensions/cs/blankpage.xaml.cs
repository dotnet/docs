// <snippet2>
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
            StorageFile newFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("testfile.txt");
            var streamNewFile = await newFile.OpenAsync(FileAccessMode.ReadWrite);

            using (var outputNewFile = streamNewFile.GetOutputStreamAt(0))
            {
                using (StreamWriter writer = new StreamWriter(outputNewFile.AsStreamForWrite()))
                {
                    await writer.WriteLineAsync("content for new file");
                    await writer.WriteLineAsync(UserText.Text);
                }
            }
        }

        private async void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile openedFile = await ApplicationData.Current.LocalFolder.GetFileAsync("testfile.txt");
            var streamOpenedFile = await openedFile.OpenAsync(FileAccessMode.Read);

            using (var inputOpenedFile = streamOpenedFile.GetInputStreamAt(0))
            {
                using (StreamReader reader = new StreamReader(inputOpenedFile.AsStreamForRead()))
                {
                    Results.Text = await reader.ReadToEndAsync();
                }
            }
        }
    }
}
// </snippet2>
