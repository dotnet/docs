using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace SDKSample
{
    public class MyApp : Application
    {
        Window mainWindow;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }
        private void CreateAndShowMainWindow ()
        {
            // Create the application's main window
            mainWindow = new Window();
            mainWindow.Title = "BitmapImage Sample";

            //<Snippet1>
            // Define a BitmapImage.
            Image myImage = new Image();
            BitmapImage bi = new BitmapImage();

            // Begin initialization.
            bi.BeginInit();

            // Set properties.
            bi.CacheOption = BitmapCacheOption.OnDemand;
            bi.CreateOptions = BitmapCreateOptions.DelayCreation;
            bi.DecodePixelHeight = 125;
            bi.DecodePixelWidth = 125;
            bi.Rotation = Rotation.Rotate90;
            MessageBox.Show(bi.IsDownloading.ToString());
            bi.UriSource = new Uri("smiley.png", UriKind.Relative);

            // End initialization.
            bi.EndInit();
            myImage.Source = bi;
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(5);
            //</Snippet1>

            //Define a Second BitmapImage and Source
            Image myImage2 = new Image();
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.DecodePixelHeight = 75;
            bi2.DecodePixelWidth = 75;
            bi2.CacheOption = BitmapCacheOption.None;
            bi2.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bi2.Rotation = Rotation.Rotate180;
            bi2.UriSource = new Uri("smiley.png", UriKind.Relative);
            bi2.EndInit();
            myImage2.Source = bi2;
            myImage2.Stretch = Stretch.None;
            myImage2.Margin = new Thickness(5);

            //<Snippet2>
            Stream imageStream = new FileStream("tulipfarm.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
            BitmapSource myBitmapSource = BitmapFrame.Create(imageStream);
            BitmapFrame myBitmapSourceFrame = (BitmapFrame)myBitmapSource;
            ColorContext sourceColorContext = myBitmapSourceFrame.ColorContexts[0];
            ColorContext destColorContext = new ColorContext(PixelFormats.Bgra32);
            ColorConvertedBitmap ccb = new ColorConvertedBitmap(myBitmapSource, sourceColorContext, destColorContext, PixelFormats.Pbgra32);
            Image myImage3 = new Image();
            myImage3.Source = ccb;
            myImage3.Stretch = Stretch.None;
            imageStream.Close();
            //</Snippet2>

            //Show ColorConvertedBitmap Properties
            Stream imageStream2 = new FileStream("tulipfarm.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
            BitmapSource myBitmapSource2 = BitmapFrame.Create(imageStream2);
            BitmapFrame myBitmapSourceFrame2 = (BitmapFrame)myBitmapSource;
            //<Snippet3>
            ColorConvertedBitmap myColorConvertedBitmap = new ColorConvertedBitmap();
            myColorConvertedBitmap.BeginInit();
            myColorConvertedBitmap.SourceColorContext = myBitmapSourceFrame2.ColorContexts[0];
            myColorConvertedBitmap.Source = myBitmapSource2;
            myColorConvertedBitmap.DestinationFormat = PixelFormats.Pbgra32;
            myColorConvertedBitmap.DestinationColorContext = new ColorContext(PixelFormats.Bgra32);
            myColorConvertedBitmap.EndInit();
            //</Snippet3>

            
            //Define a StackPanel
            StackPanel myStackPanel = new StackPanel();

            // Add the images to the parent StackPanel
            myStackPanel.Children.Add(myImage);
            myStackPanel.Children.Add(myImage2);
            myStackPanel.Children.Add(myImage3);

            // Add the StackPanel as the Content of the Parent Window Object
            mainWindow.Content = myStackPanel;
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