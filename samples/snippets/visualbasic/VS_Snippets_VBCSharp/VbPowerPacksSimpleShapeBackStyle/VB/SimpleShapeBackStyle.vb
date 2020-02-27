Public Class SimpleShapeBackStyle
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Change between transparent and opaque.
        If OvalShape1.BackStyle = PowerPacks.BackStyle.Transparent Then
            OvalShape1.BackStyle = PowerPacks.BackStyle.Opaque
            OvalShape1.BackColor = Color.LimeGreen
        Else
            OvalShape1.BackStyle = PowerPacks.BackStyle.Transparent
        End If
    End Sub
    ' </Snippet1>
End Class
