// <SnippetRectExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class RectExample : Page
    {
        public RectExample()
        {   
            Path myPath1 = new Path();
            myPath1.Stroke = Brushes.Black;
            myPath1.StrokeThickness = 1;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255);
            myPath1.Fill = mySolidColorBrush;

            // Create the rectangle.
            // This RectangleGeometry specifies a rectangle that is 100 pixels high and
            // 150 wide. The left side of the rectangle is 10 pixels from the left of the 
            // Canvas and the top side of the rectangle is 100 pixels from the top of the Canvas.  
            // Note: You could alternatively use the Rect Constructor to create this:
            // Rect my Rect1 = new Rect(10,100,150,100");
            Rect myRect1 = new Rect();
            myRect1.X = 10;
            myRect1.Y = 100;
            myRect1.Width = 150;
            myRect1.Height = 100;
            RectangleGeometry myRectangleGeometry1 = new RectangleGeometry();
            myRectangleGeometry1.Rect = myRect1;

            GeometryGroup myGeometryGroup1 = new GeometryGroup();
            myGeometryGroup1.Children.Add(myRectangleGeometry1);

            myPath1.Data = myGeometryGroup1;

            Path myPath2 = new Path();
            myPath2.Stroke = Brushes.Black;
            myPath2.StrokeThickness = 1;
            myPath2.Fill = mySolidColorBrush;

            // Create the rectangle.
            // This Rect uses the Size property to specify a height of 50 and width
            // of 200. The Location property uses a Point value to determine the location of the
            // top-left corner of the rectangle.
            Rect myRect2 = new Rect();
            myRect2.Size = new Size(50, 200);
            myRect2.Location = new Point(300, 100);
            RectangleGeometry myRectangleGeometry2 = new RectangleGeometry();
            myRectangleGeometry2.Rect = myRect2;

            GeometryGroup myGeometryGroup2 = new GeometryGroup();
            myGeometryGroup2.Children.Add(myRectangleGeometry2);

            myPath2.Data = myGeometryGroup2;

            // Add path shape to the UI.
            Canvas myCanvas = new Canvas();
            myCanvas.Children.Add(myPath1);
            myCanvas.Children.Add(myPath2);
            this.Content = myCanvas;       
        }
    }

}
// </SnippetRectExampleWholePage>
