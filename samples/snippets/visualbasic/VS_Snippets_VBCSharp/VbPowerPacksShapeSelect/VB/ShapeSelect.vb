Public Class ShapeSelect

    Private Sub ShapeSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        SelectShape(OvalShape3)
    End Sub
    ' <Snippet1>
    Public Sub SelectShape(ByVal shape As Microsoft.VisualBasic.PowerPacks.Shape)
        ' Select the control, if it can be selected.
        If shape.CanSelect Then
            shape.Select()
        End If
    End Sub
    ' </Snippet1>
End Class
