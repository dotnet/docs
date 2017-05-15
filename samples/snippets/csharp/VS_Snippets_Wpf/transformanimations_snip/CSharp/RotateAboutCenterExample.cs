/*
  RotateAboutCenterExample.cs
     This example shows how to use the RepeatBehavior property to make a timeline repeat.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace Microsoft.Samples.Animation
{
    public partial class RotateAboutCenterExample : Page
    {
//<SnippetUIElementRenderTransformOrigin>
        public RotateAboutCenterExample()
        {
            this.WindowTitle = "Rotate About Center Example";
            NameScope.SetNameScope(this, new NameScope());
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(50);

            Button myButton = new Button();
            myButton.Name = "myRenderTransformButton";
            this.RegisterName(myButton.Name,myButton);
            myButton.RenderTransformOrigin = new Point(0.5,0.5);
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.Content = "Hello World";


            RotateTransform myRotateTransform = new RotateTransform(0);
            myButton.RenderTransform = myRotateTransform;
            this.RegisterName("MyAnimatedTransform",myRotateTransform);

            myStackPanel.Children.Add(myButton);

            //
            // Creates an animation that accelerates through 40% of its duration and
            //      decelerates through the 60% of its duration.
            //
            DoubleAnimation myRotateAboutCenterAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myRotateAboutCenterAnimation,"MyAnimatedTransform");
            Storyboard.SetTargetProperty(myRotateAboutCenterAnimation,new PropertyPath(RotateTransform.AngleProperty));
            myRotateAboutCenterAnimation.From = 0.0;
            myRotateAboutCenterAnimation.To = 360;
            myRotateAboutCenterAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            // Create a Storyboard to contain the animations and
            // add the animations to the Storyboard.
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myRotateAboutCenterAnimation);

            // Create an EventTrigger and a BeginStoryboard action to
            // start the storyboard.
            EventTrigger myEventTrigger = new EventTrigger();
            myEventTrigger.RoutedEvent = Button.ClickEvent;
            myEventTrigger.SourceName = myButton.Name;
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;
            myEventTrigger.Actions.Add(myBeginStoryboard);
            myStackPanel.Triggers.Add(myEventTrigger);

            this.Content = myStackPanel;
        }
//</SnippetUIElementRenderTransformOrigin>
    }
}
