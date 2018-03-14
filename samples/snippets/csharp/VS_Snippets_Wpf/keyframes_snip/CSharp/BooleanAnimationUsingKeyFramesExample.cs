// <SnippetBooleanAnimationUsingKeyFramesWholePage>
// Demonstrates a BooleanAnimationUsingKeyFrames. The animation is used to
// animate the IsEnabled property of a button.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Microsoft.Samples.KeyFrameExamples
{
    public class BooleanAnimationUsingKeyFramesExample : Page
    {
        public BooleanAnimationUsingKeyFramesExample()
        {
            Title = "BooleanAnimationUsingKeyFrames Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Vertical;
            myStackPanel.Margin = new Thickness(20);

            // Create a TextBlock to introduce the example.
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Click the button to animate its IsEnabled property"
                               + " with aBooleanAnimationUsingKeyFrames animation.";
            myStackPanel.Children.Add(myTextBlock);

            // Create the Button that is the target of the animation.
            Button myButton = new Button();
            myButton.Margin = new Thickness(200);
            myButton.Content = "Click Me";

            myStackPanel.Children.Add(myButton);


            // Assign the Button a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "AnimatedButton", myButton);

            // Create a BooleanAnimationUsingKeyFrames to
            // animate the IsEnabled property of the Button.
            BooleanAnimationUsingKeyFrames booleanAnimation
                = new BooleanAnimationUsingKeyFrames();
            booleanAnimation.Duration = TimeSpan.FromSeconds(4);


            // All the key frames defined below are DiscreteBooleanKeyFrames. 
            // Discrete key frames create sudden "jumps" between values 
            // (no interpolation). Only discrete key frames can be used 
            // for Boolean key frame animations.

            // Value at the beginning is false
            booleanAnimation.KeyFrames.Add(
                new DiscreteBooleanKeyFrame(
                    false, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.0))) // KeyTime
                );

            // Value becomes true after the first second.
            booleanAnimation.KeyFrames.Add(
                new DiscreteBooleanKeyFrame(
                    true, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.0))) // KeyTime
                );

            // Value becomes false after the 2nd second.
            booleanAnimation.KeyFrames.Add(
                new DiscreteBooleanKeyFrame(
                    false, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.0))) // KeyTime
                );

            // Value becomes true after the third second.
            booleanAnimation.KeyFrames.Add(
                new DiscreteBooleanKeyFrame(
                    true, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3.0))) // KeyTime
                );

            // Value becomes false after 3 and half seconds.
            booleanAnimation.KeyFrames.Add(
                new DiscreteBooleanKeyFrame(
                    false, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3.5))) // KeyTime
                );

            // Value becomes true after the fourth second.
            booleanAnimation.KeyFrames.Add(
                new DiscreteBooleanKeyFrame(
                    true, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4.0))) // KeyTime
                );

            // Set the animation to target the IsEnabled property
            // of the object named "AnimatedButton".
            Storyboard.SetTargetName(booleanAnimation, "AnimatedButton");
            Storyboard.SetTargetProperty(
                booleanAnimation, new PropertyPath(Button.IsEnabledProperty));

            // Create a storyboard to apply the animation.
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(booleanAnimation);

            // Start the storyboard when the button is clicked.
            myButton.Click += delegate(object sender, RoutedEventArgs e)
            {
                myStoryboard.Begin(this);
            };

            Content = myStackPanel;
        }

    }
}
// </SnippetBooleanAnimationUsingKeyFramesWholePage>





