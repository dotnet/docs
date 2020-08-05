using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Security.Permissions;
using System.Collections.ObjectModel;

namespace SDKSample
{
    public class MyApp : Application
    {
        Window mainWindow;

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private void CreateAndShowMainWindow ()
        {

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "Imaging Sample";
            ScrollViewer mySV = new ScrollViewer();

            //<Snippet1>
            int width = 128;
            int height = width;
            int stride = width/8;
            byte[] pixels = new byte[height*stride];

            // Try creating a new image with a custom palette.
            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            colors.Add(System.Windows.Media.Colors.Red);
            colors.Add(System.Windows.Media.Colors.Blue);
            colors.Add(System.Windows.Media.Colors.Green);
            BitmapPalette myPalette = new BitmapPalette(colors);

            // Creates a new empty image with the pre-defined palette

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
            FileStream stream = new FileStream("empty.tif", FileMode.Create);
            TiffBitmapEncoder encoder = new TiffBitmapEncoder();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString();
            encoder.Frames.Add(BitmapFrame.Create(image));
            MessageBox.Show(myPalette.Colors.Count.ToString());
            encoder.Save(stream);
            //</Snippet3>

            //</Snippet1>

            // Draw the Image
            Image myImage = new Image();
            myImage.Source = image;
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(20);

            //<Snippet4>

            // Open a Stream and decode a TIFF image
            Stream imageStreamSource = new FileStream("tulipfarm.tif", FileMode.Open, FileAccess.Read, FileShare.Read);
            TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];

            // Draw the Image
            Image myImage1 = new Image();
            myImage1.Source = bitmapSource;
            myImage1.Stretch = Stretch.None;
            myImage1.Margin = new Thickness(20);
            //</Snippet4>

            //<Snippet5>

            // Get the palette from an image
            BitmapImage image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri("tulipfarm.tif", UriKind.RelativeOrAbsolute);
            image2.EndInit();
            BitmapPalette myPalette3 = new BitmapPalette(image2, 256);

            //Draw the third Image
            Image myImage2 = new Image();
            myImage2.Source = image2;
            myImage2.Stretch = Stretch.None;
            myImage2.Margin = new Thickness(20);
            //</Snippet5>

            //<Snippet6>

            //Create a new TIFF image based on existing Image
            FileStream stream2 = new FileStream("image.tif", FileMode.Create);
            TiffBitmapEncoder encoder2 = new TiffBitmapEncoder();
            TiffBitmapDecoder decoder2 = new TiffBitmapDecoder(new Uri("tulipfarm.tif", UriKind.RelativeOrAbsolute), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
            encoder2.Frames = decoder2.Frames;
            //<Snippet7>
            BitmapMetadata tiffMetadata = new BitmapMetadata("tiff");
            tiffMetadata.SetQuery("/ifd/{ushort=1000}", 9999);
            tiffMetadata.SetQuery("/ifd/{uint=1001}", 23456);
            tiffMetadata.SetQuery("/ifd/{uint=1002}", 34567);
            tiffMetadata.SetQuery("/ifd/PaddingSchema:padding", (UInt32)4096);
            tiffMetadata.SetQuery("/ifd/exif", new BitmapMetadata("exif"));
            tiffMetadata.SetQuery("/ifd/exif/PaddingSchema:padding", (UInt32)4096);
            //</Snippet7>
            encoder2.Save(stream2);
            stream2.Close();
            //</Snippet6>

            //<Snippet9>
            FileStream stream4 = new FileStream("image3.tif", FileMode.Create);
            BitmapMetadata myBitmapMetadata2 = new BitmapMetadata("tiff");
            TiffBitmapEncoder encoder4 = new TiffBitmapEncoder();
            MessageBox.Show(myBitmapMetadata2.IsFixedSize.ToString());
            MessageBox.Show(myBitmapMetadata2.IsReadOnly.ToString());
            MessageBox.Show(myBitmapMetadata2.Format.ToString());
            MessageBox.Show(myBitmapMetadata2.Location.ToString());
            encoder4.Frames = decoder2.Frames;
            encoder4.Save(stream4);
            stream4.Close();
            //</Snippet9>

            // <Snippet8>
            FileStream stream3 = new FileStream( "image2.tif", FileMode.Create );
            BitmapMetadata myBitmapMetadata = new BitmapMetadata( "tiff" );
            TiffBitmapEncoder encoder3 = new TiffBitmapEncoder();
            myBitmapMetadata.ApplicationName = "Microsoft Digital Image Suite 10";
            myBitmapMetadata.Author = new ReadOnlyCollection<string>(
                new List<string>() { "Lori Kane" } );
            myBitmapMetadata.CameraManufacturer = "Tailspin Toys";
            myBitmapMetadata.CameraModel = "TT23";
            myBitmapMetadata.Comment = "Nice Picture";
            myBitmapMetadata.Copyright = "2010";
            myBitmapMetadata.DateTaken = "5/23/2010";
            myBitmapMetadata.Keywords = new ReadOnlyCollection<string>(
                new List<string>() { "Lori", "Kane" } );
            myBitmapMetadata.Rating = 5;
            myBitmapMetadata.Subject = "Lori";
            myBitmapMetadata.Title = "Lori's photo";

            // Create a new frame that is identical to the one
            // from the original image, except for the new metadata.
            encoder3.Frames.Add(
                BitmapFrame.Create(
                decoder2.Frames[0],
                decoder2.Frames[0].Thumbnail,
                myBitmapMetadata,
                decoder2.Frames[0].ColorContexts ) );

            encoder3.Save( stream3 );
            stream3.Close();
            // </Snippet8>

            //<Snippet10>
            BitmapSource image5 = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                BitmapPalettes.WebPalette,
                pixels,
                stride);

            FileStream stream5 = new FileStream("palette.tif", FileMode.Create);
            TiffBitmapEncoder encoder5 = new TiffBitmapEncoder();
            encoder5.Frames.Add(BitmapFrame.Create(image5));
            encoder5.Save(stream5);
            //</Snippet10>

            // Define a StackPanel to host Content

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            // Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage);
            myStackPanel.Children.Add(myTextBlock);
            myStackPanel.Children.Add(myImage1);
            myStackPanel.Children.Add(myImage2);

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
            MyApp app = new MyApp ();
            app.Run ();
        }
    }
}