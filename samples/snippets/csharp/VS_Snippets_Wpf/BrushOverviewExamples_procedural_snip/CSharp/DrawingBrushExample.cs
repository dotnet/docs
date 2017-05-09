
// <SnippetGraphicsMMDrawingBrushAsButtonBackgroundExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{

    public class DrawingBrushExample : Page
    {
    
        public DrawingBrushExample()
        {
        
            StackPanel mainPanel = new StackPanel();
            canvasBackgroundExample(mainPanel);
            this.Content = mainPanel;
        
        }
                 

        // <SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample>
        private void canvasBackgroundExample(Panel mainPanel)
        {
            
            // <SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample1>
            // Create a DrawingBrush.
            DrawingBrush myDrawingBrush = new DrawingBrush();

            // Create a drawing.
            GeometryDrawing myGeometryDrawing = new GeometryDrawing();
            myGeometryDrawing.Brush = Brushes.LightBlue;
            myGeometryDrawing.Pen = new Pen(Brushes.Gray, 1);
            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(new EllipseGeometry(new Point(25,50), 12.5, 25));
            ellipses.Children.Add(new EllipseGeometry(new Point(50,50), 12.5, 25));
            ellipses.Children.Add(new EllipseGeometry(new Point(75,50), 12.5, 25));
            
            myGeometryDrawing.Geometry = ellipses;
            myDrawingBrush.Drawing = myGeometryDrawing;

            Button myButton = new Button();
            myButton.Content = "A Button";

            // Use the DrawingBrush to paint the button's background.
            myButton.Background = myDrawingBrush;
            // </SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample1>
            
            mainPanel.Children.Add(myButton);
    
    
        }
        // </SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample>
    
    }

}
// </SnippetGraphicsMMDrawingBrushAsButtonBackgroundExampleWholePage>