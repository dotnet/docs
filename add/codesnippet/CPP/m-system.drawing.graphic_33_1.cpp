public:
   void TranslateClipInt( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      Rectangle clipRect = Rectangle(0,0,100,100);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Translate clipping region.
      int dx = 50;
      int dy = 50;
      e->Graphics->TranslateClip( dx, dy );

      // Fill rectangle to demonstrate translated clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }