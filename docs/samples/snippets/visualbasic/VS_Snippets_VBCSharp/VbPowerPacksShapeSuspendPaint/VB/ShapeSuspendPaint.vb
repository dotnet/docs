Public Class ShapeSuspendPaint
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        ' Suspend painting.
        OvalShape1.SuspendPaint()
        ' Set some properties.
        OvalShape1.BackStyle = PowerPacks.BackStyle.Opaque
        OvalShape1.BackColor = Color.Blue
        OvalShape1.FillStyle = PowerPacks.FillStyle.Plaid
        OvalShape1.FillColor = Color.Red
        ' Resume painting and execute any pending requests.
        OvalShape1.ResumePaint(True)
    End Sub
    ' </Snippet1>
End Class
