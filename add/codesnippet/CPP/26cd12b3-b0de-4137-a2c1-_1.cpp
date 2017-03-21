public:
   void IsVisible4Float( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of rectangles.
      float x1 = 100.0F;
      float y1 = 100.0F;
      float width1 = 20.0F;
      float height1 = 20.0F;
      float x2 = 200.0F;
      float y2 = 200.0F;
      float width2 = 20.0F;
      float height2 = 20.0F;

      // If rectangle is visible, fill it.
      if ( e->Graphics->IsVisible( x1, y1, width1, height1 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), x1, y1, width1, height1 );
      }

      if ( e->Graphics->IsVisible( x2, y2, width2, height2 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), x2, y2, width2, height2 );
      }
   }