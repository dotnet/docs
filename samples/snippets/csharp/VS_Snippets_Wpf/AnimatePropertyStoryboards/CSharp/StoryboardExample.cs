//<Snippet11>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{


    // Uses a storyboard to animate the properties
    // of two buttons.
    public class StoryboardExample : Page
    {

        public StoryboardExample()
        {
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());
            
            this.WindowTitle = "Animate Properties using Storyboards";
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.MinWidth = 500;
            myStackPanel.Margin = new Thickness(30);
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left;
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = "Storyboard Animation Example";
            myStackPanel.Children.Add(myTextBlock);
            
            //
            // Create and animate the first button.
            //
            
            // Create a button.
            Button myWidthAnimatedButton = new Button();
            myWidthAnimatedButton.Height = 30;
            myWidthAnimatedButton.Width = 200;
            myWidthAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left;
            myWidthAnimatedButton.Content = "A Button";

            // Set the Name of the button so that it can be referred
            // to in the storyboard that's created later.
            // The ID doesn't have to match the variable name;
            // it can be any unique identifier.
            myWidthAnimatedButton.Name = "myWidthAnimatedButton";
            
            // Register the name with the page to which the button belongs.
            this.RegisterName(myWidthAnimatedButton.Name, myWidthAnimatedButton);
            
            // Create a DoubleAnimation to animate the width of the button.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 200;
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));          
   
            // Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(myDoubleAnimation, myWidthAnimatedButton.Name); 
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.WidthProperty));
            
            // Create a storyboard to contain the animation.
            Storyboard myWidthAnimatedButtonStoryboard = new Storyboard();
            myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation);
            
            // Animate the button width when it's clicked.
            myWidthAnimatedButton.Click += delegate(object sender, RoutedEventArgs args)
                {
                    myWidthAnimatedButtonStoryboard.Begin(myWidthAnimatedButton);
                };

            
            myStackPanel.Children.Add(myWidthAnimatedButton);

            //
            // Create and animate the second button.
            //

            // Create a second button.
            Button myColorAnimatedButton = new Button();
            myColorAnimatedButton.Height = 30;
            myColorAnimatedButton.Width = 200;
            myColorAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left;
            myColorAnimatedButton.Content = "Another Button";
            
            // Create a SolidColorBrush to paint the button's background.
            SolidColorBrush myBackgroundBrush = new SolidColorBrush();
            myBackgroundBrush.Color = Colors.Blue;
            
            // Because a Brush isn't a FrameworkElement, it doesn't
            // have a Name property to set. Instead, you just
            // register a name for the SolidColorBrush with
            // the page where it's used.
            this.RegisterName("myAnimatedBrush", myBackgroundBrush);
            
            // Use the brush to paint the background of the button.
            myColorAnimatedButton.Background = myBackgroundBrush;
            
            // Create a ColorAnimation to animate the button's background.
            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.Red;
            myColorAnimation.To = Colors.Blue;
            myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(7000));    
            
            // Configure the animation to target the brush's Color property.
            Storyboard.SetTargetName(myColorAnimation, "myAnimatedBrush");                        
            Storyboard.SetTargetProperty(myColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));    

            // Create a storyboard to contain the animation.
            Storyboard myColorAnimatedButtonStoryboard = new Storyboard();
            myColorAnimatedButtonStoryboard.Children.Add(myColorAnimation);

            // Animate the button background color when it's clicked.
            myColorAnimatedButton.Click += delegate(object sender, RoutedEventArgs args)
                {
                    myColorAnimatedButtonStoryboard.Begin(myColorAnimatedButton);
                };

          
            myStackPanel.Children.Add(myColorAnimatedButton);
            this.Content = myStackPanel;

        }
    }
}
//</Snippet11>