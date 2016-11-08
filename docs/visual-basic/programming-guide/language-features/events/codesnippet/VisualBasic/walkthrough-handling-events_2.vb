    Private Sub mWidget_PercentDone( 
        ByVal Percent As Single, 
        ByRef Cancel As Boolean 
    ) Handles mWidget.PercentDone
        lblPercentDone.Text = CInt(100 * Percent) & "%"
        My.Application.DoEvents()
        If mblnCancel Then Cancel = True
    End Sub