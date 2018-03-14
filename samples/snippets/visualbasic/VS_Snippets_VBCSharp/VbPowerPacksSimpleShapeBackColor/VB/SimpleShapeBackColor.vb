Public Class SimpleShapeBackColor
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Set the BackStyle and FillStyle.
        OvalShape1.BackStyle = PowerPacks.BackStyle.Opaque
        OvalShape1.FillStyle = PowerPacks.FillStyle.Transparent
        ' Change the color between red and blue.
        If OvalShape1.BackColor = Color.Red Then
            OvalShape1.BackColor = Color.Blue
        Else
            OvalShape1.BackColor = Color.Red
        End If
    End Sub
    ' </Snippet1>
End Class
