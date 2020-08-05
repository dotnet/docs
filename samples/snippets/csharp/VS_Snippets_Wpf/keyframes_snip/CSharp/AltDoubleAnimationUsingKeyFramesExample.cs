// <SnippetAltDoubleAnimationUsingKeyFramesWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Microsoft.Samples.KeyFrameExamples
{
    /// <summary>
    /// This example shows how to use the DoubleAnimationUsingKeyFrames class to
    /// animate the position of an object.
    /// Key frame animations enable you to create complex animations
    /// by specifying multiple destination values
    /// and controlling the animation's interpolation method.
    /// </summary>
    public class AltDoubleAnimationUsingKeyFramesExample : Page
    {
        public AltDoubleAnimationUsingKeyFramesExample()
        {
            Title = "DoubleAnimationUsingKeyFrames Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create a rectangle.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 100;
            aRectangle.Height = 100;
            aRectangle.Stroke = Brushes.Black;
            aRectangle.StrokeThickness = 5;

            // Create a Canvas to contain and
            // position the rectangle.
            Canvas containerCanvas = new Canvas();
            containerCanvas.Width = 610;
            containerCanvas.Height = 300;
            containerCanvas.Children.Add(aRectangle);
            Canvas.SetTop(aRectangle, 100);
            Canvas.SetLeft(aRectangle, 10);

            // Create a TranslateTransform to
            // move the rectangle.
            TranslateTransform animatedTranslateTransform =
                new TranslateTransform();
            aRectangle.RenderTransform = animatedTranslateTransform;

            // Assign the TranslateTransform a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "AnimatedTranslateTransform", animatedTranslateTransform);

            // Create a DoubleAnimationUsingKeyFrames to
            // animate the TranslateTransform.
            DoubleAnimationUsingKeyFrames translationAnimation
                = new DoubleAnimationUsingKeyFrames();
            translationAnimation.Duration = TimeSpan.FromSeconds(6);

            // Animate from the starting position to 500
            // over the first second using linear
            // interpolation.
            translationAnimation.KeyFrames.Add(
                new LinearDoubleKeyFrame(
                    500, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))) // KeyTime
                );

            // Animate from 500 (the value of the previous key frame)
            // to 400 at 4 seconds using discrete interpolation.
            // Because the interpolation is discrete, the rectangle will appear
            // to "jump" from 500 to 400.
            translationAnimation.KeyFrames.Add(
                new DiscreteDoubleKeyFrame(
                    400, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4))) // KeyTime
                );

            // Animate from 400 (the value of the previous key frame) to 0
            // over two seconds, starting at 4 seconds (the key time of the
            // last key frame) and ending at 6 seconds.
            translationAnimation.KeyFrames.Add(
                new SplineDoubleKeyFrame(
                    0, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), // KeyTime
                    new KeySpline(0.6,0.0,0.9,0.0) // KeySpline
                    )
                );

            // Set the animation to repeat forever.
            translationAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation to target the X property
            // of the object named "AnimatedTranslateTransform."
            Storyboard.SetTargetName(translationAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(
                translationAnimation, new PropertyPath(TranslateTransform.XProperty));

            // Create a storyboard to apply the animation.
            Storyboard translationStoryboard = new Storyboard();
            translationStoryboard.Children.Add(translationAnimation);

            // Start the storyboard after the rectangle loads.
            aRectangle.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                translationStoryboard.Begin(this);
            };

            Content = containerCanvas;
        }
    }
}
// </SnippetAltDoubleAnimationUsingKeyFramesWholePage>
