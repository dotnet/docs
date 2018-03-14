//<Snippet20>
using System;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Controls;
using System.Windows;
//</Snippet20>

namespace AdavancedInkTopicsSamples
{
    //<Snippet6>
    // A control for managing ink input
    class InkControl : Label
    {
        InkPresenter ip;
        DynamicRenderer dr;

        // The StylusPointsCollection that gathers points 
        // before Stroke from is created.
        StylusPointCollection stylusPoints = null;
        
        public InkControl()
        {
            // Add an InkPresenter for drawing.
            ip = new InkPresenter();
            this.Content = ip;

            // Add a dynamic renderer that 
            // draws ink as it "flows" from the stylus.
            dr = new DynamicRenderer();
            ip.AttachVisuals(dr.RootVisual, dr.DrawingAttributes);
            this.StylusPlugIns.Add(dr);

        }

        static InkControl()
        {
            // Allow ink to be drawn only within the bounds of the control.
            Type owner = typeof(InkControl);
            ClipToBoundsProperty.OverrideMetadata(owner,
                new FrameworkPropertyMetadata(true));
        }

        //<Snippet7>
        protected override void OnStylusDown(StylusDownEventArgs e)
        {
            // Capture the stylus so all stylus input is routed to this control.
            Stylus.Capture(this);

            // Allocate memory for the StylusPointsCollection and
            // add the StylusPoints that have come in so far.
            stylusPoints = new StylusPointCollection();
            StylusPointCollection eventPoints = 
                e.GetStylusPoints(this, stylusPoints.Description);

            stylusPoints.Add(eventPoints);

        }
        //</Snippet7>

        //<Snippet8>
        protected override void OnStylusMove(StylusEventArgs e)
        {
            if (stylusPoints == null)
            {
                return;
            }

            // Add the StylusPoints that have come in since the 
            // last call to OnStylusMove.
            StylusPointCollection newStylusPoints = 
                e.GetStylusPoints(this, stylusPoints.Description);
            stylusPoints.Add(newStylusPoints);
        }
        //</Snippet8>

        //<Snippet10>
        protected override void OnStylusUp(StylusEventArgs e)
        {
            if (stylusPoints == null)
            {
                return;
            }

            // Add the StylusPoints that have come in since the 
            // last call to OnStylusMove.
            StylusPointCollection newStylusPoints = 
                e.GetStylusPoints(this, stylusPoints.Description);
            stylusPoints.Add(newStylusPoints);

            // Create a new stroke from all the StylusPoints since OnStylusDown.
            Stroke stroke = new Stroke(stylusPoints);

            // Add the new stroke to the Strokes collection of the InkPresenter.
            ip.Strokes.Add(stroke);

            // Clear the StylusPointsCollection.
            stylusPoints = null;

            // Release stylus capture.
            Stylus.Capture(null);
        }
        //</Snippet10>

        //<Snippet11>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {

            base.OnMouseLeftButtonDown(e);

            // If a stylus generated this event, return.
            if (e.StylusDevice != null)
            {
                return;
            }

            // Start collecting the points.
            stylusPoints = new StylusPointCollection();
            Point pt = e.GetPosition(this);
            stylusPoints.Add(new StylusPoint(pt.X, pt.Y));

        }
        //</Snippet11>

        //<Snippet12>
        protected override void OnMouseMove(MouseEventArgs e)
        {

            base.OnMouseMove(e);

            // If a stylus generated this event, return.
            if (e.StylusDevice != null)
            {
                return;
            }

            // Don't collect points unless the left mouse button
            // is down.
            if (e.LeftButton == MouseButtonState.Released || 
                stylusPoints == null)
            {
                return;
            }

            Point pt = e.GetPosition(this);
            stylusPoints.Add(new StylusPoint(pt.X, pt.Y));
        }
        //</Snippet12>

        //<Snippet13>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {

            base.OnMouseLeftButtonUp(e);

            // If a stylus generated this event, return.
            if (e.StylusDevice != null)
            {
                return;
            }

            if (stylusPoints == null)
            {
                return;
            }

            Point pt = e.GetPosition(this);
            stylusPoints.Add(new StylusPoint(pt.X, pt.Y));

            // Create a stroke and add it to the InkPresenter.
            Stroke stroke = new Stroke(stylusPoints);
            stroke.DrawingAttributes = dr.DrawingAttributes;
            ip.Strokes.Add(stroke);

            stylusPoints = null;

        }
        //</Snippet13>
    }
    //</Snippet6>
}
