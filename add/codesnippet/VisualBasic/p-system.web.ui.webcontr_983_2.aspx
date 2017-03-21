  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    LayoutEditorPart1.Title = Server.HtmlEncode(TextBox1.Text)
  End Sub