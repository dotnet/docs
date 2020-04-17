//<Snippet101>
// EllipseGeometryExample.cs
//
// This sample demonstrates how to animate the center
// position of an EllipseGeometry using a PointAnimation.

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Microsoft.Samples.Animation.AnimatePathShapeSample
{

    public class EllipseGeometryExample : Page {

        public EllipseGeometryExample()
        {

            NameScope.SetNameScope(this, new NameScope());

            WindowTitle = "EllipseGeometry Animation Example";

            Canvas myCanvas = new Canvas();
            myCanvas.Width = 400;
            myCanvas.Height = 400;
            myCanvas.Margin = new Thickness(20);

            // Create a Path object to contain the geometry.
            System.Windows.Shapes.Path myPath =
                new System.Windows.Shapes.Path();
            myPath.Fill = System.Windows.Media.Brushes.Blue;
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.StrokeThickness = 5;

            // Create an EllipseGeometry.
            System.Windows.Media.EllipseGeometry myEllipseGeometry =
                new System.Windows.Media.EllipseGeometry();
            myEllipseGeometry.Center = new System.Windows.Point(200, 200);
            myEllipseGeometry.RadiusX = 25;
            myEllipseGeometry.RadiusY = 50;

            // Register a name for the geometry so that it can
            // be targeted by animations.
            this.RegisterName("MyEllipseGeometry", myEllipseGeometry);

            // Add the geometry to the Path.
            myPath.Data = myEllipseGeometry;
            myCanvas.Children.Add(myPath);
            this.Content = myCanvas;

            // Create a PointAnimation to animate the center of the ellipse.
            PointAnimation myPointAnimation = new PointAnimation();
            myPointAnimation.From = new System.Windows.Point(200, 200);
            myPointAnimation.To = new System.Windows.Point(50, 50);
            myPointAnimation.Duration =
                new Duration(TimeSpan.FromMilliseconds(5000));
            myPointAnimation.AutoReverse = true;
            myPointAnimation.RepeatBehavior = RepeatBehavior.Forever;

            Storyboard.SetTargetName(myPointAnimation, "MyEllipseGeometry");
            Storyboard.SetTargetProperty(myPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myPointAnimation);

            // Use an anonymous event handler to begin the animation
            // when the path is loaded.
            myPath.Loaded +=  delegate(object sender, RoutedEventArgs args)
                {
                    myStoryboard.Begin(myPath);
                };
        }
    }
}
//</Snippet101>
