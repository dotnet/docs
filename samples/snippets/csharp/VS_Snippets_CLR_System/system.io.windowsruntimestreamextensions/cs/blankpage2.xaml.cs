// <snippet4>
using System;
using System.IO;
using System.Text;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ExampleApplication
{
    public sealed partial class BlankPage : Page
    {
        System.Text.UnicodeEncoding ue;
        byte[] bytesToWrite;
        byte[] bytesToAdd;
        int totalBytes;

        public BlankPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ue = new System.Text.UnicodeEncoding();
            bytesToWrite = ue.GetBytes("example text to write to memory stream");
            bytesToAdd = ue.GetBytes("text added through datawriter");
            totalBytes = bytesToWrite.Length + bytesToAdd.Length;
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] bytesRead = new byte[totalBytes];
            using (MemoryStream memStream = new MemoryStream(totalBytes))
            {
                await memStream.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);

                DataWriter writer = new DataWriter(memStream.AsOutputStream());
                writer.WriteBytes(bytesToAdd);
                await writer.StoreAsync();

                memStream.Seek(0, SeekOrigin.Begin);

                DataReader reader = new DataReader(memStream.AsInputStream());
                await reader.LoadAsync((uint)totalBytes);
                reader.ReadBytes(bytesRead);
                Results.Text = ue.GetString(bytesRead, 0, bytesRead.Length);
            }
        }
    }
}
// </snippet4>