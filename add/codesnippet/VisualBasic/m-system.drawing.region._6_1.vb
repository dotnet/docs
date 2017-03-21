    Public Sub TranslateExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in blue.
        Dim regionRect As New Rectangle(100, 50, 100, 100)
        e.Graphics.DrawRectangle(Pens.Blue, regionRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Apply the translation to the region.
        myRegion.Translate(150, 100)

        ' Fill the transformed region with red and draw it to the
        ' screen in red.
        Dim myBrush As New SolidBrush(Color.Red)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub