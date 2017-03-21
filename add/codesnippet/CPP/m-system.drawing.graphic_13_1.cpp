public:
   void FillRegionRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create rectangle for region.
      Rectangle fillRect = Rectangle(100,100,200,200);

      // Create region for fill.
      System::Drawing::Region^ fillRegion = gcnew System::Drawing::Region( fillRect );

      // Fill region to screen.
      e->Graphics->FillRegion( blueBrush, fillRegion );
   }