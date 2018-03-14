/*

This Sample shows a Rectangle with a gradient fill and an animated height

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation; 
using System.Windows.Shapes;

namespace Microsoft.Samples.Animation.AnimatedTransformations
{       
    public class AnimatedHeightExample : Page
    {        
    
    
        private Storyboard myStoryboard; 
        
        public AnimatedHeightExample()
        { 
             
             // Create a name scope for the page.
             NameScope.SetNameScope(this, new NameScope());
             
             WindowTitle = "Animated Height Example";
 //<SnippetFEName>              
             //  
             // Create a Rectangle
             //
             Rectangle myRectangle = new Rectangle();
             myRectangle.Width = 200;
             myRectangle.Height = 200;
             myRectangle.Name = "myRectangle";
             this.RegisterName(myRectangle.Name, myRectangle); 
 //</SnippetFEName>                
             //
             //  Set the Rectangle's Fill Property with a LinearGradientBrush      
             //
             LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
             myLinearGradientBrush.StartPoint = new Point(0,0);
             myLinearGradientBrush.EndPoint = new Point(0,1);          

             GradientStop myGradientStop1 = new GradientStop();
             myGradientStop1.Color = Colors.Red;
             myGradientStop1.Offset = 0;         
             myLinearGradientBrush.GradientStops.Add( myGradientStop1 );

             GradientStop myGradientStop2 = new GradientStop();
             myGradientStop2.Color = Colors.Purple;
             myGradientStop2.Offset = 0.5;
             myLinearGradientBrush.GradientStops.Add( myGradientStop2 );

             GradientStop myGradientStop3 = new GradientStop();
             myGradientStop3.Color = Colors.Blue;
             myGradientStop3.Offset = 1;
             myLinearGradientBrush.GradientStops.Add( myGradientStop3 );
             
             myRectangle.Fill = myLinearGradientBrush;
                
             //
             // Start animating the rectangle's height after it's been loaded.
             //
             myStoryboard = new Storyboard(); 
             DoubleAnimation myDoubleAnimation = 
                new DoubleAnimation(0.0, 100.0, new Duration(TimeSpan.FromSeconds(2)));
             myDoubleAnimation.BeginTime = TimeSpan.FromSeconds(0.5);      
             myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
             myDoubleAnimation.AutoReverse = true;        
             Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath( Rectangle.HeightProperty ));
             myStoryboard.Children.Add(myDoubleAnimation);

             // Create an event handler to start the storyboard
             // after the rectangle is loaded.
             myRectangle.Loaded += new RoutedEventHandler(rectangleLoaded);      

             DockPanel mainPanel = new DockPanel();
             mainPanel.Children.Add( myRectangle );
             this.Content = mainPanel;
                           
        } 
        
        private void rectangleLoaded(object sender, RoutedEventArgs args)
        {
        
            // Start the storyboard.
            myStoryboard.Begin(this);
        }
    }
}
