public:
   void IsVisibleInt( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of points.
      int x1 = 100;
      int y1 = 100;
      int x2 = 200;
      int y2 = 200;

      // If point is visible, fill ellipse that represents it.
      if ( e->Graphics->IsVisible( x1, y1 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Red ), x1, y1, 10, 10 );
      }

      if ( e->Graphics->IsVisible( x2, y2 ) )
      {
         e->Graphics->FillEllipse( gcnew SolidBrush( Color::Blue ), x2, y2, 10, 10 );
      }
   }