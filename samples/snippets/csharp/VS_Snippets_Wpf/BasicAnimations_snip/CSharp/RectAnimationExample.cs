// <SnippetRectAnimationWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace SDKSamples
{
    public class RectAnimationExample : Page
    {
        public RectAnimationExample()
        {

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = new Rect(0, 200, 100, 100);

            // Assign the geometry a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "MyAnimatedRectangleGeometry", myRectangleGeometry);

            Path myPath = new Path();
            myPath.Fill = Brushes.LemonChiffon;
            myPath.StrokeThickness = 1;
            myPath.Stroke = Brushes.Black;
            myPath.Data = myRectangleGeometry;

            RectAnimation myRectAnimation = new RectAnimation();
            myRectAnimation.Duration = TimeSpan.FromSeconds(2);
            myRectAnimation.FillBehavior = FillBehavior.HoldEnd;

            // Set the animation to repeat forever.
            myRectAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the From and To properties of the animation.
            myRectAnimation.From = new Rect(0, 200, 100, 100);
            myRectAnimation.To = new Rect(600, 50, 200, 50);

            // Set the animation to target the Rect property
            // of the object named "MyAnimatedRectangleGeometry."
            Storyboard.SetTargetName(myRectAnimation, "MyAnimatedRectangleGeometry");
            Storyboard.SetTargetProperty(
                myRectAnimation, new PropertyPath(RectangleGeometry.RectProperty));

            // Create a storyboard to apply the animation.
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(myRectAnimation);

            // Start the storyboard when the Path loads.
            myPath.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                ellipseStoryboard.Begin(this);
            };

            Canvas containerCanvas = new Canvas();
            containerCanvas.Children.Add(myPath);

            Content = containerCanvas;
        }
    }
}
// </SnippetRectAnimationWholePage>
