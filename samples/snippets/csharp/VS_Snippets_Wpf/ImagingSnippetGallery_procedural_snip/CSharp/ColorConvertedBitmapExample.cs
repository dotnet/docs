using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;

namespace SDKSample
{
    public partial class ColorConvertedBitmapExample : Page
    {
        public ColorConvertedBitmapExample()
        {

            //How to use ColorConvertedBitmap
            string jpegFile = "sampleImages/WaterLilies.jpg";
            Stream imageStream = new FileStream(jpegFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            BitmapSource bsrc = BitmapFrame.Create(imageStream);
            BitmapFrame bsrcFrame = (BitmapFrame)bsrc;
            //ColorContext sourceColorContext = (ColorContext)bsrcFrame.ColorContexts;
            ColorContext sourceColorContext = new ColorContext(PixelFormats.Indexed1);
            // Get the ColorContext from the BitmapFrame if there is one.
            ReadOnlyCollection<ColorContext> myColorContextCollection = bsrcFrame.ColorContexts;
            if (myColorContextCollection != null)
            {
                foreach (ColorContext myColorContext in myColorContextCollection)
                {
                    sourceColorContext = myColorContext;
                }
            }

            // sourceColorContext= bsrcFrame.ColorContext;
            // ColorContext sourceColorContext = new ColorContext();

            ColorContext destColorContext = new ColorContext(System.Windows.Media.PixelFormats.Indexed1);
            ColorConvertedBitmap ccb = new ColorConvertedBitmap(bsrc, sourceColorContext, destColorContext, PixelFormats.Bgr24);

            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 200;
            //set image source
            myImage.Source = ccb;

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            //myStackPanel.Children.Add(myImage);
            //TextBlock tb = new TextBlock();
            //tb.Text = s;
            myStackPanel.Children.Add(myImage);
            this.Content = myStackPanel;
        }
    }
}