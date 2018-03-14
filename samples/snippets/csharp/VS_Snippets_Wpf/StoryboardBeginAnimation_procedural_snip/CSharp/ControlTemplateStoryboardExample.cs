// <SnippetControlTemplateStoryboardExampleWholePage>
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
    public class ControlTemplateStoryboardExample : Page
    {
    
        private Storyboard myStoryboard;
        
        public ControlTemplateStoryboardExample()
        {
        
            
            ControlTemplate myControlTemplate = 
                new ControlTemplate(typeof(Button));
            FrameworkElementFactory borderFactory = 
                new FrameworkElementFactory(typeof(Border)); 
            FrameworkElementFactory contentPresenterFactory 
                = new FrameworkElementFactory(typeof(ContentPresenter));
            borderFactory.AppendChild(contentPresenterFactory);
            myControlTemplate.VisualTree = borderFactory;
           
           /*
            borderFactory.SetValue(Border.BackgroundProperty,
                TemplateBindingExpression(Button.BackgroundProperty));*/
        
              // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());        
          
              this.WindowTitle = "Controlling a Storyboard";
              this.Background = Brushes.White;
  
              StackPanel myStackPanel = new StackPanel();
              myStackPanel.Margin = new Thickness(20);
              
              // Create a rectangle.
              Rectangle myRectangle = new Rectangle();
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
                  new DoubleAnimation(100, 500, new Duration(TimeSpan.FromSeconds(5)));            
              Storyboard.SetTargetName(myDoubleAnimation, "myRectangle");
              Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
              myStoryboard = new Storyboard();
              myStoryboard.Children.Add(myDoubleAnimation);
              
            //
            // Create a button to start the storyboard.
            //
            Button beginButton = new Button();
            beginButton.Template = myControlTemplate;           
            beginButton.Content = "Begin";
            beginButton.Click += new RoutedEventHandler(beginButton_Clicked);            
            
            myStackPanel.Children.Add(beginButton);           
            this.Content = myStackPanel;
            
        }
        
        // Begins the storyboard.
        private void beginButton_Clicked(object sender, RoutedEventArgs args)
        {
        
            myStoryboard.Begin(this);                  
        }
        
 

    }
}
// </SnippetControlTemplateStoryboardExampleWholePage>
