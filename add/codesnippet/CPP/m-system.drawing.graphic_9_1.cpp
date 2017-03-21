public:
   void IntersectClipRegion( PaintEventArgs^ e )
   {
      // Set clipping region.
      Rectangle clipRect = Rectangle(0,0,200,200);
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( clipRect );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Update clipping region to intersection of
      // existing region with specified rectangle.
      Rectangle intersectRect = Rectangle(100,100,200,200);
      System::Drawing::Region^ intersectRegion = gcnew System::Drawing::Region( intersectRect );
      e->Graphics->IntersectClip( intersectRegion );

      // Fill rectangle to demonstrate effective clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 500, 500 );

      // Reset clipping region to infinite.
      e->Graphics->ResetClip();

      // Draw clipRect and intersectRect to screen.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Black ), clipRect );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red ), intersectRect );
   }