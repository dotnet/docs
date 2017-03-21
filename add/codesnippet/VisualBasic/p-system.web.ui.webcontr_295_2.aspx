  Shared editControlTitle As String
  
  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As System.EventArgs)
    editControlTitle = Server.HtmlEncode(TextBox1.Text)
    PropertyGridEditorPart1.Title = editControlTitle 
  End Sub
  
  Protected Sub PropertyGridEditorPart1_Init(ByVal _
    sender As Object, ByVal e As System.EventArgs)
    If Not editControlTitle Is Nothing Then
      PropertyGridEditorPart1.Title = editControlTitle
    End If
  End Sub