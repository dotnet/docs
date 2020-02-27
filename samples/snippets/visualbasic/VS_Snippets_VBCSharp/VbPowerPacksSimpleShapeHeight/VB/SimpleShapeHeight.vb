Public Class SimpleShapeHeight
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Set the height.
        OvalShape1.Height = OvalShape1.Height + 50
        ' Set the width the same as the height to make it a circle.
        OvalShape1.Width = OvalShape1.Height
    End Sub
    ' </Snippet1>
End Class
