// <SnippetPointAnimationUsingKeyFramesWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Microsoft.Samples.KeyFrameExamples
{
    /// <summary>
    /// This example shows how to use the PointAnimationUsingKeyFrames class
    /// to animate the position of an object.
    /// </summary>
    public class PointAnimationUsingKeyFramesExample : Page
    {
        public PointAnimationUsingKeyFramesExample()
        {
            Title = "PointAnimationUsingKeyFrames Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create an EllipseGeometry.
            EllipseGeometry myAnimatedEllipseGeometry =
                new EllipseGeometry(new Point(200,100), 15, 15);

            // Assign the EllipseGeometry a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "MyAnimatedEllipseGeometry", myAnimatedEllipseGeometry);

            // Create a Path element to display the geometry.
            Path aPath = new Path();   
            aPath.Fill = Brushes.Blue;
            aPath.Data = myAnimatedEllipseGeometry;
 
            // Create a Canvas to contain the path.
            Canvas containerCanvas = new Canvas();
            containerCanvas.Width = 500;
            containerCanvas.Height = 400;
            containerCanvas.Children.Add(aPath);

            // Create a PointAnimationUsingKeyFrames to
            // animate the EllipseGeometry.
            PointAnimationUsingKeyFrames centerPointAnimation
                = new PointAnimationUsingKeyFrames();
            centerPointAnimation.Duration = TimeSpan.FromSeconds(5);

            // Animate from the starting position to (100,300)
            // over the first half-second using linear
            // interpolation.
            centerPointAnimation.KeyFrames.Add(
                new LinearPointKeyFrame(
                    new Point(100, 300), // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.5))) // KeyTime
                );

            // Animate from (100,300) (the value of the previous key frame) 
            // to (400,300) at 1 second using discrete interpolation.
            // Because the interpolation is discrete, the ellipse will appear
            // to "jump" to (400,300) at 1 second.
            centerPointAnimation.KeyFrames.Add(
                new DiscretePointKeyFrame(
                    new Point(400, 300), // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))) // KeyTime
                );

            // Animate from (400,300) (the value of the previous key frame) to (200,100)
            // over two seconds, starting at 1 second (the key time of the
            // last key frame) and ending at 3 seconds.
            centerPointAnimation.KeyFrames.Add(
                new SplinePointKeyFrame(
                    new Point(200, 100), // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3)), // KeyTime
                    new KeySpline(0.6, 0.0, 0.9, 0.0) // KeySpline
                    )
                );

            // Set the animation to repeat forever. 
            centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation to target the Center property
            // of the object named "MyAnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, "MyAnimatedEllipseGeometry");
            Storyboard.SetTargetProperty(
                centerPointAnimation, new PropertyPath(EllipseGeometry.CenterProperty));

            // Create a storyboard to apply the animation.
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(centerPointAnimation);

            // Start the storyboard when the Path loads.
            aPath.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                ellipseStoryboard.Begin(this);
            };

            Content = containerCanvas;
        }

    }
}
// </SnippetPointAnimationUsingKeyFramesWholePage>





