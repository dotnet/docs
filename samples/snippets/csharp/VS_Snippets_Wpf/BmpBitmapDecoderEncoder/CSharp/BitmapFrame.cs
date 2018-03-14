using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Security;

[assembly: SecurityTransparent] 

namespace SDKSample
{
    public class app : Application
    {
        Window mainWindow;
        
        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        
        private void CreateAndShowMainWindow ()
        {

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "BMP Imaging Sample";
            ScrollViewer mySV = new ScrollViewer();

            //<Snippet4>
            int width = 128;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            // Try creating a new image with a custom palette.
            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            colors.Add(System.Windows.Media.Colors.Red);
            colors.Add(System.Windows.Media.Colors.Blue);
            colors.Add(System.Windows.Media.Colors.Green);
            BitmapPalette myPalette = new BitmapPalette(colors);

            // Creates a new empty image with the pre-defined palette
			//<SnippetBmpEncoder>
            //<Snippet2>
            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);
            //</Snippet2>

            //<Snippet3>
            FileStream stream = new FileStream("new.bmp", FileMode.Create);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            //</Snippet3>
			//</SnippetBmpEncoder>

            //</Snippet4>

            //<Snippet1>

            // Open a Stream and decode a BMP image
            Stream imageStreamSource = new FileStream("tulipfarm.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
            BmpBitmapDecoder decoder = new BmpBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            
            // Draw the Image
            Image myImage = new Image();
            myImage.Source = bitmapSource;
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(20);
            //</Snippet1>

            //<Snippet5>

            // Open a Uri and decode a BMP image
            Uri myUri = new Uri("tulipfarm.bmp", UriKind.RelativeOrAbsolute);
            BmpBitmapDecoder decoder2 = new BmpBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource2 = decoder2.Frames[0];

            // Draw the Image
            Image myImage2 = new Image();
            myImage2.Source = bitmapSource2;
            myImage2.Stretch = Stretch.None;
            myImage2.Margin = new Thickness(20);
            //</Snippet5>

            // Define a StackPanel to host the decoded BMP images
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            
            // Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage); 
            myStackPanel.Children.Add(myImage2);
            myStackPanel.Children.Add(myTextBlock);

            // Add the StackPanel as the Content of the Parent Window Object
            mySV.Content = myStackPanel;
            mainWindow.Content = mySV;
            mainWindow.Show();
        }
    }

    // Define a static entry class
    internal static class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {
            app app = new app ();
            app.Run ();
        }
    }
}