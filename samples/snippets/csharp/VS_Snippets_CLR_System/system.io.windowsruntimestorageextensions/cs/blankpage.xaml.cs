// <snippet2>
using System;
using System.IO;
using System.Text;
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
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder contents = new StringBuilder();
            string nextLine;
            int lineCounter = 1;

            var openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile selectedFile = await openPicker.PickSingleFileAsync();

            using (StreamReader reader = new StreamReader(await selectedFile.OpenStreamForReadAsync()))
            {
                while ((nextLine = await reader.ReadLineAsync()) != null)
                {
                    contents.AppendFormat("{0}. ", lineCounter);
                    contents.Append(nextLine);
                    contents.AppendLine();
                    lineCounter++;
                    if (lineCounter > 3)
                    {
                        contents.AppendLine("Only first 3 lines shown.");
                        break;
                    }
                }
            }
            DisplayContentsBlock.Text = contents.ToString();
        }
    }
}
// </snippet2>
