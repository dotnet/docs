using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace StrokeCollectionEraseMethods
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>

    public partial class Window3 : Window
    {
        InkThumbnail thumbnail1 = new InkThumbnail();

        public Window3()
        {
            InitializeComponent();

            //thumbnail inherits from Control
            thumbnail1.Height = 100;
            thumbnail1.Width = 100;
            //thumbnail1.Background = Brushes.White;

            thumbnail1.Source = inkCanvas1;
            inkCanvas1.Children.Add(thumbnail1);
            inkCanvas1.Background = Brushes.Green;

            //The thumbnail is green.
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }

    //<Snippet33>
    public class InkThumbnail : FrameworkElement
    {
        private InkCanvas sourceInkCanvas = null;
        
        // Get the InkCanvas that the user draws on.
        public InkCanvas Source
        {

            get 
            { 
                return sourceInkCanvas; 
            }

            set
            {
                
                if (sourceInkCanvas != null)
                {
                    // Detach the event handler from the former InkCanvas.
                    sourceInkCanvas.StrokeCollected -= new InkCanvasStrokeCollectedEventHandler(SourceChanged);
                }

                sourceInkCanvas = value;


                if (sourceInkCanvas != null)
                {
                    // Attach the even handler to the InkCannvas
                    sourceInkCanvas.StrokeCollected += new InkCanvasStrokeCollectedEventHandler(SourceChanged);
                }

            }
        }

        // Handle the StrokeCollection event of the InkCanvas.
        private void SourceChanged(object sender, InkCanvasStrokeCollectedEventArgs e)
        {

            // Cause the thumbnail to be redrawn.
            this.InvalidateVisual();
        }


        protected override void OnRender(DrawingContext drawingContext)
        {
            
            base.OnRender(drawingContext);

            // Draw the strokes from the InkCanvas at 1/4 of their size.
            drawingContext.PushTransform(new ScaleTransform(0.25, 0.25));

            if (sourceInkCanvas != null)
            {
                sourceInkCanvas.Strokes.Draw(drawingContext);
            }
        }

 
    }
    //</Snippet33>
 
}