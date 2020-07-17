// <SnippetGraphicsMMGradientAnimationExamplesWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BrushesIntroduction
{
    public class GradientStopAnimationExample : Page
    {
        public GradientStopAnimationExample()
        {
            Title = "GradientStop Animation Example";
            Background = Brushes.White;

            // Create a NameScope for the page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create a rectangle. This rectangle will
            // be painted with a gradient.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 200;
            aRectangle.Height = 100;
            aRectangle.Stroke = Brushes.Black;
            aRectangle.StrokeThickness = 1;

            // Create a LinearGradientBrush to paint
            // the rectangle's fill.
            LinearGradientBrush gradientBrush = new LinearGradientBrush();

            // Create gradient stops for the brush.
            GradientStop stop1 = new GradientStop(Colors.MediumBlue, 0.0);
            GradientStop stop2 = new GradientStop(Colors.Purple, 0.5);
            GradientStop stop3 = new GradientStop(Colors.Red, 1.0);

            // Register a name for each gradient stop with the
            // page so that they can be animated by a storyboard.
            this.RegisterName("GradientStop1", stop1);
            this.RegisterName("GradientStop2", stop2);
            this.RegisterName("GradientStop3", stop3);

            // Add the stops to the brush.
            gradientBrush.GradientStops.Add(stop1);
            gradientBrush.GradientStops.Add(stop2);
            gradientBrush.GradientStops.Add(stop3);

            // Apply the brush to the rectangle.
            aRectangle.Fill = gradientBrush;

            //
            // Animate the first gradient stop's offset from
            // 0.0 to 1.0 and then back to 0.0.
            //
            DoubleAnimation offsetAnimation = new DoubleAnimation();
            offsetAnimation.From = 0.0;
            offsetAnimation.To = 1.0;
            offsetAnimation.Duration = TimeSpan.FromSeconds(1.5);
            offsetAnimation.AutoReverse = true;
            Storyboard.SetTargetName(offsetAnimation, "GradientStop1");
            Storyboard.SetTargetProperty(offsetAnimation,
                new PropertyPath(GradientStop.OffsetProperty));

            //
            // Animate the second gradient stop's color from
            // Purple to Yellow and then back to Purple.
            //
            ColorAnimation gradientStopColorAnimation = new ColorAnimation();
            gradientStopColorAnimation.From = Colors.Purple;
            gradientStopColorAnimation.To = Colors.Yellow;
            gradientStopColorAnimation.Duration = TimeSpan.FromSeconds(1.5);
            gradientStopColorAnimation.AutoReverse = true;
            Storyboard.SetTargetName(gradientStopColorAnimation, "GradientStop2");
            Storyboard.SetTargetProperty(gradientStopColorAnimation,
                new PropertyPath(GradientStop.ColorProperty));

            // Set the animation to begin after the first animation
            // ends.
            gradientStopColorAnimation.BeginTime = TimeSpan.FromSeconds(3);

            //
            // Animate the third gradient stop's color so
            // that it becomes transparent.
            //
            ColorAnimation opacityAnimation = new ColorAnimation();

            // Reduces the target color's alpha value by 1,
            // making the color transparent.
            opacityAnimation.By = Color.FromScRgb(-1.0F, 0F, 0F, 0F);
            opacityAnimation.Duration = TimeSpan.FromSeconds(1.5);
            opacityAnimation.AutoReverse = true;
            Storyboard.SetTargetName(opacityAnimation, "GradientStop3");
            Storyboard.SetTargetProperty(opacityAnimation,
                new PropertyPath(GradientStop.ColorProperty));

            // Set the animation to begin after the first two
            // animations have ended.
            opacityAnimation.BeginTime = TimeSpan.FromSeconds(6);

            // Create a Storyboard to apply the animations.
            Storyboard gradientStopAnimationStoryboard = new Storyboard();
            gradientStopAnimationStoryboard.Children.Add(offsetAnimation);
            gradientStopAnimationStoryboard.Children.Add(gradientStopColorAnimation);
            gradientStopAnimationStoryboard.Children.Add(opacityAnimation);

            // Begin the storyboard when the left mouse button is
            // pressed over the rectangle.
            aRectangle.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
            {
                gradientStopAnimationStoryboard.Begin(this);
            };

            StackPanel mainPanel = new StackPanel();
            mainPanel.Margin = new Thickness(10);
            mainPanel.Children.Add(aRectangle);
            Content = mainPanel;
        }
    }
}
// </SnippetGraphicsMMGradientAnimationExamplesWholePage>
