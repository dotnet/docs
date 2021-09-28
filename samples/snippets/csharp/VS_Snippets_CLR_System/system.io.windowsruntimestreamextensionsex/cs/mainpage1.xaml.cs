using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using System.Net.Http;
using Windows.Storage.Pickers;

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
