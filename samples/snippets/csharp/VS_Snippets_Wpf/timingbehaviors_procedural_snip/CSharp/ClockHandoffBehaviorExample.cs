//<SnippetClockHandoffBehaviorExampleWholePage>
/*

   This sample animates the position of an ellipse when
   the user clicks within the main border. If the user
   left-clicks, the SnapshotAndReplace HandoffBehavior
   is used when applying the animations. If the user
   right-clicks, the Compose HandoffBehavior is used
   instead.

*/

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;

namespace Microsoft.Samples.Animation.TimingBehaviors
{

    // Create the demonstration.
    public class ClockHandoffBehaviorExample : Page {

        private TranslateTransform interactiveTranslateTransform;
        private Border containerBorder;
        private Ellipse interactiveEllipse;

        public ClockHandoffBehaviorExample()
        {

            WindowTitle = "Interactive Animation Example";
            DockPanel myPanel = new DockPanel();
            myPanel.Margin = new Thickness(20.0);

            containerBorder = new Border();
            containerBorder.Background = Brushes.White;
            containerBorder.BorderBrush = Brushes.Black;
            containerBorder.BorderThickness = new Thickness(2.0);
            containerBorder.VerticalAlignment = VerticalAlignment.Stretch;

            interactiveEllipse = new Ellipse();
            interactiveEllipse.Fill = Brushes.Lime;
            interactiveEllipse.Stroke = Brushes.Black;
            interactiveEllipse.StrokeThickness = 2.0;
            interactiveEllipse.Width = 25;
            interactiveEllipse.Height = 25;
            interactiveEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            interactiveEllipse.VerticalAlignment = VerticalAlignment.Top;

            interactiveTranslateTransform = new TranslateTransform();
            interactiveEllipse.RenderTransform =
                interactiveTranslateTransform;

            containerBorder.MouseLeftButtonDown +=
                new MouseButtonEventHandler(border_mouseLeftButtonDown);
            containerBorder.MouseRightButtonDown +=
                new MouseButtonEventHandler(border_mouseRightButtonDown);

            containerBorder.Child = interactiveEllipse;
            myPanel.Children.Add(containerBorder);
            this.Content = myPanel;
        }

        // When the user left-clicks, use the
        // SnapshotAndReplace HandoffBehavior when applying the animation.
        private void border_mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point clickPoint = Mouse.GetPosition(containerBorder);

            // Set the target point so the center of the ellipse
            // ends up at the clicked point.
            Point targetPoint = new Point();
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2;
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2;

            // Animate to the target point.
            DoubleAnimation xAnimation =
                new DoubleAnimation(targetPoint.X,
                new Duration(TimeSpan.FromSeconds(4)));
            AnimationClock xAnimationClock = xAnimation.CreateClock();

            interactiveTranslateTransform.ApplyAnimationClock(
                TranslateTransform.XProperty,
                xAnimationClock,
                HandoffBehavior.SnapshotAndReplace);

            DoubleAnimation yAnimation =
                new DoubleAnimation(targetPoint.Y,
                new Duration(TimeSpan.FromSeconds(4)));

            AnimationClock yAnimationClock = yAnimation.CreateClock();
            interactiveTranslateTransform.ApplyAnimationClock(
                TranslateTransform.YProperty,
                yAnimationClock,
                HandoffBehavior.SnapshotAndReplace);

            // Change the color of the ellipse.
            interactiveEllipse.Fill = Brushes.Lime;
        }

        // When the user right-clicks, use the
        // Compose HandoffBehavior when applying the animation.
        private void border_mouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            // Find the point where the use clicked.
            Point clickPoint = Mouse.GetPosition(containerBorder);

            // Set the target point so the center of the ellipse
            // ends up at the clicked point.
            Point targetPoint = new Point();
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2;
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2;

            // Animate to the target point.
            DoubleAnimation xAnimation =
                new DoubleAnimation(targetPoint.X,
                new Duration(TimeSpan.FromSeconds(4)));
            AnimationClock xAnimationClock = xAnimation.CreateClock();

            interactiveTranslateTransform.ApplyAnimationClock(
                TranslateTransform.XProperty,
                xAnimationClock,
                HandoffBehavior.Compose);

            DoubleAnimation yAnimation =
                new DoubleAnimation(targetPoint.Y,
                new Duration(TimeSpan.FromSeconds(4)));

            AnimationClock yAnimationClock = yAnimation.CreateClock();
            interactiveTranslateTransform.ApplyAnimationClock(
                TranslateTransform.YProperty,
                yAnimationClock,
                HandoffBehavior.Compose);

            // Change the color of the ellipse.
            interactiveEllipse.Fill = Brushes.Orange;
        }
    }
}
//</SnippetClockHandoffBehaviorExampleWholePage>
