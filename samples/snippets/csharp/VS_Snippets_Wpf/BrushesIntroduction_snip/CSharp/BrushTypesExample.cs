using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace BrushesIntroduction
{
    public class BrushTypesExample : Page
    {

        public BrushTypesExample()
        {
            StackPanel mainPanel = new StackPanel();
            createSolidColorBrushExample(mainPanel);
            createLinearGradientBrushExample(mainPanel);
            createRadialGradientBrushExample(mainPanel);
            createImageBrushExample(mainPanel);
            createDrawingBrushExample(mainPanel);
            createVisualBrushExample(mainPanel);

            this.Content = mainPanel;
        }

        private void createSolidColorBrushExample(Panel examplePanel)
        {

            // <SnippetGraphicsMMSolidColorBrushExampleInline>
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create a SolidColorBrush and use it to
            // paint the rectangle.
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Red);
            exampleRectangle.Fill = myBrush;
            // </SnippetGraphicsMMSolidColorBrushExampleInline>

            examplePanel.Children.Add(exampleRectangle);
        }

        private void createLinearGradientBrushExample(Panel examplePanel)
        {

            // <SnippetGraphicsMMLinearGradientBrushExampleInline>
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create a LinearGradientBrush and use it to
            // paint the rectangle.
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));

            exampleRectangle.Fill = myBrush;
            // </SnippetGraphicsMMLinearGradientBrushExampleInline>

            examplePanel.Children.Add(exampleRectangle);
        }

        private void createRadialGradientBrushExample(Panel examplePanel)
        {

            // <SnippetGraphicsMMRadialGradientBrushExampleInline>
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create a RadialGradientBrush and use it to
            // paint the rectangle.
            RadialGradientBrush myBrush = new RadialGradientBrush();
            myBrush.GradientOrigin = new Point(0.75, 0.25);
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));

            exampleRectangle.Fill = myBrush;
            // </SnippetGraphicsMMRadialGradientBrushExampleInline>

            examplePanel.Children.Add(exampleRectangle);
        }

        private void createImageBrushExample(Panel examplePanel)
        {

            // <SnippetGraphicsMMImageBrushExampleInline>
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create an ImageBrush and use it to
            // paint the rectangle.
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri(@"sampleImages\pinkcherries.jpg", UriKind.Relative));

            exampleRectangle.Fill = myBrush;
            // </SnippetGraphicsMMImageBrushExampleInline>

            examplePanel.Children.Add(exampleRectangle);
        }

        private void createVisualBrushExample(Panel examplePanel)
        {

            // <SnippetGraphicsMMVisualBrushExampleInline>
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create a VisualBrush and use it
            // to paint the rectangle.
            VisualBrush myBrush = new VisualBrush();

            //
            // Create the brush's contents.
            //
            StackPanel aPanel = new StackPanel();

            // Create a DrawingBrush and use it to
            // paint the panel.
            DrawingBrush myDrawingBrushBrush = new DrawingBrush();
            GeometryGroup aGeometryGroup = new GeometryGroup();
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));
            RadialGradientBrush checkerBrush = new RadialGradientBrush();
            checkerBrush.GradientStops.Add(new GradientStop(Colors.MediumBlue, 0.0));
            checkerBrush.GradientStops.Add(new GradientStop(Colors.White, 1.0));
            GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);
            myDrawingBrushBrush.Drawing = checkers;
            aPanel.Background = myDrawingBrushBrush;

            // Create some text.
            TextBlock someText = new TextBlock();
            someText.Text = "Hello, World";
            FontSizeConverter fSizeConverter = new FontSizeConverter();
            someText.FontSize = (double)fSizeConverter.ConvertFromString("10pt");
            someText.Margin = new Thickness(10);

            aPanel.Children.Add(someText);

            myBrush.Visual = aPanel;
            exampleRectangle.Fill = myBrush;

            // </SnippetGraphicsMMVisualBrushExampleInline>

            examplePanel.Children.Add(exampleRectangle);
        }

        private void createDrawingBrushExample(Panel examplePanel)
        {

            // <SnippetGraphicsMMDrawingBrushExampleInline>
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create a DrawingBrush and use it to
            // paint the rectangle.
            DrawingBrush myBrush = new DrawingBrush();

            GeometryDrawing backgroundSquare =
                new GeometryDrawing(
                    Brushes.White,
                    null,
                    new RectangleGeometry(new Rect(0, 0, 100, 100)));

            GeometryGroup aGeometryGroup = new GeometryGroup();
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));

            LinearGradientBrush checkerBrush = new LinearGradientBrush();
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.0));
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Gray, 1.0));

            GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);

            DrawingGroup checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(backgroundSquare);
            checkersDrawingGroup.Children.Add(checkers);

            myBrush.Drawing = checkersDrawingGroup;
            myBrush.Viewport = new Rect(0, 0, 0.25, 0.25);
            myBrush.TileMode = TileMode.Tile;

            exampleRectangle.Fill = myBrush;
            // </SnippetGraphicsMMDrawingBrushExampleInline>

            examplePanel.Children.Add(exampleRectangle);
        }
    }
}
