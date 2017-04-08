
// <SnippetGraphicsMMFrameworkElementStoryboardHandoffBehaviorExample>
/*

   This sample animates the position of an ellipse when 
   the user clicks within the main border. If the user
   left-clicks, the SnapshotAndReplace HandoffBehavior
   is used when applying the animations. If the user
   right-clicks, the Compose HandoffBehavior is used
   instead.

*/

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{

    // Create the demonstration.
    public class FrameworkElementStoryboardHandoffBehaviorExample : Page {
        
        
        private Border containerBorder;
        private Ellipse interactiveEllipse;
        private Storyboard theStoryboard;
        private DoubleAnimation xAnimation;
        private DoubleAnimation yAnimation;
        
        public FrameworkElementStoryboardHandoffBehaviorExample()
        {
        
            WindowTitle = "Interactive Animation Example";
            
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());  
            
            DockPanel myPanel = new DockPanel();
            myPanel.Margin = new Thickness(20.0);            
    
            containerBorder = new Border();
            containerBorder.Background = Brushes.White;
            containerBorder.BorderBrush = Brushes.Black;
            containerBorder.BorderThickness = new Thickness(2.0); 
            containerBorder.VerticalAlignment = VerticalAlignment.Stretch;
            
            interactiveEllipse = new Ellipse();
            interactiveEllipse.Fill = Brushes.Lime;
            interactiveEllipse.Stroke = Brushes.Black;
            interactiveEllipse.StrokeThickness = 2.0;
            interactiveEllipse.Width = 25;
            interactiveEllipse.Height = 25;
            interactiveEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            interactiveEllipse.VerticalAlignment = VerticalAlignment.Top;
            

            TranslateTransform interactiveTranslateTransform = new TranslateTransform();       
            this.RegisterName("InteractiveTranslateTransform", interactiveTranslateTransform);
            
            interactiveEllipse.RenderTransform = 
                interactiveTranslateTransform;
                
            xAnimation = new DoubleAnimation();
            xAnimation.Duration = TimeSpan.FromSeconds(4);
            yAnimation = xAnimation.Clone();
            Storyboard.SetTargetName(xAnimation, "InteractiveTranslateTransform");
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetName(yAnimation, "InteractiveTranslateTransform");
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath(TranslateTransform.YProperty));            
            
            theStoryboard = new Storyboard();
            theStoryboard.Children.Add(xAnimation);
            theStoryboard.Children.Add(yAnimation);
                
                
            containerBorder.MouseLeftButtonDown += 
                new MouseButtonEventHandler(border_mouseLeftButtonDown);
            containerBorder.MouseRightButtonDown += 
                new MouseButtonEventHandler(border_mouseRightButtonDown);                
            
            containerBorder.Child = interactiveEllipse;
            myPanel.Children.Add(containerBorder);
            this.Content = myPanel;
        }
        

        // When the user left-clicks, use the 
        // SnapshotAndReplace HandoffBehavior when applying the animation.        
        private void border_mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        
            Point clickPoint = Mouse.GetPosition(containerBorder);
            
            // Set the target point so the center of the ellipse
            // ends up at the clicked point.
            Point targetPoint = new Point();
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2;
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2;  
            
            // Animate to the target point.
            xAnimation.To = targetPoint.X;
            yAnimation.To = targetPoint.Y;
            theStoryboard.Begin(this, HandoffBehavior.SnapshotAndReplace);
            

            // Change the color of the ellipse.
            interactiveEllipse.Fill = Brushes.Lime;
                    
        }
        
        // When the user right-clicks, use the 
        // Compose HandoffBehavior when applying the animation.
        private void border_mouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
        
            // Find the point where the use clicked.
            Point clickPoint = Mouse.GetPosition(containerBorder);
            
            // Set the target point so the center of the ellipse
            // ends up at the clicked point.
            Point targetPoint = new Point();
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2;
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2;
 
            // Animate to the target point.
            xAnimation.To = targetPoint.X;
            yAnimation.To = targetPoint.Y;
            theStoryboard.Begin(this, HandoffBehavior.Compose);
                
            // Change the color of the ellipse.
            interactiveEllipse.Fill = Brushes.Orange;
            
                    
        }
        
    }
 
}
// </SnippetGraphicsMMFrameworkElementStoryboardHandoffBehaviorExample>