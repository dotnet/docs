using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace StrokeSnippets_CS
{
    //<Snippet24>
    // Enumerator that specifies the drawing mode of the stroke.
    public enum DrawingMode
    {
        Solid,
        StyulusPoints
    }
    //</Snippet24>

    class CustomRenderedStroke : MyStroke
    {
        public CustomRenderedStroke(StylusPointCollection points) : base(points)
        {
         
        }

        public CustomRenderedStroke(StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes)
            : base(stylusPoints, drawingAttributes)
        {
         
        }

        //<Snippet25>
        private DrawingMode strokeMode = DrawingMode.Solid;

        // Property that specifies whether to draw a solid stroke or the stylus points
        public DrawingMode Mode
        {
            get
            {
                return strokeMode;
            }

             set
            {
                if (strokeMode != value)
                {
                    strokeMode = value;
                    this.OnInvalidated(new EventArgs());
                }
            }
        }

        protected override void DrawCore(System.Windows.Media.DrawingContext context, DrawingAttributes overrides)
        {
            SolidColorBrush strokeBrush = new SolidColorBrush(overrides.Color);

            // If strokeMode it set to Solid, draw the strokes regularly.
            // Otherwise, draw the stylus points.
            if (strokeMode == DrawingMode.Solid)
            {
                Geometry geometry = GetGeometry(overrides);
                context.DrawGeometry(strokeBrush, null, geometry);
            }
            else // strokeMode == DrawingMode.StylusPoints
            {
                StylusPointCollection points;

                // Get the stylus points used to draw the stroke.  The points used depends on
                // the value of FitToCurve.
                if (this.DrawingAttributes.FitToCurve)
                {
                    points = this.GetBezierStylusPoints();
                }
                else
                {
                    points = this.StylusPoints;
                }

                // Draw a circle at each stylus point.
                foreach (StylusPoint p in points)
                {
                    context.DrawEllipse(null, new Pen(strokeBrush, 1), (Point)p, 5, 5);
                }
            }
        }
        //</Snippet25>
    }
}
