using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace AdvancedInkInputSemples
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>

    public partial class Window2 : Window
    {

        FilteredInkCanvas filteredIC = new FilteredInkCanvas();

        public Window2()
        {
            InitializeComponent();

 
            root.Children.Add(filteredIC);

            WindowState = WindowState.Maximized;
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, RoutedEventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }

    public class FilteredInkCanvas : InkCanvas
    {
        //FilterPlugin filter = new FilterPlugin();
        ImageRenderer imageRenderer1 = new ImageRenderer();
        
        public FilteredInkCanvas()
            : base()
        {
            
            this.DynamicRenderer = imageRenderer1;
            this.DefaultDrawingAttributes.Height = 20;
            this.DefaultDrawingAttributes.Width = 20;
        }

        protected override void OnStrokeCollected(InkCanvasStrokeCollectedEventArgs e)
        {
            base.OnStrokeCollected(e);

            // This is a hack, but I didn't want to create a whole control again.
            this.Strokes.Remove(e.Stroke);
            ImageStroke newStroke = new ImageStroke(e.Stroke, this.DynamicRenderer.ElementBounds);
            this.Strokes.Add(newStroke);
        }
    }
}