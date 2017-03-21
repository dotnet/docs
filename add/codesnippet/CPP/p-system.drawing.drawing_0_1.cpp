private:
   void DemonstrateRegionData2( PaintEventArgs^ e )
   {
      //Create a simple region.
      System::Drawing::Region^ region1 = gcnew System::Drawing::Region( Rectangle(10,10,100,100) );

      // Extract the region data.
      System::Drawing::Drawing2D::RegionData^ region1Data = region1->GetRegionData();
      array<Byte>^data1;
      data1 = region1Data->Data;

      // Create a second region.
      System::Drawing::Region^ region2 = gcnew System::Drawing::Region;

      // Get the region data for the second region.
      System::Drawing::Drawing2D::RegionData^ region2Data = region2->GetRegionData();

      // Set the Data property for the second region to the Data from the first region.
      region2Data->Data = data1;

      // Construct a third region using the modified RegionData of the second region.
      System::Drawing::Region^ region3 = gcnew System::Drawing::Region( region2Data );

      // Dispose of the first and second regions.
      delete region1;
      delete region2;

      // Call ExcludeClip passing in the third region.
      e->Graphics->ExcludeClip( region3 );

      // Fill in the client rectangle.
      e->Graphics->FillRectangle( Brushes::Red, this->ClientRectangle );
      delete region3;
   }