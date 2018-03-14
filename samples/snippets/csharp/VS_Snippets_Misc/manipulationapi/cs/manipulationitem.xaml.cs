//---------------------------------------------------------------------
// <copyright file="ManipulableItem.xaml.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Input.Manipulations;
using System.Windows.Media;
using System.Windows.Threading;
using System.Diagnostics;

namespace ManipulationAPI
{
    /// <summary>
    /// A simple item that can be translated, rotated, and scaled by dragging
    /// with the mouse. It has checkboxes to allow enabling/disabling the
    /// various types of motions, and a pivot indicator (which can be toggled
    /// on and off by clicking it).
    /// </summary>
    public partial class ManipulationItem : UserControl
    {
        #region Private Members
        private const float minLinearFlickVelocity = 0.01F;
        private const float minScaleRotateRadius = 15F;

        private readonly ManipulationProcessor2D manipulationProcessor;
        private readonly InertiaProcessor2D inertiaProcessor;
        private readonly ManipulationPivot2D pivot;
        private readonly DispatcherTimer inertiaTimer;
        private Point dragCenter = new Point(double.NaN, double.NaN);
        
        // This is used only to demo the ManipulationProcessor2D snippet
        // This (and the snippet) isn't actually used in this app.
        private Point elementPosition = new Point(0, 0);
        #endregion

        /******************************************************************************/
  
        #region Constructor
        public ManipulationItem()
        {
            InitializeComponent();

            PivotButton.Click += OnPivotClick;

            // The DeadZone is a little red ring that shows the area inside which
            // no rotation or scaling will happen if you drag the mouse. We set
            // it to four times the size of the manipulation processor's MininumScaleRotateRadius.
            // Reason for the number:
            // - x2, because diameter = 2 * radius
            // - x2, because the number on the manipulation processor is radius from
            //   the center of mass of the manipulators being used, which in the case
            //   of this test app will be the midpoint between the mouse and the hub.
            //DeadZone.Width = 4 * minScaleRotateRadius;
            //DeadZone.Height = 4 * minScaleRotateRadius;

            manipulationProcessor = new ManipulationProcessor2D(Manipulations2D.None);
            manipulationProcessor.MinimumScaleRotateRadius = minScaleRotateRadius;
            manipulationProcessor.Started += OnManipulationStarted;

            manipulationProcessor.Started += OnManipulationStarted2;


            manipulationProcessor.Delta += OnManipulationDelta;
            manipulationProcessor.Completed += OnManipulationCompleted;

            inertiaProcessor = new InertiaProcessor2D();
            inertiaProcessor.TranslationBehavior.DesiredDeceleration = 0.0001F;
            inertiaProcessor.RotationBehavior.DesiredDeceleration = 1e-6F;
            inertiaProcessor.ExpansionBehavior.DesiredDeceleration = 0.0001F;
            inertiaProcessor.Delta += OnManipulationDelta;
            inertiaProcessor.Completed += OnInertiaCompleted;
                        
            inertiaTimer = new DispatcherTimer(
                DispatcherPriority.Input,
                Dispatcher.CurrentDispatcher);
            inertiaTimer.IsEnabled = false;
            inertiaTimer.Interval = TimeSpan.FromMilliseconds(25);
            inertiaTimer.Tick += OnTimerTick;

            pivot = new ManipulationPivot2D();

            RenderTransformOrigin = new Point(0.5, 0.5);

            Radius = 75;
            Center = new Point(0, 0);
            IsPivotActive = true;
            Move(Radius, Radius, 0, 1);
        }
        #endregion

        /******************************************************************************/

        #region Public Properties

        /// <summary>
        /// Gets or sets the container used for manipulations.
        /// </summary>
        public UIElement Container
        {
            get; 
            set;
        }

        public Manipulations2D SupportedManipulations
        {
            get
            {
                return manipulationProcessor.SupportedManipulations;
            }
            set
            {
                manipulationProcessor.SupportedManipulations = value;
            }
        }

        #endregion

        /******************************************************************************/

