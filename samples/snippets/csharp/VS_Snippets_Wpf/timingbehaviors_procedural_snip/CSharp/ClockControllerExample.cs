// <SnippetGraphicsMMClockControllerExample>
/*
  This example shows how to interactively control
  a root clock.
*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public class ClockControllerExample : Page
    {

        private AnimationClock myControllableClock;
        private Button seekButton;
        private TextBox seekAmountTextBox;
        private ListBox timeSeekOriginListBox;

        public ClockControllerExample()
        {
            StackPanel mainPanel = new StackPanel();

            // Create a rectangle to animate.
            Rectangle animatedRectangle = new Rectangle();
            animatedRectangle.Width = 100;
            animatedRectangle.Height = 100;
            animatedRectangle.Fill = Brushes.Orange;
            mainPanel.Children.Add(animatedRectangle);

            // Create a DoubleAnimation to
            // animate its width.
            DoubleAnimation widthAnimation =
                new DoubleAnimation(
                    100,
                    500,
                    new Duration(TimeSpan.FromSeconds(5)));

            // Create a clock from the animation.
            myControllableClock = widthAnimation.CreateClock();

            // Apply the clock to the rectangle's Width property.
            animatedRectangle.ApplyAnimationClock(
                Rectangle.WidthProperty, myControllableClock);
            myControllableClock.Controller.Stop();

            //
            // Create some buttons to control the clock.
            //

            // Create a button to begin the clock.
            Button beginButton = new Button();
            beginButton.Content = "Begin";
            beginButton.Click +=
                new RoutedEventHandler(beginButton_Clicked);
            mainPanel.Children.Add(beginButton);

            // Create a button to pause the clock.
            Button pauseButton = new Button();
            pauseButton.Content = "Pause";
            pauseButton.Click +=
                new RoutedEventHandler(pauseButton_Clicked);
            mainPanel.Children.Add(pauseButton);

            // Create a button to resume the clock.
            Button resumeButton = new Button();
            resumeButton.Content = "Resume";
            resumeButton.Click +=
                new RoutedEventHandler(resumeButton_Clicked);
            mainPanel.Children.Add(resumeButton);

            // Create a button to advance the clock to
            // its fill period.
            Button skipToFillButton = new Button();
            skipToFillButton.Content = "Skip to Fill";
            skipToFillButton.Click +=
                new RoutedEventHandler(skipToFillButton_Clicked);
            mainPanel.Children.Add(skipToFillButton);

            // Create a button to stop the clock.
            Button stopButton = new Button();
            stopButton.Content = "Stop";
            stopButton.Click +=
                new RoutedEventHandler(stopButton_Clicked);
            mainPanel.Children.Add(stopButton);

            //
            // Create some controls the enable the user to
            // seek the clock.
            //

            StackPanel seekDetailsPanel = new StackPanel();
            seekDetailsPanel.Margin = new Thickness(0,20,0,20);
            seekDetailsPanel.Orientation = Orientation.Horizontal;
            Label seekAmountLabel = new Label();
            seekAmountLabel.Content = "Seek amount:";
            seekDetailsPanel.Children.Add(seekAmountLabel);

            // Create a text box so that the user can
            // specify the amount by which to seek.
            seekAmountTextBox = new TextBox();
            seekAmountTextBox.Text = "0:0:1";
            seekAmountTextBox.VerticalAlignment = VerticalAlignment.Top;
            seekAmountTextBox.TextChanged +=
                new TextChangedEventHandler(seekAmountTextBox_TextChanged);
            seekDetailsPanel.Children.Add(seekAmountTextBox);

            Label timeSeekOriginLabel = new Label();
            timeSeekOriginLabel.Content = "Seek Origin:";
            seekDetailsPanel.Children.Add(timeSeekOriginLabel);

            // Create a ListBox so the user can
            // select whether the seek time is relative
            // to the clock's BeginTime or Duration.
            timeSeekOriginListBox = new ListBox();
            timeSeekOriginListBox.Items.Add("BeginTime");
            timeSeekOriginListBox.Items.Add("Duration");
            timeSeekOriginListBox.Padding = new Thickness(5);
            timeSeekOriginListBox.SelectedIndex = 0;
            seekDetailsPanel.Children.Add(timeSeekOriginListBox);

            // Create a button to seek the clock.
            seekButton = new Button();
            seekButton.Content = "Seek";
            seekButton.Click += new RoutedEventHandler(seekButton_Clicked);
            seekDetailsPanel.Children.Add(seekButton);
            mainPanel.Children.Add(seekDetailsPanel);

            this.Content = mainPanel;
        }

        // Starts the clock.
        private void beginButton_Clicked(object sender, RoutedEventArgs e)
        {
            myControllableClock.Controller.Begin();
        }

        // Pauses the clock.
        private void pauseButton_Clicked(object sender, RoutedEventArgs e)
        {
            myControllableClock.Controller.Pause();
        }

        // Resumes the clock.
        private void resumeButton_Clicked(object sender, RoutedEventArgs e)
        {
            myControllableClock.Controller.Resume();
        }

        // Adances the clock to its fill period.
        private void skipToFillButton_Clicked(object sender, RoutedEventArgs e)
        {
            myControllableClock.Controller.SkipToFill();
        }

        // Stops the clock.
        private void stopButton_Clicked(object sender, RoutedEventArgs e)
        {
            myControllableClock.Controller.Stop();
        }

        // Seeks the clock.
        private void seekButton_Clicked(object sender, RoutedEventArgs e)
        {

            try {

                // Obtain the seek amount from the seekAmountTextBox TextBox.
                TimeSpan seekAmount = TimeSpan.Parse(seekAmountTextBox.Text);

                // Determine the seek origin by reading the selected value
                // from the timeSeekOriginListBox ListBox.
                TimeSeekOrigin selectedOrigin =
                    (TimeSeekOrigin)Enum.Parse(typeof(TimeSeekOrigin),
                    (string)timeSeekOriginListBox.SelectedItem);

                // Seek to the specified location.
                myControllableClock.Controller.Seek(seekAmount, selectedOrigin);
            }catch(FormatException formatEx)
            {
                MessageBox.Show(seekAmountTextBox.Text
                    + " is not a valid TimeSpan. Please enter another value.");

                // Disable the seek button until the user enters another value.
                seekButton.IsEnabled = false;
            }
        }

        // Verifies that seekAmountTextBox has text content.
        // If there is no text, disable the seek button.
        private void seekAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox theTextBox = (TextBox)e.Source;
            if (theTextBox.Text == null || theTextBox.Text.Length < 1)
                seekButton.IsEnabled = false;
            else
                seekButton.IsEnabled = true;
        }
    }
}
// </SnippetGraphicsMMClockControllerExample>
