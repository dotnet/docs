//<SnippetGetAnimationBaseValueExampleWholePage>
/*

   This sample shows how to use the
   Animatable.GetAnimationBaseValue and
   UIElement.GetAnimationBaseValue methods
   to get the non-animated value of an
   animated Animatable or UIElement.

*/

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;

namespace Microsoft.Samples.Animation.TimingBehaviors
{

    public class GetAnimationBaseValueExample : Page {

        private RotateTransform animatedRotateTransform;
        public GetAnimationBaseValueExample()
        {

            WindowTitle = "GetAnimationBaseValue Example";
            StackPanel myPanel = new StackPanel();
            myPanel.Margin = new Thickness(20.0);

            // Create a button.
            Button animatedButton = new Button();
            animatedButton.Content = "Click Me";
            animatedButton.Width = 100;
            animatedButton.Margin = new Thickness(100);

            // Create and animate a RotateTransform and
            // apply it to the button's RenderTransform
            // property.
            animatedRotateTransform = new RotateTransform();
            animatedRotateTransform.Angle = 45;
            DoubleAnimation angleAnimation =
                new DoubleAnimation(0,360, TimeSpan.FromSeconds(5));
            angleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            animatedRotateTransform.BeginAnimation(
                RotateTransform.AngleProperty, angleAnimation);
            animatedButton.RenderTransform = animatedRotateTransform;
            animatedButton.RenderTransformOrigin = new Point(0.5,0.5);
//<SnippetBeginAnimation>
            // Animate the button's width.
            DoubleAnimation widthAnimation =
                new DoubleAnimation(120, 300, TimeSpan.FromSeconds(5));
            widthAnimation.RepeatBehavior = RepeatBehavior.Forever;
            widthAnimation.AutoReverse = true;
            animatedButton.BeginAnimation(Button.WidthProperty, widthAnimation);
//</SnippetBeginAnimation>

            // Handle button clicks.
            animatedButton.Click += new RoutedEventHandler(animatedButton_Clicked);

            // Add the button to the panel.
            myPanel.Children.Add(animatedButton);
            this.Content = myPanel;
        }

 //<SnippetGetAnimationBaseValue>
        // Display the base value for Button.Width and RotateTransform.Angle.
        private void animatedButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button animatedButton = (Button)sender;
            MessageBox.Show("Button width base value: " +
                animatedButton.GetAnimationBaseValue(Button.WidthProperty)
                + "\nRotateTransform base value: " +
                animatedRotateTransform.GetAnimationBaseValue(RotateTransform.AngleProperty));
        }
 //</SnippetGetAnimationBaseValue>
    }
}
//</SnippetGetAnimationBaseValueExampleWholePage>