        #region Private Properties
        /// <summary>
        /// Gets the center of the item, in container coordinates.
        /// </summary>
        private Point Center
        {
            get { return new Point(pivot.X, pivot.Y); }
            set
            {
                pivot.X = (float)value.X;
                pivot.Y = (float)value.Y;
                LabelCenter.Content = String.Format("{0} x {1}", (int)value.X, (int)value.Y);
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the object, in degrees.
        /// </summary>
        private double Orientation { get; set; }

        /// <summary>
        /// Gets or sets the radius of the object, in pixels.
        /// </summary>
        private double Radius
        {
            get { return pivot.Radius; }
            set
            {
                pivot.Radius = (float)value;
                Width = 2 * value;
                Height = 2 * value;
            }
        }

        /// <summary>
        /// Gets or sets whether the pivot is active.
        /// </summary>
        private bool IsPivotActive
        {
            get { return manipulationProcessor.Pivot != null; }
            set
            {
                manipulationProcessor.Pivot = value ? pivot : null;
                PivotButton.Opacity = value ? 1.0 : 0.3;
            }
        }
        #endregion

        /******************************************************************************/

        #region Protected Methods
        /// <summary>
        /// Here when the mouse goes down on the item.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            e.MouseDevice.Capture(this);
        }

        /// <summary>
        /// Here when the mouse goes up.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.MouseDevice.Captured == this)
            {
                e.MouseDevice.Capture(null);
            }
        }

        /// <summary>
        /// Here when we've captured the mouse.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotMouseCapture(MouseEventArgs e)
        {
            base.OnGotMouseCapture(e);
            ProcessMouse(e.MouseDevice);
        }


        /// <summary>
        /// Here when the mouse moves.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ProcessMouse(e.MouseDevice);
        }
        #endregion

        /******************************************************************************/

        #region Private Methods
        /// <summary>
        /// Process a mouse event.
        /// </summary>
        /// <param name="mouse"></param>
        private void ProcessMouse(MouseDevice mouse)
        {

            if ((mouse.Captured == this))
            {
                Point position = mouse.GetPosition(Container);
                
                List<Manipulator2D> manipulators = new List<Manipulator2D>();
                manipulators.Add(new Manipulator2D(
                    0,
                    (float)(position.X),
                    (float)(position.Y)));

                // If translation is turned off and the pivot is turned on,
                // make it act like there's a manipulator on the pivot point,
                // to allow us to do scaling
                if (((SupportedManipulations & Manipulations2D.Translate) == Manipulations2D.None)
                    && IsPivotActive)
                {
                    manipulators.Add(new Manipulator2D(
                        1,
                        (float)(Center.X),
                        (float)(Center.Y)));
                }

                const Manipulations2D translateAndRotate = Manipulations2D.Translate | Manipulations2D.Rotate;
                if ((manipulators.Count == 1)
                    && ((manipulationProcessor.SupportedManipulations & translateAndRotate) == translateAndRotate)
                    && IsPivotActive)
                {
                    dragCenter = position;
                }
                else
                {
                    dragCenter.X = double.NaN;
                    dragCenter.Y = double.NaN;
                }

                manipulationProcessor.ProcessManipulators(
                    Timestamp,
                    manipulators);
            }
        }


        /// <summary>
        /// Here when the state of a checkbox changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCheckedChanged(object sender, RoutedEventArgs e)
        {
            //manipulationProcessor.SupportedManipulations = SupportedManipulations;
            //if (inertiaProcessor.IsRunning)
            //{
            //    inertiaProcessor.Complete(Timestamp);
            //}
        }

        /// <summary>
        /// Here when the pivot button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPivotClick(object sender, RoutedEventArgs e)
        {
            IsPivotActive = !IsPivotActive;
        }


        /// <summary>
        /// Here when manipulation gives a delta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnManipulationDelta(object sender, Manipulation2DDeltaEventArgs e)
        {
            ScreenMessage(String.Format("Delta: Rotation: {0}", e.Delta.Rotation));
            Move(
                e.Delta.TranslationX,
                e.Delta.TranslationY,
                e.Delta.Rotation,
                e.Delta.ScaleX);
        }

