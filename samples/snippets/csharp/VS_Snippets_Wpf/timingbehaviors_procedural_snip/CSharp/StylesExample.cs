/*
  StylesExample.cs
     This example shows how to create storyboards in a style.
*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace Microsoft.Samples.Animation.TimingBehaviors
{
    public partial class StylesExample : Page
    {
    
    
    
        public StylesExample()
        {
        
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());
        
           this.WindowTitle = "Storyboard in Styles Example";
           this.Background = Brushes.White; 
           
           //
           // Define a Button style 
           //
           Style myStyle = new Style();
           Setter mySetter = new Setter();
           // mySetter.Property = 
                     
           EventTrigger myEventTrigger = new EventTrigger();
           myEventTrigger.RoutedEvent = Button.MouseEnterEvent;
           BeginStoryboard myBeginStoryboard = new BeginStoryboard();
           Storyboard myStoryboard = new Storyboard();
           myBeginStoryboard.Storyboard = myStoryboard;
           
           
           DoubleAnimation myDoubleAnimation = new DoubleAnimation();
       Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.OpacityProperty));
       myDoubleAnimation.From = 1.0;
       myDoubleAnimation.To = 0.5;      
       myDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(500));
       myDoubleAnimation.AutoReverse = true;
       myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
           myStoryboard.Children.Add(myDoubleAnimation);
           myEventTrigger.Actions.Add(myBeginStoryboard);
           
           //
           //  Returns the button's opacity to 1 when the mouse leaves. 
           //
           myEventTrigger = new EventTrigger();
           myEventTrigger.RoutedEvent = Button.MouseLeaveEvent;
           myBeginStoryboard = new BeginStoryboard();
           myStoryboard = new Storyboard();
           myBeginStoryboard.Storyboard = myStoryboard;
           myDoubleAnimation = new DoubleAnimation();
       Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Button.OpacityProperty));
       myDoubleAnimation.From = 1.0;      
       myDoubleAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(100));
           myStoryboard.Children.Add(myDoubleAnimation);
           myEventTrigger.Actions.Add(myBeginStoryboard);   
           
           //
           //  Changes the button's color when clicked. Notice that the animation can't target the SolidColorBrush used 
           //     to paint the button's background directly. The brush must be accessed through the button's Background property.
           //
           myEventTrigger = new EventTrigger();
           myEventTrigger.RoutedEvent = Button.ClickEvent;
           myBeginStoryboard = new BeginStoryboard();
           myStoryboard = new Storyboard();
           myBeginStoryboard.Storyboard = myStoryboard;
           ColorAnimation myColorAnimation = new ColorAnimation();
       //Storyboard.SetTargetProperty(myColorAnimation, new PropertyPath("(0).(1)",new DependencyProperty[] { (Button.Background).(SolidColorBrush.Color)   }))
       myColorAnimation.From = Color.FromArgb(255,255,165,0); 
       myColorAnimation.To = Color.FromArgb(255,255,255,255); 
       myColorAnimation.Duration = new Duration( TimeSpan.FromMilliseconds(100));
       myColorAnimation.AutoReverse = true;
           myStoryboard.Children.Add(myColorAnimation);
           myEventTrigger.Actions.Add(myBeginStoryboard);            
        }
    }
}
