Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeIsAccessible

    Private Sub ShapeIsAccessible_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAccessibility()
        MsgBox(OvalShape2.IsAccessible.ToString)
    End Sub
    ' <Snippet1>
    Private Sub SetAccessibility()
        ' Loop through the Shapes collection of the form.
        For Each s As Shape In ShapeContainer1.Shapes
            ' If the shape is disabled, set IsAccessible to false.
            If s.Enabled = False Then
                s.IsAccessible = False
            End If
        Next
    End Sub
    ' </Snippet1>
End Class
