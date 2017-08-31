Public Class SimpleShapeDisplayRect
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Get the DisplayRectangle for each OvalShape.
        Dim rect1 As Rectangle = OvalShape1.DisplayRectangle
        Dim rect2 As Rectangle = OvalShape2.DisplayRectangle
        ' If the DisplayRectangles intersect, move OvalShape2.
        If rect1.IntersectsWith(rect2) Then
            OvalShape2.SetBounds(rect1.Right, rect1.Bottom, 
              rect2.Width, rect2.Height)
        End If
    End Sub
    ' </Snippet1>
End Class
