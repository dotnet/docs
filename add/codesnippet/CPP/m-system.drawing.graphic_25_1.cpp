public:
   void SetClipRectangle( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      Rectangle clipRect = Rectangle(0,0,100,100);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }