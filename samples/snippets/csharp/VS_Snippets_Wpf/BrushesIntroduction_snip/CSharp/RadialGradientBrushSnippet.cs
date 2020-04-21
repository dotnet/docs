// <SnippetSimpleRadialGradientExampleWholePage>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BrushesIntroduction
{
    public class RadialGradientBrushSnippet : Page
    {
        public RadialGradientBrushSnippet()
        {
            Title = "RadialGradientBrush Example";
            Background = Brushes.White;
            Margin = new Thickness(20);

            //
            // Create a RadialGradientBrush with four gradient stops.
            //
            RadialGradientBrush radialGradient = new RadialGradientBrush();

            // Set the GradientOrigin to the center of the area being painted.
            radialGradient.GradientOrigin = new Point(0.5, 0.5);

            // Set the gradient center to the center of the area being painted.
            radialGradient.Center = new Point(0.5, 0.5);

            // Set the radius of the gradient circle so that it extends to
            // the edges of the area being painted.
            radialGradient.RadiusX = 0.5;
            radialGradient.RadiusY = 0.5;

            // Create four gradient stops.
            radialGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            radialGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.25));
            radialGradient.GradientStops.Add(new GradientStop(Colors.Blue, 0.75));
            radialGradient.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.0));

            // Freeze the brush (make it unmodifiable) for performance benefits.
            radialGradient.Freeze();

            // Create a rectangle and paint it with the
            // RadialGradientBrush.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 200;
            aRectangle.Height = 100;
            aRectangle.Fill = radialGradient;

            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(aRectangle);
            Content = mainPanel;
        }
    }
}


// </SnippetSimpleRadialGradientExampleWholePage>
