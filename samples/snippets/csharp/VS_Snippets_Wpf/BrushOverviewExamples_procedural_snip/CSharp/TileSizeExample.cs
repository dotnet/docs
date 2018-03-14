

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Microsoft.Samples.BrushExamples
{

    public class TileSizeExample : Page
    {
    
        
        public TileSizeExample()
        {

            // Create the main panel.
            StackPanel mainPanel = new StackPanel();
            mainPanel.Orientation = Orientation.Horizontal;
            createRelativeTileSizeExample(mainPanel);
            createAbsoluteTileSizeExample(mainPanel);
            this.Content = mainPanel;
        

        }
        
        
        private void createRelativeTileSizeExample(Panel mainPanel)
        {


            Border rectangleBorder = new Border();
            rectangleBorder.BorderBrush = Brushes.Black;
            rectangleBorder.BorderThickness = new Thickness(1);
            rectangleBorder.VerticalAlignment = VerticalAlignment.Top;
            rectangleBorder.Margin = new Thickness(0,0,10,0);

            // <SnippetGraphicsMMRelativeViewportUnitsExample1>
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 50;
            myRectangle.Height = 100;
            
            // Load the image.
            BitmapImage theImage = 
                new BitmapImage(
                    new Uri("sampleImages\\cherries_larger.jpg", UriKind.Relative));   
            ImageBrush myImageBrush = new ImageBrush(theImage);
            
            // Create tiles that are 1/4 the size of 
            // the output area.
            myImageBrush.Viewport = new Rect(0,0,0.25,0.25);
            myImageBrush.ViewportUnits = BrushMappingMode.RelativeToBoundingBox;
            
            // Set the tile mode to Tile.
            myImageBrush.TileMode = TileMode.Tile;
  
            // Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush;
            // </SnippetGraphicsMMRelativeViewportUnitsExample1>
            
            rectangleBorder.Child = myRectangle;
            mainPanel.Children.Add(rectangleBorder);            
        
        }

        private void createAbsoluteTileSizeExample(Panel mainPanel)
        {


            Border rectangleBorder = new Border();
            rectangleBorder.BorderBrush = Brushes.Black;
            rectangleBorder.BorderThickness = new Thickness(1);
            rectangleBorder.VerticalAlignment = VerticalAlignment.Top;
            rectangleBorder.Margin = new Thickness(0, 0, 10, 0);

            // <SnippetGraphicsMMAbsoluteViewportUnitsExample1>
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 50;
            myRectangle.Height = 100;

            // Load the image.       
            BitmapImage theImage =
                new BitmapImage(
                    new Uri("sampleImages\\cherries_larger.jpg", UriKind.Relative));
            ImageBrush myImageBrush = new ImageBrush(theImage);

            // Create tiles that are 25 x 25, regardless of the size
            // of the output area.
            myImageBrush.Viewport = new Rect(0, 0, 25, 25);
            myImageBrush.ViewportUnits = BrushMappingMode.Absolute;

            // Set the tile mode to Tile.
            myImageBrush.TileMode = TileMode.Tile;

            // Use the ImageBrush to paint the rectangle's background.
            myRectangle.Fill = myImageBrush;
            // </SnippetGraphicsMMAbsoluteViewportUnitsExample1>

            rectangleBorder.Child = myRectangle;
            mainPanel.Children.Add(rectangleBorder);

        }
  
    }

}