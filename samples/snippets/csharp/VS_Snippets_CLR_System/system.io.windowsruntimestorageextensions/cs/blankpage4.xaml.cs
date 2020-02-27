// <snippet8>
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
            using (StreamWriter writer = 
                new StreamWriter(await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                "testfile.txt",  CreationCollisionOption.OpenIfExists)))
            {
                await writer.WriteLineAsync("new entry");
                await writer.WriteLineAsync(UserText.Text);
            }
        }

        private async void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            StorageFile openedFile = await ApplicationData.Current.LocalFolder.GetFileAsync("testfile.txt");
            using (StreamReader reader = new StreamReader(await openedFile.OpenStreamForReadAsync()))
            {
                Results.Text = await reader.ReadToEndAsync();
            }
        }
    }
}
// </snippet8>