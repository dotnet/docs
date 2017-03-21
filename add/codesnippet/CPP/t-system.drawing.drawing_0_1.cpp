public:
   void GetRegionDataExample( PaintEventArgs^ e )
   {
      // Create a rectangle and draw it to the screen in black.
      Rectangle regionRect = Rectangle(20,20,100,100);
      e->Graphics->DrawRectangle( Pens::Black, regionRect );

      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Get the RegionData for this region.
      RegionData^ myRegionData = myRegion->GetRegionData();
      int myRegionDataLength = myRegionData->Data->Length;
      DisplayRegionData( e, myRegionDataLength, myRegionData );
   }

   // THIS IS A HELPER FUNCTION FOR GetRegionData.
   void DisplayRegionData( PaintEventArgs^ e, int len, RegionData^ dat )
   {
      // Display the result.
      int i;
      float x = 20,y = 140;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );
      e->Graphics->DrawString( "myRegionData = ", myFont, myBrush, PointF(x,y) );
      y = 160;
      for ( i = 0; i < len; i++ )
      {
         if ( x > 300 )
         {
            y += 20;
            x = 20;
         }
         e->Graphics->DrawString( dat->Data[ i ].ToString(), myFont, myBrush, PointF(x,y) );
         x += 30;
      }
   }