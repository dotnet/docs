//This app used to draw strokes onto a Label, but the Visual object model changed 
// so drastically that that's difficult to do.  Instead, the app has methods
//that returns a DrawingVisual that contains a stroke.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace DrawTransformSample
{
    public class DrawTransformApp : Application
    {
        Window myWindow;
        Canvas myCanvas;
        InkCanvas myIC;
        Label myLabel;
        Matrix myMatrix;
        VisualCollection myVisuals;

        protected override void OnStartup(StartupEventArgs e)
        {
            myWindow = new Window();

            // Create new Canvas
            // and connect it to the top-level Window
            myCanvas = new Canvas();
            myWindow.Content = myCanvas;

            myIC = new InkCanvas();

            // You must set a background to get stroke events
            myIC.Background = Brushes.LightGray;

            // Get each stroke as it is added to the InkCanvas
            myIC.StrokeCollected += 
                new InkCanvasStrokeCollectedEventHandler(myIC_StrokeCollected);

            myIC.SetValue(Canvas.TopProperty, 30d);
            myIC.SetValue(Canvas.LeftProperty, 30d);
            myIC.SetValue(Canvas.WidthProperty, 450d);
            myIC.SetValue(Canvas.HeightProperty, 400d);

            // Add the InkCanvas to the Canvas
            myCanvas.Children.Add(myIC);

            myLabel = new Label();

            myLabel.Background = Brushes.Salmon;
            myLabel.SetValue(Canvas.TopProperty, 30d);
            myLabel.SetValue(Canvas.LeftProperty, 500d);
            myLabel.SetValue(Canvas.WidthProperty, 450d);
            myLabel.SetValue(Canvas.HeightProperty, 400d);

            // Add the Label to the Canvas
            myCanvas.Children.Add(myLabel);

            // Associate Visual collection with Label
            //myVisuals = VisualOperations.GetChildren(myLabel);

            myMatrix = new Matrix();

            // Shrink the new Stroke by 50% in both dimensions
            // The new Stroke added to the label should appear
            // in the upper-left quadrant
            myMatrix.Scale(0.5, 0.5);

            // Display the Window
            myWindow.Show();
        }

        public enum dMode
        {
            dCOnly,
            dCandDA,
            all
        }

        dMode _state = dMode.dCOnly;

        void myIC_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            // Create a copy of the new Stroke object
            Stroke myStroke = e.Stroke.Clone();

            // Draw stroke based on state
            if(_state == dMode.dCOnly)
            {
                DrawDCOnly(myStroke);
            }
            else if(_state == dMode.dCandDA)
            {
                DrawDCandDA(myStroke);
            }
            else
            {
                drawAll(myStroke);
            }
        }

        // <Snippet1>
        protected DrawingVisual DrawDCOnly(Stroke myStroke)
        {
            // Create new Visual context to draw on
            DrawingVisual myVisual = new DrawingVisual();
            DrawingContext myContext = myVisual.RenderOpen();

            // myMatrix is scaled by:
            // myMatrix.Scale(0.5, 0.5)
            myStroke.Transform(myMatrix, false);

            // Draw the stroke on the Visual context using DrawingContext
            myStroke.Draw(myContext);

            // Close the context
            myContext.Close();

            return myVisual;
        }
        // </Snippet1>

        // <Snippet2>
        protected DrawingVisual DrawDCandDA(Stroke myStroke)
        {
            // Create new Visual context to draw on
            DrawingVisual myVisual = new DrawingVisual();
            DrawingContext myContext = myVisual.RenderOpen();

            // Draw stroke using DrawingContext and DrawingAttributes
            // (to make the stroke magenta)
            DrawingAttributes myDAs = new DrawingAttributes();
            myDAs.Color = Colors.Magenta;

            myStroke.Draw(myContext, myDAs);

            // Close the context
            myContext.Close();

            return myVisual;
        }
        // </Snippet2>

        protected void drawAll(Stroke myStroke)
        {
            // <Snippet3>
            Guid[] myPIDs = myStroke.GetPropertyDataIds();
            // </Snippet3>
        }

        [System.STAThread()]
        static void Main(string[] args)
        {
            new DrawTransformApp().Run();
        }
    }
}
