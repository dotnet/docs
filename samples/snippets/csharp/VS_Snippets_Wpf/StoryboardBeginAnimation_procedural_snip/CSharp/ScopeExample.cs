// <SnippetNameScopeExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{

    public class ScopeExample : Page
    {

        private Storyboard myStoryboard;
        private StackPanel myMainPanel;
        private Button button1, button2;

        public ScopeExample()
        {

            this.Background = Brushes.White;
            myMainPanel = new StackPanel();

            // Create a name scope for the stackpanel.
            NameScope.SetNameScope(myMainPanel, new NameScope());

            myMainPanel.Background = Brushes.Orange;

            button1 = new Button();
            button1.Name = "Button1";

            // Register button1's name with myMainPanel.
            myMainPanel.RegisterName(button1.Name, button1);
            button1.Content = "Button 1";
            button1.Click += new RoutedEventHandler(button1Clicked);
            myMainPanel.Children.Add(button1);

            button2 = new Button();
            button2.Name = "Button2";

            // Register button2's name with myMainPanel.
            myMainPanel.RegisterName(button2.Name, button2);
            button2.Content = "Button 2";
            button2.Click += new RoutedEventHandler(button2Clicked);
            myMainPanel.Children.Add(button2);

            // Create some animations and a storyboard.
            DoubleAnimation button1WidthAnimation =
                new DoubleAnimation(300, 200, new Duration(TimeSpan.FromSeconds(5)));
            Storyboard.SetTargetName(button1WidthAnimation, button1.Name);
            Storyboard.SetTargetProperty(button1WidthAnimation, new PropertyPath(Button.WidthProperty));

            DoubleAnimation button2WidthAnimation =
                new DoubleAnimation(300, 200, new Duration(TimeSpan.FromSeconds(5)));
            Storyboard.SetTargetName(button2WidthAnimation, button2.Name);
            Storyboard.SetTargetProperty(button2WidthAnimation, new PropertyPath(Button.WidthProperty));

            DoubleAnimation heightAnimationWithoutTarget =
                new DoubleAnimation(300, 200, new Duration(TimeSpan.FromSeconds(5)));
            Storyboard.SetTargetProperty(heightAnimationWithoutTarget, new PropertyPath(FrameworkElement.HeightProperty));

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(button1WidthAnimation);
            myStoryboard.Children.Add(button2WidthAnimation);
            myStoryboard.Children.Add(heightAnimationWithoutTarget);

            this.Content = myMainPanel;
        }

        private void button1Clicked(object sender, RoutedEventArgs args)
        {

            // Starts the animations. The animation without a specified
            // target name, heightAnimationWithoutTarget, is applied to
            // myMainPanel.
            myStoryboard.Begin(myMainPanel);
        }

        private void button2Clicked(object sender, RoutedEventArgs args)
        {

            // Starts the animations. The animation without a specified
            // target name, heightAnimationWithoutTarget, is applied to
            // button2.
            myStoryboard.Begin(button2);
        }
    }
}
// </SnippetNameScopeExample>