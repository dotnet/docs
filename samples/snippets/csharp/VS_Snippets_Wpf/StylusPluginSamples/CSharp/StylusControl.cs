using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Windows.Input;
using System.Windows.Ink;
using System.Windows.Input.StylusPlugIns;

namespace AdvancedInkInputSemples
{
    /// <summary>
    /// A custom control.
    /// </summary>

    // A control for managing ink input
    public class StylusControl : Label
    {
        InkPresenter inkPresenter1;
        DynamicRenderer dynamicRenderer1;
        // Declare the StylusPointsCollection where we'll 
        // gather points before creating a Stroke from them
        StylusPointCollection stylusPoints = null;
        FilterPlugin filterPlugin1;
        CustomDynamicRenderer2 cdr;
        RecognizerPlugin recoPlugin;

        DrawingAttributes currentAttributes;
        StylusPointCollection playPoints;

        static StylusControl()
        {
            //This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
            //This style is defined in themes\generic.xaml
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(StylusControl),
            //    new FrameworkPropertyMetadata(typeof(StylusControl)));

            // Allow ink to be drawn only within the bounds of the control.
            Type owner = typeof(StylusControl);
            ClipToBoundsProperty.OverrideMetadata(owner,
                new FrameworkPropertyMetadata(true));
        }

        public StylusControl()
        {
            // Add an InkPresenter for drawing
            inkPresenter1 = new InkPresenter();

            // When StylusContol is a Label
            this.Content = inkPresenter1;

            // When StylusContol is a Border
            //this.Child = inkPresenter1;

            // Add a custom filter plugin that restricts the 
            // input area first, before rendering occurs
            filterPlugin1 = new FilterPlugin();
            filterPlugin1.StrokeRendered += new StrokeRenderedEventHandler(filterPlugin1_StrokeRendered);
            this.StylusPlugIns.Add(filterPlugin1);
            
            cdr = new CustomDynamicRenderer2();
            cdr.DrawingAttributes.Color = Colors.Green;
            currentAttributes = cdr.DrawingAttributes;
            inkPresenter1.AttachVisuals(cdr.RootVisual, cdr.DrawingAttributes);
            //this.StylusPlugIns.Add(cdr);

            AttatchDynamicRenderer();

            recoPlugin = new RecognizerPlugin();
            //this.StylusPlugIns.Add(recoPlugin);

            //DrawRect(cdr.Rect);


        }

        public void ChangeDAOnCustomDR()
        {
            if (!StylusPlugIns.Contains(cdr))
            {
                return;
            }

            cdr.DrawingAttributes.Color = Colors.Red;
            //DrawingAttributes da = new DrawingAttributes();
            //da.Color = Colors.Red;

            //cdr.DrawingAttributes = da;

        }

        void filterPlugin1_StrokeRendered(object sender, StrokeRenderedEventArgs e)
        {
            //MessageBox.Show("stroke rendered");
            Stroke newStroke = new Stroke(e.StrokePoints, currentAttributes);
            inkPresenter1.Strokes.Add(newStroke);
        }

        StylusDevice stylus1 = null;
        StylusDevice stylus2 = null;

        protected override void OnStylusInRange(StylusEventArgs e)
        {
            //Application.Current.Windows[0].Title = "StylusInRange " + DateTime.Now.ToLongTimeString();

            if (!e.Inverted)
            {
                stylus1 = e.StylusDevice;
            }
            else
            {
                stylus2 = e.StylusDevice;
            }

            //if ((stylus1 != null) && (stylus2 != null))
            //{
            //    bool result = stylus1 == stylus2;
            //    Application.Current.Windows[0].Title = "styluses equal: " + result.ToString();
            //}
        }

        protected override void OnStylusOutOfRange(StylusEventArgs e)
        {
            //Application.Current.Windows[0].Title = "StylusOutOfRange";
        }

        private void AttatchDynamicRenderer()
        {
            //<Snippet3>
            // Create a DrawingAttributes to use for the 
            // DynamicRenderer.
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Width = 5;
            inkDA.Height = 5;
            inkDA.Color = Colors.Purple;

            // Add a dynamic renderer plugin that 
            // draws ink as it "flows" from the stylus
            DynamicRenderer dynamicRenderer1 = new DynamicRenderer();
            dynamicRenderer1.DrawingAttributes = inkDA;

            this.StylusPlugIns.Add(dynamicRenderer1);
            inkPresenter1.AttachVisuals(dynamicRenderer1.RootVisual,
                dynamicRenderer1.DrawingAttributes);
            //</Snippet3>
        }

