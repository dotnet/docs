// <SnippetSeekStoryboardExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class SeekStoryboardExample : Page
    {
    
        private Storyboard myStoryboard;

        public SeekStoryboardExample()
        {
        
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());        

            StackPanel myStackPanel = new StackPanel();
            
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
            
            // Create a buton to begin the Storyboard.
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Horizontal;
            Button beginButton = new Button();
            beginButton.Content = "Begin";
            beginButton.Click += new RoutedEventHandler(beginButton_Clicked);
            buttonPanel.Children.Add(beginButton);

            // Create a button to seek to a specific time in the Storyboard.
            Button seekStoryboardButton = new Button();
            seekStoryboardButton.Content = "Seek to One Second After Begin Time";
            seekStoryboardButton.Click += new RoutedEventHandler(seekStoryboardButton_Clicked);
            buttonPanel.Children.Add(seekStoryboardButton);

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

        // Seek (skip to) one second into the Storboard's active period (Duration). 
        private void seekStoryboardButton_Clicked(object sender, RoutedEventArgs args)
        {
            // Create time interval to seek to. This TimeSpan is set for one second.
            TimeSpan myTimeSpan = new TimeSpan(0, 0, 1);

            // Seek (skip to) to one second from the begin time of the Storyboard.
            myStoryboard.Seek(this, myTimeSpan, TimeSeekOrigin.BeginTime);

        }   
    }
}
// </SnippetSeekStoryboardExampleWholePage>
