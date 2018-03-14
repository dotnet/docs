using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Input.StylusPlugIns;

namespace AdavancedInkTopicsSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        CustomRenderingInkCanvas customInkCanvas;
        InkCanvas ic;
        FilterInkCanvas filterInkCanvas;
        TextBox textbox1;
        InkControl control;



        public Window1()
        {
            InitializeComponent();

            //customInkCanvas = new CustomRenderingInkCanvas();
            //root.Children.Add(customInkCanvas);
            //customInkCanvas.EditingModeInverted = InkCanvasEditingMode.EraseByPoint;
            //customInkCanvas.StrokeCollected += new InkCanvasStrokeCollectedEventHandler(customInkCanvas_StrokeCollected); 
        
            //filterInkCanvas = new FilterInkCanvas();
            //root.Children.Add(filterInkCanvas);

            //ic = new InkCanvas();
            //root.Children.Add(ic);
            //ic.StrokeCollected += new InkCanvasStrokeCollectedEventHandler(customInkCanvas_StrokeCollected); 
        
            //textbox1 = new TextBox();
            //InkCanvas.SetTop(textbox1, 30);
            //InkCanvas.SetLeft(textbox1, 100);
            //textbox1.Text = "Hello world";
            //ic.Children.Add(textbox1);  

            control = new InkControl();
            root.Children.Add(control);

            ClearStrokes.Click += new RoutedEventHandler(ClearStrokes_Click);
            WindowState = WindowState.Maximized;
        }

        void ClearStrokes_Click(object sender, RoutedEventArgs e)
        {
            customInkCanvas.Strokes.Clear();
        }

        void customInkCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("customInkCanvase_StrokeCollected");
            e.Stroke.DrawingAttributes.Color = Colors.Green;
            if (e.Stroke is CustomStroke)
            {
                System.Diagnostics.Debug.WriteLine("stroke is custom");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("stroke is not custom");
            }

            if (customInkCanvas.Strokes.Contains(e.Stroke))
            {
                System.Diagnostics.Debug.WriteLine("stroke is in ink canvas");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("stroke is not in ink canvas");  //always lands here
            }

            System.Diagnostics.Debug.WriteLine("");
        }

    }

    //<Snippet4>
    public class FilterInkCanvas : InkCanvas
    {
        FilterPlugin filter = new FilterPlugin();

        public FilterInkCanvas()
            : base()
        {
            this.StylusPlugIns.Add(filter);
        }
    }
    //</Snippet4>

    //<Snippet5>
    public class DynamicallyFilteredInkCanvas : InkCanvas
    {
        FilterPlugin filter = new FilterPlugin();

        public DynamicallyFilteredInkCanvas()
            : base()
        {
            int dynamicRenderIndex = 
                this.StylusPlugIns.IndexOf(this.DynamicRenderer);
            
            this.StylusPlugIns.Insert(dynamicRenderIndex, filter);

        }

    }
    //</Snippet5>

    //<Snippet9>
    public class CustomRenderingInkCanvas : InkCanvas
    {
        CustomDynamicRenderer customRenderer = new CustomDynamicRenderer();

        public CustomRenderingInkCanvas() : base()
        {
            // Use the custom dynamic renderer on the
            // custom InkCanvas.
            this.DynamicRenderer = customRenderer;
        }

        protected override void OnStrokeCollected(InkCanvasStrokeCollectedEventArgs e)
        {
            // Remove the original stroke and add a custom stroke.
            this.Strokes.Remove(e.Stroke);
            CustomStroke customStroke = new CustomStroke(e.Stroke.StylusPoints);
            this.Strokes.Add(customStroke);

            // Pass the custom stroke to base class' OnStrokeCollected method.
            InkCanvasStrokeCollectedEventArgs args = 
                new InkCanvasStrokeCollectedEventArgs(customStroke);
            base.OnStrokeCollected(args);

        }

    }
    //</Snippet9>
}

