using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace System.Drawing.Imaging.ClassicImageAttributesCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetBrushRemapTable(System.Drawing.Imaging.ColorMap[])
        // <snippet1>
        public void SetBrushRemapTableExample(PaintEventArgs e)
        {
                     
            // Create a color map.
            ColorMap[] myColorMap = new ColorMap[1];
            myColorMap[0] = new ColorMap();
            myColorMap[0].OldColor = Color.Red;
            myColorMap[0].NewColor = Color.Green;
                     
            // Create an ImageAttributes object, passing it to the myColorMap
                     
            // array.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetBrushRemapTable(myColorMap);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetColorKey(System.Drawing.Color,System.Drawing.Color,System.Drawing.Imaging.ColorAdjustType)
        // <snippet2>
        private void SetColorKeyExample(PaintEventArgs e)
        {
                     
            // Open an Image file and draw it to the screen.
            Image myImage = Image.FromFile("Circle.bmp");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create an ImageAttributes object and set the color key.
            Color lowerColor = Color.FromArgb(245,0,0);
            Color upperColor = Color.FromArgb(255,0,0);
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorKey(lowerColor,
                upperColor,
                ColorAdjustType.Default);
                     
            // Draw the image with the color key set.
            Rectangle rect = new Rectangle(150, 20, 100, 100);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 100, 100, 
                GraphicsUnit.Pixel, imageAttr);      
            
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetColorMatrix(System.Drawing.Imaging.ColorMatrix)
        // <snippet3>
        private void SetColorMatrixExample(PaintEventArgs e)
        {
                     
            // Create a rectangle image with all colors set to 128 (medium
                     
            // gray).
            Bitmap myBitmap = new Bitmap(50, 50, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(myBitmap);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 128, 128, 128)),
                new Rectangle(0, 0, 50, 50));
            myBitmap.Save("Rectangle1.jpg");
                     
            // Open an Image file and draw it to the screen.
            Image myImage = Image.FromFile("Rectangle1.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Initialize the color matrix.
            ColorMatrix myColorMatrix = new ColorMatrix();
            
            // Red
            myColorMatrix.Matrix00 = 1.75f; 
            
            // Green
            myColorMatrix.Matrix11 = 1.00f; 
            
            // Blue
            myColorMatrix.Matrix22 = 1.00f; 
            
            // alpha
            myColorMatrix.Matrix33 = 1.00f; 
           
            // w
            myColorMatrix.Matrix44 = 1.00f; 
            
                     
            // Create an ImageAttributes object and set the color matrix.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(myColorMatrix);
                     
            // Draw the image using the color matrix.
            Rectangle rect = new Rectangle(100, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);      
            
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetGamma(System.Single)
        // <snippet4>
        private void SetGammaExample(PaintEventArgs e)
        {
                     
            // Create an Image object from the file Camera.jpg, and draw it to
            // the screen.
            Image myImage = Image.FromFile("Camera.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create an ImageAttributes object and set the gamma to 2.2.
            System.Drawing.Imaging.ImageAttributes imageAttr = 
                   new System.Drawing.Imaging.ImageAttributes();
            imageAttr.SetGamma(2.2f);
                     
            // Draw the image with gamma set to 2.2.
            Rectangle rect = new Rectangle(250, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetNoOp
        // <snippet5>
        private void SetNoOpExample(PaintEventArgs e)
        {
                     
            // Create an Image object from the file Camera.jpg.
            Image myImage = Image.FromFile("Camera.jpg");
                     
            // Create an ImageAttributes object, and set the gamma to 0.25.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(0.25f);
                     
            // Draw the image with gamma set to 0.25.
            Rectangle rect1 = new Rectangle(20, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect1, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
            
            // Call the ImageAttributes NoOp method.
            imageAttr.SetNoOp();
                     
            // Draw the image after NoOp is set, so the default gamma value
            // of 1.0 will be used.
            Rectangle rect2 = new Rectangle(250, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect2, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetRemapTable(System.Drawing.Imaging.ColorMap[])
        // <snippet6>
        private void SetRemapTableExample(PaintEventArgs e)
        {
                     
            // Create a filled, red image, and save it to Circle2.jpg.
            Bitmap myBitmap = new Bitmap(50, 50);
            Graphics g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle(0, 0, 50, 50));
            myBitmap.Save("Circle2.jpg");
                     
            // Create an Image object from the Circle2.jpg file, and draw it to
                     
            // the screen.
            Image myImage = Image.FromFile("Circle2.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create a color map.
            ColorMap[] myColorMap = new ColorMap[1];
            myColorMap[0] = new ColorMap();
            myColorMap[0].OldColor = Color.Red;
            myColorMap[0].NewColor = Color.Green;
                     
            // Create an ImageAttributes object, and then pass the
           // myColorMap object to the SetRemapTable method.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetRemapTable(myColorMap);
                     
            // Draw the image with the remap table set.
            Rectangle rect = new Rectangle(150, 20, 50, 50);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 50, 50, 
                GraphicsUnit.Pixel, imageAttr);    
           
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetThreshold(System.Single)
        // <snippet7>
        private void SetThresholdExample(PaintEventArgs e)
        {
                     
            // Open an Image file, and draw it to the screen.
            Image myImage = Image.FromFile("Camera.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Create an ImageAttributes object, and set its color threshold.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetThreshold(0.7f);
                     
            // Draw the image with the colors bifurcated.
            Rectangle rect = new Rectangle(300, 20, 200, 200);
            e.Graphics.DrawImage(myImage, rect, 0, 0, 200, 200, 
                GraphicsUnit.Pixel, imageAttr);    
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.Imaging.ImageAttributes.SetWrapMode(System.Drawing.Drawing2D.WrapMode)
        // <snippet8>
        private void SetWrapModeExample(PaintEventArgs e)
        {
                     
            // Create a filled, red circle, and save it to Circle3.jpg.
            Bitmap myBitmap = new Bitmap(50, 50);
            Graphics g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            g.FillEllipse(new SolidBrush(Color.Red),
                new Rectangle(0, 0, 25, 25));
            myBitmap.Save("Circle3.jpg");
                     
            // Create an Image object from the Circle3.jpg file, and draw it
            // to the screen.
            Image myImage = Image.FromFile("Circle3.jpg");
            e.Graphics.DrawImage(myImage, 20, 20);
                     
            // Set the wrap mode.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetWrapMode(WrapMode.Tile);
                     
            // Create a TextureBrush.
            Rectangle brushRect = new Rectangle(0,0,25,25);
            TextureBrush myTBrush = new TextureBrush(myImage, brushRect, imageAttr);
                     
            // Draw to the screen a rectangle filled with red circles.
            e.Graphics.FillRectangle(myTBrush, 100, 20, 200, 200);
        }
        // </snippet8>

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";
		}
		#endregion
        public static void Main()
        {
            Application.Run(new Form1());
        }
	}
}
