using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Windows.Shapes;


namespace Microsoft.Samples.Animation
{


    public partial class IndirectTargetingExample : Page
    {
    
        
        public IndirectTargetingExample()
        {
            InitializeComponent();
            BrushTargetingExample();
            CollectionTargetingExample();
                  
        }
        
        private void BrushTargetingExample()
        {
            // <Snippet137>
            
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope()); 
            
            Rectangle rectangle01 = new Rectangle();
            rectangle01.Name = "Rectangle01";   
            this.RegisterName(rectangle01.Name, rectangle01);
            rectangle01.Width = 100;
            rectangle01.Height = 100;
            rectangle01.Fill = 
                (SolidColorBrush)this.Resources["MySolidColorBrushResource"];
            
            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.Blue;
            myColorAnimation.To = Colors.AliceBlue;
            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard.SetTargetName(myColorAnimation, rectangle01.Name);
            
            // <Snippet134>
            // <Snippet135>
            // <SnippetPropertyChainAndPath>
            DependencyProperty[] propertyChain =
                new DependencyProperty[]
                    {Rectangle.FillProperty, SolidColorBrush.ColorProperty};
            // </Snippet135>
            // <Snippet136>
            string thePath = "(0).(1)";
            // </Snippet136>
            // </SnippetPropertyChainAndPath>
            PropertyPath myPropertyPath = new PropertyPath(thePath, propertyChain);
            Storyboard.SetTargetProperty(myColorAnimation, myPropertyPath);
            // </Snippet134>
            
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myColorAnimation);
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;
            EventTrigger myMouseEnterTrigger = new EventTrigger();
            myMouseEnterTrigger.RoutedEvent = Rectangle.MouseEnterEvent;
            myMouseEnterTrigger.Actions.Add(myBeginStoryboard);
            rectangle01.Triggers.Add(myMouseEnterTrigger);
            // </Snippet137>
            myStackPanel.Children.Add(rectangle01);        
        
        }
        
        private void CollectionTargetingExample()
        {
            // <Snippet138>
            Rectangle rectangle02 = new Rectangle();
            rectangle02.Name = "Rectangle02";
            this.RegisterName(rectangle02.Name, rectangle02);
            rectangle02.Width = 100;
            rectangle02.Height = 100;
            rectangle02.Fill = Brushes.Blue;
            rectangle02.RenderTransform = 
                (TransformGroup)this.Resources["MyTransformGroupResource"];
            
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = 360;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            Storyboard.SetTargetName(myDoubleAnimation, rectangle02.Name);
            
            // <Snippet139>
            // <Snippet140>
            DependencyProperty[] propertyChain =
                new DependencyProperty[]
                    {
                        Rectangle.RenderTransformProperty, 
                        TransformGroup.ChildrenProperty,
                        RotateTransform.AngleProperty
                    };
            // </Snippet140>
            // <Snippet141>
            string thePath = "(0).(1)[1].(2)";
            // </Snippet141>
            PropertyPath myPropertyPath = new PropertyPath(thePath, propertyChain);
            Storyboard.SetTargetProperty(myDoubleAnimation, myPropertyPath);
            // </Snippet139>
            
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            BeginStoryboard myBeginStoryboard = new BeginStoryboard();
            myBeginStoryboard.Storyboard = myStoryboard;
            EventTrigger myMouseEnterTrigger = new EventTrigger();
            myMouseEnterTrigger.RoutedEvent = Rectangle.MouseEnterEvent;
            myMouseEnterTrigger.Actions.Add(myBeginStoryboard);
            rectangle02.Triggers.Add(myMouseEnterTrigger);
            // </Snippet138>
            myStackPanel.Children.Add(rectangle02);        
        
        }        
        
        
    }


}
