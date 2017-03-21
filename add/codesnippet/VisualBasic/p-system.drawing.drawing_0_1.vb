    Private Sub DemonstrateRegionData2(ByVal e As PaintEventArgs)

        'Create a simple region.
        Dim region1 As New Region(New Rectangle(10, 10, 100, 100))

        ' Extract the region data.
        Dim region1Data As System.Drawing.Drawing2D.RegionData = region1.GetRegionData
        Dim data1() As Byte
        data1 = region1Data.Data

        ' Create a second region.
        Dim region2 As New Region

        ' Get the region data for the second region.
        Dim region2Data As System.Drawing.Drawing2D.RegionData = region2.GetRegionData()

        ' Set the Data property for the second region to the Data from the first region.
        region2Data.Data = data1

        ' Construct a third region using the modified RegionData of the second region.
        Dim region3 As New Region(region2Data)

        ' Dispose of the first and second regions.
        region1.Dispose()
        region2.Dispose()

        ' Call ExcludeClip passing in the third region.
        e.Graphics.ExcludeClip(region3)

        ' Fill in the client rectangle.
        e.Graphics.FillRectangle(Brushes.Red, Me.ClientRectangle)

        region3.Dispose()

    End Sub