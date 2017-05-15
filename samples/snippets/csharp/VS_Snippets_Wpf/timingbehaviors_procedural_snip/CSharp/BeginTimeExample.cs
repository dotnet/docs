/*

This example shows how the BeginTime property determines when a timeline starts.
Several rectangles re-animated by DoubleAnimations with identical durations and target values, but with different
  BeginTime settings.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class BeginTimeExample : Page
    {
        public BeginTimeExample()
        {
        
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());
            
            this.WindowTitle = "BeginTime Example";

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness( 20 );

            Border myBorder = new Border();
            Color myColor = new Color();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Color.FromArgb(153,255,255,255));
            mySolidColorBrush.Color = myColor;
            myBorder.Background = mySolidColorBrush;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness(20);
            myTextBlock.Text = "This example shows how the BeginTime property determines when a timeline starts.";
            myTextBlock.Text += " Several rectangles are animated by DoubleAnimations with identical durations and";
            myTextBlock.Text += " target values, but with different BeginTime settings.";
            myBorder.Child = myTextBlock;
            myStackPanel.Children.Add(myBorder);

            myTextBlock = new TextBlock();
            myTextBlock.Text = "Animation BeginTime: \"0:0:0\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle defaultBeginTimeRectangle = new Rectangle();
            defaultBeginTimeRectangle.Name = "defaultBeginTimeRectangle";
            this.RegisterName( defaultBeginTimeRectangle.Name, defaultBeginTimeRectangle );
            defaultBeginTimeRectangle.Width = 20;
            defaultBeginTimeRectangle.Height = 20;
            myColor = new Color();
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            defaultBeginTimeRectangle.Fill = mySolidColorBrush;
            defaultBeginTimeRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(defaultBeginTimeRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Margin = new Thickness(0,20,0,0);
            myTextBlock.Text = "Animation BeginTime: \"0:0:5\" \n";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle delayedBeginTimeRectangle = new Rectangle();
            delayedBeginTimeRectangle.Name = "delayedBeginTimeRectangle";
            this.RegisterName( delayedBeginTimeRectangle.Name, delayedBeginTimeRectangle );
            delayedBeginTimeRectangle.Width = 20;
            delayedBeginTimeRectangle.Height = 20;
            myColor = new Color();
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            delayedBeginTimeRectangle.Fill = mySolidColorBrush;
            delayedBeginTimeRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(delayedBeginTimeRectangle);


            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nParent Timeline BeginTime: \"0:0:5\" \nAnimation BeginTime: \"0:0:5\" ";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle delayedAnimationWithDelayedParentRectangle = new Rectangle();
            delayedAnimationWithDelayedParentRectangle.Name = "delayedAnimationWithDelayedParentRectangle";
            this.RegisterName( delayedAnimationWithDelayedParentRectangle.Name,
                delayedAnimationWithDelayedParentRectangle );
            delayedAnimationWithDelayedParentRectangle.Width = 20;
            delayedAnimationWithDelayedParentRectangle.Height = 20;
            myColor = new Color();
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            delayedAnimationWithDelayedParentRectangle.Fill = mySolidColorBrush;
            delayedAnimationWithDelayedParentRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(delayedAnimationWithDelayedParentRectangle);

            //
            //  Create an animation with no delay in the start time.
            //
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDoubleAnimation, defaultBeginTimeRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myDoubleAnimation.From = 20;
            myDoubleAnimation.To = 400;
            myDoubleAnimation.BeginTime = TimeSpan.FromSeconds(0);
            myDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myDoubleAnimation.FillBehavior = FillBehavior.HoldEnd;


            //
            //  Create an animation with a 5 second delay in the start time.
            //
            DoubleAnimation myDelayedDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDelayedDoubleAnimation, delayedBeginTimeRectangle.Name);
            Storyboard.SetTargetProperty(myDelayedDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myDelayedDoubleAnimation.BeginTime = TimeSpan.FromSeconds(5);
            myDelayedDoubleAnimation.From = 20;
            myDelayedDoubleAnimation.To = 400;
            myDelayedDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myDelayedDoubleAnimation.FillBehavior = FillBehavior.HoldEnd;


            //
            //  Create an animation with a 5 second delay in both the parent and
            //  child timelines.
            //
            ParallelTimeline myParallelTimeline = new ParallelTimeline();
            myParallelTimeline.BeginTime = TimeSpan.FromSeconds(5);
            DoubleAnimation myParallelDelayedDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myParallelDelayedDoubleAnimation,
                delayedAnimationWithDelayedParentRectangle.Name);
            Storyboard.SetTargetProperty(myParallelDelayedDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myParallelDelayedDoubleAnimation.From = 20;
            myParallelDelayedDoubleAnimation.To = 400;
            myParallelDelayedDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myParallelDelayedDoubleAnimation.FillBehavior = FillBehavior.HoldEnd;
            myParallelDelayedDoubleAnimation.BeginTime = TimeSpan.FromSeconds(5);

            //
            // Create a Storyboard to contain the animations and add the animations to the Storyboard
            //
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Children.Add(myDelayedDoubleAnimation);
            myParallelTimeline.Children.Add(myParallelDelayedDoubleAnimation);
            myStoryboard.Children.Add(myParallelTimeline);

            //
            //  Create the button to restart the animations
            //
            Button myButton = new Button();
            myButton.Margin = new Thickness(0,30,0,0);
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.Content = "Restart Animations";
            myStackPanel.Children.Add( myButton );

           //
           //  Create an EventTrigger and a BeginStoryboard action to start
           //    the storyboard
           //
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
