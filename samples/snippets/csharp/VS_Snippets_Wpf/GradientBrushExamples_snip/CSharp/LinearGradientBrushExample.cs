using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Microsoft.Samples.GradientBrushExamples
{

    public class LinearGradientBrushExample : Page
    {
    
        public LinearGradientBrushExample()
        {
            this.WindowTitle = "LinearGradientBrush Example";
            this.Background = Brushes.White;
            
            StackPanel mainPanel = new StackPanel();

            // <SnippetDiagonalGradient1CSharp>            
            Rectangle diagonalFillRectangle = new Rectangle();
            diagonalFillRectangle.Width = 200;
            diagonalFillRectangle.Height = 100;
            
            // Create a diagonal linear gradient with four stops.   
            LinearGradientBrush myLinearGradientBrush =
                new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0,0);
            myLinearGradientBrush.EndPoint = new Point(1,1);
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));                
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));        
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));
                
            // Use the brush to paint the rectangle.
            diagonalFillRectangle.Fill = myLinearGradientBrush;
            // </SnippetDiagonalGradient1CSharp>            
            
            // <SnippetHorizontalGradient1CSharp>            
            Rectangle horizontalFillRectangle = new Rectangle();
            horizontalFillRectangle.Width = 200;
            horizontalFillRectangle.Height = 100;
            
            // Create a horizontal linear gradient with four stops.   
            LinearGradientBrush myHorizontalGradient =
                new LinearGradientBrush();
            myHorizontalGradient.StartPoint = new Point(0,0.5);
            myHorizontalGradient.EndPoint = new Point(1,0.5);
            myHorizontalGradient.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            myHorizontalGradient.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));                
            myHorizontalGradient.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));        
            myHorizontalGradient.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));
                
            // Use the brush to paint the rectangle.
            horizontalFillRectangle.Fill = myHorizontalGradient; 

            // </SnippetHorizontalGradient1CSharp>
 

            // <SnippetVerticalGradient1CSharp>
            Rectangle verticalFillRectangle = new Rectangle();
            verticalFillRectangle.Width = 200;
            verticalFillRectangle.Height = 100;
            
            // Create a vertical linear gradient with four stops.   
            LinearGradientBrush myVerticalGradient =
                new LinearGradientBrush();
            myVerticalGradient.StartPoint = new Point(0.5,0);
            myVerticalGradient.EndPoint = new Point(0.5,1);
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));                
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));        
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));
                
            // Use the brush to paint the rectangle.
            verticalFillRectangle.Fill = myVerticalGradient;  
            // </SnippetVerticalGradient1CSharp>
            
            mainPanel.Children.Add(diagonalFillRectangle);
            mainPanel.Children.Add(horizontalFillRectangle);
            mainPanel.Children.Add(verticalFillRectangle);
 
            this.Content = mainPanel;
            
        }
        
    }
}