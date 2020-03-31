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
        // <SnippetHitTestingOverviewSnippet10>
        // Respond to the mouse button down event by setting up a hit test results callback.
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Expand the hit test area by creating a geometry centered on the hit test point.
            EllipseGeometry expandedHitTestArea = new EllipseGeometry(pt, 10.0, 10.0);

            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();

            // Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest(myControl, null,
                new HitTestResultCallback(MyHitTestResultCallback),
                new GeometryHitTestParameters(expandedHitTestArea));

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                ProcessHitTestResultsList();
            }
        }
        // </SnippetHitTestingOverviewSnippet10>

        // <SnippetHitTestingOverviewSnippet11>
        // Return the result of the hit test to the callback.
        public HitTestResultBehavior MyHitTestResultCallback(HitTestResult result)
        {
            // Retrieve the results of the hit test.
            IntersectionDetail intersectionDetail = ((GeometryHitTestResult)result).IntersectionDetail;

            switch (intersectionDetail)
            {
                case IntersectionDetail.FullyContains:

                    // Add the hit test result to the list that will be processed after the enumeration.
                    hitResultsList.Add(result.VisualHit);

                    return HitTestResultBehavior.Continue;

                case IntersectionDetail.Intersects:

                    // Set the behavior to return visuals at all z-order levels.
                    return HitTestResultBehavior.Continue;

                case IntersectionDetail.FullyInside:

                    // Set the behavior to return visuals at all z-order levels.
                    return HitTestResultBehavior.Continue;

                default:
                    return HitTestResultBehavior.Stop;
            }
        }
        // </SnippetHitTestingOverviewSnippet11>

        private void OnDummyEvent02(object sender, MouseButtonEventArgs e)
        {
            // <SnippetHitTestingOverviewSnippet12>
            // Retrieve the coordinate of the mouse position.
            Point pt = e.GetPosition((UIElement)sender);

            // Expand the hit test area by creating a geometry centered on the hit test point.
            EllipseGeometry expandedHitTestArea = new EllipseGeometry(pt, 10.0, 10.0);

            // Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest(myControl, null,
                new HitTestResultCallback(MyHitTestResultCallback),
                new GeometryHitTestParameters(expandedHitTestArea));
            // </SnippetHitTestingOverviewSnippet12>

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                ProcessHitTestResultsList();
            }
        }

        // Dummy class to hold snippet.
        public class MyDummyVisual03 : DrawingVisual
        {
            // <SnippetHitTestingOverviewSnippet13>
            // Override default hit test support in visual object.
            protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
            {
                IntersectionDetail intersectionDetail = IntersectionDetail.NotCalculated;

                // Perform custom actions during the hit test processing.

                return new GeometryHitTestResult(this, intersectionDetail);
            }
            // </SnippetHitTestingOverviewSnippet13>
        }

        // Dummy class to hold snippet.
        public class MyDummyVisual04 : DrawingVisual
        {
            // <SnippetHitTestingOverviewSnippet14>
            // Override default hit test support in visual object.
            protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
            {
                // Perform actions based on hit test of bounding rectangle.

                // Return results of base class hit testing,
                // which only returns hit on the geometry of visual objects.
                return base.HitTestCore(hitTestParameters);
            }
            // </SnippetHitTestingOverviewSnippet14>
        }
    }
}
