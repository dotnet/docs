/*
  SpeedExample.cs
     This example demonstrates how different speed ratios affect an animation

*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class SpeedExample : Page
    {
        public SpeedExample()
        {

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            this.WindowTitle = "Speed Example";

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness( 20 );

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Speed=\"1\"";
            myStackPanel.Children.Add(myTextBlock);

            //
            //  Create the rectangles to animate
            //
            Rectangle defaultSpeedRectangle = new Rectangle();
            defaultSpeedRectangle.Name = "defaultSpeedRectangle";
            this.RegisterName( defaultSpeedRectangle.Name, defaultSpeedRectangle );
            defaultSpeedRectangle.Width = 20;
            defaultSpeedRectangle.Height = 20;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            defaultSpeedRectangle.Fill = mySolidColorBrush;
            defaultSpeedRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(defaultSpeedRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Margin= new Thickness(0,20,0,0);
            myTextBlock.Text = "Speed=\"2\"";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle fasterRectangle = new Rectangle();
            fasterRectangle.Name = "fasterRectangle";
            this.RegisterName( fasterRectangle.Name, fasterRectangle );
            fasterRectangle.Width = 20;
            fasterRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            fasterRectangle.Fill = mySolidColorBrush;
            fasterRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(fasterRectangle);

            myTextBlock = new TextBlock();
            myTextBlock.Margin= new Thickness(0,20,0,0);
            myTextBlock.Text = "Speed=\"0.5\"";
            myStackPanel.Children.Add(myTextBlock);

            Rectangle slowerRectangle = new Rectangle();
            slowerRectangle.Name = "slowerRectangle";
            this.RegisterName( slowerRectangle.Name, slowerRectangle );
            slowerRectangle.Width = 20;
            slowerRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(170,51,51,255));
            slowerRectangle.Fill = mySolidColorBrush;
            slowerRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(slowerRectangle);

            //
            //  Creates an animation with the default speed ratio value of 1
            //
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDoubleAnimation, defaultSpeedRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myDoubleAnimation.From = 20;
            myDoubleAnimation.To = 400;
            myDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(2000));
            myDoubleAnimation.SpeedRatio = 1;

            //
            //  Creates an animation with the speed ratio value of 2
            //
            DoubleAnimation myDoubleSpeedRatioDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDoubleSpeedRatioDoubleAnimation, fasterRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleSpeedRatioDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myDoubleSpeedRatioDoubleAnimation.From = 20;
            myDoubleSpeedRatioDoubleAnimation.To = 400;
            myDoubleSpeedRatioDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
            myDoubleSpeedRatioDoubleAnimation.SpeedRatio = 2;

            //
            //  Creates an animation with the speed ratio value of 0.5
            //
            DoubleAnimation myHalvedSpeedRatioDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myHalvedSpeedRatioDoubleAnimation, slowerRectangle.Name);
            Storyboard.SetTargetProperty(myHalvedSpeedRatioDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myHalvedSpeedRatioDoubleAnimation.From = 20;
            myHalvedSpeedRatioDoubleAnimation.To = 400;
            myHalvedSpeedRatioDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
            myHalvedSpeedRatioDoubleAnimation.SpeedRatio = 0.5;

            //
            //  Create a Storyboard to contain the animations and add the animations to the Storyboard
            //
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Children.Add(myDoubleSpeedRatioDoubleAnimation);
            myStoryboard.Children.Add(myHalvedSpeedRatioDoubleAnimation);

            //
            //  Create the button to restart the animations.
            //
            Button myButton = new Button();
            myButton.Margin = new Thickness( 0,30,0,0 );
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.Content = "Restart Animations";
            myStackPanel.Children.Add(myButton);

            //
            //  Create an EventTrigger and a BeginStoryboard action to start the storyboard
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
