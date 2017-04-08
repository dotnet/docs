
// <Snippet100>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Shapes;
using System.Windows.Input;


namespace Microsoft.Samples.Animation
{
    public class StoryboardsExample : Page
    {      
        public StoryboardsExample()
        {
            this.WindowTitle = "Storyboards Example";
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // <Snippet102>            
            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "MyRectangle";
            
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());            
            
            this.RegisterName(myRectangle.Name, myRectangle);
            // </Snippet102>
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            // <Snippet103>
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Colors.Blue);
            this.RegisterName("MySolidColorBrush", mySolidColorBrush);
            // </Snippet103>
            myRectangle.Fill = mySolidColorBrush;
            
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 100;
            myDoubleAnimation.To = 200;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            // <Snippet105> 
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, 
                new PropertyPath(Rectangle.WidthProperty));
            // </Snippet105>
            
            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.Blue;
            myColorAnimation.To = Colors.Red;
            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            // <Snippet107>
            Storyboard.SetTargetName(myColorAnimation, "MySolidColorBrush");
            Storyboard.SetTargetProperty(myColorAnimation, 
                new PropertyPath(SolidColorBrush.ColorProperty)); 
            // </Snippet107>
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Children.Add(myColorAnimation);

            myRectangle.MouseEnter += delegate(object sender, MouseEventArgs e)
            {
                myStoryboard.Begin(this);
            };
            
            myStackPanel.Children.Add(myRectangle);
            this.Content = myStackPanel;
        } 
    }
}
// </Snippet100>