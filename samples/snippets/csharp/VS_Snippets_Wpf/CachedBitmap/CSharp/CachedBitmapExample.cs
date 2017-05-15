using System;
using System.Collections.Generic;
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
        
        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup (e);
            CreateAndShowMainWindow ();
        }
        private void CreateAndShowMainWindow ()
        {

            // Create the application's main window
            mainWindow = new Window ();
            mainWindow.Title = "CachedBitmap Imaging Sample";

            // Create a BitmapSource using a Uri
            BitmapSource source = BitmapFrame.Create(new Uri("tulipfarm.jpg", UriKind.RelativeOrAbsolute));

            // Create a new BitmapSource by scaling the original one.

            //<Snippet1>

            TransformedBitmap scaledSource = new TransformedBitmap();
            scaledSource.BeginInit();
            scaledSource.Source = source;
            scaledSource.Transform = new ScaleTransform(5, 5, 25, 25);
            scaledSource.EndInit();
            //</Snippet1>
            
            // Create a cache for the scaled BitmapSource
            // OnLoad will create the cache as soon as the new BitmapSource is created.

            //<Snippet4>

            //<Snippet2>
            CachedBitmap cachedSource = new CachedBitmap(
                scaledSource, 
                BitmapCreateOptions.None,
                BitmapCacheOption.OnLoad);
            //</Snippet2>
            
            //<Snippet3>

            // Create a new BitmapSource using a different format than the original one.
            FormatConvertedBitmap newFormatSource = new FormatConvertedBitmap();
            newFormatSource.BeginInit();
            newFormatSource.Source = cachedSource;
            newFormatSource.DestinationFormat = PixelFormats.Gray32Float;
            newFormatSource.EndInit();
            //</Snippet3>

            //</Snippet4>

            // Define an Image Control to host the FormatConvertedImage
            Image myImage = new Image();
            myImage.Source = newFormatSource;
            
            // Define a StackPanel to host Content
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            
            // Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage);

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