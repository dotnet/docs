public:
   void RotateTransformExample( PaintEventArgs^ e )
   {
      // Create a graphics path and add an ellipse.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Rectangle rect = Rectangle(100,20,100,50);
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

      // Apply the rotate transform to the brush.
      myPGBrush->RotateTransform( 45, MatrixOrder::Append );

      // Draw the brush to the screen again after applying the
      // transform.
      e->Graphics->FillRectangle( myPGBrush, 10, 10, 200, 300 );
   }