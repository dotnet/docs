//<Snippet11>
/*

   This sample demonstrates how to apply non-storyboard animations to a property.
   To animate in markup, you must use storyboards.

*/

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Microsoft.Samples.Animation.LocalAnimations
{

    // Create the demonstration.
    public class LocalAnimationExample : Page
    {

        public LocalAnimationExample()
        {

            WindowTitle = "Local Animation Example";
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // Create and set the Button.
            Button aButton = new Button();
            aButton.Content = "A Button";

            // Animate the Button's Width.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 75;
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration =  new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Apply the animation to the button's Width property.
            aButton.BeginAnimation(Button.WidthProperty, myDoubleAnimation);

            // Create and animate a Brush to set the button's Background.
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = Colors.Blue;

            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.Blue;
            myColorAnimation.To = Colors.Red;
            myColorAnimation.Duration =  new Duration(TimeSpan.FromMilliseconds(7000));
            myColorAnimation.AutoReverse = true;
            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Apply the animation to the brush's Color property.
            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            aButton.Background = myBrush;

            // Add the Button to the panel.
            myStackPanel.Children.Add(aButton);
            this.Content = myStackPanel;
        }
    }
}
//</Snippet11>
