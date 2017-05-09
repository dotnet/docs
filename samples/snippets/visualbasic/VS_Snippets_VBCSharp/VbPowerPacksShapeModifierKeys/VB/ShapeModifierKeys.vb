Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeModifierKeys
    ' <Snippet1>
    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape1.Click
        If Shape.ModifierKeys = Keys.Control Then
            CType(sender, Shape).Hide()
        End If
    End Sub
    ' </Snippet1>
End Class
