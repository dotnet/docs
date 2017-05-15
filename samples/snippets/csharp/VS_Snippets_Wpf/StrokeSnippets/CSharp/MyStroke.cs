using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

using System;
using System.Collections.Generic;
using System.Text;

namespace StrokeSnippets_CS
{
    class MyStroke : Stroke
    {
        // Let user reset color for all new strokes
        // by setting the color for any stroke.
        // We'll start off by setting the color to black.
        private Color myColor = Colors.Black;

        Guid dtGuid;

        public MyStroke(StylusPointCollection points) : base(points)
        {
            initialize();
            //MoveStylusPoints();
        }

        public MyStroke(StylusPointCollection stylusPoints, DrawingAttributes drawingAttributes)
            : base(stylusPoints, drawingAttributes)
        {
            //MoveStylusPoints();
        }

        private void initialize()
        {
            setTimeStamp();
        }

        public void MoveStylusPoints()
        {
            StylusPointCollection points = this.StylusPoints;

            for (int i = 0; i < points.Count; ++i)
            {
                StylusPoint p = points[i];
                p.Y = p.Y + 20;
                points[i] = p;
            }

        }

        private void setTimeStamp()
        {
            // See if we have the same timestamp as the border
            Attribute sAttr = Attribute.GetCustomAttribute(typeof(MyBorder), typeof(GuidAttribute));
            dtGuid = new Guid("03457307-3475-3450-3035-640435034540");
        }

        // <Snippet15>
        protected override void OnDrawingAttributesChanged(PropertyDataChangedEventArgs e)
        {
            // Notify base class of event
            base.OnDrawingAttributesChanged(e);

            // See if the change was a new DrawingAttribute.Color property
            Type eT = e.NewValue.GetType();



            //if (eT == typeof(Color))
            //{
            //    Color c = (Color)e.NewValue;

            //    if (c == Colors.Red)
            //    {
            //        MessageBox.Show("The stroke is now red!");
            //    }
            //}
        }
        // </Snippet15>



        //<Snippet23>
        protected override void DrawCore(DrawingContext context, DrawingAttributes overrides)
        {
            // Draw the stroke. Calling base.DrawCore accomplishes the same thing.
            Geometry geometry = GetGeometry(overrides);
            context.DrawGeometry(new SolidColorBrush(overrides.Color), null, geometry);

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
                context.DrawEllipse(null, new Pen(Brushes.Black, 1), (Point)p, 5, 5);
            }
          
        }
        //</Snippet23>

        private void DrawSelectedStrokeAndPoints(DrawingContext context, DrawingAttributes overrides)
        {
        }

        // <Snippet16>
        protected override void OnDrawingAttributesReplaced(DrawingAttributesReplacedEventArgs e)
        {
            //// Notify base class of event
            //base.OnDrawingAttributesReplaced(e);

            //if (e.NewDrawingAttributes.Color == Colors.Red)
            //{
            //    MessageBox.Show("The stroke is now red!");
            //}
        }
        // </Snippet16>

        void MyStroke_PacketsChanged(object sender, EventArgs e)
        {}

        // <Snippet17>
        protected override void OnStylusPointsChanged(EventArgs e)
        {
            // Notify base class of event
            base.OnStylusPointsChanged(e);
        }
        // </Snippet17>

        void MyStroke_PropertyDataChanged(object sender, PropertyDataChangedEventArgs e)
        { }

        // <Snippet18>
        protected override void OnPropertyDataChanged(PropertyDataChangedEventArgs e)
        {
            // Notify base class of event
            base.OnPropertyDataChanged(e);

            // If the current stroke color changes,
            // reset the default color for the class.
            if (e.PropertyGuid.Equals(DrawingAttributeIds.Color))
            {
                myColor = this.DrawingAttributes.Color;
            }
        }
        // </Snippet18>

        private bool IsSelected;

        public bool Selected
        {
            get
            {
                return IsSelected;
            }

            set
            {
                if (IsSelected != value)
                {
                    IsSelected = value;
                    this.OnInvalidated(new EventArgs());
                }
            }
        }
    }
}
