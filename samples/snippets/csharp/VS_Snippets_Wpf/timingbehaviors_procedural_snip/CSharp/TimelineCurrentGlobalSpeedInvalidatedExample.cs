﻿//<SnippetTimelineCurrentGlobalSpeedInvalidatedExampleWholePage>
/*

   This example shows how to register for the
   CurrentGlobalSpeedInvalidated event
   using a Timeline.

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

    public class TimelineCurrentGlobalSpeedInvalidatedExample : Page {

        private TextBlock currentTimeTextBlock;
        public TimelineCurrentGlobalSpeedInvalidatedExample()
        {

            // Create a name scope.
            NameScope.SetNameScope(this, new NameScope());

            WindowTitle = "GetAnimationBaseValue Example";
            StackPanel myPanel = new StackPanel();
            myPanel.Margin = new Thickness(20);

            // Create a rectangle.
            Rectangle animatedRectangle = new Rectangle();
            animatedRectangle.Width = 100;
            animatedRectangle.Height = 50;
            animatedRectangle.Margin = new Thickness(50);
            animatedRectangle.Fill = Brushes.Orange;
            animatedRectangle.Stroke = Brushes.Gray;
            animatedRectangle.StrokeThickness = 2;

            // Create a RotateTransform.
            RotateTransform animatedTransform = new RotateTransform();
            animatedTransform.Angle = 0;
            this.RegisterName("animatedTransform", animatedTransform);
            animatedRectangle.RenderTransform = animatedTransform;
            animatedRectangle.RenderTransformOrigin = new Point(0.5,0.5);
            myPanel.Children.Add(animatedRectangle);
            this.Content = myPanel;

            // Create a TextBlock to show the storyboard's current time.
            currentTimeTextBlock = new TextBlock();
            myPanel.Children.Add(currentTimeTextBlock);

            // Animate the RotateTransform's angle using a Storyboard.
            DoubleAnimation angleAnimation = new DoubleAnimation(0,360, TimeSpan.FromSeconds(5));
            angleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            angleAnimation.AutoReverse = true;
            Storyboard.SetTargetName(angleAnimation, "animatedTransform");
            Storyboard.SetTargetProperty(angleAnimation,
                new PropertyPath(RotateTransform.AngleProperty));

            Storyboard theStoryboard = new Storyboard();
            theStoryboard.Children.Add(angleAnimation);

            // Register the CurrentGlobalSpeedInvalidated event.
            // You must register for events before you begin
            // the storyboard.
            angleAnimation.CurrentGlobalSpeedInvalidated +=
                new EventHandler(angleAnimation_CurrentGlobalSpeedInvalidated);

            // Start the storyboard.
            theStoryboard.Begin(animatedRectangle, true);
        }

        private void angleAnimation_CurrentGlobalSpeedInvalidated(object sender, EventArgs e)
        {

            // Sender is the clock that was created for the DoubleAnimation.
            Clock doubleAnimationClock = (Clock)sender;

            // Update the TextBlock with the time of its parent.
            currentTimeTextBlock.Text = doubleAnimationClock.Parent.CurrentTime.ToString();
        }
    }
}
//</SnippetTimelineCurrentGlobalSpeedInvalidatedExampleWholePage>
