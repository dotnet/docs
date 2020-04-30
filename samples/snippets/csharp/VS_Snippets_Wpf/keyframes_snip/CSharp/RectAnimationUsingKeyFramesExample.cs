// <SnippetRectAnimationUsingKeyFramesWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Microsoft.Samples.KeyFrameExamples
{
    /// <summary>
    /// This example shows how to use the RectAnimationUsingKeyFrames class to
    /// animate the position and size of a rectangle.
    /// Key frame animations enable you to create complex animations
    /// by specifying multiple destination values
    /// and controlling the animation's interpolation method.
    /// </summary>
    public class RectAnimationUsingKeyFramesExample : Page
    {
        public RectAnimationUsingKeyFramesExample()
        {
            Title = "RectAnimationUsingKeyFrames Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Center;

            //Add the Path Element
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.Fill = Brushes.LemonChiffon;
            myPath.StrokeThickness = 1;

            // Create a RectangleGeometry to specify the Path data.
            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = new Rect(0, 200, 100, 100);
            myPath.Data = myRectangleGeometry;

            myStackPanel.Children.Add(myPath);

            // Assign the TranslateTransform a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "AnimatedRectangleGeometry", myRectangleGeometry);

            // Create a RectAnimationUsingKeyFrames to
            // animate the RectangleGeometry.
            RectAnimationUsingKeyFrames rectAnimation
                = new RectAnimationUsingKeyFrames();
            rectAnimation.Duration = TimeSpan.FromSeconds(6);

            // Set the animation to repeat forever.
            rectAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Animate position, width, and height in first 2 seconds. LinearRectKeyFrame creates
            // a smooth, linear animation between values.
            rectAnimation.KeyFrames.Add(
                new LinearRectKeyFrame(
                    new Rect(600,50,200,50), // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))) // KeyTime
                );

            // In the next half second, change height to 10. DiscreteRectKeyFrame creates a
            // sudden "jump" between values.
            rectAnimation.KeyFrames.Add(
                new DiscreteRectKeyFrame(
                    new Rect(600, 50, 200, 10), // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.5))) // KeyTime
                );

            // In the final 2 seconds of the animation, go back to the starting position, width, and height.
            // Spline key frames like SplineRectKeyFrame creates a variable transition between values depending
            // on the KeySpline property. In this example, the animation starts off slow but toward the end of
            // the time segment, it speeds up exponentially.
            rectAnimation.KeyFrames.Add(
                new SplineRectKeyFrame(
                    new Rect(0, 200, 100, 100), // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4.5)), // KeyTime
                    new KeySpline(0.6, 0.0, 0.9, 0.0) // KeySpline
                    )
                );

            // Set the animation to target the Rect property
            // of the object named "AnimatedRectangleGeometry."
            Storyboard.SetTargetName(rectAnimation, "AnimatedRectangleGeometry");
            Storyboard.SetTargetProperty(
                rectAnimation, new PropertyPath(RectangleGeometry.RectProperty));

            // Create a storyboard to apply the animation.
            Storyboard rectStoryboard = new Storyboard();
            rectStoryboard.Children.Add(rectAnimation);

            // Start the storyboard after the rectangle loads.
            myPath.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                rectStoryboard.Begin(this);
            };

            Content = myStackPanel;
        }
    }
}
// </SnippetRectAnimationUsingKeyFramesWholePage>
