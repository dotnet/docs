// <snippetImports>
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using System.Net.Http;
using Windows.Storage.Pickers;
// </snippetImports>

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

    // <snippet2>
    private async void button2_Click(object sender, RoutedEventArgs e)
    {
         // Create an HttpClient and access an image as a stream.
        var client = new HttpClient();
        Stream stream = await client.GetStreamAsync("https://learn.microsoft.com/en-us/dotnet/images/hub/featured-1.png");
        // Create a .NET memory stream.
        var memStream = new MemoryStream();
         // Convert the stream to the memory stream, because a memory stream supports seeking.
        await stream.CopyToAsync(memStream);
         // Set the start position.
        memStream.Position = 0;
         // Create a new bitmap image.
        var bitmap = new BitmapImage();
         // Set the bitmap source to the stream, which is converted to a IRandomAccessStream.
        bitmap.SetSource(memStream.AsRandomAccessStream());
         // Set the image control source to the bitmap.
        image1.Source = bitmap;
    }
    // </snippet2>
}
