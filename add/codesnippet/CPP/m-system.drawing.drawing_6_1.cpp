private:
   void ResetTransformExample( PaintEventArgs^ e )
   {
      // Create a LinearGradientBrush.
      Rectangle myRect = Rectangle(20,20,200,100);
      LinearGradientBrush^ myLGBrush = gcnew LinearGradientBrush( myRect,Color::Blue,Color::Red,0.0f,true );

      // Draw an ellipse to the screen using the LinearGradientBrush.
      e->Graphics->FillEllipse( myLGBrush, myRect );

      // Transform the LinearGradientBrush.
      array<Point>^ transformArray = {Point(20,150),Point(400,150),Point(20,200)};
      Matrix^ myMatrix = gcnew Matrix( myRect,transformArray );
      myLGBrush->MultiplyTransform( myMatrix, MatrixOrder::Prepend );

      // Draw a second ellipse to the screen
      // using the transformed brush.
      e->Graphics->FillEllipse( myLGBrush, 20, 150, 380, 50 );

      // Reset the brush transform.
      myLGBrush->ResetTransform();

      // Draw a third ellipse to the screen using the reset brush.
      e->Graphics->FillEllipse( myLGBrush, 20, 250, 200, 100 );
   }