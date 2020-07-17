// <SnippetColorAnimationUsingKeyFramesWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Microsoft.Samples.KeyFrameExamples
{
    public class ColorAnimationUsingKeyFramesExample : Page
    {
        public ColorAnimationUsingKeyFramesExample()
        {
            Title = "BooleanAnimationUsingKeyFrames Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Center;

            // Create the Border that is the target of the animation.
            SolidColorBrush animatedBrush = new SolidColorBrush();
            animatedBrush.Color = Color.FromArgb(255, 0, 255, 0);
            Border myBorder = new Border();

            // Set the initial color of the border to green.
            myBorder.BorderBrush = animatedBrush;
            myBorder.BorderThickness = new Thickness(28);
            myBorder.Padding = new Thickness(20);
            myStackPanel.Children.Add(myBorder);

            // Create a TextBlock to host inside the Border.
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "This example shows how to use the ColorAnimationUsingKeyFrames"
                               + " to create an animation on the BorderBrush property of a Border.";
            myBorder.Child = myTextBlock;

            // Assign the Brush a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "AnimatedBrush", animatedBrush);

            // Create a ColorAnimationUsingKeyFrames to
            // animate the BorderBrush property of the Button.
            ColorAnimationUsingKeyFrames colorAnimation
                = new ColorAnimationUsingKeyFrames();
            colorAnimation.Duration = TimeSpan.FromSeconds(6);

            // Create brushes to use as animation values.
            Color redColor = new Color();
            redColor = Color.FromArgb(255, 255, 0, 0);
            Color yellowColor = new Color();
            yellowColor = Color.FromArgb(255, 255, 255, 0);
            Color greenColor = new Color();
            greenColor = Color.FromArgb(255, 0, 255, 0);

            // Go from green to red in the first 2 seconds. LinearColorKeyFrame creates
            // a smooth, linear animation between values.
            colorAnimation.KeyFrames.Add(
                new LinearColorKeyFrame(
                    redColor, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.0))) // KeyTime
                );

            // In the next half second, go to yellow. DiscreteColorKeyFrame creates a
            // sudden jump between values.
            colorAnimation.KeyFrames.Add(
                new DiscreteColorKeyFrame(
                    yellowColor, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.5))) // KeyTime
                );

            // In the final 2 seconds of the animation, go from yellow back to green. SplineColorKeyFrame
            // creates a variable transition between values depending on the KeySpline property. In this example,
            // the animation starts off slow but toward the end of the time segment, it speeds up exponentially.
            colorAnimation.KeyFrames.Add(
                new SplineColorKeyFrame(
                    greenColor, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4.5)), // KeyTime
                    new KeySpline(0.6, 0.0, 0.9, 0.0) // KeySpline
                    )
                );

            // Set the animation to repeat forever.
            colorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation to target the Color property
            // of the object named "AnimatedBrush".
            Storyboard.SetTargetName(colorAnimation, "AnimatedBrush");
            Storyboard.SetTargetProperty(
                colorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));

            // Create a storyboard to apply the animation.
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(colorAnimation);

            // Start the storyboard when the Border loads.
            myBorder.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                myStoryboard.Begin(this);
            };

            Content = myStackPanel;
        }
    }
}
// </SnippetColorAnimationUsingKeyFramesWholePage>
