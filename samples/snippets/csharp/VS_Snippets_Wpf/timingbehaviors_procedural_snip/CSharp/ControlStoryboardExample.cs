// <SnippetControlStoryboardExampleUsingWholePage>
/*
    This example shows how to control
    a storyboard after it has started.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class ControlStoryboardExample : Page
    {
    
        private Storyboard myStoryboard;
        
        public ControlStoryboardExample()
        {
        
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());        
        
            this.WindowTitle = "Controlling a Storyboard";
            this.Background = Brushes.White;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);
            
            // Create a rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 20;
            myRectangle.Margin = new Thickness(12,0,0,5);
            myRectangle.Fill = new SolidColorBrush(Color.FromArgb(170, 51, 51, 255));
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myStackPanel.Children.Add(myRectangle);
            
            // Assign the rectangle a name by 
            // registering it with the page, so that
            // it can be targeted by storyboard
            // animations.
            this.RegisterName("myRectangle", myRectangle);           
            
            //
            // Create an animation and a storyboard to animate the
            // rectangle.
            //
            DoubleAnimation myDoubleAnimation = 
                new DoubleAnimation(100, 500, new Duration(TimeSpan.FromSeconds(5)));            
            Storyboard.SetTargetName(myDoubleAnimation, "myRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            
            //
            // Create some buttons to control the storyboard
            // and a panel to contain them.
            //
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Horizontal;
            Button beginButton = new Button();
            beginButton.Content = "Begin";
            beginButton.Click += new RoutedEventHandler(beginButton_Clicked);            
            buttonPanel.Children.Add(beginButton);
            Button pauseButton = new Button();
            pauseButton.Content = "Pause";
            pauseButton.Click +=new RoutedEventHandler(pauseButton_Clicked);
            buttonPanel.Children.Add(pauseButton);
            Button resumeButton = new Button();
            resumeButton.Content = "Resume";
            resumeButton.Click +=new RoutedEventHandler(resumeButton_Clicked);
            buttonPanel.Children.Add(resumeButton);
            Button skipToFillButton = new Button();
            skipToFillButton.Content = "Skip to Fill";
            skipToFillButton.Click +=new RoutedEventHandler(skipToFillButton_Clicked);
            buttonPanel.Children.Add(skipToFillButton);
            Button setSpeedRatioButton = new Button();
            setSpeedRatioButton.Content = "Triple Speed";
            setSpeedRatioButton.Click +=new RoutedEventHandler(setSpeedRatioButton_Clicked);
            buttonPanel.Children.Add(setSpeedRatioButton);
            Button stopButton = new Button();
            stopButton.Content = "Stop";
            stopButton.Click +=new RoutedEventHandler(stopButton_Clicked);
            buttonPanel.Children.Add(stopButton);
            myStackPanel.Children.Add(buttonPanel);           
            this.Content = myStackPanel;            
        }
        
        // Begins the storyboard.
        private void beginButton_Clicked(object sender, RoutedEventArgs args)
        {
            // Specifying "true" as the second Begin parameter
            // makes this storyboard controllable.
            myStoryboard.Begin(this, true);          
        
        }
        
        // Pauses the storyboard.
        private void pauseButton_Clicked(object sender, RoutedEventArgs args)
        {
             myStoryboard.Pause(this);          
        
        }
        
        // Resumes the storyboard.
        private void resumeButton_Clicked(object sender, RoutedEventArgs args)
        {
             myStoryboard.Resume(this);          
        
        }     
        
        // Advances the storyboard to its fill period.
        private void skipToFillButton_Clicked(object sender, RoutedEventArgs args)
        {
             myStoryboard.SkipToFill(this);          
        
        } 
        
        // Updates the storyboard's speed.
        private void setSpeedRatioButton_Clicked(object sender, RoutedEventArgs args)
        {
            // Makes the storyboard progress three times as fast as normal.
            myStoryboard.SetSpeedRatio(this, 3);          
        
        }           
        
        // Stops the storyboard.
        private void stopButton_Clicked(object sender, RoutedEventArgs args)
        {
             myStoryboard.Stop(this);          
        
        }         
        
        
        
    }
}
// </SnippetControlStoryboardExampleUsingWholePage>
