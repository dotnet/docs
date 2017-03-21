public:
   void SetClipRectangleFCombine( PaintEventArgs^ e )
   {
      // Create rectangle for clipping region.
      RectangleF clipRect = RectangleF(0.0F,0.0F,100.0F,100.0F);

      // Set clipping region of graphics to rectangle.
      e->Graphics->SetClip( clipRect, CombineMode::Replace );

      // Fill rectangle to demonstrate clip region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }