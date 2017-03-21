private:
   void RotateTransformExample( PaintEventArgs^ e )
   {
      // Create a LinearGradientBrush.
      Rectangle myRect = Rectangle(20,20,200,100);
      LinearGradientBrush^ myLGBrush = gcnew LinearGradientBrush( myRect,Color::Blue,Color::Red,0.0f,true );

      // Draw an ellipse to the screen using the LinearGradientBrush.
      e->Graphics->FillEllipse( myLGBrush, myRect );

      // Rotate the LinearGradientBrush.
      myLGBrush->RotateTransform( 45.0f, MatrixOrder::Prepend );

      // Rejustify the brush to start at the left edge of the ellipse.
      myLGBrush->TranslateTransform(  -100.0f, 0.0f );

      // Draw a second ellipse to the screen using
      // the transformed brush.
      e->Graphics->FillEllipse( myLGBrush, 20, 150, 200, 100 );
   }