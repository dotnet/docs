    private void DemonstrateRegionData2(PaintEventArgs e)
    {

        //Create a simple region.
        Region region1 = new Region(new Rectangle(10, 10, 100, 100));

        // Extract the region data.
        System.Drawing.Drawing2D.RegionData region1Data = region1.GetRegionData();
        byte[] data1;
        data1 = region1Data.Data;

        // Create a second region.
        Region region2 = new Region();

        // Get the region data for the second region.
        System.Drawing.Drawing2D.RegionData region2Data = region2.GetRegionData();

        // Set the Data property for the second region to the Data from the first region.
        region2Data.Data = data1;

        // Construct a third region using the modified RegionData of the second region.
        Region region3 = new Region(region2Data);

        // Dispose of the first and second regions.
        region1.Dispose();
        region2.Dispose();

        // Call ExcludeClip passing in the third region.
        e.Graphics.ExcludeClip(region3);

        // Fill in the client rectangle.
        e.Graphics.FillRectangle(Brushes.Red, this.ClientRectangle);

        region3.Dispose();

    }