using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // <snippet1>
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            // Create a file picker.
            FileOpenPicker picker = new FileOpenPicker();

            // Set properties on the file picker such as start location and the type
            // of files to display.
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add(".txt");

            // Show picker enabling user to pick one file.
            StorageFile result = await picker.PickSingleFileAsync();

            if (result != null)
            {
                try
                {
                    // Retrieve the stream. This method returns a IRandomAccessStreamWithContentType.
                    var stream = await result.OpenReadAsync();

                    // Convert the stream to a .NET stream using AsStream, pass to a
                    // StreamReader and read the stream.
                    using (StreamReader sr = new StreamReader(stream.AsStream()))
                    {
                        TextBlock1.Text = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    TextBlock1.Text = "Error occurred reading the file. " + ex.Message;
                }
            }
            else
            {
                TextBlock1.Text = "User did not pick a file";
            }
        }
        // </snippet1>
    }
}
