    Private Sub SetAndFillClip(ByVal e As PaintEventArgs)

        ' Set the Clip property to a new region.
        e.Graphics.Clip = New Region(New Rectangle(10, 10, 100, 200))

        ' Fill the region.
        e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip)

        ' Demonstrate the clip region by drawing a string
        ' at the outer edge of the region.
        e.Graphics.DrawString("Outside of Clip", _
            New Font("Arial", 12.0F, FontStyle.Regular), _
            Brushes.Black, 0.0F, 0.0F)

    End Sub