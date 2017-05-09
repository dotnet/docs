using System;
using System.Windows;
using System.Collections;
using System.Windows.Media;

namespace SDKSample
{
    public class MyShape : ContainerVisual
    {
        public static int numberCircles = 5;
        public static double radius = 50.0d;
        public static Random myRandom = new Random();
        public static ArrayList hitResultsList = new ArrayList();

        internal MyShape()
        {
            // Create a random x:y coordinate for the shape.
            int left = myRandom.Next(0, MyWindow._width);
            int top = myRandom.Next(0, MyWindow._height);

            double currRadius = radius;
            if (radius == 0.0d)
            {
                currRadius = (double)myRandom.Next(30, 100);
            }

            // Draw five concentric circles for the shape.
            double r = currRadius;
            for (int i = 0; i < numberCircles; i++)
            {
                new MyCircle(this, new System.Windows.Point(left, top), r);
                r = currRadius * (1.0d - (((double)i + 1.0d) / (double)numberCircles));
            }
        }

        //<Snippet104>
        // Constant values from the "winuser.h" header file.
        public const int WM_LBUTTONUP = 0x0202,
                         WM_RBUTTONUP = 0x0205;

        // Respond to WM_LBUTTONUP or WM_RBUTTONUP messages by determining which visual object was clicked.
        public static void OnHitTest(System.Windows.Point pt, int msg)
        {
            // Clear the contents of the list used for hit test results.
            hitResultsList.Clear();

            // Determine whether to change the color of the circle or to delete the shape.
            if (msg == WM_LBUTTONUP)
            {
                MyWindow.changeColor = true;
            }
            if (msg == WM_RBUTTONUP)
            {
                MyWindow.changeColor = false;
            }

            // Set up a callback to receive the hit test results enumeration.
            VisualTreeHelper.HitTest(MyWindow.myHwndSource.RootVisual,
                                     null,
                                     new HitTestResultCallback(CircleHitTestResult),
                                     new PointHitTestParameters(pt));

            // Perform actions on the hit test results list.
            if (hitResultsList.Count > 0)
            {
                ProcessHitTestResultsList();
            }
        }
        //</Snippet104>

        // Handle the hit test results enumeration in the callback.
        internal static HitTestResultBehavior CircleHitTestResult(HitTestResult result)
        {
            // Add the hit test result to the list that will be processed after the enumeration.
            hitResultsList.Add(result.VisualHit);

            // Determine whether hit test should return only the top-most layer visual.
            if (MyWindow.topmostLayer == true)
            {
                // Set the behavior to stop the enumeration of visuals.
                return HitTestResultBehavior.Stop;
            }
            else
            {
                // Set the behavior to continue the enumeration of visuals.
                // All visuals that intersect at the hit test coordinates are returned,
                // whether visible or not.
                return HitTestResultBehavior.Continue;
            }
        }

        // Process the results of the hit test after the enumeration in the callback.
        // Do not add or remove objects from the visual tree until after the enumeration.
        internal static void ProcessHitTestResultsList()
        {
            foreach (MyCircle circle in hitResultsList)
            {
                // Determine whether to change the color of the ring or to delete the circle.
                if (MyWindow.changeColor == true)
                {
                    // Draw a different color ring for the circle.
                    circle.Render();
                }
                else
                {
                    if (circle.Parent == MyWindow.myHwndSource.RootVisual)
                    {
                        // Remove the root visual by disposing of the host hwnd.
                        MyWindow.myHwndSource.Dispose();
                        MyWindow.myHwndSource = null;
                        return;
                    }
                    else
                    {
                        // Remove the shape that is the parent of the child circle.
                        ((ContainerVisual)MyWindow.myHwndSource.RootVisual).Children.Remove((Visual)circle.Parent);
                    }
                }
            }
        }

        internal class MyCircle : DrawingVisual
        {
            public System.Windows.Point _pt;
            public double _radius;

            internal MyCircle(MyShape parent, System.Windows.Point pt, double radius)
            {
                _pt = pt;
                _radius = radius;
                this.Render();

                // Add the circle as a child to the shape parent.
                parent.Children.Add(this);
            }

            internal void Render()
            {
                // Draw a circle.
                DrawingContext dc = this.RenderOpen();
                dc.DrawEllipse(new SolidColorBrush(MyColor.GenRandomColor()), null, _pt, _radius, _radius);
                dc.Close();
            }
        }

        class MyColor
        {
            public static Random myRandom = new Random();

            public static System.Windows.Media.Color GenRandomColor()
            {
                // Generate a random color value.
                return System.Windows.Media.Color.FromRgb((byte)myRandom.Next(0, 255), (byte)myRandom.Next(0, 255), (byte)myRandom.Next(0, 255));
            }
        }
    }
}