    Public Sub GetRegionDataExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the RegionData for this region.
        Dim myRegionData As RegionData = myRegion.GetRegionData()
        Dim myRegionDataLength As Integer = myRegionData.Data.Length
        DisplayRegionData(e, myRegionDataLength, myRegionData)
    End Sub

    ' Helper Function for GetRegionData.
    Public Sub DisplayRegionData(ByVal e As PaintEventArgs, ByVal len As Integer, _
    ByVal dat As RegionData)

        ' Display the result.
        Dim i As Integer
        Dim x As Single = 20
        Dim y As Single = 140
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        e.Graphics.DrawString("myRegionData = ", myFont, myBrush, _
        New PointF(x, y))
        y = 160
        For i = 0 To len - 1
            If x > 300 Then
                y += 20
                x = 20
            End If
            e.Graphics.DrawString(dat.Data(i).ToString(), myFont, _
            myBrush, New PointF(x, y))
            x += 30
        Next i
    End Sub