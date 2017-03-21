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