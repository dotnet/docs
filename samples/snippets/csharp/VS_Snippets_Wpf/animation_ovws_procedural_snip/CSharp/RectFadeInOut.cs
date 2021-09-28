// <SnippetRectFadeInOutCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SDKSample
{

    public class RectangleOpacityFadeExample : Page
    {
        public RectangleOpacityFadeExample()
        {
            NameScope.SetNameScope(this, new NameScope());

            this.WindowTitle = "Fading Rectangle Example";
            StackPanel myPanel = new StackPanel();
            myPanel.Margin = new Thickness(10);

            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(5000));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;

            EventTrigger myLoadedEventTrigger = new EventTrigger();
            myLoadedEventTrigger.RoutedEvent = Rectangle.LoadedEvent;
            myLoadedEventTrigger.Actions.Add(myBeginStoryboard);

            myRectangle.Triggers.Add(myLoadedEventTrigger);
            myPanel.Children.Add(myRectangle);
            this.Content = myPanel;
        }
    }
}

// </SnippetRectFadeInOutCodeExampleWholePage>