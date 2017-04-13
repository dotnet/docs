// <snippet10>
// <snippet20>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
// </snippet20>

namespace MarqueeControlLibrary
{
    // <snippet97>
    // This defines the possible values for the MarqueeBorder
    // control's SpinDirection property.
    public enum MarqueeSpinDirection
    {
        CW,
        CCW
    }

    // <snippet98>
    // This defines the possible values for the MarqueeBorder
    // control's LightShape property.
    public enum MarqueeLightShape
    {
        Square,
        Circle
    }
    // </snippet98>
    // </snippet97>

    // <snippet30>
    [Designer(typeof(MarqueeControlLibrary.Design.MarqueeBorderDesigner ))]
    [ToolboxItemFilter("MarqueeControlLibrary.MarqueeBorder", ToolboxItemFilterType.Require)]
    public partial class MarqueeBorder : Panel, IMarqueeWidget
    {
        // </snippet30>

        // <snippet40>
        public static int MaxLightSize = 10;

        // These fields back the public properties.
        private int updatePeriodValue = 50;
        private int lightSizeValue = 5;
        private int lightPeriodValue = 3;
        private int lightSpacingValue = 1;
        private Color lightColorValue;
        private Color darkColorValue;
        private MarqueeSpinDirection spinDirectionValue = MarqueeSpinDirection.CW;
        private MarqueeLightShape lightShapeValue = MarqueeLightShape.Square;

        // These brushes are used to paint the light and dark
        // colors of the marquee lights.
        private Brush lightBrush;
        private Brush darkBrush;

        // This field tracks the progress of the "first" light as it
        // "travels" around the marquee border.
        private int currentOffset = 0;

        // This component updates the control asynchronously.
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        public MarqueeBorder()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // Initialize light and dark colors 
            // to the control's default values.
            this.lightColorValue = this.ForeColor;
            this.darkColorValue = this.BackColor;
            this.lightBrush = new SolidBrush(this.lightColorValue);
            this.darkBrush = new SolidBrush(this.darkColorValue);

            // The MarqueeBorder control manages its own padding,
            // because it requires that any contained controls do
            // not overlap any of the marquee lights.
            int pad = 2 * (this.lightSizeValue + this.lightSpacingValue);
            this.Padding = new Padding(pad, pad, pad, pad);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        // </snippet40>

        ///////////////////////////////////////////////////////////////////////
        #region IMarqueeWidget implementation

        // <snippet50>
        public virtual void StartMarquee()
        {
            // The MarqueeBorder control may contain any number of 
            // controls that implement IMarqueeWidget, so find
            // each IMarqueeWidget child and call its StartMarquee
            // method.
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl is IMarqueeWidget)
                {
                    IMarqueeWidget widget = cntrl as IMarqueeWidget;
                    widget.StartMarquee();
                }
            }

