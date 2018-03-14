using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Threading;

namespace AdvancedInkInputSemples
{
    //<Snippet19>
    delegate void WorkerMethod();

    class CustomDynamicRenderer : DynamicRenderer
    {
        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            base.OnStylusDown(rawStylusInput);
            rawStylusInput.NotifyWhenProcessed(null);

        }

        protected override void OnStylusDownProcessed(object callbackData, bool targetVerified)
        {
            base.OnStylusDownProcessed(callbackData, targetVerified);

            Dispatcher renderingThreadDispatcher = this.GetDispatcher();
            renderingThreadDispatcher.BeginInvoke(DispatcherPriority.Normal, new WorkerMethod(DoSomething));
        }

        private void DoSomething()
        {
            // Perform work on the rendering thread.
        }
    }
    //</Snippet19>

    class CustomDynamicRenderer2 : DynamicRenderer
    {
        [ThreadStatic]
        static private Brush brush = null;

        [ThreadStatic]
        static private Pen pen = null;

        private Point prevPoint;

        public CustomDynamicRenderer2()
            : base()
        {
        }

     
        //<Snippet18>
        protected override void OnIsActiveForInputChanged()
        {
            base.OnIsActiveForInputChanged();

            if (!this.IsActiveForInput)
            {
                // Clean up any resources the plug-in uses.
            }
            else
            {
                // Allocate the resources the plug-in uses.
            }
        }
        //</Snippet18>

        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            base.OnStylusUp(rawStylusInput);

            rawStylusInput.NotifyWhenProcessed(null);
        }

        protected override void OnStylusUpProcessed(object callbackData, bool targetVerified)
        {
            base.OnStylusUpProcessed(callbackData, targetVerified);
            //NotifyOnNextRenderComplete();
        }
        //<Snippet22>
        protected override void OnAdded()
        {
            base.OnAdded();
             
            MessageBox.Show(this.Element.ToString());
        }
        //</Snippet22>

        protected override void OnRemoved()
        {
            base.OnRemoved();
            MessageBox.Show(this.Element.ToString());
        }

        // <Snippet16>
        protected override void OnEnabledChanged()
        {
            base.OnEnabledChanged();

            if (this.Enabled)
            {
                MessageBox.Show("The StylusPlugin is enabled.");
            }
            else
            {
                MessageBox.Show("The StylusPlugin is not enabled.");
            }
        }
        // </Snippet16>

        //<Snippet21>
        protected override void OnDrawingAttributesReplaced()
        {
            base.OnDrawingAttributesReplaced();

            MessageBox.Show(this.DrawingAttributes.Color.ToString());
        }
        //</Snippet21>

        //<Snippet11>
        protected override void OnDraw(DrawingContext drawingContext,
                                       StylusPointCollection stylusPoints,
                                       Geometry geometry, Brush fillBrush)
        {
            // Create a new Brush, if necessary
            if (brush == null)
            {
                Color primaryColor;

                if (fillBrush is SolidColorBrush)
                {
                    primaryColor = ((SolidColorBrush)fillBrush).Color;
                }
                else
                {
                    primaryColor = Colors.Red;
                }

                brush = new LinearGradientBrush(Colors.Blue, primaryColor, 20d);
            }

            drawingContext.DrawGeometry(brush, null, geometry);

        }
        //</Snippet11>

    }
}
