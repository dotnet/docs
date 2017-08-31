Public Class ShapeToBack
    ' <Snippet1>
    Private Sub Shapes_Click(
        ByVal sender As System.Object, 
        ByVal e As System.EventArgs
      ) Handles RectangleShape1.Click, OvalShape1.Click

        ' Send the control that was clicked to the bottom of the z-order.
        sender.SendToBack()
    End Sub
    ' </Snippet1>
End Class
