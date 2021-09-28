using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Microsoft.Samples.GradientBrushExamples
{

    public class GradientStopsExample : Page
    {

        private StackPanel myMainPanel;

        public GradientStopsExample()
        {
            this.WindowTitle = "Gradient Stop Examples";
            this.Background = Brushes.White;

            myMainPanel = new StackPanel();

            createTransparentGradientStopExample();

            this.Content = myMainPanel;
        }

        private void createTransparentGradientStopExample()
        {
            // <SnippetTransparentGradientStopExample1CSharp>
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();

            // This gradient stop is partially transparent.
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromArgb(32, 0, 0, 255), 0.0));

            // This gradient stop is fully opaque.
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(Color.FromArgb(255, 0, 0, 255), 1.0));

            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = myLinearGradientBrush;

            // </SnippetTransparentGradientStopExample1CSharp>

            myMainPanel.Children.Add(myRectangle);
        }
    }
}