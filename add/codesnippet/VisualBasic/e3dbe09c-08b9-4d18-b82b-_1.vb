    ' Open the Help file for the Character Map topic and 
    ' display the Index page.
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Help.ShowHelp(TextBox1, "file://c:\charmap.chm", HelpNavigator.Index)
    End Sub