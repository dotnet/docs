// <SnippetSeekExampleUsingWholePage>
/*
    This example shows how to seek a storyboard.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{
    public partial class SeekExample : Page
    {

        private Storyboard myStoryboard;
        private TextBlock currentTimeIndicator;
        private TextBox seekDestination;
        private TextBlock rectangleWidthIndicator;
        private Rectangle myRectangle;

        public SeekExample()
        {

            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            this.WindowTitle = "Controlling a Storyboard";
            this.Background = Brushes.White;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // Create a rectangle.
            myRectangle = new Rectangle();
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
                new DoubleAnimation(100, 500, new Duration(TimeSpan.FromSeconds(60)));
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
            Button removeButton = new Button();
            removeButton.Content = "Remove";
            removeButton.Click +=new RoutedEventHandler(removeButton_Clicked);
            buttonPanel.Children.Add(removeButton);

            myStackPanel.Children.Add(buttonPanel);

            // Create some controls to display the
            // storyboard's current time and the
            // current width of the rectangle.
            StackPanel seekPanel = new StackPanel();
            seekPanel.Margin = new Thickness(10);
            StackPanel aPanel = new StackPanel();
            Label aLabel = new Label();
            aPanel.Orientation = Orientation.Horizontal;
            aLabel.Content = "Current Time: ";
            aPanel.Children.Add(aLabel);
            currentTimeIndicator = new TextBlock();
            aPanel.Children.Add(currentTimeIndicator);
            seekPanel.Children.Add(aPanel);

            aPanel = new StackPanel();
            aPanel.Orientation = Orientation.Horizontal;
            aLabel = new Label();
            aLabel.Content = "Rectangle Width: ";
            aPanel.Children.Add(aLabel);
            rectangleWidthIndicator = new TextBlock();
            rectangleWidthIndicator.Text = myRectangle.Width.ToString();
            aPanel.Children.Add(rectangleWidthIndicator);
            seekPanel.Children.Add(aPanel);

            // Create some controls to enable the
            // user to specify a seek position.

            aPanel = new StackPanel();
            aPanel.Orientation = Orientation.Horizontal;
            aLabel = new Label();
            aLabel.Content = "Seek Offset: " ;
            aPanel.Children.Add(aLabel);
            seekDestination = new TextBox();
            seekDestination.Text = "0";
            aPanel.Children.Add(seekDestination);
            seekPanel.Children.Add(aPanel);

            Button seekButton = new Button();
            seekButton.Content = "Seek";
            seekButton.Click += new RoutedEventHandler(seekButton_Clicked);
            seekPanel.Children.Add(seekButton);
            Button seekAlignedToLastTickButton = new Button();
            seekAlignedToLastTickButton.Content = "Seek Aligned to Last Tick";
            seekAlignedToLastTickButton.Click += new RoutedEventHandler(seekAlignedToLastTickButton_Clicked);
            seekPanel.Children.Add(seekAlignedToLastTickButton);

            myStackPanel.Children.Add(seekPanel);

            this.Content = myStackPanel;

            myStoryboard.CurrentTimeInvalidated += new EventHandler(myStoryboard_CurrentTimeInvalidated);
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

        // Removes the storyboard.
        private void removeButton_Clicked(object sender, RoutedEventArgs args)
        {
             myStoryboard.Remove(this);
        }

        private void seekButton_Clicked(object sender, RoutedEventArgs args)
        {
            try {

                // The rectangle width will probably not be at its new
                // value when this call is made, because the storyboard's
                // clock probably hasn't ticked yet.
                TimeSpan seekTime = TimeSpan.Parse(seekDestination.Text);
                myStoryboard.Seek(this, seekTime, TimeSeekOrigin.BeginTime);
                rectangleWidthIndicator.Text = myRectangle.Width.ToString();
            }catch(FormatException ex)
            {
                MessageBox.Show("Invalid TimeSpan value.");
                seekDestination.Focus();
            }
        }

        private void seekAlignedToLastTickButton_Clicked(object sender, RoutedEventArgs args)
        {

            try {

                // The rectangle width will be at its new
                // value when this call is made, because SeekAlignedToLastTick
                // operation immediately updates timeline and animation
                // values.
                TimeSpan seekTime = TimeSpan.Parse(seekDestination.Text);
                myStoryboard.SeekAlignedToLastTick(this, seekTime, TimeSeekOrigin.BeginTime);
                rectangleWidthIndicator.Text = myRectangle.Width.ToString();
            }catch(FormatException ex)
            {
                MessageBox.Show("Invalid TimeSpan value.");
                seekDestination.Focus();
            }
        }

        private void myStoryboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {

            currentTimeIndicator.Text = myStoryboard.GetCurrentTime(this).ToString();
        }
    }
}
// </SnippetSeekExampleUsingWholePage>
