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