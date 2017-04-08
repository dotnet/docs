using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Microsoft.Samples.Graphics.UsingImageBrush
{
    public class TileSizeExample : Page
    {
        public TileSizeExample()
        {

            // <SnippetRelativeTileSizeExample>
            
            //
            // Create an ImageBrush and set the size of each
            // tile to 50% by 50% of the area being painted. 
            // 
            ImageBrush relativeTileSizeImageBrush = new ImageBrush();
            relativeTileSizeImageBrush.ImageSource =
                new BitmapImage(new Uri(@"sampleImages\cherries_larger.jpg", UriKind.Relative));
            relativeTileSizeImageBrush.TileMode = TileMode.Tile;
            
            // Specify the size of the base tile. 
            // By default, the size of the Viewport is
            // relative to the area being painted,
            // so a value of 0.5 indicates 50% of the output
            // area.
            relativeTileSizeImageBrush.Viewport = new Rect(0, 0, 0.5, 0.5);

            // Create a rectangle and paint it with the ImageBrush.
            Rectangle relativeTileSizeExampleRectangle = new Rectangle();
            relativeTileSizeExampleRectangle.Width = 200;
            relativeTileSizeExampleRectangle.Height = 150;
            relativeTileSizeExampleRectangle.Stroke = Brushes.LimeGreen;
            relativeTileSizeExampleRectangle.StrokeThickness = 1;
            relativeTileSizeExampleRectangle.Fill = relativeTileSizeImageBrush;
            // </SnippetRelativeTileSizeExample>

            // <SnippetAbsoluteTileSizeExample>

            //
            // Create an ImageBrush and set the size of each
            // tile to 25 by 25 pixels. 
            // 
            ImageBrush absoluteTileSizeImageBrush = new ImageBrush();
            absoluteTileSizeImageBrush.ImageSource =
                 new BitmapImage(new Uri(@"sampleImages\cherries_larger.jpg", UriKind.Relative));
            absoluteTileSizeImageBrush.TileMode = TileMode.Tile;

            // Specify that the Viewport is to be interpreted as
            // an absolute value. 
            absoluteTileSizeImageBrush.ViewportUnits = BrushMappingMode.Absolute;

            // Set the size of the base tile. Had we left ViewportUnits set
            // to RelativeToBoundingBox (the default value), 
            // each tile would be 25 times the size of the area being
            // painted. Because ViewportUnits is set to Absolute,
            // the following line creates tiles that are 25 by 25 pixels.
            absoluteTileSizeImageBrush.Viewport = new Rect(0, 0, 25, 25);

            // Create a rectangle and paint it with the ImageBrush.
            Rectangle absoluteTileSizeExampleRectangle = new Rectangle();
            absoluteTileSizeExampleRectangle.Width = 200;
            absoluteTileSizeExampleRectangle.Height = 150;
            absoluteTileSizeExampleRectangle.Stroke = Brushes.LimeGreen;
            absoluteTileSizeExampleRectangle.StrokeThickness = 1;
            absoluteTileSizeExampleRectangle.Fill = absoluteTileSizeImageBrush;
            // </SnippetAbsoluteTileSizeExample>

            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(relativeTileSizeExampleRectangle);
            mainPanel.Children.Add(absoluteTileSizeExampleRectangle);
            Content = mainPanel;

            Title = "Tile Size Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

        }
    }
}
