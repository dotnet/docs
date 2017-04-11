// <SnippetRenderTargetBitmapCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace SDKSample
{
    public partial class RenderTargetBitmapExample : Page
    {
        public RenderTargetBitmapExample()
        {

 			//<SnippetCreateRTBImage>
            Image myImage = new Image();
            FormattedText text = new FormattedText("ABC",
                    new CultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    new Typeface(this.FontFamily, FontStyles.Normal, FontWeights.Normal, new FontStretch()),
                    this.FontSize,
                    this.Foreground);

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            drawingContext.DrawText(text, new Point(2, 2));
            drawingContext.Close();

            RenderTargetBitmap bmp = new RenderTargetBitmap(180, 180, 120, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            myImage.Source = bmp;
 			//</SnippetCreateRTBImage>

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myImage);
            this.Content = myStackPanel;
        }
    }
}
// </SnippetRenderTargetBitmapCodeExampleWholePage>