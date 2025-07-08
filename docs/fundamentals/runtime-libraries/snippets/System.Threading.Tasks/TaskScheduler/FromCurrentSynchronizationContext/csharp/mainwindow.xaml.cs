// <Snippet01>
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_CS1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int fileCount;
        int colCount;
        int rowCount;
        private int tilePixelHeight;
        private int tilePixelWidth;
        private int largeImagePixelHeight;
        private int largeImagePixelWidth;
        private int largeImageStride;
        PixelFormat format;
        BitmapPalette palette = null;

        public MainWindow()
        {
            InitializeComponent();

            // For this example, values are hard-coded to a mosaic of 8x8 tiles.
            // Each tile is 50 pixels high and 66 pixels wide and 32 bits per pixel.
            colCount = 12;
            rowCount = 8;
            tilePixelHeight = 50;
            tilePixelWidth = 66;
            largeImagePixelHeight = tilePixelHeight * rowCount;
            largeImagePixelWidth = tilePixelWidth * colCount;
            largeImageStride = largeImagePixelWidth * (32 / 8);
            this.Width = largeImagePixelWidth + 40;
            image.Width = largeImagePixelWidth;
            image.Height = largeImagePixelHeight;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            // For best results use 1024 x 768 jpg files at 32bpp.
            string[] files = System.IO.Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures\", "*.jpg");

            fileCount = files.Length;
            Task<byte[]>[] images = new Task<byte[]>[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                int x = i;
                images[x] = Task.Factory.StartNew(() => LoadImage(files[x]));
            }

            // When they've all been loaded, tile them into a single byte array.
            var tiledImage = Task.Factory.ContinueWhenAll(
                images, (i) => TileImages(i));

            // We are currently on the UI thread. Save the sync context and pass it to
            // the next task so that it can access the UI control "image".
            var UISyncContext = TaskScheduler.FromCurrentSynchronizationContext();

            // On the UI thread, put the bytes into a bitmap and
            // display it in the Image control.
            var t3 = tiledImage.ContinueWith((antecedent) =>
            {
                // Get System DPI.
                Matrix m = PresentationSource.FromVisual(Application.Current.MainWindow)
                                            .CompositionTarget.TransformToDevice;
                double dpiX = m.M11;
                double dpiY = m.M22;

                BitmapSource bms = BitmapSource.Create(largeImagePixelWidth,
                    largeImagePixelHeight,
                    dpiX,
                    dpiY,
                    format,
                    palette, //use default palette
                    antecedent.Result,
                    largeImageStride);
                image.Source = bms;
            }, UISyncContext);
        }

        byte[] LoadImage(string filename)
        {
            // Use the WPF BitmapImage class to load and
            // resize the bitmap. NOTE: Only 32bpp formats are supported correctly.
            // Support for additional color formats is left as an exercise
            // for the reader. For more information, see documentation for ColorConvertedBitmap.

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(filename);
            bitmapImage.DecodePixelHeight = tilePixelHeight;
            bitmapImage.DecodePixelWidth = tilePixelWidth;
            bitmapImage.EndInit();

            format = bitmapImage.Format;
            int size = (int)(bitmapImage.Height * bitmapImage.Width);
            int stride = (int)bitmapImage.Width * 4;
            byte[] dest = new byte[stride * tilePixelHeight];

            bitmapImage.CopyPixels(dest, stride, 0);

            return dest;
        }

        int Stride(int pixelWidth, int bitsPerPixel)
        {
            return (((pixelWidth * bitsPerPixel + 31) / 32) * 4);
        }

        // Map the individual image tiles to the large image
        // in parallel. Any kind of raw image manipulation can be
        // done here because we are not attempting to access any
        // WPF controls from multiple threads.
        byte[] TileImages(Task<byte[]>[] sourceImages)
        {
            byte[] largeImage = new byte[largeImagePixelHeight * largeImageStride];
            int tileImageStride = tilePixelWidth * 4; // hard coded to 32bpp

            Random rand = new Random();
            Parallel.For(0, rowCount * colCount, (i) =>
            {
                // Pick one of the images at random for this tile.
                int cur = rand.Next(0, sourceImages.Length);
                byte[] pixels = sourceImages[cur].Result;

                // Get the starting index for this tile.
                int row = i / colCount;
                int col = (int)(i % colCount);
                int idx = ((row * (largeImageStride * tilePixelHeight)) + (col * tileImageStride));

                // Write the pixels for the current tile. The pixels are not contiguous
                // in the array, therefore we have to advance the index by the image stride
                // (minus the stride of the tile) for each scanline of the tile.
                int tileImageIndex = 0;
                for (int j = 0; j < tilePixelHeight; j++)
                {
                    // Write the next scanline for this tile.
                    for (int k = 0; k < tileImageStride; k++)
                    {
                        largeImage[idx++] = pixels[tileImageIndex++];
                    }
                    // Advance to the beginning of the next scanline.
                    idx += largeImageStride - tileImageStride;
                }
            });
            return largeImage;
        }
    }
}
// </Snippet01>
