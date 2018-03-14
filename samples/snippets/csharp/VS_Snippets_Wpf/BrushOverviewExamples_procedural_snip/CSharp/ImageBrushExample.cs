
// <SnippetGraphicsMMImageBrushAsCanvasBackgroundExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{

    public class ImageBrushExample : Page
    {
    
        public ImageBrushExample()
        {
        
            StackPanel mainPanel = new StackPanel();
            canvasBackgroundExample(mainPanel);
            this.Content = mainPanel;
        
        }
                 

        // <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample>
        private void canvasBackgroundExample(Panel mainPanel)
        {
            
            // <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample1>
            BitmapImage theImage = new BitmapImage
                (new Uri("sampleImages\\Waterlilies.jpg", UriKind.Relative));
            // </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample1>
            
            // <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample2>
            ImageBrush myImageBrush = new ImageBrush(theImage);
            // </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample2>
            
            // <SnippetGraphicsMMImageBrushAsCanvasBackgroundExample3>
            Canvas myCanvas = new Canvas();
            myCanvas.Width = 300;
            myCanvas.Height = 200;
            myCanvas.Background = myImageBrush;
            // </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample3>
            
            mainPanel.Children.Add(myCanvas);
    
    
        }
        // </SnippetGraphicsMMImageBrushAsCanvasBackgroundExample>
    
    }

}
// </SnippetGraphicsMMImageBrushAsCanvasBackgroundExampleWholePage>