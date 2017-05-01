// <snippetWriteableBitmapFullPage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace WriteableBitmapDemo
{
    class Program
    {
        static WriteableBitmap writeableBitmap;
        static Window w;
        static Image i;

        [STAThread]
        static void Main(string[] args)
        {
            i = new Image();
            RenderOptions.SetBitmapScalingMode(i, BitmapScalingMode.NearestNeighbor);
            RenderOptions.SetEdgeMode(i, EdgeMode.Aliased);
           
            w = new Window();
            w.Content = i;
            w.Show();

            writeableBitmap = new WriteableBitmap(
                (int)w.ActualWidth, 
                (int)w.ActualHeight, 
                96, 
                96, 
                PixelFormats.Bgr32, 
                null);

            i.Source = writeableBitmap;

            i.Stretch = Stretch.None;
            i.HorizontalAlignment = HorizontalAlignment.Left;
            i.VerticalAlignment = VerticalAlignment.Top;

            i.MouseMove += new MouseEventHandler(i_MouseMove);
            i.MouseLeftButtonDown += 
                new MouseButtonEventHandler(i_MouseLeftButtonDown);
            i.MouseRightButtonDown += 
                new MouseButtonEventHandler(i_MouseRightButtonDown);

            w.MouseWheel += new MouseWheelEventHandler(w_MouseWheel);

            Application app = new Application();
            app.Run();
        }

        // <snippet2>
        // The DrawPixel method updates the WriteableBitmap by using
        // unsafe code to write a pixel into the back buffer.
        static void DrawPixel(MouseEventArgs e)
        {
            int column = (int)e.GetPosition(i).X;
            int row = (int)e.GetPosition(i).Y;

            // Reserve the back buffer for updates.
            writeableBitmap.Lock();

            unsafe
            {
                // Get a pointer to the back buffer.
                int pBackBuffer = (int)writeableBitmap.BackBuffer;

                // Find the address of the pixel to draw.
                pBackBuffer += row * writeableBitmap.BackBufferStride;
                pBackBuffer += column * 4;

                // Compute the pixel's color.
                int color_data = 255 << 16; // R
                color_data |= 128 << 8;   // G
                color_data |= 255 << 0;   // B

                // Assign the color data to the pixel.
                *((int*) pBackBuffer) = color_data;
            }

            // Specify the area of the bitmap that changed.
            writeableBitmap.AddDirtyRect(new Int32Rect(column, row, 1, 1));

            // Release the back buffer and make it available for display.
            writeableBitmap.Unlock();
        }
        // </snippet2>

        // <snippet3>
        static void ErasePixel(MouseEventArgs e)
        {
            byte[] ColorData = { 0, 0, 0, 0 }; // B G R

            Int32Rect rect = new Int32Rect(
                    (int)(e.GetPosition(i).X), 
                    (int)(e.GetPosition(i).Y), 
                    1, 
                    1);

            writeableBitmap.WritePixels( rect, ColorData, 4, 0);
        }
        // </snippet3>

        static void i_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ErasePixel(e);
        }

        static void i_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DrawPixel(e);
        }

        static void i_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DrawPixel(e);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                ErasePixel(e);
            }
        }

        static void w_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            System.Windows.Media.Matrix m = i.RenderTransform.Value;

            if (e.Delta > 0)
            {
                m.ScaleAt(
                    1.5, 
                    1.5, 
                    e.GetPosition(w).X, 
                    e.GetPosition(w).Y);
            }
            else
            {
                m.ScaleAt(
                    1.0 / 1.5, 
                    1.0 / 1.5, 
                    e.GetPosition(w).X, 
                    e.GetPosition(w).Y);
            }

            i.RenderTransform = new MatrixTransform(m);
        }
    }
}
// </snippetWriteableBitmapFullPage>