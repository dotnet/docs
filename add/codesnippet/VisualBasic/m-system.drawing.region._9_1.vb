    Private Sub FillRegionExcludingPath(ByVal e As PaintEventArgs)

        ' Create the region using a rectangle.
        Dim myRegion As New Region(New Rectangle(20, 20, 100, 100))

        ' Create the GraphicsPath.
        Dim path As New System.Drawing.Drawing2D.GraphicsPath

        ' Add a circle to the graphics path.
        path.AddEllipse(50, 50, 25, 25)

        ' Exclude the circle from the region.
        myRegion.Exclude(path)

        ' Retrieve a Graphics object from the form.
        Dim formGraphics As Graphics = e.Graphics

        ' Fill the region in blue.
        formGraphics.FillRegion(Brushes.Blue, myRegion)

        ' Dispose of the path and region objects.
        path.Dispose()
        myRegion.Dispose()

    End Sub