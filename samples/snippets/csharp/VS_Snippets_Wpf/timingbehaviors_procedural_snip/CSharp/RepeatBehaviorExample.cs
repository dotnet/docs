/*
  RepeatBehaviorExample.cs
     This example shows how to use the RepeatBehavior property to make a timeline repeat.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class RepeatBehaviorExample : Page
    {
        public RepeatBehaviorExample()
        {

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            this.WindowTitle = "RepeatBehavior Example";

            Border myBorder = new Border();
            myBorder.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.Content = myBorder;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);
            myBorder.Child = myStackPanel;

            Border myBorder1 = new Border();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Color.FromArgb(153,255,255,255));
            myBorder1.Background = mySolidColorBrush;
            myStackPanel.Children.Add(myBorder1);

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness(20);
            myTextBlock.Text = "This example shows how the RepeatBehavior property ";
            myTextBlock.Text += "is used to make a timeline repeat. Several rectangles are animated by ";
            myTextBlock.Text += "DoubleAnimations with identical durations and target values, but with different ";
            myTextBlock.Text += "RepeatBehavior settings.";
            myBorder1.Child = myTextBlock;

            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nRepeatBehavior=\"Forever\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle foreverRepeatingRectangle = new Rectangle();
            foreverRepeatingRectangle.Name = "foreverRepeatingRectangle";
            this.RegisterName( foreverRepeatingRectangle.Name, foreverRepeatingRectangle);
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            foreverRepeatingRectangle.Fill = mySolidColorBrush;
            foreverRepeatingRectangle.Width = 50;
            foreverRepeatingRectangle.Height = 20;
            foreverRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(foreverRepeatingRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nRepeatBehavior=\"0:0:4\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle fourSecondsRepeatingRectangle = new Rectangle();
            fourSecondsRepeatingRectangle.Name = "fourSecondsRepeatingRectangle";
            this.RegisterName( fourSecondsRepeatingRectangle.Name, fourSecondsRepeatingRectangle);
            fourSecondsRepeatingRectangle.Fill= mySolidColorBrush;
            fourSecondsRepeatingRectangle.Width = 50;
            fourSecondsRepeatingRectangle.Height = 20;
            fourSecondsRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(fourSecondsRepeatingRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nRepeatBehavior=\"2x\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle twiceRepeatingRectangle = new Rectangle();
            twiceRepeatingRectangle.Name = "twiceRepeatingRectangle";
            this.RegisterName( twiceRepeatingRectangle.Name, twiceRepeatingRectangle);
            twiceRepeatingRectangle.Fill = mySolidColorBrush;
            twiceRepeatingRectangle.Width = 50;
            twiceRepeatingRectangle.Height = 20;
            twiceRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(twiceRepeatingRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nRepeatBehavior=\"0.05\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle halfRepeatingRectangle = new Rectangle();
            halfRepeatingRectangle.Name = "halfRepeatingRectangle";
            this.RegisterName( halfRepeatingRectangle.Name, halfRepeatingRectangle);

            halfRepeatingRectangle.Fill = mySolidColorBrush;
            halfRepeatingRectangle.Width = 50;
            halfRepeatingRectangle.Height = 20;
            halfRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(halfRepeatingRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nRepeatBehavior=\"0:0:1\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle oneSecondRepeatingRectangle = new Rectangle();
            oneSecondRepeatingRectangle.Name = "oneSecondRepeatingRectangle";
            this.RegisterName( oneSecondRepeatingRectangle.Name, oneSecondRepeatingRectangle);
            oneSecondRepeatingRectangle.Fill = mySolidColorBrush;
            oneSecondRepeatingRectangle.Width = 50;
            oneSecondRepeatingRectangle.Height = 20;
            oneSecondRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(oneSecondRepeatingRectangle);

            StackPanel myStackPanel1 = new StackPanel();
            myStackPanel.Children.Add(myStackPanel1);
            myStackPanel1.Orientation = Orientation.Horizontal;
            myStackPanel1.Margin = new Thickness(0,20,0,0);

            //
            // Create an animation that repeats indefinitely.
            //
            DoubleAnimation myForeverRepeatingDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myForeverRepeatingDoubleAnimation,foreverRepeatingRectangle.Name);
            Storyboard.SetTargetProperty(myForeverRepeatingDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myForeverRepeatingDoubleAnimation.From = 50;
            myForeverRepeatingDoubleAnimation.To = 300;
            myForeverRepeatingDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
            myForeverRepeatingDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //
            //  Create an animation that repeats for four seconds.
            //      As a result,the animation repeats twice.
            DoubleAnimation myFourSecondsRepeatingDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myFourSecondsRepeatingDoubleAnimation,
                 fourSecondsRepeatingRectangle.Name);
            Storyboard.SetTargetProperty(myFourSecondsRepeatingDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myFourSecondsRepeatingDoubleAnimation.From = 50;
            myFourSecondsRepeatingDoubleAnimation.To = 300;
            myFourSecondsRepeatingDoubleAnimation.Duration =
                new Duration(TimeSpan.FromMilliseconds(2000));
            myFourSecondsRepeatingDoubleAnimation.RepeatBehavior=
                new RepeatBehavior(TimeSpan.FromMilliseconds(4000));

            //
            // Create an animation that repeats twice.
            //
            DoubleAnimation myTwiceRepeatingDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myTwiceRepeatingDoubleAnimation, twiceRepeatingRectangle.Name);
            Storyboard.SetTargetProperty(myTwiceRepeatingDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myTwiceRepeatingDoubleAnimation.From = 50;
            myTwiceRepeatingDoubleAnimation.To = 300;
            myTwiceRepeatingDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myTwiceRepeatingDoubleAnimation.RepeatBehavior = new RepeatBehavior(2);

            //
            // Create an animation that repeats 0.5 times. The resulting animation plays for one second,
            //   half of its Duration. It animates from 50 to 150.
            DoubleAnimation myHalfRepeatingDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myHalfRepeatingDoubleAnimation, halfRepeatingRectangle.Name);
            Storyboard.SetTargetProperty(myHalfRepeatingDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myHalfRepeatingDoubleAnimation.From = 50;
            myHalfRepeatingDoubleAnimation.To = 300;
            myHalfRepeatingDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
            myHalfRepeatingDoubleAnimation.RepeatBehavior = new RepeatBehavior(0.5);

            //
            //  Create an animation that repeats for one second. The resulting animation
            //       plays for one second, half of its Duration. It animates from 50 to 150.
            DoubleAnimation myOneSecondDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myOneSecondDoubleAnimation,oneSecondRepeatingRectangle.Name);
            Storyboard.SetTargetProperty(myOneSecondDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myOneSecondDoubleAnimation.From = 50;
            myOneSecondDoubleAnimation.To = 300;
            myOneSecondDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
            myOneSecondDoubleAnimation.RepeatBehavior =
                new RepeatBehavior(TimeSpan.FromMilliseconds(1000));

            //
            //  Create a Storyboard to contain the animations and add the animations to the Storyboard
            //
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myForeverRepeatingDoubleAnimation);
            myStoryboard.Children.Add(myFourSecondsRepeatingDoubleAnimation);
            myStoryboard.Children.Add(myTwiceRepeatingDoubleAnimation);
            myStoryboard.Children.Add(myHalfRepeatingDoubleAnimation);
            myStoryboard.Children.Add(myOneSecondDoubleAnimation);

            //
            //  Create buttons to restart and stop the animations.
            //
            Button myRestartButton = new Button();
            myRestartButton.Name = "restartButton";
            this.RegisterName(myRestartButton.Name, myRestartButton);
            myRestartButton.Content = "Start Animations";
            myStackPanel1.Children.Add(myRestartButton);

            Button myStopButton = new Button();
            myStopButton.Name = "stopButton";
            this.RegisterName(myStopButton.Name, myStopButton);
            myStopButton.Content = "Stop";
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(102,153,0,255));
            myStopButton.Background = mySolidColorBrush;
            myStackPanel1.Children.Add(myStopButton);

            //
            //  Create EventTriggers and the BeginStoryboard and StopStoryboard actions to start
            //    and stop the storyboard.
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Name = "myBeginStoryboard";
            this.RegisterName(myBeginStoryboard.Name,myBeginStoryboard);
            myBeginStoryboard.Storyboard = myStoryboard;

            EventTrigger myEventTrigger = new EventTrigger();
            myEventTrigger.RoutedEvent = Button.ClickEvent;
            myEventTrigger.SourceName = myRestartButton.Name;
            myEventTrigger.Actions.Add(myBeginStoryboard);
            myStackPanel.Triggers.Add(myEventTrigger);

            EventTrigger myEventTrigger1 = new EventTrigger();
            myEventTrigger1.RoutedEvent = Button.ClickEvent;
            myEventTrigger1.SourceName = myStopButton.Name;

            StopStoryboard myStopStoryboard = new StopStoryboard();
            myStopStoryboard.BeginStoryboardName = myBeginStoryboard.Name;
            myEventTrigger1.Actions.Add(myStopStoryboard);
            myStackPanel.Triggers.Add(myEventTrigger1);
        }
    }
}