        /// <summary>
        /// Here when manipulation completes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnManipulationCompleted(object sender, Manipulation2DCompletedEventArgs e)
        {
            ScreenMessage("Manipulation Completed");
            dragCenter = new Point(double.NaN, double.NaN);

            float velocityX = e.Velocities.LinearVelocityX;
            float velocityY = e.Velocities.LinearVelocityY;
            float speedSquared = velocityX * velocityX + velocityY * velocityY;
            if (speedSquared < minLinearFlickVelocity * minLinearFlickVelocity)
            {
                velocityX = velocityY = 0;
            }

            inertiaProcessor.TranslationBehavior.InitialVelocityX = velocityX;
            inertiaProcessor.TranslationBehavior.InitialVelocityY = velocityY;
            inertiaProcessor.RotationBehavior.InitialVelocity = 0.1016f; // e.Velocities.AngularVelocity;

            inertiaProcessor.RotationBehavior.DesiredDeceleration = 0.0000065f;

            SetDesiredRotation(inertiaProcessor);

            inertiaProcessor.RotationBehavior.DesiredRotation = (float)Math.PI * 7.0f;

            inertiaProcessor.ExpansionBehavior.InitialVelocityX = 5.7f; // e.Velocities.ExpansionVelocityX;
            inertiaProcessor.ExpansionBehavior.InitialVelocityY = 5.7f; // e.Velocities.ExpansionVelocityY;
            inertiaProcessor.ExpansionBehavior.InitialRadius = 11.0f;

            //inertiaProcessor.ExpansionBehavior.InitialVelocityX = 0.05f;
            //inertiaProcessor.ExpansionBehavior.InitialVelocityY = 0.05f;
            //inertiaProcessor.RotationBehavior.DesiredRotation = 55.6f;

            //inertiaProcessor.InitialRadius = (float)Radius;
            inertiaTimer.Start();
        }

        /// <summary>
        /// Here when inertia completes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInertiaCompleted(object sender, Manipulation2DCompletedEventArgs e)
        {
            inertiaTimer.Stop();
        }

