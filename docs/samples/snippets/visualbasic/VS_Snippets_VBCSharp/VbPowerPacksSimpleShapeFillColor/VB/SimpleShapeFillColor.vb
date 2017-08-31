Imports Microsoft.VisualBasic.PowerPacks

Public Class SimpleShapeFillColor
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Set the fill style.
        OvalShape1.FillStyle = FillStyle.Solid
        ' Set the fill color.
        OvalShape1.FillColor = Color.Red
        ' Set the gradient style.
        OvalShape1.FillGradientStyle = FillGradientStyle.Central
        ' Set the gradient color.
        OvalShape1.FillGradientColor = Color.Purple
    End Sub
    ' </Snippet1>
End Class
