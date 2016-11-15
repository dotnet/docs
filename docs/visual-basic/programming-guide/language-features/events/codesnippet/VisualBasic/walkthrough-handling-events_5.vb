    Private Sub Button1_Click( 
        ByVal sender As Object, 
        ByVal e As System.EventArgs 
    ) Handles Button1.Click
        mblnCancel = False
        lblPercentDone.Text = "0%"
        lblPercentDone.Refresh()
        mWidget.LongTask(12.2, 0.33)
        If Not mblnCancel Then lblPercentDone.Text = CStr(100) & "%"
    End Sub