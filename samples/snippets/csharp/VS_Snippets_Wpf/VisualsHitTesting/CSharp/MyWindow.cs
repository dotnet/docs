using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace SDKSample
{
    class MyWindow
    {
        public static int _width = Form1.ActiveForm.ClientSize.Width;
        public static int _height = Form1.ActiveForm.ClientSize.Height;
        public static HwndSource myHwndSource;
        public static bool topmostLayer = true;
        public static bool changeColor;

        public static void FillWithCircles(IntPtr parentHwnd)
        {
            // Fill the client area of the form with randomly placed circles.
            for (int i = 0; i < 200; i++)
            {
                CreateShape(parentHwnd);
            }
        }

        //<Snippet100>
        public static void CreateShape(IntPtr parentHwnd)
        {
            // Create an instance of the shape.
            MyShape myShape = new MyShape();

            // Determine whether the host container window has been created.
            if (myHwndSource == null)
            {
                // Create the host container window for the visual objects.
                CreateHostHwnd(parentHwnd);

                // Associate the shape with the host container window.
                myHwndSource.RootVisual = myShape;
            }
            else
            {
                // Assign the shape as a child of the root visual.
                ((ContainerVisual)myHwndSource.RootVisual).Children.Add(myShape);
            }
        }
        //</Snippet100>

        //<Snippet101>
        // Constant values from the "winuser.h" header file.
        internal const int WS_CHILD = 0x40000000,
                           WS_VISIBLE = 0x10000000;

        internal static void CreateHostHwnd(IntPtr parentHwnd)
        {
            // Set up the parameters for the host hwnd.
            HwndSourceParameters parameters = new HwndSourceParameters("Visual Hit Test", _width, _height);
            parameters.WindowStyle = WS_VISIBLE | WS_CHILD;
            parameters.SetPosition(0, 24);
            parameters.ParentWindow = parentHwnd;
            //<Snippet102>
            parameters.HwndSourceHook = new HwndSourceHook(ApplicationMessageFilter);
            //</Snippet102>

            // Create the host hwnd for the visuals.
            myHwndSource = new HwndSource(parameters);

            // Set the hwnd background color to the form's background color.
            myHwndSource.CompositionTarget.BackgroundColor = System.Windows.Media.Brushes.OldLace.Color;
        }
        //</Snippet101>

        //<Snippet103>
        // Constant values from the "winuser.h" header file.
        internal const int WM_LBUTTONUP = 0x0202,
                           WM_RBUTTONUP = 0x0205;

        internal static IntPtr ApplicationMessageFilter(
            IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Handle messages passed to the visual.
            switch (message)
            {
                // Handle the left and right mouse button up messages.
                case WM_LBUTTONUP:
                case WM_RBUTTONUP:
                    System.Windows.Point pt = new System.Windows.Point();
                    pt.X = (uint)lParam & (uint)0x0000ffff;  // LOWORD = x
                    pt.Y = (uint)lParam >> 16;               // HIWORD = y
                    MyShape.OnHitTest(pt, message);
                    break;
            }

            return IntPtr.Zero;
        }
        //</Snippet103>
    }
}
