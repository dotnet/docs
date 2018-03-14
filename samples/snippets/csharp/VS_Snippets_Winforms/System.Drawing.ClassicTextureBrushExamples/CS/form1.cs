using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicTextureBrushExamplesCS
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

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


        // Snippet for: M:System.Drawing.TextureBrush.Clone
        // <snippet1>
        public void Clone_Example(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Create an exact copy of tBrush.
            TextureBrush cloneBrush = (TextureBrush)tBrush.Clone();
                     
            // Fill a rectangle with cloneBrush.
            e.Graphics.FillRectangle(cloneBrush, 0, 0, 100, 100);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.TextureBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
        // <snippet2>
        public void MultiplyTransform_Example1(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Create a transformation matrix.
            Matrix translateMatrix = new Matrix();
            translateMatrix.Translate(50, 0);
                     
            // Multiply the transformation matrix of tBrush by translateMatrix.
            tBrush.MultiplyTransform(translateMatrix, MatrixOrder.Prepend);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.TextureBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet3>
        public void MultiplyTransform_Example2(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Create a transformation matrix.
            Matrix translateMatrix = new Matrix();
            translateMatrix.Translate(50, 0);
                     
            // Multiply the transformation matrix of tBrush by translateMatrix.
            tBrush.MultiplyTransform(translateMatrix);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100);
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.TextureBrush.ResetTransform
        // <snippet4>
        public void ResetTransform_Example(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Rotate the texture image by 90 degrees.
            tBrush.RotateTransform(90);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
                     
            // Reset transformation matrix to identity.
            tBrush.ResetTransform();
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.TextureBrush.RotateTransform(System.Single)
        // <snippet5>
        public void RotateTransform_Example1(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Rotate the texture image by 90 degrees.
            tBrush.RotateTransform(90);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.TextureBrush.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet6>
        public void RotateTransform_Example2(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Rotate the texture image by 90 degrees.
            tBrush.RotateTransform(90, MatrixOrder.Prepend);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.TextureBrush.ScaleTransform(System.Single,System.Single)
        // <snippet7>
        public void ScaleTransform_Example1(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Scale the texture image 2X in the x-direction.
            tBrush.ScaleTransform(2, 1);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.TextureBrush.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet8>
        public void ScaleTransform_Example2(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Scale the texture image 2X in the x-direction.
            tBrush.ScaleTransform(2, 1, MatrixOrder.Prepend);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
        }
        // </snippet8>


        // Snippet for: M:System.Drawing.TextureBrush.TranslateTransform(System.Single,System.Single)
        // <snippet9>
        public void TranslateTransform_Example1(PaintEventArgs e)
        {
                     
            // Create a TextureBrush object.
            TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
            // Move the texture image 2X in the x-direction.
            tBrush.TranslateTransform(50, 0, MatrixOrder.Prepend);
                     
            // Fill a rectangle with tBrush.
            e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
        }
            // </snippet9>


            // Snippet for: M:System.Drawing.TextureBrush.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
            // <snippet10>
            public void TranslateTransform_Example2(PaintEventArgs e)
            {
                     
                // Create a TextureBrush object.
                TextureBrush tBrush = new TextureBrush(new Bitmap("texture.jpg"));
                     
                // Move the texture image 2X in the x-direction.
                tBrush.TranslateTransform(50, 0);
                     
                // Fill a rectangle with tBrush.
                e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100);
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
	}
}
