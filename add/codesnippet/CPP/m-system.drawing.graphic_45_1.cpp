public:
   void TranslateClipFloat( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      RectangleF clipRect = RectangleF(0.0F,0.0F,100.0F,100.0F);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect );

      // Translate clipping region.
      float dx = 50.0F;
      float dy = 50.0F;
      e->Graphics->TranslateClip( dx, dy );

      // Fill rectangle to demonstrate translated clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }