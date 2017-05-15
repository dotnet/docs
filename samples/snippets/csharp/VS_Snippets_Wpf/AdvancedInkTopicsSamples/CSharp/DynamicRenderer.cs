//<Snippet19>
using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Input;
using System.Windows.Ink;
//</Snippet19>

namespace AdavancedInkTopicsSamples
{
    //<Snippet1>
    // A StylusPlugin that renders ink with a linear gradient brush effect.
    class CustomDynamicRenderer : DynamicRenderer
    {
        [ThreadStatic]
        static private Brush brush = null;

        [ThreadStatic]
        static private Pen pen = null;

        private Point prevPoint;

        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            // Allocate memory to store the previous point to draw from.
            prevPoint = new Point(double.NegativeInfinity, double.NegativeInfinity);
            base.OnStylusDown(rawStylusInput);
        }

        protected override void OnDraw(DrawingContext drawingContext,
                                       StylusPointCollection stylusPoints,
                                       Geometry geometry, Brush fillBrush)
        {
            // Create a new Brush, if necessary.
            if (brush == null)
            {
                brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 20d);
            }

            // Create a new Pen, if necessary.
            if (pen == null)
            {
                pen = new Pen(brush, 2d);
            }

            // Draw linear gradient ellipses between 
            // all the StylusPoints that have come in.
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                Point pt = (Point)stylusPoints[i];
                Vector v = Point.Subtract(prevPoint, pt);

                // Only draw if we are at least 4 units away 
                // from the end of the last ellipse. Otherwise, 
                // we're just redrawing and wasting cycles.
                if (v.Length > 4)
                {
                    // Set the thickness of the stroke based 
                    // on how hard the user pressed.
                    double radius = stylusPoints[i].PressureFactor * 10d;
                    drawingContext.DrawEllipse(brush, pen, pt, radius, radius);
                    prevPoint = pt;
                }
            }
        }
    }
    //</Snippet1>

    //<Snippet2>
    // A class for rendering custom strokes
    class CustomStroke : Stroke
    {
        Brush brush;
        Pen pen;

        public CustomStroke(StylusPointCollection stylusPoints)
            : base(stylusPoints)
        {
            // Create the Brush and Pen used for drawing.
            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 20d);
            pen = new Pen(brush, 2d);
        }

        protected override void DrawCore(DrawingContext drawingContext, 
                                         DrawingAttributes drawingAttributes)
        {
            // Allocate memory to store the previous point to draw from.
            Point prevPoint = new Point(double.NegativeInfinity, 
                                        double.NegativeInfinity);

            // Draw linear gradient ellipses between 
            // all the StylusPoints in the Stroke.
            for (int i = 0; i < this.StylusPoints.Count; i++)
            {
                Point pt = (Point)this.StylusPoints[i];
                Vector v = Point.Subtract(prevPoint, pt);

                // Only draw if we are at least 4 units away 
                // from the end of the last ellipse. Otherwise, 
                // we're just redrawing and wasting cycles.
                if (v.Length > 4)
                {
                    // Set the thickness of the stroke 
                    // based on how hard the user pressed.
                    double radius = this.StylusPoints[i].PressureFactor * 10d;
                    drawingContext.DrawEllipse(brush, pen, pt, radius, radius);
                    prevPoint = pt;
                }
            }
        }
    }
    //</Snippet2>

    //<Snippet3>
    // A StylusPlugin that restricts the input area.
    class FilterPlugin : StylusPlugIn
    {
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            // Call the base class before modifying the data.
            base.OnStylusDown(rawStylusInput);

            // Restrict the stylus input.
            Filter(rawStylusInput);
        }

        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            // Call the base class before modifying the data.
            base.OnStylusMove(rawStylusInput);

            // Restrict the stylus input.
            Filter(rawStylusInput);
        }

        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            // Call the base class before modifying the data.
            base.OnStylusUp(rawStylusInput);

            // Restrict the stylus input
            Filter(rawStylusInput);
        }

        private void Filter(RawStylusInput rawStylusInput)
        {
            // Get the StylusPoints that have come in.
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();

            // Modify the (X,Y) data to move the points 
            // inside the acceptable input area, if necessary.
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 50) sp.X = 50;
                if (sp.X > 250) sp.X = 250;
                if (sp.Y < 50) sp.Y = 50;
                if (sp.Y > 250) sp.Y = 250;
                stylusPoints[i] = sp;
            }

            // Copy the modified StylusPoints back to the RawStylusInput.
            rawStylusInput.SetStylusPoints(stylusPoints);
        }
    }
    //</Snippet3>
}
