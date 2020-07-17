using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BasicManipulation
{
    /// <summary>
    /// Interaction logic for ReportBoundaryFeedBackExample.xaml
    /// </summary>
    public partial class ReportBoundaryFeedBackExample : Window
    {
        MatrixTransform initialPosition;

        public ReportBoundaryFeedBackExample()
        {
            InitializeComponent();
            initialPosition = TryFindResource("InitialMatrixTransform") as MatrixTransform;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (initialPosition == null)
            {
                MessageBox.Show("transform not found");
                return;
            }

            manRect.RenderTransform = initialPosition;
        }

        //<SnippetManipulationPivot>
        void Window_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            // Set the ManipulationPivot so that the element rotates as it is
            // moved with one finger.
            FrameworkElement element = e.OriginalSource as FrameworkElement;
            ManipulationPivot pivot = new ManipulationPivot();
            pivot.Center = new Point(element.ActualWidth / 2, element.ActualHeight / 2);
            pivot.Radius = 20;
            e.Pivot = pivot;

            e.ManipulationContainer = this;
            e.Handled = true;
        }
        //</SnippetManipulationPivot>

        //<SnippetReportBoundaryFeedback>
        void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {

            Rectangle rectToMove = e.OriginalSource as Rectangle;
            Vector overshoot;

            // When the element crosses the boundary of the window, check whether
            // the manipulation is in inertia.  If it is, complete the manipulation.
            // Otherwise, report the boundary feedback.
            if (CalculateOvershoot(rectToMove, e.ManipulationContainer, out overshoot))
            {
                if (e.IsInertial)
                {
                    e.Complete();
                    e.Handled = true;
                    return;
                }
                else
                {
                    //Report that the element hit the boundary
                    e.ReportBoundaryFeedback(new ManipulationDelta(overshoot, 0, new Vector(), new Vector()));
                }
            }

            // Move the element as usual.

            // Get the Rectangle and its RenderTransform matrix.
            Matrix rectsMatrix = ((MatrixTransform)rectToMove.RenderTransform).Matrix;

            // Rotate the Rectangle.
            rectsMatrix.RotateAt(e.DeltaManipulation.Rotation,
                                 e.ManipulationOrigin.X,
                                 e.ManipulationOrigin.Y);

            // Resize the Rectangle.  Keep it square
            // so use only the X value of Scale.
            rectsMatrix.ScaleAt(e.DeltaManipulation.Scale.X,
                                e.DeltaManipulation.Scale.X,
                                e.ManipulationOrigin.X,
                                e.ManipulationOrigin.Y);

            // Move the Rectangle.
            rectsMatrix.Translate(e.DeltaManipulation.Translation.X,
                                  e.DeltaManipulation.Translation.Y);

            // Apply the changes to the Rectangle.
            rectToMove.RenderTransform = new MatrixTransform(rectsMatrix);

            e.Handled = true;
        }

        private bool CalculateOvershoot(UIElement element, IInputElement container, out Vector overshoot)
        {
            // Get axis aligned element bounds
            var elementBounds = element.RenderTransform.TransformBounds(
                          VisualTreeHelper.GetDrawing(element).Bounds);

            //double extraX = 0.0, extraY = 0.0;
            overshoot = new Vector();

            FrameworkElement parent = container as FrameworkElement;
            if (parent == null)
            {
                return false;
            }

            // Calculate overshoot.
            if (elementBounds.Left < 0)
                overshoot.X = elementBounds.Left;
            else if (elementBounds.Right > parent.ActualWidth)
                overshoot.X = elementBounds.Right - parent.ActualWidth;

            if (elementBounds.Top < 0)
                overshoot.Y = elementBounds.Top;
            else if (elementBounds.Bottom > parent.ActualHeight)
                overshoot.Y = elementBounds.Bottom - parent.ActualHeight;

            // Return false if Overshoot is empty; otherwsie, return true.
            return !Vector.Equals(overshoot, new Vector());
        }
        //</SnippetReportBoundaryFeedback>

        void Window_InertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {

            // Decrease the velocity of the Rectangle's movement by
            // 10 inches per second every second.
            // (10 inches * 96 pixels per inch / 1000ms^2)
            e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0);

            // Decrease the velocity of the Rectangle's resizing by
            // 0.1 inches per second every second.
            // (0.1 inches * 96 pixels per inch / (1000ms^2)
            e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / 1000.0 * 1000.0;

            // Decrease the velocity of the Rectangle's rotation rate by
            // 2 rotations per second every second.
            // (2 * 360 degrees / (1000ms^2)
            e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0);

            e.Handled = true;
        }
    }
}
