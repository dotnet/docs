using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Markup;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SDKSamples
{
    class InitializeElements : Application
    {
//<SnippetMain>
        [STAThread]
        static void Main(string[] args)
        {
            UIElement e;
            string file = Directory.GetCurrentDirectory() + "\\starting.xaml";
            using (Stream stream = File.Open(file, FileMode.Open))
            {
                // loading files from current directory, project settings take care of copying the file
                ParserContext pc = new ParserContext();
                pc.BaseUri = new Uri(file, UriKind.Absolute);
                e = (UIElement)XamlReader.Load(stream, pc);
            }

            Size paperSize = new Size(8.5 * 96, 11 * 96);
            e.Measure(paperSize);
            e.Arrange(new Rect(paperSize));
            e.UpdateLayout();

            /*
             *   Render effect at normal dpi, indicator is the original RED rectangle
             */
            RenderTargetBitmap image1 = Rasterize(e, paperSize.Width, paperSize.Height, 96, 96);
            Save(image1, "render1.png");

            Button b = new Button();
            b.BeginInit();
            b.Background = Brushes.Blue;
            b.Width = b.Height = 200;
            b.EndInit();
            b.Measure(paperSize);
            b.Arrange(new Rect(paperSize));
            b.UpdateLayout();

            // now render the altered version, with the element built up and initialized

            RenderTargetBitmap image2 = Rasterize(b, paperSize.Width, paperSize.Height, 96, 96);
            Save(image2, "render2.png");
        }
//</SnippetMain>

        private static RenderTargetBitmap Rasterize(Visual visual, double width, double height, double dpiX, double dpiY)
        {
            int pixelWidth = (int)(width * dpiX / 96);
            int pixelHeight = (int)(height * dpiY / 96);

            RenderTargetBitmap bi = new RenderTargetBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Pbgra32);


            Rectangle rect = new Rectangle();
            rect.Width = width;
            rect.Height = height;
            rect.Fill = Brushes.White;
            rect.Measure(new Size(width, height));
            rect.Arrange(new Rect(0, 0, width, height));
            bi.Render(rect);
            bi.Render(visual);

            return bi;
        }

        private static void Save(BitmapSource id, string filename)
        {
            BitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(id));

            Stream imageStreamDest = new System.IO.FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None);

            encoder.Save(imageStreamDest);

            imageStreamDest.Close();

            Console.WriteLine("Saved {0}", filename);
        }
    }
}


