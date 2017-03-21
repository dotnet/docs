  Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.CancelVerb.Enabled Then
      EditorZone1.CancelVerb.Enabled = False
    Else
      EditorZone1.CancelVerb.Enabled = True
    End If
  End Sub