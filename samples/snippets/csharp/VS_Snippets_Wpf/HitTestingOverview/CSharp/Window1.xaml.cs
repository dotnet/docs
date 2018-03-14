using System;
using System.Collections;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        ArrayList hitResultsList = new ArrayList();
        public Window1()
        {
            InitializeComponent();
        }
        private void WindowLoaded(object sender, EventArgs e)
        {
        }

        // <Snippet100>
        // Respond to the left mouse button down event by initiating the hit test.
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Perform the hit test against a given portion of the visual object tree.
            HitTestResult result = VisualTreeHelper.HitTest(myCanvas, pt);

            if (result != null)
            {
                // Perform action on hit visual object.
            }
        }
        // </Snippet100>

        // <Snippet101>
        // Respond to the right mouse button down event by setting up a hit test results callback.
        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();

            // Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest(myCanvas, null,
                new HitTestResultCallback(MyHitTestResult),
                new PointHitTestParameters(pt));

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                Console.WriteLine("Number of Visuals Hit: " + hitResultsList.Count);
            }
        }
        // </Snippet101>

        // <Snippet102>
        // Return the result of the hit test to the callback.
        public HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            // Add the hit test result to the list that will be processed after the enumeration.
            hitResultsList.Add(result.VisualHit);

            // Set the behavior to return visuals at all z-order levels.
            return HitTestResultBehavior.Continue;
        }
        // </Snippet102>

        // Dummy routine to hold snippet.
        public HitTestResultBehavior MyDummyHitTestResult(HitTestResult result)
        {
            // <Snippet103>
            // Set the behavior to stop enumerating visuals.
            return HitTestResultBehavior.Stop;
            // </Snippet103>
        }

        // <Snippet104>
        // Respond to the mouse wheel event by setting up a hit test filter and results enumeration.
        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();

            // Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest(myCanvas,
                              new HitTestFilterCallback(MyHitTestFilter),
                              new HitTestResultCallback(MyHitTestResult),
                              new PointHitTestParameters(pt));

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                ProcessHitTestResultsList();
            }
        }
        // </Snippet104>

        // Dummy routine to hold snippet.
        private void OnDummyEvent01(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();

            // <Snippet105>
            // Set up a callback to receive the hit test result enumeration,
            // but no hit test filter enumeration.
            VisualTreeHelper.HitTest(myCanvas,
                              null,  // No hit test filtering.
                              new HitTestResultCallback(MyHitTestResult),
                              new PointHitTestParameters(pt));
            // </Snippet105>

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                ProcessHitTestResultsList();
            }
        }

        // <Snippet106>
        // Filter the hit test values for each object in the enumeration.
        public HitTestFilterBehavior MyHitTestFilter(DependencyObject o)
        {
            // Test for the object value you want to filter.
            if (o.GetType() == typeof(Label))
            {
                // Visual object and descendants are NOT part of hit test results enumeration.
                return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
            }
            else
            {
                // Visual object is part of hit test results enumeration.
                return HitTestFilterBehavior.Continue;
            }
        }
        // </Snippet106>


        public void ProcessHitTestResultsList() { }
    }

    // Dummy class to hold snippet.
    public class MyDummyVisual : DrawingVisual
    {
        //<Snippet107>
        // Override default hit test support in visual object.
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            Point pt = hitTestParameters.HitPoint;

            // Perform custom actions during the hit test processing,
            // which may include verifying that the point actually
            // falls within the rendered content of the visual.

            // Return hit on bounding rectangle of visual object.
            return new PointHitTestResult(this, pt);
        }
        //</Snippet107>
    }

    // Dummy class to hold snippet.
    public class MyDummyVisual2 : DrawingVisual
    {
        //<Snippet108>
        // Override default hit test support in visual object.
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            // Perform actions based on hit test of bounding rectangle.
            // ...

            // Return results of base class hit testing,
            // which only returns hit on the geometry of visual objects.
            return base.HitTestCore(hitTestParameters);
        }
        //</Snippet108>
    }
}