        private void DrawRect(Rect rect)
        {
            //DrawingVisual boundsVisual = new DrawingVisual();
            //DrawingContext boundsContext = null;

            //rect.Width = rect.Width * 2;
            //rect.Height = rect.Height * 2;
            //try
            //{
            //    boundsContext = boundsVisual.RenderOpen();

            //    Pen border = new Pen(Brushes.Purple, 10);
            //    boundsContext.DrawRectangle(Brushes.Purple, border, rect);
            //}
            //finally
            //{
            //    if (boundsContext != null)
            //    {
            //        boundsContext.Close();
            //    }
            //}

            //VisualCollection childVisuals = VisualOperations.GetChildren(this);
            //if (!childVisuals.Contains(boundsVisual))
            //{
            //    childVisuals.Add(boundsVisual);
            //}
        }

        public bool FilterEnabled
        {
            get
            {
                return filterPlugin1.Enabled;
            }
            set
            {
                filterPlugin1.Enabled = value;
            }

        }


        public bool AddRemoveDynamicRenderer()
        {
            bool containsPlugin = this.StylusPlugIns.Contains(dynamicRenderer1);
            if (containsPlugin)
            {
                StylusPlugIns.Remove(dynamicRenderer1);
            }
            else
            {
                StylusPlugIns.Insert(0, dynamicRenderer1);
            }
            //MessageBox.Show(filterPlugin1.IsActiveForInput.ToString());

            return !containsPlugin;

        }

        public bool IsDynamicRendererActive
        {
            get
            {
                return dynamicRenderer1.IsActiveForInput;
            }
        }

        public bool AddRemoveFilterPlugin()
        {
            bool containsPlugin = this.StylusPlugIns.Contains(filterPlugin1);
            if (containsPlugin)
            {
                StylusPlugIns.Remove(filterPlugin1);
            }
            else
            {
                //StylusPlugIns.Insert(0, filterPlugin1);
                StylusPlugIns.Add(filterPlugin1);
            }

            return !containsPlugin;

        }

        public bool IsFilterPluginActive
        {
            get
            {
                return filterPlugin1.IsActiveForInput;
            }
        }

        public bool RemovePluginSample()
        {
            //<Snippet2>
            if (this.StylusPlugIns.Contains(filterPlugin1))
            {
                StylusPlugIns.Remove(filterPlugin1);
            }
            //</Snippet2>

            return this.StylusPlugIns.Contains(filterPlugin1);

        }

        void PluginCollectionSnippets()
        {
            //<Snippet5>
            this.StylusPlugIns.Clear();
            //</Snippet5>

            //<Snippet6>
            StylusPlugIn[] plugIns = new StylusPlugIn[this.StylusPlugIns.Count];
            this.StylusPlugIns.CopyTo(plugIns, 0);
            //</Snippet6>

            //<Snippet7>
            if (this.StylusPlugIns.Count > 0)
            {
                StylusPlugIn firstPlugin = this.StylusPlugIns[0];
            }
            //</Snippet7>

        }

        //<Snippet4>
        public void MoveDownPlugIn(StylusPlugIn pluginToMoveDown)
        {
            int index = this.StylusPlugIns.IndexOf(pluginToMoveDown);

            // If the plug-in isn't already the last one in the
            // StylusPluginCollection, move it down one position.
            if (index < StylusPlugIns.Count - 1)
            {
                StylusPlugIns.RemoveAt(index);
                StylusPlugIns.Insert(index + 1, pluginToMoveDown);
            }
        }
        //</Snippet4>


        //public override bool EnsureVisuals()
        //{
        //    bool baseReturn = base.EnsureVisuals();

        //    VisualCollection childVisuals = VisualOperations.GetChildren(this);

        //    if (!childVisuals.Contains(dynamicRenderer1.RootVisual))
        //        childVisuals.Add(dynamicRenderer1.RootVisual);

        //    return baseReturn;
        //}

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (e.StylusDevice != null)
            {
                return;
            }