        /// <summary>
        /// Here when the inertia timer ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            inertiaProcessor.Process(Timestamp);
        }

        /// <summary>
        /// Move the item as specified.
        /// </summary>
        /// <param name="deltaX">Distance to translate along X axis.</param>
        /// <param name="deltaY">Distance to translate along Y axis.</param>
        /// <param name="rotation">Amount to rotate, in radians.</param>
        /// <param name="scale">Scale factor to apply.</param>
        private void Move(
            double deltaX,
            double deltaY,
            double rotation,
            double scale)
        {
            //AdjustForSingleManipulatorDragRotation(ref deltaX, ref deltaY, rotation);

            MatrixTransform transform = RenderTransform as MatrixTransform;
            if ((transform == null) || transform.IsFrozen)
            {
                transform = new MatrixTransform();
                RenderTransform = transform;
            }

            double newX = Center.X + deltaX;
            double newY = Center.Y + deltaY;
            if (Container != null)
            {
                newX = Math.Max(0, Math.Min(newX, Container.RenderSize.Width));
                newY = Math.Max(0, Math.Min(newY, Container.RenderSize.Height));
            }

            Center = new Point(newX, newY);
            Orientation += rotation * 180.0 / Math.PI;
            Radius = Math.Max(40, Math.Min(350, scale * Radius));

            Matrix matrix = Matrix.Identity;
            matrix.Rotate(Orientation);
            matrix.Translate(Center.X - Radius, Center.Y - Radius);
            matrix.Scale(1.0f, 1.0f);

            transform.Matrix = matrix;
        }

        /// <summary>
        /// If you're dragging with a single manipulator, *and* rotation and translation
        /// are both enabled, *and* the pivot is turned on, then we want the object to
        /// swing into line behind the drag point. This adjusts for that.
        /// </summary>
        /// <param name="deltaX">Distance to translate along X axis.</param>
        /// <param name="deltaY">Distance to translate along Y axis.</param>
        /// <param name="rotation">Amount to rotate, in radians.</param>
        private void AdjustForSingleManipulatorDragRotation(
            ref double deltaX,
            ref double deltaY,
            double rotation)
        {
            if (double.IsNaN(dragCenter.X) || double.IsNaN(dragCenter.Y))
            {
                // we're not in single-manipulator-drag-rotate mode, do nothing
                return;
            }

            Vector toCenter = Center - dragCenter;
            double sin = Math.Sin(rotation);
            double cos = Math.Cos(rotation);
            Vector rotatedToCenter = new Vector(
                toCenter.X * cos - toCenter.Y * sin,
                toCenter.X * sin + toCenter.Y * cos);
            Vector shift = rotatedToCenter - toCenter;
            deltaX += shift.X;
            deltaY += shift.Y;
        }

        /// <summary>
        /// Get the manipulations that a checkbox specifies.
        /// </summary>
        /// <param name="checkbox"></param>
        /// <returns></returns>
        //private static Manipulations2D GetManipulations(CheckBox checkbox)
        //{
        //    return (checkbox.IsChecked.Value) ? (Manipulations2D)checkbox.Tag : Manipulations2D.None;
        //}

        private void ScreenMessage(string msg)
        {
            Canvas canvas = Container as Canvas;
            if (canvas != null)
            {
                Grid grid = canvas.Parent as Grid;
                if (grid != null && grid.Children.Count > 0)
                {
                    Label label = grid.Children[0] as Label;
                    if (label != null)
                    {
                        label.Content = msg;
                    }
                }
            }
        }
        #endregion

        /******************************************************************************/

        #region Test
        private void OnManipulationStarted2(object sender, Manipulation2DStartedEventArgs e)
        {
            ScreenMessage(String.Format("Started: Origin: {0}x{1} {2}", e.OriginX, e.OriginY, Timestamp));
        }
         
        #endregion

        /******************************************************************************/

        #region Snippets - All snippets are in this region

        // <Snippet_ManipulationItem_Timestamp>
        #region Timestamp
        private long Timestamp
        {
            get
            {
                // Get timestamp in 100-nanosecond units.
                double nanosecondsPerTick = 1000000000.0 / System.Diagnostics.Stopwatch.Frequency;
                return (long)(System.Diagnostics.Stopwatch.GetTimestamp() / nanosecondsPerTick / 100.0);
            }
        }
        #endregion
        // </Snippet_ManipulationItem_Timestamp>

        // <Snippet_ManipulationItem_OnLostMouseCapture>
        #region OnLostMouseCapture
        protected override void OnLostMouseCapture(MouseEventArgs e)
        {
            base.OnLostMouseCapture(e);
            manipulationProcessor.ProcessManipulators(Timestamp, null);
        }
        #endregion
        // </Snippet_ManipulationItem_OnLostMouseCapture>

        // <Snippet_ManipulationItem_OnManipulationStarted>
        #region OnManipulationStarted
        private void OnManipulationStarted(object sender, Manipulation2DStartedEventArgs e)
        {
            if (inertiaProcessor.IsRunning)
            {
                inertiaProcessor.Complete(Timestamp);
            }
        }
        #endregion
        // </Snippet_ManipulationItem_OnManipulationStarted>

        // <Snippet_ManipulationItem_OnManipulationOrInertiaDelta>
        #region OnManipulationOrInertiaDelta
        private void OnManipulationOrInertiaDelta(object sender, Manipulation2DDeltaEventArgs e)
        {
            // The values obtained from e.Delta can be used to move, resize, or
            // change the orientation of the element that is being manipulated.
        }
        #endregion
        // </Snippet_ManipulationItem_OnManipulationOrInertiaDelta>

        private void SetDesiredRotation(InertiaProcessor2D inertiaProcessor)
        {
            // <Snippet_ManipulationItem_SetDesiredRotation>
            #region SetDesiredRotation
            // PI * 2 radians = 360 degrees.
            inertiaProcessor.RotationBehavior.DesiredRotation = (float)Math.PI * 7.0f;
            #endregion
            // </Snippet_ManipulationItem_SetDesiredRotation>
        }

        // <Snippet_ManipulationItem_ManipulationProcessor2D>
        #region ManipulationProcessor2D
        private double ElementCenterX
        {
            get { return elementPosition.X; }
            set
            {
                elementPosition.X = value;
                manipulationProcessor.Pivot.X = (float)value;
            }
        }

        private double ElementCenterY
        {
            get { return elementPosition.Y; }
            set
            {
                elementPosition.Y = value;
                manipulationProcessor.Pivot.Y = (float)value;
            }
        }
        #endregion
        // </Snippet_ManipulationItem_ManipulationProcessor2D>

        #endregion Snippets
    }
}
