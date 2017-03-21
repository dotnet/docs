public:
   void ExcludeClipRegion( PaintEventArgs^ e )
   {
      // Create rectangle for region.
      Rectangle excludeRect = Rectangle(100,100,200,200);

      // Create region for exclusion.
      System::Drawing::Region^ excludeRegion = gcnew System::Drawing::Region( excludeRect );

      // Set clipping region to exclude region.
      e->Graphics->ExcludeClip( excludeRegion );

      // Fill large rectangle to show clipping region.
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 300, 300 );
   }