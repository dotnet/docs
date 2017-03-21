public:
   void MultiplyTransformExample( PaintEventArgs^ e )
   {
      // Create a graphics path and add an rectangle.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Rectangle rect = Rectangle(20,20,100,50);
      myPath->AddRectangle( rect );

      // Get the path's array of points.
      array<PointF>^myPathPointArray = myPath->PathPoints;

      // Create a path gradient brush.
      PathGradientBrush^ myPGBrush = gcnew PathGradientBrush( myPathPointArray );

      // Set the color span.
      myPGBrush->CenterColor = Color::Red;
      array<Color>^ mySurroundColor = {Color::Blue};
      myPGBrush->SurroundColors = mySurroundColor;

      // Draw the brush to the screen prior to transformation.
      e->Graphics->FillRectangle( myPGBrush, 10, 10, 200, 200 );

      // Create a new matrix that rotates by 90 degrees, and
      // translates by 100 in each direction.
      Matrix^ myMatrix = gcnew Matrix( 0,1,-1,0,100,100 );

      // Apply the transform to the brush.
      myPGBrush->MultiplyTransform( myMatrix, MatrixOrder::Append );

      // Draw the brush to the screen again after applying the
      // transform.
      e->Graphics->FillRectangle( myPGBrush, 10, 10, 200, 300 );
   }