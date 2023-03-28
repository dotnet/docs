using System.IO;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPApp2
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
            Image1.Source = bitmap;
        }
        // </snippet1>
    }
}
