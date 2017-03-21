  Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = "<br />"
    Dim part As EditorPart
    For Each part In EditorZone1.EditorParts
      Label1.Text += part.ID + "<br />"
    Next part
  End Sub