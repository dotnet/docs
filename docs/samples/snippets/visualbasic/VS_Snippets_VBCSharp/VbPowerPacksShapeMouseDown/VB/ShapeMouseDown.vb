Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeMouseDown
    ' <Snippet1>
    Private Sub RectangleShape1_MouseDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles RectangleShape1.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            CType(sender, Shape).BorderColor = Color.Red
        End If
    End Sub
    ' </Snippet1>
End Class
