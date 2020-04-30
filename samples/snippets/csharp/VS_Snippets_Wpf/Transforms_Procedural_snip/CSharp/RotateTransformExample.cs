using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public class RotateTransformExample : Page
    {
        public RotateTransformExample()
        {
            WindowTitle = "RotateTransform Example";

            // <SnippetRotatePolylineAboutTopLeft>
            // Create a Polyline.
            Polyline polyline1 = new Polyline();
            polyline1.Points.Add(new Point(25, 25));
            polyline1.Points.Add(new Point(0, 50));
            polyline1.Points.Add(new Point(25, 75));
            polyline1.Points.Add(new Point(50, 50));
            polyline1.Points.Add(new Point(25, 25));
            polyline1.Points.Add(new Point(25, 0));
            polyline1.Stroke = Brushes.Blue;
            polyline1.StrokeThickness = 10;

            // Create a RotateTransform to rotate
            // the Polyline 45 degrees about its
            // top-left corner.
            RotateTransform rotateTransform1 =
                new RotateTransform(45);
            polyline1.RenderTransform = rotateTransform1;

            // Create a Canvas to contain the Polyline.
            Canvas canvas1 = new Canvas();
            canvas1.Width = 200;
            canvas1.Height = 200;
            Canvas.SetLeft(polyline1, 75);
            Canvas.SetTop(polyline1, 50);
            canvas1.Children.Add(polyline1);
            // </SnippetRotatePolylineAboutTopLeft>

            Border border1 = new Border();
            border1.BorderBrush = Brushes.Black;
            border1.BorderThickness = new Thickness(1);
            border1.HorizontalAlignment = HorizontalAlignment.Left;
            border1.Background = (Brush)Application.Current.Resources["MyBlueGridBrushResource"];
            border1.Child = canvas1;

            StackPanel mainPanel = new StackPanel();
            mainPanel.Margin = new Thickness(20);
            mainPanel.Children.Add(border1);

            // <SnippetRotatePolylineAboutCenter>
            // Create a Polyline.
            Polyline polyline2 = new Polyline();
            polyline2.Points = polyline1.Points;
            polyline2.Stroke = Brushes.Blue;
            polyline2.StrokeThickness = 10;

            // Create a RotateTransform to rotate
            // the Polyline 45 degrees about the
            // point (25,50).
            RotateTransform rotateTransform2 =
                new RotateTransform(45);
            rotateTransform2.CenterX = 25;
            rotateTransform2.CenterY = 50;
            polyline2.RenderTransform = rotateTransform2;

            // Create a Canvas to contain the Polyline.
            Canvas canvas2 = new Canvas();
            canvas2.Width = 200;
            canvas2.Height = 200;
            Canvas.SetLeft(polyline2, 75);
            Canvas.SetTop(polyline2, 50);
            canvas2.Children.Add(polyline2);
            // </SnippetRotatePolylineAboutCenter>

            Border border2 = new Border();
            border2.BorderBrush = Brushes.Black;
            border2.BorderThickness = new Thickness(1);
            border2.HorizontalAlignment = HorizontalAlignment.Left;
            border2.Background = (Brush)Application.Current.Resources["MyBlueGridBrushResource"];
            border2.Child = canvas2;
            mainPanel.Children.Add(border2);

            this.Content = mainPanel;
        }
    }
}
