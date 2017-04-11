using System;
using System.Collections;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace AdvancedInkInputSemples
{
    class CustomDynamicRenderer : DynamicRenderer
    {
        [ThreadStatic]
        static private Brush brush = null;

        [ThreadStatic]
        static private Pen pen = null;

        private Point prevPoint;

        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            prevPoint = new Point(double.NegativeInfinity, double.NegativeInfinity);
            base.OnStylusDown(rawStylusInput);
        }

        protected override void OnDraw(DrawingContext drawingContext, StylusPointCollection stylusPoints, Geometry geometry, Brush fillBrush)
        {
            if (brush == null)
            {
                brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 20d);
            }
            if (pen == null)
            {
                pen = new Pen(brush, 2d);
            }
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                Point pt = (Point)stylusPoints[i];
                Vector v = Point.Subtract(prevPoint, pt);
                if (v.Length > 4)
                {
                    double radius = stylusPoints[i].PressureFactor * 10d;
                    drawingContext.DrawEllipse(brush, pen, pt, radius, radius);
                    prevPoint = pt;
                }
            }
        }
    }

    class FilterPlugin : StylusPlugIn
    {
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            base.OnStylusDown(rawStylusInput);
            Filter(rawStylusInput);
        }
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            base.OnStylusMove(rawStylusInput);
            Filter(rawStylusInput);
        }
        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            base.OnStylusUp(rawStylusInput);
            Filter(rawStylusInput);
        }
        private void Filter(RawStylusInput rawStylusInput)
        {
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 100) sp.X = 100;
                if (sp.X > 400) sp.X = 400;
                if (sp.Y < 100) sp.Y = 100;
                if (sp.Y > 400) sp.Y = 400;
                stylusPoints[i] = sp;
            }
            rawStylusInput.SetStylusPoints(stylusPoints);
        }
    }

    class TransformPlugin : StylusPlugIn
    {
        private Matrix _matrix;
        public TransformPlugin(Matrix matrix)
        {
            _matrix = matrix;
        }
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            base.OnStylusDown(rawStylusInput);
            Transform(rawStylusInput);
        }
        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            base.OnStylusMove(rawStylusInput);
            Transform(rawStylusInput);
        }
        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            base.OnStylusUp(rawStylusInput);
            Transform(rawStylusInput);
        }
        private void Transform(RawStylusInput rawStylusInput)
        {
            StylusPointCollection stylusPoints = rawStylusInput.GetStylusPoints();
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                Point pt = (Point)sp;
                pt *= _matrix;
                sp.X = pt.X;
                sp.Y = pt.Y;
                stylusPoints[i] = sp;
            }
            rawStylusInput.SetStylusPoints(stylusPoints);
        }
    }

    public struct PluginDescription
    {
        public StylusPlugIn Plugin;
        public string Name;
        public override string ToString()
        {
            return Name;
        }
    }

    class Stroke3D : Stroke
    {
        Brush brush;
        Pen pen;
        Guid guidUsingStandardRenderer = new Guid("772c1f44-34db-45a3-97db-5325d5e53a52");
        Guid guidUsingCustomRenderer = new Guid("44df9701-c3f8-48fd-86cc-e8c9c5341826");

        public Stroke3D(StylusPointCollection stylusPoints)
            : base(stylusPoints)
        {
            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 20d);
            pen = new Pen(brush, 2d);
        }

        protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
        {
            if (this.ContainsPropertyData(guidUsingCustomRenderer))
            {
                Point prevPoint = new Point(double.NegativeInfinity, double.NegativeInfinity);
                for (int i = 0; i < this.StylusPoints.Count; i++)
                {
                    Point pt = (Point)this.StylusPoints[i];
                    Vector v = Point.Subtract(prevPoint, pt);
                    if (v.Length > 4)
                    {
                        double radius = this.StylusPoints[i].PressureFactor * 10d;
                        drawingContext.DrawEllipse(brush, pen, pt, radius, radius);
                        prevPoint = pt;
                    }
                }
            }
            if (this.ContainsPropertyData(guidUsingStandardRenderer))
            {
                base.DrawCore(drawingContext, drawingAttributes);
            }
        }
    }

    public class StefansStylusControl : Label
    {
        InkPresenter ip;
        PluginDescription dynamicRenderer;
        PluginDescription translatePlugin;
        PluginDescription customrenderer;
        PluginDescription filterPlugin;
        StylusPointCollection stylusPoints = null;
        ArrayList inPlugins;
        ArrayList outPlugins;
        Guid guidUsingStandardRenderer = new Guid("772c1f44-34db-45a3-97db-5325d5e53a52");
        Guid guidUsingCustomRenderer = new Guid("44df9701-c3f8-48fd-86cc-e8c9c5341826");


        static StefansStylusControl()
        {
            Type ownerType = typeof(StefansStylusControl);
            ClipToBoundsProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata(true));
            FocusVisualStyleProperty.OverrideMetadata(ownerType, new FrameworkPropertyMetadata((object)null));
        }

        public StefansStylusControl()
        {
            Stylus.Enable();
            ip = new InkPresenter();
            this.Content = ip; //for label
            //this.Child = ip;  //for border
            inPlugins = new ArrayList();
            outPlugins = new ArrayList();

            Matrix translateMatrix = new Matrix();
            translateMatrix.Translate(20d, 50d);
            translatePlugin.Plugin = new TransformPlugin(translateMatrix);
            translatePlugin.Name = "Translate Plugin";
            outPlugins.Add(translatePlugin);

            filterPlugin.Plugin = new FilterPlugin();
            filterPlugin.Name = "Filter Plugin";
            outPlugins.Add(filterPlugin);

            CustomDynamicRenderer cr = new CustomDynamicRenderer();
            customrenderer.Plugin = cr;
            customrenderer.Name = "Custom Renderer";
            outPlugins.Add(customrenderer);
            ip.AttachVisuals(cr.RootVisual, cr.DrawingAttributes);
            //this.StylusPlugIns.Add(cr);

            DynamicRenderer dr = new DynamicRenderer();
            dynamicRenderer.Plugin = dr;
            dynamicRenderer.Name = "Standard Renderer";
            inPlugins.Add(dynamicRenderer);
            ip.AttachVisuals(dr.RootVisual, dr.DrawingAttributes);
            this.StylusPlugIns.Add(dr);
        }

        public StrokeCollection Strokes
        {
            get { return ip.Strokes; }
        }

        public void Add(PluginDescription pluginToAdd)
        {
            StylusPlugIns.Add(pluginToAdd.Plugin);
            inPlugins.Add(pluginToAdd);
            outPlugins.Remove(pluginToAdd);
        }

        public void Remove(PluginDescription pluginToRemove)
        {
            StylusPlugIns.Remove(pluginToRemove.Plugin);
            inPlugins.Remove(pluginToRemove);
            outPlugins.Add(pluginToRemove);
        }

        public void MoveUp(PluginDescription pluginToMoveUp)
        {
            int index = inPlugins.IndexOf(pluginToMoveUp);
            if (index > 0)
            {
                StylusPlugIns.Remove(pluginToMoveUp.Plugin);
                StylusPlugIns.Insert(index - 1, pluginToMoveUp.Plugin);
                inPlugins.Remove(pluginToMoveUp);
                inPlugins.Insert(index - 1, pluginToMoveUp);
            }
        }

        public void MoveDown(PluginDescription pluginToMoveDown)
        {
            int index = inPlugins.IndexOf(pluginToMoveDown);
            if (index < StylusPlugIns.Count - 1)
            {
                StylusPlugIns.Remove(pluginToMoveDown.Plugin);
                StylusPlugIns.Insert(index + 1, pluginToMoveDown.Plugin);
                inPlugins.Remove(pluginToMoveDown);
                inPlugins.Insert(index + 1, pluginToMoveDown);
            }
        }

        public ArrayList InPlugins
        {
            get { return inPlugins; }
        }

        public ArrayList OutPlugins
        {
            get { return outPlugins; }
        }

        protected override void OnStylusDown(StylusDownEventArgs e)
        {
            Stylus.Capture(this);
            StylusPointCollection newStylusPoints = e.GetStylusPoints(this);
            stylusPoints = new StylusPointCollection(newStylusPoints.Description);
            stylusPoints.Add(newStylusPoints);
        }

        protected override void OnStylusMove(StylusEventArgs e)
        {
            if (stylusPoints == null) stylusPoints = new StylusPointCollection();
            StylusPointCollection newStylusPoints = e.GetStylusPoints(this, stylusPoints.Description);
            stylusPoints.Add(newStylusPoints);
        }

        protected override void OnStylusUp(StylusEventArgs e)
        {
            if (stylusPoints == null) stylusPoints = new StylusPointCollection();
            StylusPointCollection newStylusPoints = e.GetStylusPoints(this, stylusPoints.Description);
            stylusPoints.Add(newStylusPoints);

            Stroke3D stroke = new Stroke3D(stylusPoints);
            if (inPlugins.Contains(customrenderer))
                stroke.AddPropertyData(guidUsingCustomRenderer, 1);
            if (inPlugins.Contains(dynamicRenderer))
                stroke.AddPropertyData(guidUsingStandardRenderer, 1);
            ip.Strokes.Add(stroke);

            stylusPoints = null;
            Stylus.Capture(null);
        }
    }
}