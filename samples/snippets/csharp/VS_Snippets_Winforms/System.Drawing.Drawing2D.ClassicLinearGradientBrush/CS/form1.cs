using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.Drawing2D.ClassicLinearGradientBrushCS
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


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.Clone
        // <snippet1>
        private void CloneExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            int x=20, y=20, h=100, w=200;
            Rectangle myRect = new Rectangle(x, y, w, h);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Aquamarine, 45.0f, true);
        
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, x, y, w, h);
                     
            // Clone the LinearGradientBrush.
            LinearGradientBrush clonedLGBrush =
                (LinearGradientBrush)myLGBrush.Clone();
                     
            // Justify the left edge of the gradient with the
            // left edge of the ellipse.
            clonedLGBrush.TranslateTransform(-100.0f, 0.0f);
                     
            // Draw a second ellipse to the screen using the cloned HBrush.
            y=150;
            e.Graphics.FillEllipse(clonedLGBrush, x, y, w, h);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet2>
        private void MultiplyTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Transform the LinearGradientBrush.
            Point[] transformArray = { new Point(20, 150),
                 new Point(400,150), new Point(20, 200) };
       
            Matrix myMatrix = new Matrix(myRect, transformArray);
            myLGBrush.MultiplyTransform(
                myMatrix,
                MatrixOrder.Prepend);
                     
            // Draw a second ellipse to the screen using
            // the transformed brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 150, 380, 50);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.ResetTransform
        // <snippet3>
        private void ResetTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Transform the LinearGradientBrush.
            Point[] transformArray = { new Point(20, 150),
                 new Point(400,150), new Point(20, 200) };
               
            Matrix myMatrix = new Matrix(myRect, transformArray);
            myLGBrush.MultiplyTransform( myMatrix, MatrixOrder.Prepend);
                     
            // Draw a second ellipse to the screen
            // using the transformed brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 150, 380, 50);
                     
            // Reset the brush transform.
            myLGBrush.ResetTransform();
                     
            // Draw a third ellipse to the screen using the reset brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 250, 200, 100);
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet4>
        private void RotateTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Rotate the LinearGradientBrush.
            myLGBrush.RotateTransform(45.0f, MatrixOrder.Prepend);
       
            // Rejustify the brush to start at the left edge of the ellipse.
            myLGBrush.TranslateTransform(-100.0f, 0.0f);
                     
            // Draw a second ellipse to the screen using
            // the transformed brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 150, 200, 100);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet5>
        private void ScaleTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Scale the LinearGradientBrush.
            myLGBrush.ScaleTransform(2.0f, 1.0f, MatrixOrder.Prepend);
           
            // Rejustify the brush to start at the left edge of the ellipse.
            myLGBrush.TranslateTransform(-20.0f, 0.0f);
                     
            // Draw a second ellipse to the screen using
            // the transformed brush.
            e.Graphics.FillEllipse(myLGBrush, 20, 150, 200, 100);
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.SetBlendTriangularShape(System.Single,System.Single)
        // <snippet6>
        private void SetBlendTriangularShapeExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Create a triangular shaped brush with the peak at the center
            // of the drawing area.
            myLGBrush.SetBlendTriangularShape(.5f, 1.0f);
                     
            // Use the triangular brush to draw a second ellipse.
            myRect.Y = 150;
            e.Graphics.FillEllipse(myLGBrush, myRect);
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.SetSigmaBellShape(System.Single,System.Single)
        // <snippet7>
        private void SetSigmaBellShapeExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw an ellipse to the screen using the LinearGradientBrush.
            e.Graphics.FillEllipse(myLGBrush, myRect);
                     
            // Create a bell-shaped brush with the peak at the
                     
            // center of the drawing area.
            myLGBrush.SetSigmaBellShape(.5f, 1.0f);
                     
            // Use the bell- shaped brush to draw a second
            // ellipse.
            myRect.Y = 150;
            e.Graphics.FillEllipse(myLGBrush, myRect);
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet8>
        private void TranslateTransformExample(PaintEventArgs e)
        {
                     
            // Create a LinearGradientBrush.
            Rectangle myRect = new Rectangle(20, 20, 200, 100);
            LinearGradientBrush myLGBrush = new LinearGradientBrush(
                myRect, Color.Blue, Color.Red,  0.0f, true);
                     
            // Draw a rectangle to the screen using the LinearGradientBrush.
            e.Graphics.FillRectangle(myLGBrush, myRect);
                     
            // Rotate the LinearGradientBrush.
            myLGBrush.RotateTransform(90.0f);
                     
            // Scale the gradient for the height of the rectangle.
            myLGBrush.ScaleTransform(0.5f, 1.0f);
                     
            // Draw to the screen, the rotated and scaled gradient.
            e.Graphics.FillRectangle(myLGBrush, 20, 150, 200, 100);
                     
            // Rejustify the brush to start at the top edge of the
            // rectangle.
            myLGBrush.TranslateTransform(-20.0f, 0.0f);
                     
            // Draw a third rectangle to the screen using the translated
            // brush.
            e.Graphics.FillRectangle(myLGBrush, 20, 300, 200, 100);
        }
        // </snippet8>

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
