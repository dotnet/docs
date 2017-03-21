/*
AnimatingSizeExample.cs
  This example shows two ways of animating the size
     of a framework element.
*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace Microsoft.Samples.Animation
{
    public partial class AnimatingSizeExample : Page
    {
        public AnimatingSizeExample()
        {
            this.WindowTitle = "Animating Size Example";
            NameScope.SetNameScope(this, new NameScope());
            Canvas myCanvas = new Canvas();
            myCanvas.Width = 650;
            myCanvas.Height = 400;

            //
            //  Create the the first button.
            //
            Button myAnimatedWidthButton = new Button();
            myAnimatedWidthButton.Name = "AnimatedWidthButton";
            this.RegisterName(myAnimatedWidthButton.Name,myAnimatedWidthButton);
            Canvas.SetLeft(myAnimatedWidthButton, 20);
            Canvas.SetTop(myAnimatedWidthButton, 20);
            myAnimatedWidthButton.Width = 200;
            myAnimatedWidthButton.Height = 150;
            myAnimatedWidthButton.BorderBrush = Brushes.Red;
            myAnimatedWidthButton.BorderThickness = new Thickness(5);
            myAnimatedWidthButton.Content = "Click Me";

            //
            //  Create an animation to increase the size of a button
            //    by animating the width property.
            DoubleAnimation myWidthAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myWidthAnimation,"AnimatedWidthButton");
            Storyboard.SetTargetProperty(myWidthAnimation,new PropertyPath(Button.WidthProperty));
            myWidthAnimation.To = 500;
            myWidthAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(10000));
            myWidthAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //
            // Create a Storyboard to contain the animation and
            //   add the animation to the Storyboard.
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myWidthAnimation);

            //
            // Create an EventTrigger and a BeginStoryboard action to
            // start the storyboard.
            //
            EventTrigger myEventTrigger = new EventTrigger();
            myEventTrigger.RoutedEvent = Button.LoadedEvent;
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;
            myEventTrigger.Actions.Add(myBeginStoryboard);
            myAnimatedWidthButton.Triggers.Add(myEventTrigger);
            myCanvas.Children.Add(myAnimatedWidthButton);

            //
            //
            //
            Button myAnimatedScaleTransformButton = new Button();
            Canvas.SetLeft(myAnimatedScaleTransformButton, 20);
            Canvas.SetTop(myAnimatedScaleTransformButton, 200);
            myAnimatedScaleTransformButton.Width = 200;
            myAnimatedScaleTransformButton.Height = 150;
            myCanvas.Children.Add(myAnimatedScaleTransformButton);

            myAnimatedScaleTransformButton.BorderBrush = Brushes.Black;
            myAnimatedScaleTransformButton.BorderThickness = new Thickness(3);
            myAnimatedScaleTransformButton.Content = "Click Me";
            ScaleTransform myScaleTransform = new ScaleTransform(1,1);
            myAnimatedScaleTransformButton.RenderTransform = myScaleTransform;
            this.RegisterName("MyAnimatedScaleTransform",myScaleTransform);

            //
            //  Create an animation to increase the size of a button
            //    by transforming the X-scale property.
            DoubleAnimation myScaleTransformAnimation = new DoubleAnimation();
            Storyboard.SetTargetName(myScaleTransformAnimation,"MyAnimatedScaleTransform");
            Storyboard.SetTargetProperty(myScaleTransformAnimation,new PropertyPath(ScaleTransform.ScaleXProperty));
            myScaleTransformAnimation.To = 3.0;
            myScaleTransformAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(10000));
            myScaleTransformAnimation.AutoReverse = true;
            myWidthAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //
            // Create a Storyboard to contain the animation and
            //   add the animation to the Storyboard.
            Storyboard myScaleTransformStoryboard = new Storyboard();
            myScaleTransformStoryboard.Children.Add(myScaleTransformAnimation);

            //
            // Create an EventTrigger and a BeginStoryboard action to
            // start the storyboard.
            //
            EventTrigger myScaleTransformEventTrigger = new EventTrigger();
            myScaleTransformEventTrigger.RoutedEvent = Button.LoadedEvent;
            BeginStoryboard myScaleTransformBeginStoryboard = new BeginStoryboard();
            myScaleTransformBeginStoryboard.Storyboard = myScaleTransformStoryboard;
            myScaleTransformEventTrigger.Actions.Add(myScaleTransformBeginStoryboard);
            myAnimatedScaleTransformButton.Triggers.Add(myScaleTransformEventTrigger);

            this.Content = myCanvas;
        }
    }
}
