/*

OpacityAnimationExample.cs
  This example shows how to animate the opacity of objects,
     making them fade in and out of view.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class OpacityAnimationExample : Page
    {
        public OpacityAnimationExample()
        {
        
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());        
        
            this.WindowTitle = "Opacity Animation Example";
            this.Background = Brushes.White;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            //
            //  Clicking on this button animates its opacity.
            //
            Button opacityAnimatedButton = new Button();
            opacityAnimatedButton.Name = "opacityAnimatedButton";
            this.RegisterName( opacityAnimatedButton.Name, opacityAnimatedButton);
            opacityAnimatedButton.Content = "A Button";
            myStackPanel.Children.Add(opacityAnimatedButton);

            //
            //  Create an animation to animate the opacity of a button
            //
            DoubleAnimation myOpacityDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myOpacityDoubleAnimation,opacityAnimatedButton.Name);
            Storyboard.SetTargetProperty(myOpacityDoubleAnimation,new PropertyPath(Button.OpacityProperty));
            myOpacityDoubleAnimation.From = 1;
            myOpacityDoubleAnimation.To = 0;
            myOpacityDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(5000));
            myOpacityDoubleAnimation.AutoReverse = true;

            //
            //  Create a Storyboard to contain the animations and add the animations to the Storyboard
            //
            Storyboard myOpacityStoryboard = new Storyboard();
            myOpacityStoryboard.Children.Add(myOpacityDoubleAnimation);

            //
            //  Create EventTriggers and a BeginStoryboard action to start
            //  the storyboard
            BeginStoryboard myOpacityBeginStoryboard = new BeginStoryboard();
            EventTrigger myOpacityEventTrigger = new EventTrigger();
            myOpacityEventTrigger.RoutedEvent = Button.ClickEvent;
            myOpacityEventTrigger.SourceName = opacityAnimatedButton.Name;
            myStackPanel.Triggers.Add(myOpacityEventTrigger);

            myOpacityBeginStoryboard.Storyboard = myOpacityStoryboard;
            myOpacityEventTrigger.Actions.Add(myOpacityBeginStoryboard);



            //
            //  Clicking on this button animates the opacity of the brush used to paint the background.
            //
            Button opacityBrushPaintedButton = new Button();
            opacityBrushPaintedButton.Name = "opacityBrushPaintedButton";
            this.RegisterName(opacityBrushPaintedButton.Name, opacityBrushPaintedButton);
            opacityBrushPaintedButton.Content = "A Button";
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            this.RegisterName("mySolidColorBrush", mySolidColorBrush);
            mySolidColorBrush.Color = Colors.Orange;
            opacityBrushPaintedButton.Background = mySolidColorBrush;
            myStackPanel.Children.Add(opacityBrushPaintedButton);

            //
            //  Create an animation to animate the opacity of the brush used to paint the background of the button.
            //
            DoubleAnimation myBackgroundOpacityDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myBackgroundOpacityDoubleAnimation, "mySolidColorBrush");
            Storyboard.SetTargetProperty(myBackgroundOpacityDoubleAnimation, new PropertyPath(Brush.OpacityProperty));
            
            myBackgroundOpacityDoubleAnimation.From = 1;
            myBackgroundOpacityDoubleAnimation.To = 0;
            myBackgroundOpacityDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myBackgroundOpacityDoubleAnimation.AutoReverse = true;

            Storyboard myBackgroundOpacityStoryboard = new Storyboard();
            myBackgroundOpacityStoryboard.Children.Add(myBackgroundOpacityDoubleAnimation);

            //
            //  Create EventTriggers and a BeginStoryboard action to start
            //  the storyboard
            BeginStoryboard myBackgroundOpacityBeginStoryboard = new BeginStoryboard();
            EventTrigger myBackgroundOpacityEventTrigger = new EventTrigger();
            myBackgroundOpacityEventTrigger.RoutedEvent = Button.ClickEvent;
            myBackgroundOpacityEventTrigger.SourceName = opacityBrushPaintedButton.Name;
            myStackPanel.Triggers.Add(myBackgroundOpacityEventTrigger);

            myBackgroundOpacityBeginStoryboard.Storyboard = myBackgroundOpacityStoryboard;
            myBackgroundOpacityEventTrigger.Actions.Add(myBackgroundOpacityBeginStoryboard);

            this.Content = myStackPanel;
        }
    }
}
