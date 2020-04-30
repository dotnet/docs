using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Microsoft.Samples.GradientBrushExamples
{

    public class RadialGradientBrushExample : Page
    {

        private StackPanel myMainPanel;

        public RadialGradientBrushExample()
        {
            this.WindowTitle = "RadialGradientBrush Example";
            this.Background = Brushes.White;

            myMainPanel = new StackPanel();

            createRadialGradientBrushExample();

            this.Content = myMainPanel;
        }

        private void createRadialGradientBrushExample()
        {
            // <SnippetRadialGradient1CSharp>
            RadialGradientBrush myRadialGradientBrush = new RadialGradientBrush();
            myRadialGradientBrush.GradientOrigin = new Point(0.5,0.5);
            myRadialGradientBrush.Center = new Point(0.5,0.5);
            myRadialGradientBrush.RadiusX = 0.5;
            myRadialGradientBrush.RadiusY = 0.5;
            myRadialGradientBrush.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            myRadialGradientBrush.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));
            myRadialGradientBrush.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));
            myRadialGradientBrush.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));

            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 200;
            myRectangle.Height = 100;
            myRectangle.Fill = myRadialGradientBrush;
            // </SnippetRadialGradient1CSharp>

            myMainPanel.Children.Add(myRectangle);
        }
    }
}