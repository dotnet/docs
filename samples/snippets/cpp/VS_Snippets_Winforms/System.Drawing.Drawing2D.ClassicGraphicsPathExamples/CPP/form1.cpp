#using <System.Data.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Drawing2D;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

protected:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddArc(System.Drawing.Rectangle,System.Single,System.Single)
   // <snippet1>
private:
   void AddArcExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up and call AddArc, and close the figure.
      Rectangle rect = Rectangle(20,20,50,100);
      myPath->StartFigure();
      myPath->AddArc( rect, 0, 180 );
      myPath->CloseFigure();

      // Draw the path to screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Red,3.0f ), myPath );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddBezier(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet2>
private:
   void AddBezierExample( PaintEventArgs^ e )
   {
      // Create a new Path.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Call AddBezier.
      myPath->StartFigure();
      myPath->AddBezier( 50, 50, 70, 0, 100, 120, 150, 50 );

      // Close the curve.
      myPath->CloseFigure();

      // Draw the path to screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Red,2.0f ), myPath );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddBeziers(System.Drawing.Point[])
   // <snippet3>
private:
   void AddBeziersExample( PaintEventArgs^ e )
   {
      // Adds two Bezier curves.
      array<Point>^ myArray = {Point(20,100),Point(40,75),Point(60,125),Point(80,100),Point(100,50),Point(120,150),Point(140,100)};

      // Create the path and add the curves.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddBeziers( myArray );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddClosedCurve(System.Drawing.Point[],System.Single)
   // <snippet4>
private:
   void AddClosedCurveExample( PaintEventArgs^ e )
   {
      // Creates a symetrical, closed curve.
      array<Point>^ myArray = {Point(20,100),Point(40,150),Point(60,125),Point(40,100),Point(60,75),Point(40,50)};

      // Create a new path and add curve.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddClosedCurve( myArray, .5f );
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );

      // Draw the path to screen.
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddCurve(System.Drawing.Point[],System.Int32,System.Int32,System.Single)
   // <snippet5>
private:
   void AddCurveExample( PaintEventArgs^ e )
   {
      // Create some points.
      Point point1 = Point(20,20);
      Point point2 = Point(40,0);
      Point point3 = Point(60,40);
      Point point4 = Point(80,20);

      // Create an array of the points.
      array<Point>^ curvePoints = {point1,point2,point3,point4};

      // Create a GraphicsPath object and add a curve.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddCurve( curvePoints, 0, 3, 0.8f );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddEllipse(System.Drawing.Rectangle)
   // <snippet6>
private:
   void AddEllipseExample( PaintEventArgs^ e )
   {
      // Create a path and add an ellipse.
      Rectangle myEllipse = Rectangle(20,20,100,50);
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( myEllipse );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddLine(System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet7>
private:
   void AddLineExample( PaintEventArgs^ e )
   {
      //Create a path and add a symetrical triangle using AddLine.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( 30, 30, 60, 60 );
      myPath->AddLine( 60, 60, 0, 60 );
      myPath->AddLine( 0, 60, 30, 30 );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddLines(System.Drawing.Point[])
   // <snippet8>
private:
   void AddLinesExample( PaintEventArgs^ e )
   {
      // Create a symetrical triangle using an array of points.
      array<Point>^ myArray = {Point(30,30),Point(60,60),Point(0,60),Point(30,30)};

      //Create a path and add lines.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLines( myArray );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet8>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddPath(System.Drawing.Drawing2D.GraphicsPath,System.Boolean)
   // <snippet9>
private:
   void AddPathExample( PaintEventArgs^ e )
   {
      // Create the first pathright side up triangle.
      array<Point>^ myArray = {Point(30,30),Point(60,60),Point(0,60),Point(30,30)};
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLines( myArray );

      // Create the second pathinverted triangle.
      array<Point>^ myArray2 = {Point(30,30),Point(0,0),Point(60,0),Point(30,30)};
      GraphicsPath^ myPath2 = gcnew GraphicsPath;
      myPath2->AddLines( myArray2 );

      // Add the second path to the first path.
      myPath->AddPath( myPath2, true );

      // Draw the combined path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet9>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddPie(System.Int32,System.Int32,System.Int32,System.Int32,System.Single,System.Single)
   // <snippet10>
private:
   void AddPieExample( PaintEventArgs^ e )
   {
      // Create a pie slice of a circle using the AddPie method.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddPie( 20, 20, 70, 70, -45, 90 );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet10>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddPolygon(System.Drawing.Point[])
   // <snippet11>
private:
   void AddPolygonExample( PaintEventArgs^ e )
   {
      // Create an array of points.
      array<Point>^ myArray = {Point(23,20),Point(40,10),Point(57,20),Point(50,40),Point(30,40)};

      // Create a GraphicsPath object and add a polygon.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddPolygon( myArray );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet11>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddRectangle(System.Drawing.Rectangle)
   // <snippet12>
private:
   void AddRectangleExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object and add a rectangle to it.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Rectangle pathRect = Rectangle(20,20,100,200);
      myPath->AddRectangle( pathRect );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet12>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddRectangles(System.Drawing.Rectangle[])
   // <snippet13>
private:
   void AddRectanglesExample( PaintEventArgs^ e )
   {
      // Adds a pattern of rectangles to a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Rectangle>^ pathRects = {Rectangle(20,20,100,200),Rectangle(40,40,120,220),Rectangle(60,60,240,140)};
      myPath->AddRectangles( pathRects );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet13>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.AddString(System.String,System.Drawing.FontFamily,System.Int32,System.Single,System.Drawing.Point,System.Drawing.StringFormat)
   // <snippet14>
private:
   void AddStringExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up all the string parameters.
      String^ stringText = "Sample Text";
      FontFamily^ family = gcnew FontFamily( "Arial" );
      int fontStyle = (int)FontStyle::Italic;
      int emSize = 26;
      Point origin = Point(20,20);
      StringFormat^ format = StringFormat::GenericDefault;

      // Add the string to the path.
      myPath->AddString( stringText, family, fontStyle, (float)emSize, origin, format );

      //Draw the path to the screen.
      e->Graphics->FillPath( Brushes::Black, myPath );
   }
   // </snippet14>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.ClearMarkers
   // <snippet15>
private:
   void ClearMarkersExample( PaintEventArgs^ e )
   {
      // Set several markers in a path.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( 0, 0, 100, 200 );
      myPath->SetMarkers();
      myPath->AddLine( Point(100,100), Point(200,100) );
      Rectangle rect = Rectangle(200,0,100,200);
      myPath->AddRectangle( rect );
      myPath->SetMarkers();
      myPath->AddLine( Point(250,200), Point(250,300) );
      myPath->SetMarkers();

      // Clear the markers.
      myPath->ClearMarkers();

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }
   // </snippet15>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Clone
   // <snippet16>
private:
   void CloneExample( PaintEventArgs^ e )
   {
      // Set several markers in a path.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( 0, 0, 100, 200 );
      myPath->AddLine( Point(100,100), Point(200,100) );
      Rectangle rect = Rectangle(200,0,100,200);
      myPath->AddRectangle( rect );
      myPath->AddLine( Point(250,200), Point(250,300) );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );

      // Clone a copy of myPath.
      GraphicsPath^ myPath2 = dynamic_cast<GraphicsPath^>(myPath->Clone());

      // Draw the path to the screen.
      Pen^ myPen2 = gcnew Pen( Color::Red,4.0f );
      e->Graphics->DrawPath( myPen2, myPath2 );
   }
   // </snippet16>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.CloseAllFigures
   // <snippet17>
private:
   void CloseAllFiguresExample( PaintEventArgs^ e )
   {
      // Create a path containing several open-ended figures.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->StartFigure();
      myPath->AddLine( Point(10,10), Point(150,10) );
      myPath->AddLine( Point(150,10), Point(10,150) );
      myPath->StartFigure();
      myPath->AddArc( 200, 200, 100, 100, 0, 90 );
      myPath->StartFigure();
      Point point1 = Point(300,300);
      Point point2 = Point(400,325);
      Point point3 = Point(400,375);
      Point point4 = Point(300,400);
      array<Point>^ points = {point1,point2,point3,point4};
      myPath->AddCurve( points );

      // Close all the figures.
      myPath->CloseAllFigures();

      // Draw the path to the screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Black,3.0f ), myPath );
   }
   // </snippet17>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.CloseFigure
   // <snippet18>
private:
   void CloseFigureExample( PaintEventArgs^ e )
   {
      // Create a path consisting of two, open-ended lines and close
      // the lines using CloseFigure.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->StartFigure();
      myPath->AddLine( Point(10,10), Point(200,10) );
      myPath->AddLine( Point(200,10), Point(200,200) );
      myPath->CloseFigure();

      // Draw the path to the screen.
      e->Graphics->DrawPath( Pens::Black, myPath );
   }
   // </snippet18>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Flatten(System.Drawing.Drawing2D.Matrix,System.Single)
   // <snippet19>
private:
   void FlattenExample( PaintEventArgs^ e )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Matrix^ translateMatrix = gcnew Matrix;
      translateMatrix->Translate( 0, 10 );
      Point point1 = Point(20,100);
      Point point2 = Point(70,10);
      Point point3 = Point(130,200);
      Point point4 = Point(180,100);
      array<Point>^ points = {point1,point2,point3,point4};
      myPath->AddCurve( points );
      e->Graphics->DrawPath( gcnew Pen( Color::Black,2.0f ), myPath );
      myPath->Flatten( translateMatrix, 10.0f );
      e->Graphics->DrawPath( gcnew Pen( Color::Red,1.0f ), myPath );
   }
   // </snippet19>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.GetBounds
   // <snippet20>
public:
   void GetBoundsExample( PaintEventArgs^ e )
   {
      // Create path number 1 and a Pen for drawing.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Pen^ pathPen = gcnew Pen( Color::Black,1.0f );

      // Add an Ellipse to the path and Draw it (circle in start
      // position).
      myPath->AddEllipse( 20, 20, 100, 100 );
      e->Graphics->DrawPath( pathPen, myPath );

      // Get the path bounds for Path number 1 and draw them.
      RectangleF boundRect = myPath->GetBounds();
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), boundRect.X, boundRect.Y, boundRect.Height, boundRect.Width );

      // Create a second graphics path and a wider Pen.
      GraphicsPath^ myPath2 = gcnew GraphicsPath;
      Pen^ pathPen2 = gcnew Pen( Color::Black,10.0f );

      // Create a new ellipse with a width of 10.
      myPath2->AddEllipse( 150, 20, 100, 100 );
      myPath2->Widen( pathPen2 );
      e->Graphics->FillPath( Brushes::Black, myPath2 );

      // Get the second path bounds.
      RectangleF boundRect2 = myPath2->GetBounds();

      // Draw the bounding rectangle.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), boundRect2.X, boundRect2.Y, boundRect2.Height, boundRect2.Width );

      // Display the rectangle size.
      MessageBox::Show( boundRect2.ToString() );
   }
   // </snippet20>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.GetLastPoint
   // <snippet21>
private:
   void GetLastPointExample( PaintEventArgs^ /*e*/ )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( 20, 20, 100, 20 );
      PointF lastPoint = myPath->GetLastPoint();
      if ( lastPoint.IsEmpty == false )
      {
         String^ lastPointXString = lastPoint.X.ToString();
         String^ lastPointYString = lastPoint.Y.ToString();
         MessageBox::Show( String::Concat( lastPointXString, ", ", lastPointYString ) );
      }
      else
            MessageBox::Show( "lastPoint is empty" );
   }
   // </snippet21>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.IsOutlineVisible(System.Int32,System.Int32,System.Drawing.Pen,System.Drawing.Graphics)
   // <snippet22>
public:
   void IsOutlineVisibleExample( PaintEventArgs^ e )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Rectangle rect = Rectangle(20,20,100,100);
      myPath->AddRectangle( rect );
      Pen^ testPen = gcnew Pen( Color::Black,20.0f );
      myPath->Widen( testPen );
      e->Graphics->FillPath( Brushes::Black, myPath );
      bool visible = myPath->IsOutlineVisible( 100, 50, testPen, e->Graphics );
      MessageBox::Show( String::Format( "visible = {0}", visible ) );
   }
   // </snippet22>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.IsVisible(System.Int32,System.Int32,System.Drawing.Graphics)
   // <snippet23>
private:
   void IsVisibleExample( PaintEventArgs^ e )
   {
      
      // Create a path and add an ellipse.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( 0, 0, 100, 100 );
      
      // Test the visibility of point (50, 50).
      bool visible = myPath->IsVisible( 50, 50, e->Graphics );
      
      // Show the result.
      MessageBox::Show( visible.ToString() );
   }
   // </snippet23>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Reset
   // <snippet24>
public:
   void GraphicsPathResetExample( PaintEventArgs^ e )
   {
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      
      // Create a path and add a line, an ellipse, and an arc.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( Point(0,0), Point(100,100) );
      myPath->AddEllipse( 100, 100, 200, 250 );
      myPath->AddArc( 300, 250, 100, 100, 0, 90 );
      
      // Draw the pre-reset points array to the screen.
      DrawPoints1( e, myPath->PathPoints, 20 );
      
      // Reset the path.
      myPath->Reset();
      
      // See if any points remain.
      if ( myPath->PointCount > 0 )
      {
         
         // Draw the post-reset points array to the screen.
         DrawPoints1( e, myPath->PathPoints, 150 );
      }
      else
            e->Graphics->DrawString( "No Points", myFont, Brushes::Black, 150, 20 );
      // If there are no points, say so.
   }


   //End GraphicsPathResetExample
   // A helper function GraphicsPathResetExample uses to draw the points.
   // to the screen.
   void DrawPoints1( PaintEventArgs^ e, array<PointF>^ pathPoints, int xOffset )
   {
      int y = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      for ( int i = 0; i < pathPoints->Length; i++ )
      {
         e->Graphics->DrawString( String::Concat( pathPoints[ i ].X, ", ", pathPoints[ i ].Y ), myFont, Brushes::Black, (float)xOffset, (float)y );
         y += 20;

      }
   }
   // End DrawPoints
   // </snippet24>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Reverse
   // <snippet25>
   void GraphicsPathReverseExample( PaintEventArgs^ e )
   {
      // Create a path and add a line, ellipse, and arc.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( Point(0,0), Point(100,100) );
      myPath->AddEllipse( 100, 100, 200, 250 );
      myPath->AddArc( 300, 250, 100, 100, 0, 90 );

      // Draw the first set of points to the screen.
      DrawPoints2( e, myPath->PathPoints, 20 );

      // Call GraphicsPath.Reverse.
      myPath->Reverse();

      // Draw the reversed set of points to the screen.
      DrawPoints2( e, myPath->PathPoints, 150 );
   }

   //End GraphicsPathReverseExample.
   // A helper function GraphicsPathReverseExample is used to draw the
   // points to the screen.
   void DrawPoints2( PaintEventArgs^ e, array<PointF>^ pathPoints, int xOffset )
   {
      int y = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      for ( int i = 0; i < pathPoints->Length; i++ )
      {
         e->Graphics->DrawString( String::Concat( pathPoints[ i ].X, ", ", pathPoints[ i ].Y ), myFont, Brushes::Black, (float)xOffset, (float)y );
         y += 20;

      }
   }
   // End DrawPoints
   // </snippet25>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.SetMarkers
   // <snippet26>
private:
   void SetMarkersExample( PaintEventArgs^ e )
   {
      // Create a path and set two markers.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( Point(0,0), Point(50,50) );
      myPath->SetMarkers();
      Rectangle rect = Rectangle(50,50,50,50);
      myPath->AddRectangle( rect );
      myPath->SetMarkers();
      myPath->AddEllipse( 100, 100, 100, 50 );

      // Draw the path to screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Black,2.0f ), myPath );
   }
   // </snippet26>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.StartFigure
   // <snippet27>
public:
   void StartFigureExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // First set of figures.
      myPath->StartFigure();
      myPath->AddArc( 10, 10, 50, 50, 0, 270 );
      myPath->AddLine( Point(50,0), Point(100,50) );
      myPath->AddArc( 50, 100, 75, 75, 0, 270 );
      myPath->CloseFigure();
      myPath->StartFigure();
      myPath->AddArc( 100, 10, 50, 50, 0, 270 );

      // Second set of figures.
      myPath->StartFigure();
      myPath->AddArc( 10, 200, 50, 50, 0, 270 );
      myPath->CloseFigure();
      myPath->StartFigure();
      myPath->AddLine( Point(60,200), Point(110,250) );
      myPath->AddArc( 50, 300, 75, 75, 0, 270 );
      myPath->CloseFigure();
      myPath->StartFigure();
      myPath->AddArc( 100, 200, 50, 50, 0, 270 );

      // Draw the path to the screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Black ), myPath );
   }
   // End StartFigureExample
   // </snippet27>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Transform(System.Drawing.Drawing2D.Matrix)
   // <snippet28>
private:
   void TransformExample( PaintEventArgs^ e )
   {
      // Create a path and add and ellipse.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( 0, 0, 100, 200 );

      // Draw the starting position to screen.
      e->Graphics->DrawPath( Pens::Black, myPath );

      // Move the ellipse 100 points to the right.
      Matrix^ translateMatrix = gcnew Matrix;
      translateMatrix->Translate( 100, 0 );
      myPath->Transform(translateMatrix);

      // Draw the transformed ellipse to the screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Red,2.0f ), myPath );
   }
   // </snippet28>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Warp(System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.WarpMode,System.Single)
   // <snippet29>
private:
   void WarpExample( PaintEventArgs^ e )
   {
      // Create a path and add a rectangle.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      RectangleF srcRect = RectangleF(0,0,100,200);
      myPath->AddRectangle( srcRect );

      // Draw the source path (rectangle)to the screen.
      e->Graphics->DrawPath( Pens::Black, myPath );

      // Create a destination for the warped rectangle.
      PointF point1 = PointF(200,200);
      PointF point2 = PointF(400,250);
      PointF point3 = PointF(220,400);
      array<PointF>^ destPoints = {point1,point2,point3};

      // Create a translation matrix.
      Matrix^ translateMatrix = gcnew Matrix;
      translateMatrix->Translate( 100, 0 );

      // Warp the source path (rectangle).
      myPath->Warp( destPoints, srcRect, translateMatrix, WarpMode::Perspective, 0.5f );

      // Draw the warped path (rectangle) to the screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Red ), myPath );
   }
   // </snippet29>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPath.Widen(System.Drawing.Pen,System.Drawing.Drawing2D.Matrix,System.Single)
   // <snippet30>
private:
   void WidenExample( PaintEventArgs^ e )
   {
      // Create a path and add two ellipses.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( 0, 0, 100, 100 );
      myPath->AddEllipse( 100, 0, 100, 100 );

      // Draw the original ellipses to the screen in black.
      e->Graphics->DrawPath( Pens::Black, myPath );

      // Widen the path.
      Pen^ widenPen = gcnew Pen( Color::Black,10.0f );
      Matrix^ widenMatrix = gcnew Matrix;
      widenMatrix->Translate( 50, 50 );
      myPath->Widen( widenPen, widenMatrix, 1.0f );

      // Draw the widened path to the screen in red.
      e->Graphics->FillPath( gcnew SolidBrush( Color::Red ), myPath );
   }
   // </snippet30>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
