public:
   void GetBoundsExample( PaintEventArgs^ e )
   {
      // Create path number 1 and a Pen for drawing.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Pen^ pathPen = gcnew Pen( Color::Black,1.0f );

      // Add an Ellipse to the path and Draw it (circle in start
      // position).
      myPath->AddEllipse( 20, 20, 100, 100 );
      e->Graphics->DrawPath( pathPen, myPath );

      // Get the path bounds for Path number 1 and draw them.
      RectangleF boundRect = myPath->GetBounds();
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), boundRect.X, boundRect.Y, boundRect.Height, boundRect.Width );

      // Create a second graphics path and a wider Pen.
      GraphicsPath^ myPath2 = gcnew GraphicsPath;
      Pen^ pathPen2 = gcnew Pen( Color::Black,10.0f );

      // Create a new ellipse with a width of 10.
      myPath2->AddEllipse( 150, 20, 100, 100 );
      myPath2->Widen( pathPen2 );
      e->Graphics->FillPath( Brushes::Black, myPath2 );

      // Get the second path bounds.
      RectangleF boundRect2 = myPath2->GetBounds();

      // Draw the bounding rectangle.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), boundRect2.X, boundRect2.Y, boundRect2.Height, boundRect2.Width );

      // Display the rectangle size.
      MessageBox::Show( boundRect2.ToString() );
   }