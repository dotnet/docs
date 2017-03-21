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