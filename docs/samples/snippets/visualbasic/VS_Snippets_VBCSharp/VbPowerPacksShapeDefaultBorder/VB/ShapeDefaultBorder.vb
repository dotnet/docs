Public Class ShapeDefaultBorder

    Private Sub ShapeDefaultBorder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet1>
        For Each s As Microsoft.VisualBasic.PowerPacks.Shape In Me.ShapeContainer1.Shapes
            If s.BorderColor <> Microsoft.VisualBasic.PowerPacks.SimpleShape.DefaultBorderColor Then
                s.BorderColor = Color.Black
            End If
        Next
        ' </Snippet1>
    End Sub

   
End Class
