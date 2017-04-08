// <SnippetFrameworkContentElementStoryboardExampleUsingWholePage>
/*
    This example shows how to animate
    a FrameworkContentElement with a storyboard.

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
    public class FrameworkContentElementStoryboardExample : FlowDocument
    {
    
        private Storyboard myStoryboard;
        
        public FrameworkContentElementStoryboardExample()
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
            // Create a button to start the storyboard.
            //
            Button beginButton = new Button();
            beginButton.Content = "Begin";
            beginButton.Click += new RoutedEventHandler(beginButton_Clicked);            
 
            controlsContainer.Child = beginButton; 
            this.Blocks.Add(controlsContainer);
            
        }
        
        // Begins the storyboard.
        private void beginButton_Clicked(object sender, RoutedEventArgs args)
        {
        
            myStoryboard.Begin(this);                  
        }
        
 

    }
}
// </SnippetFrameworkContentElementStoryboardExampleUsingWholePage>
