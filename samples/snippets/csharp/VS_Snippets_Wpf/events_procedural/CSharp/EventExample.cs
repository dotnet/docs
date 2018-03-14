using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Microsoft.Samples.Animation.TimingBehaviors
{


    public class EventExample : Page
    {

        public EventExample()
        {
            createExample();
        }
        
        private Rectangle myRectangle;
        
        private void createExample()
        {
        
            NameScope.SetNameScope(this, new NameScope());
            myRectangle = new Rectangle();
            myRectangle.Width = 500;
            myRectangle.Height = 500;
            myRectangle.Fill = Brushes.Blue;
            this.RegisterName("myRectangle", myRectangle);
            
            StackPanel panel = new StackPanel();
            panel.Children.Add(myRectangle);


            Button badExampleButton = new Button();
            badExampleButton.Content = "Bad Example";
            badExampleButton.Click += delegate(object sender, RoutedEventArgs e)
            {
                initialExample();
            };
            panel.Children.Add(badExampleButton);

            Button goodExampleButton = new Button();
            goodExampleButton.Content = "Good Example";
            goodExampleButton.Click += delegate(object sender, RoutedEventArgs e)
            {
                betterExample();
            };
            panel.Children.Add(goodExampleButton);



            this.Content = panel;
        }
        
        private void initialExample()
        {
            
            
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Begin(myRectangle, true);
         
            // <SnippetNeedForEventsFragment>
            myStoryboard.Stop(myRectangle);
            
            // This statement might execute
            // before the storyboard has stopped.
            myRectangle.Fill = Brushes.Blue;
            // </SnippetNeedForEventsFragment>
            
        
        
        }
        
        private void betterExample()
        {

            Storyboard myStoryboard = new Storyboard();

            // <SnippetRegisterForStoryboardCurrentStateInvalidatedEvent>
            // Register for the CurrentStateInvalidated timing event.
            myStoryboard.CurrentStateInvalidated += new EventHandler(myStoryboard_CurrentStateInvalidated);
            // </SnippetRegisterForStoryboardCurrentStateInvalidatedEvent>
        
        }

        // <SnippetStoryboardCurrentStateInvalidatedEvent2>
        // Change the rectangle's color after the storyboard stops. 
        void myStoryboard_CurrentStateInvalidated(object sender, EventArgs e)
        {
            Clock myStoryboardClock = (Clock)sender;
            if (myStoryboardClock.CurrentState == ClockState.Stopped)
            {
                myRectangle.Fill = Brushes.Blue;
            }
        }
        // </SnippetStoryboardCurrentStateInvalidatedEvent2>
    
    
    }

}
