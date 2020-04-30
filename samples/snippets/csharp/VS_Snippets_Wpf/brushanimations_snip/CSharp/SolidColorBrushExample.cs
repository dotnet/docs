//<Snippet1>

// <SnippetSolidColorBrushAnimationExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Input;

namespace Microsoft.Samples.Animation
{
    /// <summary>
    /// This example shows how to animate the Opacity and Color
    /// properties of a SolidColorBrush.
    /// </summary>
    public class SolidColorBrushExample : Page
    {

        public SolidColorBrushExample()
        {
            Title = "SolidColorBrush Animation Example";
            Background = Brushes.White;

            // Create a NameScope for the page so
            // that Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create a Rectangle.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 100;
            aRectangle.Height = 100;

            // Create a SolidColorBrush to paint
            // the rectangle's fill. The Opacity
            // and Color properties of the brush
            // will be animated.
            SolidColorBrush myAnimatedBrush = new SolidColorBrush();
            myAnimatedBrush.Color = Colors.Orange;
            aRectangle.Fill = myAnimatedBrush;

            // Register the brush's name with the page
            // so that it can be targeted by storyboards.
            this.RegisterName("MyAnimatedBrush", myAnimatedBrush);

            //
            // Animate the brush's color to gray when
            // the mouse enters the rectangle.
            //
            ColorAnimation mouseEnterColorAnimation = new ColorAnimation();
            mouseEnterColorAnimation.To = Colors.Gray;
            mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(1);
            Storyboard.SetTargetName(mouseEnterColorAnimation, "MyAnimatedBrush");
            Storyboard.SetTargetProperty(
                mouseEnterColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
            Storyboard mouseEnterStoryboard = new Storyboard();
            mouseEnterStoryboard.Children.Add(mouseEnterColorAnimation);
            aRectangle.MouseEnter += delegate(object sender, MouseEventArgs e)
            {
                mouseEnterStoryboard.Begin(this);
            };

            //
            // Animate the brush's color to orange when
            // the mouse leaves the rectangle.
            //
            ColorAnimation mouseLeaveColorAnimation = new ColorAnimation();
            mouseLeaveColorAnimation.To = Colors.Orange;
            mouseLeaveColorAnimation.Duration = TimeSpan.FromSeconds(1);
            Storyboard.SetTargetName(mouseLeaveColorAnimation, "MyAnimatedBrush");
            Storyboard.SetTargetProperty(
                mouseLeaveColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
            Storyboard mouseLeaveStoryboard = new Storyboard();
            mouseLeaveStoryboard.Children.Add(mouseLeaveColorAnimation);
            aRectangle.MouseLeave += delegate(object sender, MouseEventArgs e)
            {
                mouseLeaveStoryboard.Begin(this);
            };

            //
            // Animate the brush's opacity to 0 and back when
            // the left mouse button is pressed over the rectangle.
            //
            DoubleAnimation opacityAnimation = new DoubleAnimation();
            opacityAnimation.To = 0.0;
            opacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
            opacityAnimation.AutoReverse = true;
            Storyboard.SetTargetName(opacityAnimation, "MyAnimatedBrush");
            Storyboard.SetTargetProperty(
                opacityAnimation, new PropertyPath(SolidColorBrush.OpacityProperty));
            Storyboard mouseLeftButtonDownStoryboard = new Storyboard();
            mouseLeftButtonDownStoryboard.Children.Add(opacityAnimation);
            aRectangle.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
            {
                mouseLeftButtonDownStoryboard.Begin(this);
            };

            StackPanel mainPanel = new StackPanel();
            mainPanel.Margin = new Thickness(20);
            mainPanel.Children.Add(aRectangle);
            Content = mainPanel;
        }
    }
}
// </SnippetSolidColorBrushAnimationExample>


//</Snippet1>
