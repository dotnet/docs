public:
   void IsVisibleRectangle( PaintEventArgs^ e )
   {
      // Set clip region.
      System::Drawing::Region^ clipRegion = gcnew System::Drawing::Region( Rectangle(50,50,100,100) );
      e->Graphics->SetClip( clipRegion, CombineMode::Replace );

      // Set up coordinates of rectangles.
      Rectangle rect1 = Rectangle(100,100,20,20);
      Rectangle rect2 = Rectangle(200,200,20,20);

      // If rectangle is visible, fill it.
      if ( e->Graphics->IsVisible( rect1 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), rect1 );
      }

      if ( e->Graphics->IsVisible( rect2 ) )
      {
         e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), rect2 );
      }
   }