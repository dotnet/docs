// <SnippetGraphicsMMClockControllerSpeedRatioExample>
/*
  This example shows how to interactively control 
  the speed of a clock
*/
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public class ClockControllerSpeedRatioExample : Page
    {
    
        private AnimationClock myControllableClock;
        private Button speedRatioButton;
        private TextBox speedRatioSettingTextBox;
        private double doubleParseResult = 1;
        private TextBlock currentGlobalSpeedTextBlock;
    
        public ClockControllerSpeedRatioExample()
        {
            StackPanel mainPanel = new StackPanel();
            
            // Create a rectangle to animate.
            Rectangle animatedRectangle = new Rectangle();
            animatedRectangle.Width = 100;
            animatedRectangle.Height = 100;
            animatedRectangle.Fill = Brushes.Orange;
            mainPanel.Children.Add(animatedRectangle);
//<SnippetUIElementApplyAnimationClock>            
            // Create a DoubleAnimation to
            // animate its width.
            DoubleAnimation widthAnimation = 
                new DoubleAnimation(
                    100,
                    500, 
                    new Duration(TimeSpan.FromSeconds(5)));
            //widthAnimation.RepeatBehavior = RepeatBehavior.Forever;
            widthAnimation.AutoReverse = true;
            widthAnimation.SpeedRatio = 0.5;
                    
            // Create a clock from the animation.
            myControllableClock = widthAnimation.CreateClock();
            
            // Apply the clock to the rectangle's Width property.
            animatedRectangle.ApplyAnimationClock(
                Rectangle.WidthProperty, myControllableClock);    

//</SnippetUIElementApplyAnimationClock>  
            //
            // Create some controls the enable the user to
            // interactively control the SpeedRatio of the clock. 
            //            
            StackPanel speedRatioDetailsPanel = new StackPanel();
            speedRatioDetailsPanel.Margin = new Thickness(0,20,0,20);
            speedRatioDetailsPanel.Orientation = Orientation.Horizontal;
            Label speedRatioLabel = new Label();
            speedRatioLabel.Content = "Speed Ratio:";
            speedRatioDetailsPanel.Children.Add(speedRatioLabel);
            
            // Create a text box so that the user can
            // specify the amount by which to seek.
            speedRatioSettingTextBox = new TextBox();
            speedRatioSettingTextBox.Text = 
                myControllableClock.Controller.SpeedRatio.ToString();
            speedRatioSettingTextBox.VerticalAlignment = VerticalAlignment.Top;
            speedRatioSettingTextBox.TextChanged += 
                new TextChangedEventHandler(seekAmountTextBox_TextChanged);
            speedRatioDetailsPanel.Children.Add(speedRatioSettingTextBox);          
            
            // Create a button to apply SpeedRatio changes.
            speedRatioButton = new Button();
            speedRatioButton.Content = "Apply Speed Ratio";
            speedRatioButton.Click += new RoutedEventHandler(speedRatioButton_Clicked);  
            speedRatioDetailsPanel.Children.Add(speedRatioButton);
            
            mainPanel.Children.Add(speedRatioDetailsPanel);
            
            // Display the clock's global speed information.
            Label myLabel = new Label();
            myLabel.Content = "CurrentGlobalSpeed ";
            mainPanel.Children.Add(myLabel);
            currentGlobalSpeedTextBlock = new TextBlock();
            currentGlobalSpeedTextBlock.Text = 
                myControllableClock.CurrentGlobalSpeed.ToString();
            mainPanel.Children.Add(currentGlobalSpeedTextBlock);
            
            // List for speed changes.
            myControllableClock.CurrentGlobalSpeedInvalidated += 
                new EventHandler(myControllableClock_currentGlobalSpeedInvalidated);

            this.Content = mainPanel;
        }
        

        // Updates the clock's SpeedRatio.
        private void speedRatioButton_Clicked(object sender, RoutedEventArgs e)
        {
            
            // This statement triggers a CurrentGlobalSpeedInvalidated
            // event.
            myControllableClock.Controller.SpeedRatio = doubleParseResult; 
            
        }
        
        // Displays the current global speed.
        private void myControllableClock_currentGlobalSpeedInvalidated(object sender, EventArgs e)
        {
            
            currentGlobalSpeedTextBlock.Text = 
                myControllableClock.CurrentGlobalSpeed.ToString()
                + " Event triggered at: " 
                + DateTime.Now.ToString();   

        }        

        // Verifies that speedRatioSettingTextBox has valid text content.
        // If it doesn't, the speedRatioButton is disabled.
        private void seekAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            TextBox theTextBox = (TextBox)e.Source;
            if (theTextBox.Text == null || theTextBox.Text.Length < 1
                || Double.TryParse(theTextBox.Text, 
                    System.Globalization.NumberStyles.Any, 
                    null, out doubleParseResult) == false)
                speedRatioButton.IsEnabled = false;
            else 
                speedRatioButton.IsEnabled = true;
                    
        }
 
    }
}
// </SnippetGraphicsMMClockControllerSpeedRatioExample>
