    Private Sub showKeyword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles showKeyword.Click
        ' Display Help using the provided keyword. 
        Help.ShowHelp(Me, helpfile, keyword.Text)
    End Sub 'showKeyword_Click