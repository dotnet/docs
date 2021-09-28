/*

  AccelDecelExample.cs
     This example shows how to use the AccelerationRatio and DecelerationRatio properties of timelines
     to make animations speed up or slow down as they progress.

*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class AccelDecelExample : Page
    {
        public AccelDecelExample()
        {

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            this.WindowTitle = "Acceleration and Deceleration Example";

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness( 20 );

            //
            //  Create the four rectangles to animate
            //
            Rectangle nonAcceleratedOrDeceleratedRectangle = new Rectangle();
            nonAcceleratedOrDeceleratedRectangle.Name = "nonAcceleratedOrDeceleratedRectangle";
            this.RegisterName( nonAcceleratedOrDeceleratedRectangle.Name,nonAcceleratedOrDeceleratedRectangle );
            nonAcceleratedOrDeceleratedRectangle.Width = 10;
            nonAcceleratedOrDeceleratedRectangle.Height = 20;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Color.FromArgb(251,153,51,255));
            nonAcceleratedOrDeceleratedRectangle.Fill = mySolidColorBrush;
            nonAcceleratedOrDeceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(nonAcceleratedOrDeceleratedRectangle);

            Rectangle acceleratedRectangle = new Rectangle();
            acceleratedRectangle.Name = "acceleratedRectangle";
            this.RegisterName( acceleratedRectangle.Name, acceleratedRectangle );
            acceleratedRectangle.Width = 10;
            acceleratedRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(251,51,51,255));
            acceleratedRectangle.Fill = mySolidColorBrush;
            acceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(acceleratedRectangle);

            Rectangle deceleratedRectangle = new Rectangle();
            deceleratedRectangle.Name = "deceleratedRectangle";
            this.RegisterName( deceleratedRectangle.Name, deceleratedRectangle );
            deceleratedRectangle.Width = 10;
            deceleratedRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(251,51,255,102));
            deceleratedRectangle.Fill = mySolidColorBrush;
            deceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(deceleratedRectangle);

            Rectangle acceleratedAndDeceleratedRectangle = new Rectangle();
            acceleratedAndDeceleratedRectangle.Name = "acceleratedAndDeceleratedRectangle";
            this.RegisterName( acceleratedAndDeceleratedRectangle.Name,acceleratedAndDeceleratedRectangle );
            acceleratedAndDeceleratedRectangle.Width = 10;
            acceleratedAndDeceleratedRectangle.Height = 20;
            mySolidColorBrush = new SolidColorBrush(Color.FromArgb(251,204,255,51));
            acceleratedAndDeceleratedRectangle.Fill = mySolidColorBrush;
            acceleratedAndDeceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(acceleratedAndDeceleratedRectangle);

            //
            // Creates an animation without acceleration or deceleration for comparison
            //
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDoubleAnimation, nonAcceleratedOrDeceleratedRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myDoubleAnimation.From = 20;
            myDoubleAnimation.To = 400;
            myDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(10000));

            //
            // Creates an animation that accelerates through 40% of its duration.
            //
            DoubleAnimation myAcceleratedAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myAcceleratedAnimation, acceleratedRectangle.Name);
            Storyboard.SetTargetProperty(myAcceleratedAnimation, new PropertyPath(Rectangle.WidthProperty));
            myAcceleratedAnimation.From = 20;
            myAcceleratedAnimation.To = 400;
            myAcceleratedAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(10000));
            myAcceleratedAnimation.AccelerationRatio = 0.4;

            //
            // Creates an animation that decelerates through 60% of its duration.
            //
            DoubleAnimation myDeceleratedAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myDeceleratedAnimation, deceleratedRectangle.Name);
            Storyboard.SetTargetProperty(myDeceleratedAnimation, new PropertyPath(Rectangle.WidthProperty));
            myDeceleratedAnimation.From = 20;
            myDeceleratedAnimation.To = 400;
            myDeceleratedAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(10000));
            myDeceleratedAnimation.DecelerationRatio = 0.6;

            //
            // Creates an animation that accelerates through 40% of its duration and
            //      decelerates through the 60% of its duration.
            //
            DoubleAnimation myAcceleratedAndDeceleratedAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myAcceleratedAndDeceleratedAnimation,acceleratedAndDeceleratedRectangle.Name);
            Storyboard.SetTargetProperty(myAcceleratedAndDeceleratedAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myAcceleratedAndDeceleratedAnimation.From = 20;
            myAcceleratedAndDeceleratedAnimation.To = 400;
            myAcceleratedAndDeceleratedAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(10000));
            myAcceleratedAndDeceleratedAnimation.AccelerationRatio = 0.4;
            myAcceleratedAndDeceleratedAnimation.DecelerationRatio = 0.6;

            // Create a Storyboard to contain the animations and
            // add the animations to the Storyboard.
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Children.Add(myAcceleratedAnimation);
            myStoryboard.Children.Add(myDeceleratedAnimation);
            myStoryboard.Children.Add(myAcceleratedAndDeceleratedAnimation);

            //
            // Create a button to start the animations.
            //
            Button myRestartButton = new Button();
            myRestartButton.Name = "myRestartButton";
            myRestartButton.Margin = new Thickness( 0,30,0,0);
            myRestartButton.HorizontalAlignment = HorizontalAlignment.Left;
            myRestartButton.Content = "Restart Animations";
            myStackPanel.Children.Add(myRestartButton);

            // Create an EventTrigger and a BeginStoryboard action to
            // start the storyboard.
            EventTrigger myEventTrigger = new EventTrigger();
            myEventTrigger.RoutedEvent = Button.ClickEvent;
            myEventTrigger.SourceName = myRestartButton.Name;
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;
            myEventTrigger.Actions.Add(myBeginStoryboard);
            myStackPanel.Triggers.Add(myEventTrigger);

            this.Content = myStackPanel;
          }
     }
}
