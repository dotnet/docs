using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace System.Drawing.ClassicBitmapExamplesCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

    internal class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

        }
        #endregion
        // <snippet1>
        private void Clone_Example1(PaintEventArgs e)
        {

            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap("Grapes.jpg");

            // Clone a portion of the Bitmap object.
            Rectangle cloneRect = new Rectangle(0, 0, 100, 100);
            System.Drawing.Imaging.PixelFormat format =
                myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            // Draw the cloned portion of the Bitmap object.
            e.Graphics.DrawImage(cloneBitmap, 0, 0);
        }
        // </snippet1>
        // <snippet2>
        private void Clone_Example2(PaintEventArgs e)
        {

            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap("Grapes.jpg");

            // Clone a portion of the Bitmap object.
            RectangleF cloneRect = new RectangleF(0, 0, 100, 100);
            System.Drawing.Imaging.PixelFormat format =
                myBitmap.PixelFormat;
            Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);

            // Draw the cloned portion of the Bitmap object.
            e.Graphics.DrawImage(cloneBitmap, 0, 0);
        }
        // </snippet2>

        // <snippet3>
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadImage(int Hinstance,
            string name, int type, int width, int height, int load);

        private void Hicon_Example(PaintEventArgs e)
        {

            // Get a handle to an icon.
            IntPtr Hicon = LoadImage(0, "smile.ico", 1, 0, 0, 16);

            // Create a Bitmap object from the icon handle.
            Bitmap iconBitmap = Bitmap.FromHicon(Hicon);

            // Draw the Bitmap object to the screen.
            e.Graphics.DrawImage(iconBitmap, 0, 0);
        }
        // </snippet3>

        // <snippet4>
        //<snippet11>
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        //</snippet11>


        private void DemonstrateGetHbitmap()
        {
            Bitmap bm = new Bitmap("Picture.jpg");
            IntPtr hBitmap = bm.GetHbitmap();

            // Do something with hBitmap.
            DeleteObject(hBitmap);
        }
        // </snippet4>
        // <snippet5>


        private void DemonstrateGetHbitmapWithColor()
        {
            Bitmap bm = new Bitmap("Picture.jpg");
            IntPtr hBitmap = bm.GetHbitmap(Color.Blue);

            // Do something with hBitmap.
            DeleteObject(hBitmap);
        }
        // </snippet5>
        // <snippet6>

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        private void GetHicon_Example(PaintEventArgs e)
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap(@"c:\FakePhoto.jpg");

            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(myBitmap, 0, 0);

            // Get an Hicon for myBitmap.
            IntPtr Hicon = myBitmap.GetHicon();

            // Create a new icon from the handle. 
            Icon newIcon = Icon.FromHandle(Hicon);

            // Set the form Icon attribute to the new icon.
            this.Icon = newIcon;

            // You can now destroy the icon, since the form creates
            // its own copy of the icon accessible through the Form.Icon property.
            DestroyIcon(newIcon.Handle);

        }
        // </snippet6>
        // <snippet7>
        private void GetPixel_Example(PaintEventArgs e)
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap("Grapes.jpg");

            // Get the color of a pixel within myBitmap.
            Color pixelColor = myBitmap.GetPixel(50, 50);

            // Fill a rectangle with pixelColor.
            SolidBrush pixelBrush = new SolidBrush(pixelColor);
            e.Graphics.FillRectangle(pixelBrush, 0, 0, 100, 100);
        }
        // </snippet7>
        // <snippet8>
        private void MakeTransparent_Example1(PaintEventArgs e)
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap("Grapes.gif");

            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width,
                myBitmap.Height);

            // Make the default transparent color transparent for myBitmap.
            myBitmap.MakeTransparent();

            // Draw the transparent bitmap to the screen.
            e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0,
                myBitmap.Width, myBitmap.Height);
        }
        // </snippet8>
        // <snippet9>
        private void MakeTransparent_Example2(PaintEventArgs e)
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = new Bitmap("Grapes.gif");

            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(
                myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);

            // Get the color of a background pixel.
            Color backColor = myBitmap.GetPixel(1, 1);

            // Make backColor transparent for myBitmap.
            myBitmap.MakeTransparent(backColor);

            // Draw the transparent bitmap to the screen.
            e.Graphics.DrawImage(
                myBitmap, myBitmap.Width, 0, myBitmap.Width, myBitmap.Height);
        }
        // </snippet9>
        // <snippet10>
        private void SetPixel_Example(PaintEventArgs e)
        {

            // Create a Bitmap object from a file.
            Bitmap myBitmap = new Bitmap("Grapes.jpg");

            // Draw myBitmap to the screen.
            e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width,
                myBitmap.Height);

            // Set each pixel in myBitmap to black.
            for (int Xcount = 0; Xcount < myBitmap.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < myBitmap.Height; Ycount++)
                {
                    myBitmap.SetPixel(Xcount, Ycount, Color.Black);
                }
            }

            // Draw myBitmap to the screen again.
            e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0,
                myBitmap.Width, myBitmap.Height);
        }
        // </snippet10>
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}
