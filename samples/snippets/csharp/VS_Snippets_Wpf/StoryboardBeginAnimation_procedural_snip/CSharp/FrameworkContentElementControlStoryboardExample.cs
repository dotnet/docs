// <SnippetFrameworkContentElementControlStoryboardExampleUsingWholePage>
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
using System.Windows.Documents;


namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{
    public class FrameworkContentElementControlStoryboardExample : FlowDocument
    {
    
        private Storyboard myStoryboard;
        
        public FrameworkContentElementControlStoryboardExample()
        {
        
            // Create a name scope for the document.
            NameScope.SetNameScope(this, new NameScope());        
            this.Background = Brushes.White;
            
            // Create a run of text.
            Run theText = new Run( 
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit." + 
                "Ut non lacus. Nullam a ligula id leo adipiscing ornare." +
                " Duis mattis. ");   
                
            // Create a TextEffect
            TextEffect animatedSpecialEffect = new TextEffect();
            animatedSpecialEffect.Foreground = Brushes.OrangeRed;
            animatedSpecialEffect.PositionStart = 0;
            animatedSpecialEffect.PositionCount = 0;
            
            // Assign the TextEffect a name by 
            // registering it with the page, so that
            // it can be targeted by storyboard
            // animations            
            this.RegisterName("animatedSpecialEffect", animatedSpecialEffect);  
            
            // Apply the text effect to the run.
            theText.TextEffects = new TextEffectCollection();
            theText.TextEffects.Add(animatedSpecialEffect);
            
            // Create a paragraph to contain the run.
            Paragraph animatedParagraph = new Paragraph(theText);
            animatedParagraph.Background = Brushes.LightGray;
            animatedParagraph.Padding = new Thickness(20);
   
            this.Blocks.Add(animatedParagraph);            
            BlockUIContainer controlsContainer = new BlockUIContainer();                
            
            //
            // Create an animation and a storyboard to animate the
            // text effect.
            //
            Int32Animation countAnimation = 
                new Int32Animation(0, 127, TimeSpan.FromSeconds(10)); 
            Storyboard.SetTargetName(countAnimation, "animatedSpecialEffect");
            Storyboard.SetTargetProperty(countAnimation, 
                new PropertyPath(TextEffect.PositionCountProperty));
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(countAnimation);
            
            //
            // Create some buttons to control the storyboard
            // and a panel to contain them.
            //
            StackPanel buttonPanel = new StackPanel();
            buttonPanel.Orientation = Orientation.Vertical;
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
   
            controlsContainer.Child = buttonPanel; 
            this.Blocks.Add(controlsContainer);
            
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

    }
}
// </SnippetFrameworkContentElementControlStoryboardExampleUsingWholePage>
