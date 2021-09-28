/*
AutoReverseExample.xaml
     This example shows how to use the AutoReverse property to make a timeline play backwards at the end of each iteration.
     Several rectangles are animated by DoubleAnimations with identical durations and target values, but with different
     AutoReverse and RepeatBehavior settings.
*/

using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class AutoReverseExample : Page
    {
        public AutoReverseExample()
        {

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness( 20 );

            Border myBorder = new Border();
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness( 20 );
            myTextBlock.Text = "This example shows how to use the AutoReverse property to make a";
            myTextBlock.Text += " timeline play backwards at the end of each  iteration. Several rectangles are";
            myTextBlock.Text += " animated by DoubleAnimations with identical durations and target values, but with different ";
            myTextBlock.Text += " AutoReverse and RepeatBehavior settings.";

            myBorder.Child = myTextBlock;
            myStackPanel.Children.Add(myBorder);

            myTextBlock = new TextBlock();
            myTextBlock.Text = "AutoReverse=\"False\" (Default).";
            myStackPanel.Children.Add(myTextBlock);

            //
            //  Create the rectangles to animate
            //
            Rectangle withoutAutoReverseRectangle = new Rectangle();
            withoutAutoReverseRectangle.Name = "withoutAutoReverseRectangle";
            this.RegisterName( withoutAutoReverseRectangle.Name,withoutAutoReverseRectangle );
            withoutAutoReverseRectangle.Width = 100;
            withoutAutoReverseRectangle.Height = 20;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            withoutAutoReverseRectangle.Fill = mySolidColorBrush;
            withoutAutoReverseRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(withoutAutoReverseRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness( 0,20,0,0 );
            myTextBlock.Text = "AutoReverse=\"True\".";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle autoReverseRectangle = new Rectangle();
            autoReverseRectangle.Name = "autoReverseRectangle";
            this.RegisterName( autoReverseRectangle.Name, autoReverseRectangle );
            autoReverseRectangle.Width = 100;
            autoReverseRectangle.Height = 20;
            autoReverseRectangle.Fill = mySolidColorBrush;
            autoReverseRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(autoReverseRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness( 0,20,0,0 );
            myTextBlock.Text = "In this example, AutoReverse=\"True\" \nRepeatBehavior=\"2x\".";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle autoReverseRectangleWithRepeats = new Rectangle();
            autoReverseRectangleWithRepeats.Name = "autoReverseRectangleWithRepeats";
            this.RegisterName( autoReverseRectangleWithRepeats.Name, autoReverseRectangleWithRepeats );
            autoReverseRectangleWithRepeats.Width = 100;
            autoReverseRectangleWithRepeats.Height = 20;
            autoReverseRectangleWithRepeats.Fill = mySolidColorBrush;
            autoReverseRectangleWithRepeats.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(autoReverseRectangleWithRepeats);

            myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness( 0,20,0,0 );
            myTextBlock.Text = "In this example, AutoReverse=\"True\" and RepeatBehavior=\"2x\" ";
            myTextBlock.Text += "have been set on the animation's parent timeline.";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle complexAutoReverseExample = new Rectangle();
            complexAutoReverseExample.Name = "complexAutoReverseExample";
            this.RegisterName( complexAutoReverseExample.Name, complexAutoReverseExample );
            complexAutoReverseExample.Width = 100;
            complexAutoReverseExample.Height = 20;
            complexAutoReverseExample.Fill = mySolidColorBrush;
            complexAutoReverseExample.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(complexAutoReverseExample);

            //
            //  Create an animation that does not automatically play in reverse.
            //
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDoubleAnimation, withoutAutoReverseRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myDoubleAnimation.From = 100;
            myDoubleAnimation.To = 400;
            myDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myDoubleAnimation.AutoReverse = false;

            //
            // Create an animation that automatically reverses at the end of each iteration.
            //
            DoubleAnimation myAutomaticallyReversedDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myAutomaticallyReversedDoubleAnimation, autoReverseRectangle.Name);
            Storyboard.SetTargetProperty(myAutomaticallyReversedDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myAutomaticallyReversedDoubleAnimation.From = 100;
            myAutomaticallyReversedDoubleAnimation.To = 400;
            myAutomaticallyReversedDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myAutomaticallyReversedDoubleAnimation.AutoReverse = true;

            //
            // Create an animation that automatically reverses at the end of each iteration.
            //  Set the animation to repeat twice. As
            //  a result, then animation plays forward, then backward, then forward, and then backward again.
            DoubleAnimation myRepeatedAndReversedDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myRepeatedAndReversedDoubleAnimation, autoReverseRectangleWithRepeats.Name);
            Storyboard.SetTargetProperty(myRepeatedAndReversedDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myRepeatedAndReversedDoubleAnimation.From = 100;
            myRepeatedAndReversedDoubleAnimation.To = 400;
            myRepeatedAndReversedDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myRepeatedAndReversedDoubleAnimation.AutoReverse = true;
            myRepeatedAndReversedDoubleAnimation.RepeatBehavior = new RepeatBehavior(2);

            //
            // Set the parent timeline's AutoReverse property to True and set the animation's
            //   RepeatBehavior to 2x. As a result, the animation plays forward twice and then backwards twice.
            //
            ParallelTimeline myParallelTimeline = new ParallelTimeline();
            myParallelTimeline.AutoReverse = true;
            DoubleAnimation myParallelRepeatedAndReversedDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myParallelRepeatedAndReversedDoubleAnimation, complexAutoReverseExample.Name);
            Storyboard.SetTargetProperty(myParallelRepeatedAndReversedDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myParallelRepeatedAndReversedDoubleAnimation.From = 100;
            myParallelRepeatedAndReversedDoubleAnimation.To = 400;
            myParallelRepeatedAndReversedDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myParallelRepeatedAndReversedDoubleAnimation.AutoReverse = true;
            myParallelRepeatedAndReversedDoubleAnimation.RepeatBehavior = new RepeatBehavior(2);

            //
            // Create a Storyboard to contain the animations and add the animations to the Storyboard
            //
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Children.Add(myAutomaticallyReversedDoubleAnimation);
            myStoryboard.Children.Add(myRepeatedAndReversedDoubleAnimation);
            myParallelTimeline.Children.Add(myParallelRepeatedAndReversedDoubleAnimation);
            myStoryboard.Children.Add(myParallelTimeline);

            //
            //  Create the button to restart the animations.
            //
            Button myButton = new Button();
            myButton.Margin = new Thickness( 0,30,0,0 );
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.Content = "Restart Animations";
            myStackPanel.Children.Add(myButton);

            //
            //  Create an EventTrigger and a BeginStoryboard action to start
            //    the storyboard
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;

            EventTrigger myEventTrigger = new EventTrigger();
            myEventTrigger.RoutedEvent = Button.ClickEvent;
            myEventTrigger.SourceName = myButton.Name;
            myEventTrigger.Actions.Add(myBeginStoryboard);
            myStackPanel.Triggers.Add(myEventTrigger);
            this.Content = myStackPanel;
        }
    }
}
