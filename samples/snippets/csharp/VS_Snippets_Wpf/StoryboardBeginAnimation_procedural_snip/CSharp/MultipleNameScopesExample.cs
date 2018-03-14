// <SnippetMultipleNameScopesExample>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{

 
    public class MultipleNameScopesExample : Page
    {
        
        private Storyboard storyboard1, storyboard2;
        private StackPanel mainPanel, childPanel1, childPanel2;
        private Rectangle rectangle1, rectangle2;
        
        public MultipleNameScopesExample()
        {
            
            
            this.Background = Brushes.White;
            mainPanel = new StackPanel();
            mainPanel.Background = Brushes.Gray;
            childPanel1 = new StackPanel();
            childPanel1.Background = Brushes.Orange;
            mainPanel.Children.Add(childPanel1);
            childPanel2 = new StackPanel();
            childPanel2.Background = Brushes.Red;
            mainPanel.Children.Add(childPanel2);
            
            // Create a name scope for each panel.
            NameScope.SetNameScope(mainPanel, new NameScope());
            NameScope.SetNameScope(childPanel1, new NameScope());
            NameScope.SetNameScope(childPanel2, new NameScope());
        
            // Create a rectangle, add it to childPanel1,
            // and register its name with childPanel1.
            rectangle1 = new Rectangle();
            rectangle1.Width = 50;
            rectangle1.Height = 50;
            rectangle1.Fill = Brushes.Blue;
            childPanel1.RegisterName("rectangle1", rectangle1);
            childPanel1.Children.Add(rectangle1);

            // Animate rectangle1's width.
            DoubleAnimation myDoubleAnimation = 
                new DoubleAnimation(10,100, new Duration(TimeSpan.FromSeconds(3)));
            Storyboard.SetTargetName(myDoubleAnimation, "rectangle1");
            Storyboard.SetTargetProperty(myDoubleAnimation, 
                new PropertyPath(Rectangle.WidthProperty));            
            storyboard1 = new Storyboard();
            storyboard1.Children.Add(myDoubleAnimation);
            
            Button startRectangle1AnimationButton = new Button();
            startRectangle1AnimationButton.Content = "Start rectangle1 Animation";
            startRectangle1AnimationButton.Click += 
                new RoutedEventHandler(startRectangle1AnimationButton_clicked);
            mainPanel.Children.Add(startRectangle1AnimationButton);
            
            
            // Create a rectangle, add it to childPanel1,
            // but register its name with mainPanel.
            rectangle2 = new Rectangle();
            rectangle2.Width = 50;
            rectangle2.Height = 50;
            rectangle2.Fill = Brushes.Black;
            mainPanel.RegisterName("rectangle2", rectangle2);
            childPanel1.Children.Add(rectangle2);

            // Animate rectangle2's width.
            myDoubleAnimation = 
                new DoubleAnimation(10,100, new Duration(TimeSpan.FromSeconds(3)));
            Storyboard.SetTargetName(myDoubleAnimation, "rectangle2");
            Storyboard.SetTargetProperty(myDoubleAnimation, 
                new PropertyPath(Rectangle.WidthProperty));            
            storyboard2 = new Storyboard();
            storyboard2.Children.Add(myDoubleAnimation);
            
            Button startRectangle2AnimationButton = new Button();
            startRectangle2AnimationButton.Content = "Start rectangle2 Animation";
            startRectangle2AnimationButton.Click += 
                new RoutedEventHandler(startRectangle2AnimationButton_clicked);
            mainPanel.Children.Add(startRectangle2AnimationButton);            
            
            
            

            this.Content = mainPanel;
                           
        }  
        
        
        private void startRectangle1AnimationButton_clicked(object sender, RoutedEventArgs args)
        {
        
            // Starts the animation.
            storyboard1.Begin(childPanel1);
        
        }
        
        private void startRectangle2AnimationButton_clicked(object sender, RoutedEventArgs args)
        {
        
            try {
                
                // This statement throws an exception because
                // rectangle2's name is registered with
                // mainPanel, and childPanel1 is not in
                // mainPanel's name scope.
                // Normally, as a child of mainPanel, 
                // childPanel1 would share mainPanel's name scope.
                // however, because we gave childPanel1 its own
                // name scope, it no longer shares mainPanel's name scope.
                storyboard2.Begin(childPanel1);
            
            }catch(System.InvalidOperationException ex)
            {
                
            }
            
            try {
                
                // This statement also throws an exception because
                // rectangle2's name is registered with
                // mainPanel, and childPanel1 is not in
                // mainPanel's name scope.
                // Normally, as a child of mainPanel, 
                // childPanel1 would share mainPanel's name scope.
                // however, because we gave childPanel1 its own
                // name scope, it no longer shares mainPanel's name scope.
                storyboard2.Begin(rectangle2);
            
            }catch(System.InvalidOperationException ex)
            {
                
            }            
            
            // This statement works as expected.
            storyboard2.Begin(mainPanel);
            
        
        }
        
    }    
  
}
// </SnippetMultipleNameScopesExample>