public:
   void SetClipPathCombine( PaintEventArgs^ e )
   {
      // Create graphics path.
      GraphicsPath^ clipPath = gcnew GraphicsPath;
      clipPath->AddEllipse( 0, 0, 200, 100 );

      // Set clipping region to path.
      e->Graphics->SetClip( clipPath, CombineMode::Replace );

      // Fill rectangle to demonstrate clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Black ), 0, 0, 500, 300 );
   }