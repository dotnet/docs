Public Class ShapeToFront
    ' <Snippet1>
    Private Sub Shapes_Click(
        ByVal sender As System.Object, 
        ByVal e As System.EventArgs
      ) Handles RectangleShape1.Click, OvalShape1.Click

        ' Bring the control that was clicked to the top of the z-order.
        sender.BringToFront()
    End Sub
    ' </Snippet1>
End Class
