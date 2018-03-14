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

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
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

   /// <summary>
   /// The main entry point for the application.
   /// </summary>
   /// 

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.CopyData(System.Drawing.PointF[]@,System.Byte[]@,System.Int32,System.Int32)
   // <snippet1>
public:
   void CopyDataExample( PaintEventArgs^ e )
   {
      // Create a graphics path.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up a points array.
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};

      // Create a rectangle.
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add the points, rectangle, and an ellipse to the path.
      myPath->AddLines( myPoints );
      myPath->SetMarkers();
      myPath->AddRectangle( myRect );
      myPath->SetMarkers();
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path, and arrays of
      // the  points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for listing the array of points on the left
      // side of the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // List the set of points and types and types to the left side
      // of the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator for myPath and rewind it.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      myPathIterator->Rewind();

      // Set up the arrays to receive the copied data.
      array<PointF>^points = gcnew array<PointF>(myPathIterator->Count);
      array<Byte>^types = gcnew array<Byte>(myPathIterator->Count);
      int myStartIndex;
      int myEndIndex;
      
      // Increment the starting index to the second marker in the
      // path.
      myPathIterator->NextMarker( myStartIndex, myEndIndex );
      myPathIterator->NextMarker( myStartIndex, myEndIndex );
      
      // Copy all the points and types from the starting index to the
      // ending index to the points array and the types array
      // respectively.
      int numPointsCopied = myPathIterator->CopyData( points, types, myStartIndex, myEndIndex );
      
      // List the copied points to the right side of the screen.
      j = 20;
      int copiedStartIndex = 0;
      for ( i = 0; i < numPointsCopied; i++ )
      {
         copiedStartIndex = myStartIndex + i;
         e->Graphics->DrawString( String::Format( "Point: {0}, Value: {1}, Type: {2}", copiedStartIndex, points[ i ], types[ i ] ), myFont, myBrush, 200, j );
         j += 20;

      }
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.Enumerate(System.Drawing.PointF[]@,System.Byte[]@)
   // <snippet2>
public:
   void EnumerateExample( PaintEventArgs^ e )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path, and arrays of
      // the  points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for listing the array of points on the left
      // side of the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // List the set of points and types and types to the left side
      // of the screen.
      e->Graphics->DrawString( "Original Data", myFont, myBrush, 20, j );
      j += 20;
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator for myPath.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      myPathIterator->Rewind();
      array<PointF>^points = gcnew array<PointF>(myPathIterator->Count);
      array<Byte>^types = gcnew array<Byte>(myPathIterator->Count);

      // int numPoints = myPathIterator->Enumerate(&points, &types);
      // Draw the set of copied points and types to the screen.
      j = 20;
      e->Graphics->DrawString( "Copied Data", myFont, myBrush, 200, j );
      j += 20;
      for ( i = 0; i < points->Length; i++ )
      {
         e->Graphics->DrawString( String::Format( "Point: {0}, Value: {1}, Type: {2}", i, points[ i ], types[ i ] ), myFont, myBrush, 200, j );
         j += 20;
      }
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.HasCurve
   // <snippet3>
