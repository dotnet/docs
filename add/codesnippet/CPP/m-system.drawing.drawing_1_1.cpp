public:
   void TransformPointsExample( PaintEventArgs^ e )
   {
      Pen^ myPen = gcnew Pen( Color::Blue,1.0f );
      Pen^ myPen2 = gcnew Pen( Color::Red,1.0f );

      // Create an array of points.
      array<Point>^ myArray = {Point(20,20),Point(120,20),Point(120,120),Point(20,120),Point(20,20)};

      // Draw the Points to the screen before applying the
      // transform.
      e->Graphics->DrawLines( myPen, myArray );

      // Create a matrix and scale it.
      Matrix^ myMatrix = gcnew Matrix;
      myMatrix->Scale( 3, 2, MatrixOrder::Append );
      myMatrix->TransformPoints( myArray );

      // Draw the Points to the screen again after applying the
      // transform.
      e->Graphics->DrawLines( myPen2, myArray );
   }