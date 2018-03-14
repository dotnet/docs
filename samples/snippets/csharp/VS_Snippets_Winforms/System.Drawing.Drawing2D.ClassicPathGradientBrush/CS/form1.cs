using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.Drawing2D.ClassicPathGradientBrushCS
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


        // Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet1>
        public void MultiplyTransformExample(PaintEventArgs e)
        {
                     
            // Create a graphics path and add an rectangle.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle rect = new Rectangle(20, 20, 100, 50);
            myPath.AddRectangle(rect);
                     
            // Get the path's array of points.
            PointF[] myPathPointArray = myPath.PathPoints;
                     
            // Create a path gradient brush.
            PathGradientBrush myPGBrush = new
                PathGradientBrush(myPathPointArray);
                     
            // Set the color span.
            myPGBrush.CenterColor = Color.Red;
            Color[] mySurroundColor = {Color.Blue};
            myPGBrush.SurroundColors = mySurroundColor;
                     
            // Draw the brush to the screen prior to transformation.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200);
                     
            // Create a new matrix that rotates by 90 degrees, and
            // translates by 100 in each direction.
            Matrix myMatrix = new Matrix(0, 1, -1, 0, 100, 100);
                     
            // Apply the transform to the brush.
            myPGBrush.MultiplyTransform(myMatrix, MatrixOrder.Append);
                     
            // Draw the brush to the screen again after applying the
            // transform.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 300);
        }
        // </snippet1>


       
        // Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet2>
        public void RotateTransformExample(PaintEventArgs e)
        {
                     
            // Create a graphics path and add an ellipse.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle rect = new Rectangle(100, 20, 100, 50);
            myPath.AddRectangle(rect);
                     
            // Get the path's array of points.
            PointF[] myPathPointArray = myPath.PathPoints;
                     
            // Create a path gradient brush.
            PathGradientBrush myPGBrush = new
                PathGradientBrush(myPathPointArray);
                     
            // Set the color span.
            myPGBrush.CenterColor = Color.Red;
            Color[] mySurroundColor = {Color.Blue};
            myPGBrush.SurroundColors = mySurroundColor;
                     
            // Draw the brush to the screen prior to transformation.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200);
                     
            // Apply the rotate transform to the brush.
            myPGBrush.RotateTransform(45, MatrixOrder.Append);
                     
            // Draw the brush to the screen again after applying the
            // transform.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 300);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet3>
        public void ScaleTransformExample(PaintEventArgs e)
        {
                     
            // Create a graphics path and add a rectangle.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle rect = new Rectangle(100, 20, 100, 50);
            myPath.AddRectangle(rect);
                     
            // Get the path's array of points.
            PointF[] myPathPointArray = myPath.PathPoints;
                     
            // Create a path gradient brush.
            PathGradientBrush myPGBrush = new
                PathGradientBrush(myPathPointArray);
                     
            // Set the color span.
            myPGBrush.CenterColor = Color.Red;
            Color[] mySurroundColor = {Color.Blue};
            myPGBrush.SurroundColors = mySurroundColor;
                     
            // Draw the brush to the screen prior to transformation.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200);
                     
            // Scale by a factor of 2 in the x-axis by applying the scale
            // transform to the brush.
            myPGBrush.ScaleTransform(2, 1, MatrixOrder.Append);
                     
            // Move the brush down by 100 by Applying the translate
            // transform to the brush.
            myPGBrush.TranslateTransform(-100, 100, MatrixOrder.Append);
                     
            // Draw the brush to the screen again after applying the
            // transforms.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300);
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.SetBlendTriangularShape(System.Single,System.Single)
        // <snippet4>
        public void SetBlendTriangularShapeExample(PaintEventArgs e)
        {
                     
            // Create a graphics path and add a rectangle.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle rect = new Rectangle(100, 20, 100, 50);
            myPath.AddRectangle(rect);
                     
            // Get the path's array of points.
            PointF[] myPathPointArray = myPath.PathPoints;
                     
            // Create a path gradient brush.
            PathGradientBrush myPGBrush = new
                PathGradientBrush(myPathPointArray);
                     
            // Set the color span.
            myPGBrush.CenterColor = Color.Red;
            Color[] mySurroundColor = {Color.Blue};
            myPGBrush.SurroundColors = mySurroundColor;
                     
            // Draw the brush to the screen prior to the blend.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200);
                     
            // Set the Blend factors.
            myPGBrush.SetBlendTriangularShape(0.5f, 1.0f);
                     
            // Move the brush down by 100 by Applying the translate
            // transform to the brush.
            myPGBrush.TranslateTransform(0, 100, MatrixOrder.Append);
                     
            // Draw the brush to the screen again after applying the
            // transforms.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.SetSigmaBellShape(System.Single,System.Single)
        // <snippet5>
        public void SetSigmaBellShapeExample(PaintEventArgs e)
        {
                     
            // Create a graphics path and add a rectangle.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle rect = new Rectangle(100, 20, 100, 50);
            myPath.AddRectangle(rect);
                     
            // Get the path's array of points.
            PointF[] myPathPointArray = myPath.PathPoints;
                     
            // Create a path gradient brush.
            PathGradientBrush myPGBrush = new
                PathGradientBrush(myPathPointArray);
                     
            // Set the color span.
            myPGBrush.CenterColor = Color.Red;
            Color[] mySurroundColor = {Color.Blue};
            myPGBrush.SurroundColors = mySurroundColor;
                     
            // Draw the brush to the screen prior to blend.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200);
                     
            // Set the Blend factors and transform the brush.
            myPGBrush.SetSigmaBellShape(0.5f, 1.0f);
                     
            // Move the brush down by 100 by applying the translate
            // transform to the brush.
            myPGBrush.TranslateTransform(0, 100, MatrixOrder.Append);
                     
            // Draw the brush to the screen again after setting the
            // blend and applying the transform.
            e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300);
        }
        // </snippet5>


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
