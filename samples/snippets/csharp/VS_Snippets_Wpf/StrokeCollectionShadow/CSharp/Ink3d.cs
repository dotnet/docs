
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;
using System.Windows.Input;
using System.Collections;
using System.Windows.Input.StylusPlugIns;

namespace StrokeCollectionShadow
{
    // This control allows the user to input ink and display it 
    // with 3d visual effects.
    public class Ink3d : Border
    {

        DrawingAttributes inkDA;
        InkPresenter presenter;
        StylusPointCollection stylusPoints;
        DynamicRenderer renderer = new DynamicRenderer();
        public Ink3d()
        {
            // Use an InkPresenter to display the strokes on the control.
            presenter = new InkPresenter();
            this.Child = presenter;

            inkDA = new DrawingAttributes();
            inkDA.Width = 5;
            inkDA.Height = 5;
            //inkDA.AddPropertyData(shadow, false);
            //inkDA.PropertyDataChanged += new PropertyDataChangedEventHandler(inkDA_PropertyDataChanged);

            renderer.DrawingAttributes = inkDA;
            this.StylusPlugIns.Add(renderer);
            presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes);
        }

        static Ink3d()
        {
            // Allow ink to be drawn only within the bounds of the control.
            Type owner = typeof(Ink3d);
            ClipToBoundsProperty.OverrideMetadata(owner,
                new FrameworkPropertyMetadata(true));

        }

    
        // Remove all the strokes from the control.
        public void ClearStrokes()
        {
            presenter.Strokes.Clear();
            

        }


        protected override void OnStylusDown(StylusDownEventArgs e)
        {

            base.OnStylusDown(e);

            stylusPoints = new StylusPointCollection();

            stylusPoints.Add(e.GetStylusPoints(this, stylusPoints.Description));

        }



        protected override void OnStylusMove(StylusEventArgs e)
        {

            base.OnStylusMove(e);

            if (stylusPoints == null) stylusPoints = new StylusPointCollection();

            stylusPoints.Add(e.GetStylusPoints(this, stylusPoints.Description));

        }



        protected override void OnStylusUp(StylusEventArgs e)
        {

            base.OnStylusUp(e);

            if (stylusPoints == null) stylusPoints = new StylusPointCollection();

            stylusPoints.Add(e.GetStylusPoints(this, stylusPoints.Description));

            AddStroke();

        }


        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {

            base.OnMouseLeftButtonUp(e);

            if (e.StylusDevice != null) return;

            if (stylusPoints == null) stylusPoints = new StylusPointCollection();

            Point pt = e.GetPosition(this);

            stylusPoints.Add(new StylusPoint(pt.X, pt.Y));

            AddStroke();

        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {

            base.OnMouseLeftButtonDown(e);

            if (e.StylusDevice != null) return;

            stylusPoints = new StylusPointCollection();

            Point pt = e.GetPosition(this);

            stylusPoints.Add(new StylusPoint(pt.X, pt.Y));

        }



        protected override void OnMouseMove(MouseEventArgs e)
        {

            base.OnMouseMove(e);

            if (e.StylusDevice != null) return;

            if (e.LeftButton == MouseButtonState.Released) return;

            if (stylusPoints == null) stylusPoints = new StylusPointCollection();

            Point pt = e.GetPosition(this);

            stylusPoints.Add(new StylusPoint(pt.X, pt.Y));

        }


        private void AddStroke()
        {
            ShadowedStroke stroke = new ShadowedStroke(stylusPoints, inkDA);
            stroke.Shadowed = strokesAreShadowed;

            presenter.Strokes.Add(stroke);

            stylusPoints = null;
        }

        private bool strokesAreShadowed;

        public bool Shadowed
        {
            get
            {
                return strokesAreShadowed;
            }

            // Set the value of the custom property.
            set
            {
                strokesAreShadowed = value;

                foreach (ShadowedStroke s in presenter.Strokes)
                {
                    s.Shadowed = strokesAreShadowed;
                }
            }
        }

       
    }
}
