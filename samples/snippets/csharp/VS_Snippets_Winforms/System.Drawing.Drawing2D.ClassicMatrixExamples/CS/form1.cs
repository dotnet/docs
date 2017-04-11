using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.Drawing2D.ClassicMatrixExamplesCS
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


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.Multiply(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet1>
        public void MultiplyExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Set up the matrices.
            Matrix myMatrix1 = new Matrix(
                2.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f);  
            
            Matrix myMatrix2 = new Matrix(
                0.0f, 1.0f, -1.0f, 0.0f, 0.0f, 0.0f); 
          
            Matrix myMatrix3 = new Matrix(
                1.0f, 0.0f, 0.0f, 1.0f, 250.0f, 50.0f);  
         
                     
            // Display the elements of the starting matrix.
            ListMatrixElements(e, myMatrix1, "Beginning Matrix", 6, 40);
                     
            // Multiply Matrix1 by Matrix 2.
            myMatrix1.Multiply(myMatrix2, MatrixOrder.Append);
                     
            // Display the result of the multiplication of Matrix1 and
                     
            // Matrix2.
            ListMatrixElements(e,
                myMatrix1,
                "Matrix After 1st Multiplication",
                6,
                60);
                     
            // Multiply the result from the pervious multiplication by
            // Matrix3.
            myMatrix1.Multiply(myMatrix3, MatrixOrder.Append);
                     
            // Display the result of the previous multiplication
            // multiplied by Matrix3.
            ListMatrixElements1(e,
                myMatrix1,
                "Matrix After 2nd Multiplication",
                6,
                80);
                     
            // Draw the rectangle prior to transformation.
            e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100);
                     
            // Make the transformation.
            e.Graphics.Transform = myMatrix1;
                     
            // Draw the rectangle after transformation.
            e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100);
        }
                     
        //-------------------------------------------------------
        // The following function is a helper function to
        // list the contents of a matrix.
        //-------------------------------------------------------
        public void ListMatrixElements1(
            PaintEventArgs e,
            Matrix matrix,
            string matrixName,
            int numElements,
            int y)
        {
                     
            // Set up variables for drawing the array
            // of points to the screen.
            int i;
            float x = 20, X = 200;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the matrix name to the screen.
            e.Graphics.DrawString(
                matrixName + ":  ",
                myFont,
                myBrush,
                x,
                y);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i<numElements; i++)
            {
                e.Graphics.DrawString(
                    matrix.Elements[i].ToString() + ", ",
                    myFont,
                    myBrush,
                    X,
                    y);
                X += 30;
            }
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.Reset
        // <snippet2>
        public void ResetExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Create a matrix that scales by 5 in the x direction and
            // by 3 in the y direction.
            Matrix myMatrix = new Matrix(
                5.0f, 0.0f, 0.0f, 3.0f, 0.0f, 0.0f); 
                     
            // List the matrix elements to the screen.
            ListMatrixElements(e, myMatrix, "Beginning Matrix", 6, 20);
                     
            // Reset the matrix to identity.
            myMatrix.Reset();
                     
            // Again list the matrix elements to the screen.
            ListMatrixElements2(e, myMatrix, "Matrix After Reset", 6, 40);
                     
            // Translate the matrix by 50 points in the x-axis and 40 points
            // in the y-axis.
            myMatrix.Translate(50.0f, 40.0f); 
          
            // List the matrix elements to the screen.
            ListMatrixElements1(e, myMatrix, "Matrix After Translation", 6, 60);
                     
            // Draw a rectangle to the screen.
            e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100);
                     
            // Apply the matrix transform to the Graphics.
            e.Graphics.Transform = myMatrix;
                     
            // Draw another rectangle to the screen that has the transform
            // applied.
            e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100);
        }
                     
        //-------------------------------------------------------
        // This function is a helper function to
        // list the contents of a matrix.
        //-------------------------------------------------------
        public void ListMatrixElements2(
            PaintEventArgs e,
            Matrix matrix,
            string matrixName,
            int numElements,
            int y)
        {
                     
            // Set up variables for drawing the array
            // of points to the screen.
            int i;
            float x = 20, X = 200;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the matrix name to the screen.
            e.Graphics.DrawString(
                matrixName + ":  ",
                myFont,
                myBrush,
                x,
                y);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i < numElements; i++)
            {
                e.Graphics.DrawString(
                    matrix.Elements[i].ToString() + ", ",
                    myFont,
                    myBrush,
                    X,
                    y);
                X += 30;
            }
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.Rotate(System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet3>
        public void RotateExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Draw the rectangle to the screen before applying the transform.
            e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100);
                     
            // Create a matrix and rotate it 45 degrees.
            Matrix myMatrix = new Matrix();
            myMatrix.Rotate(45, MatrixOrder.Append);
                     
            // Draw the rectangle to the screen again after applying the
                     
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100);
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.RotateAt(System.Single,System.Drawing.PointF,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet4>
        public void RotateAtExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
            PointF rotatePoint = new PointF(150.0f, 50.0f);
                     
            // Draw the rectangle to the screen before applying the
            // transform.
            e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100);
                     
            // Create a matrix and rotate it 45 degrees.
            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(45, rotatePoint, MatrixOrder.Append);
                     
            // Draw the rectangle to the screen again after applying the
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.Scale(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet5>
        public void ScaleExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Draw the rectangle to the screen before applying the
            // transform.
            e.Graphics.DrawRectangle(myPen, 50, 50, 100, 100);
                     
            // Create a matrix and scale it.
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(3, 2, MatrixOrder.Append);
                     
            // Draw the rectangle to the screen again after applying the
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 50, 50, 100, 100);
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.Shear(System.Single,System.Single)
        // <snippet6>
        public void MatrixShearExample(PaintEventArgs e)
        {
            Matrix myMatrix = new Matrix();
            myMatrix.Shear(2, 0);
            e.Graphics.DrawRectangle(new Pen(Color.Green), 0, 0, 100, 50);
            e.Graphics.MultiplyTransform(myMatrix);
            e.Graphics.DrawRectangle(new Pen(Color.Red), 0, 0, 100, 50);
            e.Graphics.DrawEllipse(new Pen(Color.Blue), 0, 0, 100, 50);
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.TransformPoints(System.Drawing.Point[])
        // <snippet7>
        public void TransformPointsExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Create an array of points.
            Point[] myArray =
                     {
                         new Point(20, 20),
                         new Point(120, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20,20)
                     };
                     
            // Draw the Points to the screen before applying the
            // transform.
            e.Graphics.DrawLines(myPen, myArray);
                     
            // Create a matrix and scale it.
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(3, 2, MatrixOrder.Append);
            myMatrix.TransformPoints(myArray);
                     
            // Draw the Points to the screen again after applying the
            // transform.
            e.Graphics.DrawLines(myPen2, myArray);
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.TransformVectors(System.Drawing.Point[])
        // <snippet8>
        public void TransformVectorsExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Create an array of points.
            Point[] myArray =
                     {
                         new Point(20, 20),
                         new Point(120, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20,20)
                     };
                     
            // Draw the Points to the screen before applying the
            // transform.
            e.Graphics.DrawLines(myPen, myArray);
                     
            // Create a matrix, scale it, and translate it.
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(3, 2, MatrixOrder.Append);
            myMatrix.Translate(100, 100, MatrixOrder.Append);
                     
            // List the matrix elements to the screen.
            ListMatrixElements(e,
                myMatrix,
                "Scaled and Translated Matrix",
                6,
                20);
                     
            // Apply the transform to the array.
            myMatrix.TransformVectors(myArray);
                     
            // Draw the Points to the screen again after applying the
            // transform.
            e.Graphics.DrawLines(myPen2, myArray);
        }
                     
        //-------------------------------------------------------
        // This function is a helper function to
        // list the contents of a matrix.
        //-------------------------------------------------------
        public void ListMatrixElements(
            PaintEventArgs e,
            Matrix matrix,
            string matrixName,
            int numElements,
            int y)
        {
                     
            // Set up variables for drawing the array
            // of points to the screen.
            int i;
            float x = 20, X = 200;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the matrix name to the screen.
            e.Graphics.DrawString(
                matrixName + ":  ",
                myFont,
                myBrush,
                x,
                y);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i<numElements; i++)
            {
                e.Graphics.DrawString(
                    matrix.Elements[i].ToString() + ", ",
                    myFont,
                    myBrush,
                    X,
                    y);
                X += 30;
            }
        }
        // </snippet8>


        // Snippet for: M:System.Drawing.Drawing2D.Matrix.Translate(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet9>
        public void TranslateExample(PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            Pen myPen2 = new Pen(Color.Red, 1);
                     
            // Draw a rectangle to the screen before applying the
            // transform.
            e.Graphics.DrawRectangle(myPen, 20, 20, 100, 50);
                     
            // Create a matrix and translate it.
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(100, 100, MatrixOrder.Append);
                     
            // Draw the Points to the screen again after applying the
            // transform.
            e.Graphics.Transform = myMatrix;
            e.Graphics.DrawRectangle(myPen2, 20, 20, 100, 50);
        }
        // </snippet9>

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
