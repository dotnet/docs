private:
   void SetAndFillClip( PaintEventArgs^ e )
   {
      // Set the Clip property to a new region.
      e->Graphics->Clip = gcnew System::Drawing::Region( Rectangle(10,10,100,200) );

      // Fill the region.
      e->Graphics->FillRegion( Brushes::LightSalmon, e->Graphics->Clip );

      // Demonstrate the clip region by drawing a string
      // at the outer edge of the region.
      e->Graphics->DrawString( "Outside of Clip", gcnew System::Drawing::Font( "Arial",12.0F,FontStyle::Regular ), Brushes::Black, 0.0F, 0.0F );
   }