private:
   void HasCurveExample( PaintEventArgs^ /*e*/ )
   {
      // Create a path and add three lines,
      // a rectangle and an ellipse.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Create a GraphicsPathIterator for myPath.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Test for a curve.
      bool myHasCurve = myPathIterator->HasCurve();

      // Show the test result.
      MessageBox::Show( myHasCurve.ToString() );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextMarker(System.Drawing.Drawing2D.GraphicsPath)
   // <snippet4>
public:
   void NextMarkerExample2( PaintEventArgs^ e )
   {
      // Create a graphics path.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up primitives to add to myPath.
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, an ellipse, and 2 markers.
      myPath->AddLines( myPoints );
      myPath->SetMarkers();
      myPath->AddRectangle( myRect );
      myPath->SetMarkers();
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for listing all the values of the path's
      // points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // List the values for all of path points and types to
      // the left side of the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Rewind the iterator.
      myPathIterator->Rewind();

      // Create a GraphicsPath to receive a section of myPath.
      GraphicsPath^ myPathSection = gcnew GraphicsPath;

      // Retrieve and list the number of points contained in
      // the first marker to the right side of the screen.
      int markerPoints;
      markerPoints = myPathIterator->NextMarker( myPathSection );
      e->Graphics->DrawString( String::Format( "Marker: 1  Num Points: {0}", markerPoints ), myFont, myBrush, 200, 20 );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextMarker(System.Int32@,System.Int32@)
   // <snippet5>
private:
   void NextMarkerExample( PaintEventArgs^ e )
   {
      // Create the GraphicsPath.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, an ellipse, and 2 markers.
      myPath->AddLines( myPoints );
      myPath->SetMarkers();
      myPath->AddRectangle( myRect );
      myPath->SetMarkers();
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for drawing the array
      // of points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // Draw the set of path points and types to the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      int myStartIndex;
      int myEndIndex;

      // Rewind the Iterator.
      myPathIterator->Rewind();

      // Draw the Markers and their start and end points
      // to the screen.
      j = 20;
      for ( i = 0; i < 3; i++ )
      {
         myPathIterator->NextMarker( myStartIndex, myEndIndex );
         e->Graphics->DrawString( String::Format( "Marker {0}:  Start: {1}  End: {2}", i, myStartIndex, myEndIndex ),
               myFont, myBrush, 200, j );
         j += 20;
      }

      // Draw the total number of points to the screen.
      j += 20;
      int myPathTotalPoints = myPathIterator->Count;
      e->Graphics->DrawString( String::Format( "Total Points = {0}", myPathTotalPoints ), myFont, myBrush, 200, j );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextPathType(System.Byte@,System.Int32@,System.Int32@)
   // <snippet6>
public:
   void NextPathTypeExample( PaintEventArgs^ e )
   {
      // Create the GraphicsPath.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, and an ellipse.
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // List all of the path points to the screen.
      ListPathPoints( e, myPath, nullptr, 20, 1 );

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Rewind the Iterator.
      myPathIterator->Rewind();

      // Iterate the subpaths and types, and list the results to
      // the screen.
            int i;
      int j = 20;
      int mySubPaths;
      int subPathStartIndex;
      int subPathEndIndex;
      Boolean IsClosed;
      Byte subPathPointType;
      int pointTypeStartIndex;
      int pointTypeEndIndex;
      int numPointsFound;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );
      j = 20;
      for ( i = 0; i < 3; i++ )
      {
         mySubPaths = myPathIterator->NextSubpath( subPathStartIndex, subPathEndIndex, IsClosed );
         numPointsFound = myPathIterator->NextPathType( subPathPointType, pointTypeStartIndex, pointTypeEndIndex );
         e->Graphics->DrawString( String::Format( "SubPath: {0}  Points Found: {1}  Type of Points: {2}", i,
               numPointsFound, subPathPointType ), myFont, myBrush, 200.0f, (float)j );
         j += 20;
      }

      // List the total number of path points to the screen.
      ListPathPoints( e, myPath, myPathIterator, 200, 2 );
   }

   //-------------------------------------------------------
   //This function is a helper function used by
   // NextPathTypeExample.
   //-------------------------------------------------------
   void ListPathPoints( PaintEventArgs^ e, GraphicsPath^ myPath, GraphicsPathIterator^ myPathIterator, int xOffset, int listType )
   {
      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for drawing the points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );
      if ( listType == 1 )
      {
         // Draw the set of path points and types to the screen.
         for ( i = 0; i < myPathPointCount; i++ )
         {
            e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ],
                  myFont, myBrush, (float)xOffset, (float)j );
            j += 20;
         }
      }
      else
      if ( listType == 2 )
      {
         // Draw the total number of points to the screen.
         int myPathTotalPoints = myPathIterator->Count;
         e->Graphics->DrawString( String::Format( "Total Points = {0}", myPathTotalPoints ), myFont, myBrush, (float)xOffset, 100.0f );
      }
      else
      {
         e->Graphics->DrawString( "Wrong or no list type argument.", myFont, myBrush, (float)xOffset, 200.0f );
      }
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextSubpath(System.Drawing.Drawing2D.GraphicsPath,System.Boolean@)
   // <snippet7>
   void NextSubpathExample2( PaintEventArgs^ e )
   {
      // Create a graphics path.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up primitives to add to myPath.
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, an ellipse, and 2 markers.
      myPath->AddLines( myPoints );
      myPath->SetMarkers();
      myPath->AddRectangle( myRect );
      myPath->SetMarkers();
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for listing all of the path's
      // points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // List the values of all the path points and types to the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator for myPath.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Rewind the iterator.
      myPathIterator->Rewind();

      // Create the GraphicsPath section.
      GraphicsPath^ myPathSection = gcnew GraphicsPath;

      // Iterate to the 3rd subpath and list the number of points therein
      // to the screen.
      int subpathPoints;
      bool IsClosed2;

      // Iterate to the third subpath.
      subpathPoints = myPathIterator->NextSubpath( myPathSection, IsClosed2 );
      subpathPoints = myPathIterator->NextSubpath( myPathSection, IsClosed2 );
      subpathPoints = myPathIterator->NextSubpath( myPathSection, IsClosed2 );

      // Write the number of subpath points to the screen.
      e->Graphics->DrawString( String::Format( "Subpath: 3   Num Points: {0}", subpathPoints ), myFont, myBrush, 200, 20 );
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextSubpath(System.Int32@,System.Int32@,System.Boolean@)
   // <snippet8>
private:
   void NextSubpathExample( PaintEventArgs^ e )
   {
      // Create the GraphicsPath.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, an ellipse, and 2 markers.
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for drawing the array of
      // points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // Draw the set of path points and types to the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      int myStartIndex;
      int myEndIndex;
      bool myIsClosed;

      // get the number of Subpaths.
      int numSubpaths = myPathIterator->NextSubpath( myPath, myIsClosed );
      numSubpaths -= 1;

      // Rewind the Iterator.
      myPathIterator->Rewind();

      // List the Subpaths to the screen.
      j = 20;
      for ( i = 0; i < numSubpaths; i++ )
      {
         myPathIterator->NextSubpath( myStartIndex, myEndIndex, myIsClosed );
         String^ s = String::Format( "Subpath {0}:  Start: {1}", i, myStartIndex );
         s = s + String::Format( "  End: {0}  IsClosed: {1}", myEndIndex, myIsClosed );
         e->Graphics->DrawString( s, myFont, myBrush, 200, j );
         j += 20;
      }

      // Draw the total number of Subpaths to the screen.
      j += 20;
      e->Graphics->DrawString( String::Format( "Number Subpaths = {0}", numSubpaths ), myFont, myBrush, 200, j );
   }
   // </snippet8>
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
