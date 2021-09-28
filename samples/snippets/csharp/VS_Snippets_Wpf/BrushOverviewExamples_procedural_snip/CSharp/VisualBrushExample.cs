// <SnippetGraphicsMMVisualBrushAsRectangleBackgroundExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Microsoft.Samples.BrushExamples
{

    public class VisualBrushExample : Page
    {

        public VisualBrushExample()
        {

            StackPanel mainPanel = new StackPanel();
            visualBrushAsRectangleFillExample(mainPanel);
            this.Content = mainPanel;
        }

        // <SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample>
        private void visualBrushAsRectangleFillExample(Panel mainPanel)
        {

            // <SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample1>
            VisualBrush myVisualBrush = new VisualBrush();

            // Create the visual brush's contents.
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Background = Brushes.White;

            Rectangle redRectangle = new Rectangle();
            redRectangle.Width = 25;
            redRectangle.Height =25;
            redRectangle.Fill = Brushes.Red;
            redRectangle.Margin = new Thickness(2);
            myStackPanel.Children.Add(redRectangle);

            TextBlock someText = new TextBlock();
            FontSizeConverter myFontSizeConverter = new FontSizeConverter();
            someText.FontSize = (double)myFontSizeConverter.ConvertFrom("10pt");
            someText.Text = "Hello, World!";
            someText.Margin = new Thickness(2);
            myStackPanel.Children.Add(someText);

            Button aButton = new Button();
            aButton.Content = "A Button";
            aButton.Margin = new Thickness(2);
            myStackPanel.Children.Add(aButton);

            // Use myStackPanel as myVisualBrush's content.
            myVisualBrush.Visual = myStackPanel;

            // Create a rectangle to paint.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 150;
            myRectangle.Height = 150;
            myRectangle.Stroke = Brushes.Black;
            myRectangle.Margin = new Thickness(5,0,5,0);

            // Use myVisualBrush to paint myRectangle.
            myRectangle.Fill = myVisualBrush;

            // </SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample1>

            mainPanel.Children.Add(myRectangle);
        }
        // </SnippetGraphicsMMVisualBrushAsRectangleBackgroundExample>
    }
}
// </SnippetGraphicsMMVisualBrushAsRectangleBackgroundExampleWholePage>