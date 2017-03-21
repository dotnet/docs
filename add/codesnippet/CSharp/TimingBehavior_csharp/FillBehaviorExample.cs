/*

FillBehaviorExample.cs
  This Sample demonstrates how the FillBehavior property influences behavior at the end of an animation.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public class FillBehaviorExample : Page
    {
        public FillBehaviorExample()
        {

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            WindowTitle = "FillBehavior Example";

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness( 20 );

            Border myBorder = new Border();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Color.FromArgb(153,255,255,255));
            myBorder.Background = mySolidColorBrush;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "This example shows how the FillBehavior property determines how an ";
            myTextBlock.Text += "animation behaves after it reaches the end of its duration.";
            myTextBlock.Margin = new Thickness( 20 );
            myBorder.Child =  myTextBlock;
            myStackPanel.Children.Add( myBorder );

            myTextBlock = new TextBlock();
            myTextBlock.Text = "FillBehavior = \"Deactivate\"";
            myStackPanel.Children.Add( myTextBlock );


            //
            //  Create the first rectangle to animate.
            //
            Rectangle deactivateAnimationRectangle = new Rectangle();
            deactivateAnimationRectangle.Name = "deactivateAnimationRectangle";
            this.RegisterName(deactivateAnimationRectangle.Name, deactivateAnimationRectangle);
            deactivateAnimationRectangle.Width = 20;
            deactivateAnimationRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            deactivateAnimationRectangle.Fill = mySolidColorBrush;
            deactivateAnimationRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add( deactivateAnimationRectangle );

            myTextBlock = new TextBlock();
            myTextBlock.Text = "\nFillBehavior = \"HoldEnd\"";
            myStackPanel.Children.Add( myTextBlock );

            //
            //  Create the second rectangle to animate.
            //
            Rectangle holdEndAnimationRectangle = new Rectangle();
            holdEndAnimationRectangle.Name = "holdEndAnimationRectangle";
            this.RegisterName(holdEndAnimationRectangle.Name, holdEndAnimationRectangle);
            holdEndAnimationRectangle.Width = 20;
            holdEndAnimationRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            holdEndAnimationRectangle.Fill = mySolidColorBrush;
            holdEndAnimationRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add( holdEndAnimationRectangle );

            //
            // Create an animation which reverts the  width of the rectangle
            //     back to its non-animated value.
            //
            DoubleAnimation myStopDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myStopDoubleAnimation, deactivateAnimationRectangle.Name);
            Storyboard.SetTargetProperty(myStopDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myStopDoubleAnimation.From = 100;
            myStopDoubleAnimation.To = 400;
            myStopDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myStopDoubleAnimation.FillBehavior = FillBehavior.Stop;

            //
            //  Create an animation which maintains the width of the rectangle at the completion of the animation.
            //
            DoubleAnimation myHoldEndDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myHoldEndDoubleAnimation, holdEndAnimationRectangle.Name);
            Storyboard.SetTargetProperty(myHoldEndDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myHoldEndDoubleAnimation.From = 100;
            myHoldEndDoubleAnimation.To = 400;
            myHoldEndDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myHoldEndDoubleAnimation.FillBehavior = FillBehavior.HoldEnd;

            //
            //  Create a Storyboard to contain the animations and add the animations to the Storyboard
            //
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myStopDoubleAnimation);
            myStoryboard.Children.Add(myHoldEndDoubleAnimation);

            //
            //  Create the button to start the animation
            //
            Button myButton = new Button();
            myButton.Name = "myButton";
            this.RegisterName( myButton.Name, myButton );
            myButton.Margin = new Thickness( 0,30,0,0 );
            myButton.Content = "Restart Animations";
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add( myButton );

            //
            //  Create an EventTrigger and a BeginStoryboard action to start
            //    the storyboard.
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
