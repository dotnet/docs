    ' Open the Help file for the Character Map topic.  
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        Help.ShowHelp(TextBox1, "file://c:\charmap.chm")
    End Sub