            Point pt = e.GetPosition(this);

            StylusPointCollection collectedPoints = new StylusPointCollection(new Point[] { pt });

            stylusPoints = new StylusPointCollection();

            stylusPoints.Add(collectedPoints);
        }

        protected override void OnStylusDown(StylusDownEventArgs e)
        {

            Stylus.Capture(this);

             //Get the StylusPoints that have come in so far
            StylusPointCollection newStylusPoints = e.GetStylusPoints(this);

            // Allocate memory for the StylusPointsCollection and
            // add the StylusPoints that have come in so far
            //stylusPoints = new StylusPointCollection(newStylusPoints.Description);
            //stylusPoints.Add(newStylusPoints);

             //Create a new StylusPointCollection using the StylusPointDescription
             //from the stylus points in the StylusDownEventArgs.
            stylusPoints = new StylusPointCollection();
            StylusPointCollection eventPoints = e.GetStylusPoints(this, stylusPoints.Description);

            stylusPoints.Add(eventPoints);


        }

        protected override void OnStylusMove(StylusEventArgs e)
        {
            // Allocate memory for the StylusPointsCollection, if necessary
            if (stylusPoints == null)
            {
                stylusPoints = new StylusPointCollection();
            }

            // Add the StylusPoints that have come in since the last call to OnStylusMove
            StylusPointCollection newStylusPoints = e.GetStylusPoints(this, stylusPoints.Description);
            stylusPoints.Add(newStylusPoints);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.StylusDevice != null)
            {
                return;
            }

            if (e.LeftButton == MouseButtonState.Released)
            {
                return;
            }

            if (stylusPoints == null)
            {
                stylusPoints = new StylusPointCollection();
            }

            Point pt = e.GetPosition(this);

            StylusPointCollection collectedPoints = new StylusPointCollection(new Point[] { pt });

            stylusPoints.Add(collectedPoints);
        }

        protected override void OnStylusUp(StylusEventArgs e)
        {
            // Allocate memory for the StylusPointsCollection, if necessary
            if (stylusPoints == null)
            {
                stylusPoints = new StylusPointCollection();
            }

            // Add the StylusPoints that have come in since the last call to OnStylusMove
            StylusPointCollection newStylusPoints = e.GetStylusPoints(this, stylusPoints.Description);
            stylusPoints.Add(newStylusPoints);

            // Create a new custom stroke from all the StylusPoints since OnStylusDown
            //Stroke3D stroke = new Stroke3D(stylusPoints);

            Stroke stroke = new Stroke(stylusPoints, currentAttributes.Clone());

            // Add the new stroke to the Strokes collection of the InkPresenter
            inkPresenter1.Strokes.Add(stroke);

            // Clear out the StylusPointsCollection
            stylusPoints = null;

            // Release stylus capture
            Stylus.Capture(null);
        }

        //protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonUp(e);

        //    if (stylusPoints == null)
        //    {
        //        return;
        //    }

 
        //    Stroke stroke = new Stroke(stylusPoints, currentAttributes.Clone());

        //    // Add the new stroke to the Strokes collection of the InkPresenter
        //    inkPresenter1.Strokes.Add(stroke);

        //    // Clear out the StylusPointsCollection
        //    stylusPoints = null;
        //}

        //<Snippet13>
        bool selectionMode = false;
        
        public void ToggleSelect()
        {
            StylusDevice currentStylus = Stylus.CurrentStylusDevice;

            // Check if the stylus is down or the mouse is pressed.
            if (Mouse.LeftButton != MouseButtonState.Pressed &&
                (currentStylus == null || currentStylus.InAir))
            {
                return;
            }
            
            selectionMode = !selectionMode;

            // If the control is in selection mode, change the color of 
            // the current stroke dark gray.
            if (selectionMode)
            {
                dynamicRenderer1.DrawingAttributes.Color = Colors.DarkGray;
               
            }
            else
            {
                dynamicRenderer1.DrawingAttributes.Color = Colors.Purple;
                
            }

            dynamicRenderer1.Reset(currentStylus, stylusPoints);
        }
        //</Snippet13>

        public void ClearInk()
        {
            inkPresenter1.Strokes.Clear();
        }
    }
}
