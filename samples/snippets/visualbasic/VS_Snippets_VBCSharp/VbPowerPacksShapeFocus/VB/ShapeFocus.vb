Public Class ShapeFocus

    Private Sub ShapeFocus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        ShapeSetFocus(OvalShape2)
    End Sub

    Private Sub ShapeFocus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' <Snippet1>
    Public Sub ShapeSetFocus(ByVal shape As Microsoft.VisualBasic.PowerPacks.Shape)
        ' Set focus to the control, if it can receive focus.
        If shape.CanFocus Then
            shape.Focus()
        End If
    End Sub
    ' </Snippet1>
End Class