            // Start the updating thread and pass it the UpdatePeriod.
            this.backgroundWorker1.RunWorkerAsync(this.UpdatePeriod);
        }

        public virtual void StopMarquee()
        {
            // The MarqueeBorder control may contain any number of 
            // controls that implement IMarqueeWidget, so find
            // each IMarqueeWidget child and call its StopMarquee
            // method.
            foreach (Control cntrl in this.Controls)
            {
                if (cntrl is IMarqueeWidget)
                {
                    IMarqueeWidget widget = cntrl as IMarqueeWidget;
                    widget.StopMarquee();
                }
            }

            // Stop the updating thread.
            this.backgroundWorker1.CancelAsync();
        }

        [Category("Marquee")]
        [Browsable(true)]
        public virtual int UpdatePeriod
        {
            get
            {
                return this.updatePeriodValue;
            }

            set
            {
                if (value > 0)
                {
                    this.updatePeriodValue = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("UpdatePeriod", "must be > 0");
                }
            }
        }

        // </snippet50>

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Public Properties

        // <snippet60>
        [Category("Marquee")]
        [Browsable(true)]
        public int LightSize
        {
            get
            {
                return this.lightSizeValue;
            }

            set
            {
                if (value > 0 && value <= MaxLightSize)
                {
                    this.lightSizeValue = value;
                    this.DockPadding.All = 2 * value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("LightSize", "must be > 0 and < MaxLightSize");
                }
            }
        }

        [Category("Marquee")]
        [Browsable(true)]
        public int LightPeriod
        {
            get
            {
                return this.lightPeriodValue;
            }

            set
            {
                if (value > 0)
                {
                    this.lightPeriodValue = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("LightPeriod", "must be > 0 ");
                }
            }
        }

        [Category("Marquee")]
        [Browsable(true)]
        public Color LightColor
        {
            get
            {
                return this.lightColorValue;
            }

            set
            {
                // The LightColor property is only changed if the 
                // client provides a different value. Comparing values 
                // from the ToArgb method is the recommended test for
                // equality between Color structs.
                if (this.lightColorValue.ToArgb() != value.ToArgb())
                {
                    this.lightColorValue = value;
                    this.lightBrush = new SolidBrush(value);
                }
            }
        }

        [Category("Marquee")]
        [Browsable(true)]
        public Color DarkColor
        {
            get
            {
                return this.darkColorValue;
            }

            set
            {
                // The DarkColor property is only changed if the 
                // client provides a different value. Comparing values 
                // from the ToArgb method is the recommended test for
                // equality between Color structs.
                if (this.darkColorValue.ToArgb() != value.ToArgb())
                {
                    this.darkColorValue = value;
                    this.darkBrush = new SolidBrush(value);
                }
            }
        }

        [Category("Marquee")]
        [Browsable(true)]
        public int LightSpacing
        {
            get
            {
                return this.lightSpacingValue;
            }

            set
            {
                if (value >= 0)
                {
                    this.lightSpacingValue = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("LightSpacing", "must be >= 0");
                }
            }
        }

        [Category("Marquee")]
        [Browsable(true)]
        [EditorAttribute(typeof(LightShapeEditor), 
             typeof(System.Drawing.Design.UITypeEditor))]
        public MarqueeLightShape LightShape
        {
            get
            {
                return this.lightShapeValue;
            }

            set
            {
                this.lightShapeValue = value;
            }
        }

        [Category("Marquee")]
        [Browsable(true)]
        public MarqueeSpinDirection SpinDirection
        {
            get
            {
                return this.spinDirectionValue;
            }

            set
            {
                this.spinDirectionValue = value;
            }
        }

        // </snippet60>

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Implementation

        // <snippet70>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            // Repaint when the layout has changed.
            this.Refresh();
        }

        // This method paints the lights around the border of the 
        // control. It paints the top row first, followed by the
        // right side, the bottom row, and the left side. The color
        // of each light is determined by the IsLit method and
        // depends on the light's position relative to the value
        // of currentOffset.
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(this.BackColor);

            base.OnPaint(e);

            // If the control is large enough, draw some lights.
            if (this.Width > MaxLightSize &&
                this.Height > MaxLightSize)
            {
                // The position of the next light will be incremented 
                // by this value, which is equal to the sum of the
                // light size and the space between two lights.
                int increment =
                    this.lightSizeValue + this.lightSpacingValue;

                // Compute the number of lights to be drawn along the
                // horizontal edges of the control.
                int horizontalLights =
                    (this.Width - increment) / increment;

                // Compute the number of lights to be drawn along the
                // vertical edges of the control.
                int verticalLights =
                    (this.Height - increment) / increment;

                // These local variables will be used to position and
                // paint each light.
                int xPos = 0;
                int yPos = 0;
                int lightCounter = 0;
                Brush brush;

                // Draw the top row of lights.
                for (int i = 0; i < horizontalLights; i++)
                {
                    brush = IsLit(lightCounter) ? this.lightBrush : this.darkBrush;

                    DrawLight(g, brush, xPos, yPos);

                    xPos += increment;
                    lightCounter++;
                }

                // Draw the lights flush with the right edge of the control.
                xPos = this.Width - this.lightSizeValue;

                // Draw the right column of lights.
                for (int i = 0; i < verticalLights; i++)
                {
                    brush = IsLit(lightCounter) ? this.lightBrush : this.darkBrush;

                    DrawLight(g, brush, xPos, yPos);

                    yPos += increment;
                    lightCounter++;
                }

                // Draw the lights flush with the bottom edge of the control.
                yPos = this.Height - this.lightSizeValue;

                // Draw the bottom row of lights.
                for (int i = 0; i < horizontalLights; i++)
                {
                    brush = IsLit(lightCounter) ? this.lightBrush : this.darkBrush;

                    DrawLight(g, brush, xPos, yPos);

                    xPos -= increment;
                    lightCounter++;
                }

                // Draw the lights flush with the left edge of the control.
                xPos = 0;

                // Draw the left column of lights.
                for (int i = 0; i < verticalLights; i++)
                {
                    brush = IsLit(lightCounter) ? this.lightBrush : this.darkBrush;

                    DrawLight(g, brush, xPos, yPos);

                    yPos -= increment;
                    lightCounter++;
                }
            }
        }
        // </snippet70>

        // <snippet80>
        // This method determines if the marquee light at lightIndex
        // should be lit. The currentOffset field specifies where
        // the "first" light is located, and the "position" of the
        // light given by lightIndex is computed relative to this 
        // offset. If this position modulo lightPeriodValue is zero,
        // the light is considered to be on, and it will be painted
        // with the control's lightBrush. 
        protected virtual bool IsLit(int lightIndex)
        {
            int directionFactor =
                (this.spinDirectionValue == MarqueeSpinDirection.CW ? -1 : 1);

            return (
                (lightIndex + directionFactor * this.currentOffset) % this.lightPeriodValue == 0
                );
        }

        protected virtual void DrawLight(
            Graphics g,
            Brush brush,
            int xPos,
            int yPos)
        {
            switch (this.lightShapeValue)
            {
                case MarqueeLightShape.Square:
                    {
                        g.FillRectangle(brush, xPos, yPos, this.lightSizeValue, this.lightSizeValue);
                        break;
                    }
                case MarqueeLightShape.Circle:
                    {
                        g.FillEllipse(brush, xPos, yPos, this.lightSizeValue, this.lightSizeValue);
                        break;
                    }
                default:
                    {
                        Trace.Assert(false, "Unknown value for light shape.");
                        break;
                    }
            }
        }
        // </snippet80>

        // <snippet90>
        // This method is called in the worker thread's context, 
        // so it must not make any calls into the MarqueeBorder
        // control. Instead, it communicates to the control using 
        // the ProgressChanged event.
        //
        // The only work done in this event handler is
        // to sleep for the number of milliseconds specified 
        // by UpdatePeriod, then raise the ProgressChanged event.
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // This event handler will run until the client cancels
            // the background task by calling CancelAsync.
            while (!worker.CancellationPending)
            {
                // The Argument property of the DoWorkEventArgs
                // object holds the value of UpdatePeriod, which 
                // was passed as the argument to the RunWorkerAsync
                // method. 
                Thread.Sleep((int)e.Argument);

                // The DoWork eventhandler does not actually report
                // progress; the ReportProgress event is used to 
                // periodically alert the control to update its state.
                worker.ReportProgress(0);
            }
        }

        // The ProgressChanged event is raised by the DoWork method.
        // This event handler does work that is internal to the
        // control. In this case, the currentOffset is incremented,
        // and the control is told to repaint itself.
        private void backgroundWorker1_ProgressChanged(
            object sender,
            System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.currentOffset++;
            this.Refresh();
        }
        // </snippet90>

        // <snippet91>
        // <snippet96>
        // This class demonstrates the use of a custom UITypeEditor. 
        // It allows the MarqueeBorder control's LightShape property
        // to be changed at design time using a customized UI element
        // that is invoked by the Properties window. The UI is provided
        // by the LightShapeSelectionControl class.
        internal class LightShapeEditor : UITypeEditor
        {
            // </snippet96>

            // <snippet92>
            private IWindowsFormsEditorService editorService = null;
            // </snippet92>

            // <snippet93>
            public override UITypeEditorEditStyle GetEditStyle(
            System.ComponentModel.ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            // </snippet93>

            // <snippet94>
            public override object EditValue(
                ITypeDescriptorContext context,
                IServiceProvider provider,
                object value)
            {
                if (provider != null)
                {
                    editorService =
                        provider.GetService(
                        typeof(IWindowsFormsEditorService))
                        as IWindowsFormsEditorService;
                }

                if (editorService != null)
                {
                    LightShapeSelectionControl selectionControl =
                        new LightShapeSelectionControl(
                        (MarqueeLightShape)value,
                        editorService);

                    editorService.DropDownControl(selectionControl);

                    value = selectionControl.LightShape;
                }

                return value;
            }
            // </snippet94>

            // <snippet99>
            // This method indicates to the design environment that
            // the type editor will paint additional content in the
            // LightShape entry in the PropertyGrid.
            public override bool GetPaintValueSupported(
                ITypeDescriptorContext context)
            {  
                return true;
            }

            // This method paints a graphical representation of the 
            // selected value of the LightShpae property.
            public override void PaintValue(PaintValueEventArgs e)
            {   
                MarqueeLightShape shape = (MarqueeLightShape)e.Value;
                using (Pen p = Pens.Black)
                {
                    if (shape == MarqueeLightShape.Square)
                    {
                        e.Graphics.DrawRectangle(p, e.Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(p, e.Bounds);
                    }
                }   
            }
            // </snippet99>
        }
        // </snippet91>

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

// 
// backgroundWorker1
// 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        }

        #endregion
    }
}
// </snippet10>