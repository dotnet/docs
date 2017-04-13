using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.Drawing2D.ClassicGraphicsPathIteratorCS
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

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
        

        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.CopyData(System.Drawing.PointF[]@,System.Byte[]@,System.Int32,System.Int32)
        // <snippet1>
        public void CopyDataExample(PaintEventArgs e)
        {
                     
            // Create a graphics path.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Set up a points array.
            Point[] myPoints =
                     {
                         new Point(20, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20, 20)
                     };
                     
            // Create a rectangle.
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add the points, rectangle, and an ellipse to the path.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path, and arrays of
            // the  points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for listing the array of points on the left
            // side of the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // List the set of points and types and types to the left side
            // of the screen.
            for(i=0; i<myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j+=20;
            }
                     
            // Create a GraphicsPathIterator for myPath and rewind it.
            GraphicsPathIterator myPathIterator =
                new GraphicsPathIterator(myPath);
            myPathIterator.Rewind();
                     
            // Set up the arrays to receive the copied data.
            PointF[] points = new PointF[myPathIterator.Count];
            byte[] types = new byte[myPathIterator.Count];
            int myStartIndex;
            int myEndIndex;
                     
            // Increment the starting index to the second marker in the
            // path.
            myPathIterator.NextMarker(out myStartIndex, out myEndIndex);
            myPathIterator.NextMarker(out myStartIndex, out myEndIndex);
                     
            // Copy all the points and types from the starting index to the
            // ending index to the points array and the types array
            // respectively.
            int numPointsCopied = myPathIterator.CopyData(
                ref points,
                ref types,
                myStartIndex,
                myEndIndex);
                     
            // List the copied points to the right side of the screen.
            j = 20;
            int copiedStartIndex = 0;
            for(i=0; i<numPointsCopied; i++)
            {
                copiedStartIndex = myStartIndex + i;
                e.Graphics.DrawString(
                    "Point: " + copiedStartIndex.ToString() +
                    ", Value: " + points[i].ToString() +
                    ", Type: " + types[i].ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j+=20;
            }
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.Enumerate(System.Drawing.PointF[]@,System.Byte[]@)
        // <snippet2>
        public void EnumerateExample(PaintEventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            Point[] myPoints =
                     {
                         new Point(20, 20),
                         new Point(120, 120),
                         new Point(20, 120),
                         new Point(20, 20)
                     };
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path, and arrays of
            // the  points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for listing the array of points on the left
            // side of the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // List the set of points and types and types to the left side
            // of the screen.
            e.Graphics.DrawString("Original Data",
                myFont,
                myBrush,
                20,
                j);
            j += 20;
            for(i=0; i<myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j+=20;
            }
                     
            // Create a GraphicsPathIterator for myPath.
            GraphicsPathIterator myPathIterator =
                new GraphicsPathIterator(myPath);
            myPathIterator.Rewind();
            PointF[] points = new PointF[myPathIterator.Count];
            byte[] types = new byte[myPathIterator.Count];
            int numPoints = myPathIterator.Enumerate(ref points, ref types);
                     
            // Draw the set of copied points and types to the screen.
            j = 20;
            e.Graphics.DrawString("Copied Data",
                myFont,
                myBrush,
                200,
                j);
            j += 20;
            for(i=0; i<points.Length; i++)
            {
                e.Graphics.DrawString("Point: " + i +
                    ", " + "Value: " + points[i].ToString() + ", " +
                    "Type: " + types[i].ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j+=20;
            }
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.HasCurve
        // <snippet3>
        private void HasCurveExample(PaintEventArgs e)
        {
                     
            // Create a path and add three lines,
            // a rectangle and an ellipse.
            GraphicsPath myPath = new GraphicsPath();
            
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) }; 

            Rectangle myRect = new Rectangle(120, 120, 100, 100);
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Create a GraphicsPathIterator for myPath.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
                     
            // Test for a curve.
            bool myHasCurve = myPathIterator.HasCurve();
                     
            // Show the test result.
            MessageBox.Show(myHasCurve.ToString());
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextMarker(System.Drawing.Drawing2D.GraphicsPath)
        // <snippet4>
        public void NextMarkerExample2(PaintEventArgs e)
        {
                     
            // Create a graphics path.
            GraphicsPath myPath = new GraphicsPath();
                     
            // Set up primitives to add to myPath.
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) };        
         
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path,
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for listing all the values of the path's
            // points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // List the values for all of path points and types to
            // the left side of the screen.
            for(i=0; i < myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),  myFont, myBrush,
                    20, j);
                    
                j+=20; 
               
            }
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
                     
            // Rewind the iterator.
            myPathIterator.Rewind();
                     
            // Create a GraphicsPath to receive a section of myPath.
            GraphicsPath myPathSection = new GraphicsPath();
                     
            // Retrieve and list the number of points contained in
                     
            // the first marker to the right side of the screen.
            int markerPoints;
            markerPoints = myPathIterator.NextMarker(myPathSection);
            e.Graphics.DrawString("Marker: 1" + "  Num Points: " +
                markerPoints.ToString(),  myFont, myBrush, 200, 20);
                
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextMarker(System.Int32@,System.Int32@)
        // <snippet5>
        private void NextMarkerExample(PaintEventArgs e)
        {
                     
            // Create the GraphicsPath.
            GraphicsPath myPath = new GraphicsPath();
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) }; 

            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path,
                     
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for drawing the array
                     
            // of points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i<myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j+=20;
            }
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
            int myStartIndex;
            int myEndIndex;
                     
            // Rewind the Iterator.
            myPathIterator.Rewind();
                     
            // Draw the Markers and their start and end points
                     
            // to the screen.
            j=20;
            for(i=0;i<3;i++)
            {
                myPathIterator.NextMarker(out myStartIndex, out myEndIndex);
                e.Graphics.DrawString("Marker " + i.ToString() +
                    ":  Start: " + myStartIndex.ToString()+
                    "  End: " + myEndIndex.ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j += 20;
            }
                     
            // Draw the total number of points to the screen.
            j += 20;
            int myPathTotalPoints = myPathIterator.Count;
            e.Graphics.DrawString("Total Points = " +
                myPathTotalPoints.ToString(),
                myFont,
                myBrush,
                200,
                j);
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextPathType(System.Byte@,System.Int32@,System.Int32@)
        // <snippet6>
        public void NextPathTypeExample(PaintEventArgs e)
        {
                     
            // Create the GraphicsPath.
            GraphicsPath myPath = new GraphicsPath();

            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                 new Point(20, 120),new Point(20, 20) }; 
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, and an ellipse.
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // List all of the path points to the screen.
            ListPathPoints(e, myPath, null, 20, 1);
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
                     
            // Rewind the Iterator.
            myPathIterator.Rewind();
                     
            // Iterate the subpaths and types, and list the results to
                     
            // the screen.
            int i, j = 20;
            int mySubPaths, subPathStartIndex, subPathEndIndex;
            Boolean IsClosed;
            byte subPathPointType;
            int pointTypeStartIndex,  pointTypeEndIndex, numPointsFound;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            j = 20;
            for(i = 0;i < 3; i++)
            {
                mySubPaths = myPathIterator.NextSubpath(
                    out subPathStartIndex,
                    out subPathEndIndex,
                    out IsClosed);
                numPointsFound = myPathIterator.NextPathType(
                    out subPathPointType,
                    out pointTypeStartIndex,
                    out pointTypeEndIndex);
                e.Graphics.DrawString(
                    "SubPath: " + i +
                    "  Points Found: " + numPointsFound.ToString() +
                    "  Type of Points: " + subPathPointType.ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j+=20;
            }
                     
            // List the total number of path points to the screen.
            ListPathPoints(e, myPath, myPathIterator, 200, 2);
        }
                     
        //-------------------------------------------------------
        //This function is a helper function used by
        // NextPathTypeExample.
        //-------------------------------------------------------
        public void ListPathPoints(
            PaintEventArgs e,
            GraphicsPath myPath,
            GraphicsPathIterator myPathIterator,
            int xOffset,
            int listType)
        {
                     
            // Get the total number of points for the path,
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for drawing the points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            if (listType == 1) 
                // List all the path points to the screen.
            {
                     
                // Draw the set of path points and types to the screen.
                for(i=0; i<myPathPointCount; i++)
                {
                    e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                        ", " + myPathPoints[i].Y.ToString() + ", " +
                        myPathTypes[i].ToString(),
                        myFont,
                        myBrush,
                        xOffset,
                        j);
                    j+=20;
                }
            }
            else if (listType == 2) 
                // Display the total number of path points.
            {
                     
                // Draw the total number of points to the screen.
                int myPathTotalPoints = myPathIterator.Count;
                e.Graphics.DrawString("Total Points = " +
                    myPathTotalPoints.ToString(),
                    myFont,
                    myBrush,
                    xOffset,
                    100);
            }
            else
            {
                e.Graphics.DrawString("Wrong or no list type argument.",
                    myFont, myBrush, xOffset, 200);
            }
        }
            // </snippet6>


            // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextSubpath(System.Drawing.Drawing2D.GraphicsPath,System.Boolean@)
            // <snippet7>
            public void NextSubpathExample2(PaintEventArgs e)
            {
                     
                // Create a graphics path.
                GraphicsPath myPath = new GraphicsPath();
                     
                // Set up primitives to add to myPath.
                Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                    new Point(20, 120),new Point(20, 20) }; 
                Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
                // Add 3 lines, a rectangle, an ellipse, and 2 markers.
                myPath.AddLines(myPoints);
                myPath.SetMarkers();
                myPath.AddRectangle(myRect);
                myPath.SetMarkers();
                myPath.AddEllipse(220, 220, 100, 100);
                     
                // Get the total number of points for the path,
                     
                // and the arrays of the points and types.
                int myPathPointCount = myPath.PointCount;
                PointF[] myPathPoints = myPath.PathPoints;
                byte[] myPathTypes = myPath.PathTypes;
                     
                // Set up variables for listing all of the path's
                     
                // points to the screen.
                int i;
                float j = 20;
                Font myFont = new Font("Arial", 8);
                SolidBrush myBrush = new SolidBrush(Color.Black);
                     
                // List the values of all the path points and types to the screen.
                for(i=0; i<myPathPointCount; i++)
                {
                    e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                        ", " + myPathPoints[i].Y.ToString() + ", " +
                        myPathTypes[i].ToString(),
                        myFont,
                        myBrush,
                        20,
                        j);
                    j+=20;
                }
                     
                // Create a GraphicsPathIterator for myPath.
                GraphicsPathIterator myPathIterator = new
                    GraphicsPathIterator(myPath);
                     
                // Rewind the iterator.
                myPathIterator.Rewind();
                     
                // Create the GraphicsPath section.
                GraphicsPath myPathSection = new GraphicsPath();
                     
                // Iterate to the 3rd subpath and list the number of points therein
                     
                // to the screen.
                int subpathPoints;
                bool IsClosed2;
                     
                // Iterate to the third subpath.
                subpathPoints = myPathIterator.NextSubpath(
                    myPathSection, out IsClosed2);
                subpathPoints = myPathIterator.NextSubpath(
                    myPathSection, out IsClosed2);
                subpathPoints = myPathIterator.NextSubpath(
                    myPathSection, out IsClosed2);
                     
                // Write the number of subpath points to the screen.
                e.Graphics.DrawString("Subpath: 3"  +
                    "   Num Points: " +
                    subpathPoints.ToString(),
                    myFont,
                    myBrush,
                    200,
                    20);
            }
        // </snippet7>


        // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextSubpath(System.Int32@,System.Int32@,System.Boolean@)
        // <snippet8>
        private void NextSubpathExample(PaintEventArgs e)
        {
                     
            // Create the GraphicsPath.
            GraphicsPath myPath = new GraphicsPath();
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), 
                new Point(20, 120),new Point(20, 20) }; 
            Rectangle myRect = new Rectangle(120, 120, 100, 100);
                     
            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.AddRectangle(myRect);
            myPath.AddEllipse(220, 220, 100, 100);
                     
            // Get the total number of points for the path,
                     
            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;
                     
            // Set up variables for drawing the array of
                     
            // points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
                     
            // Draw the set of path points and types to the screen.
            for(i=0; i < myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString()+
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j+=20;
            }
                     
            // Create a GraphicsPathIterator.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);
            int myStartIndex;
            int myEndIndex;
            bool myIsClosed;
                     
            // get the number of Subpaths.
            int numSubpaths = myPathIterator.NextSubpath(myPath,
                out myIsClosed);
            numSubpaths -= 1;
                     
            // Rewind the Iterator.
            myPathIterator.Rewind();
                     
            // List the Subpaths to the screen.
            j=20;
            for(i=0;i<numSubpaths;i++)
            {
                myPathIterator.NextSubpath(out myStartIndex,
                    out myEndIndex,
                    out myIsClosed);
                e.Graphics.DrawString("Subpath " + i.ToString() +
                    ":  Start: " + myStartIndex.ToString()+
                    "  End: " + myEndIndex.ToString() +
                    "  IsClosed: " + myIsClosed.ToString(),
                    myFont,
                    myBrush,
                    200,
                    j);
                j += 20;
            }
                     
            // Draw the total number of Subpaths to the screen.
            j += 20;
            e.Graphics.DrawString("Number Subpaths = " +
                numSubpaths.ToString(),
                myFont,
                myBrush,
                200,
                j);
        }
        // </snippet8>

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
