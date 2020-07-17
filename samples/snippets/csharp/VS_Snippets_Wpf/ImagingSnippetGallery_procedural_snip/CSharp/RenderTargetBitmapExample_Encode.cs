// <SnippetRenderTargetBitmapEncodeCodeExampleWholePage>
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace SDKSample
{
   public partial class RenderTargetBitmapExample_Encode : Page
   {
      public RenderTargetBitmapExample_Encode()
      {

         //<SnippetRTBEncodeInline1>
         // Base Image
         BitmapImage bi = new BitmapImage();
         bi.BeginInit();
         bi.UriSource = new Uri("sampleImages/waterlilies.jpg",UriKind.Relative);
         bi.DecodePixelWidth = 200;
         bi.EndInit();

         // Text to render on the image.
         FormattedText text = new FormattedText("Waterlilies",
                 new CultureInfo("en-us"),
                 FlowDirection.LeftToRight,
                 new Typeface(this.FontFamily, FontStyles.Normal, FontWeights.Normal, new FontStretch()),
                 this.FontSize,
                 Brushes.White);

         // The Visual to use as the source of the RenderTargetBitmap.
         DrawingVisual drawingVisual = new DrawingVisual();
         DrawingContext drawingContext = drawingVisual.RenderOpen();
         drawingContext.DrawImage(bi,new Rect(0,0,bi.Width,bi.Height));
         drawingContext.DrawText(text, new Point(bi.Height/2, 0));
         drawingContext.Close();

         // The BitmapSource that is rendered with a Visual.
         RenderTargetBitmap rtb = new RenderTargetBitmap(bi.PixelWidth, bi.PixelHeight, 96, 96, PixelFormats.Pbgra32);
         rtb.Render(drawingVisual);

         // Encoding the RenderBitmapTarget as a PNG file.
         PngBitmapEncoder png = new PngBitmapEncoder();
         png.Frames.Add(BitmapFrame.Create(rtb));
         using (Stream stm = File.Create("new.png"))
         {
            png.Save(stm);
         }
         //</SnippetRTBEncodeInline1>
         // Image to display.
         Image myImage = new Image();
         myImage.Width = 400;
         myImage.Source = rtb;

         // Add Image to the UI
         StackPanel myStackPanel = new StackPanel();
         myStackPanel.Children.Add(myImage);
         this.Content = myStackPanel;
      }
   }
}
// </SnippetRenderTargetBitmapEncodeCodeExampleWholePage>
