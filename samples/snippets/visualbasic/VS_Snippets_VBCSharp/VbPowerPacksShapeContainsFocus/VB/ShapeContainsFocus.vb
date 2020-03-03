Public Class ShapeContainsFocus

    Private Sub ShapeContainsFocus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        ReportFocus(OvalShape1)
    End Sub
    ' <Snippet1>
    Public Sub ReportFocus(ByVal shape As Microsoft.VisualBasic.PowerPacks.Shape)
        ' Determine whether the Shape has focus.
        If shape.ContainsFocus Then
            MsgBox(shape.Name & " has focus.")
        End If
    End Sub
    ' </Snippet1>
End Class
