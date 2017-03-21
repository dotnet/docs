    Private Sub InitializeMyScrollBar()
        ' Create and initialize a VScrollBar.
        Dim vScrollBar1 As New VScrollBar()
        
        ' Dock the scroll bar to the right side of the form.
        vScrollBar1.Dock = DockStyle.Right
        
        ' Add the scroll bar to the form.
        Controls.Add(vScrollBar1)
    End Sub
