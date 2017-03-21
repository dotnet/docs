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