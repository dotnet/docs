/*
SolidColorBrushExample.cs

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{
    public partial class SolidColorBrushExample : Page
    {
        public SolidColorBrushExample()
        {
            this.WindowTitle = "SolidColorBrush Example";
            this.Background = Brushes.White;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // <Snippet_graphicsmm_PredefinedBrush1> 
            // Create a rectangle and paint it with
            // a predefined brush.
            Rectangle myPredefinedBrushRectangle = new Rectangle();
            myPredefinedBrushRectangle.Width = 50;
            myPredefinedBrushRectangle.Height = 50;
            myPredefinedBrushRectangle.Fill = Brushes.Blue;
            // </Snippet_graphicsmm_PredefinedBrush1> 

            myStackPanel.Children.Add(myPredefinedBrushRectangle);

            // <Snippet_graphicsmm_RgbNotation1> 
            Rectangle myRgbRectangle = new Rectangle();
            myRgbRectangle.Width = 50;
            myRgbRectangle.Height = 50;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();

            // Describes the brush's color using RGB values. 
            // Each value has a range of 0-255.
            mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 255);
            myRgbRectangle.Fill = mySolidColorBrush;           
            // </Snippet_graphicsmm_RgbNotation1> 
            myStackPanel.Children.Add(myRgbRectangle);

            // <Snippet_graphicsmm_ScrgbNotation1> 
            Rectangle myScRGBRectangle = new Rectangle();
            myScRGBRectangle.Width = 50;
            myScRGBRectangle.Height = 50;
            SolidColorBrush myScrgbSolidColorBrush = new SolidColorBrush();

            // Describes the brush's color using ScRGB values. 
            // Each value has a range of 0-1.
            myScrgbSolidColorBrush.Color = Color.FromScRgb(1.0F, 0.0F, 0.0F, 1.0F);
            myScRGBRectangle.Fill = myScrgbSolidColorBrush;           
            // </Snippet_graphicsmm_ScrgbNotation1> 
            myStackPanel.Children.Add(myScRGBRectangle);



            this.Content = myStackPanel;
        }
        
        
    }
}
