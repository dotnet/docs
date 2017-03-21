  Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.ApplyVerb.Enabled Then
      EditorZone1.ApplyVerb.Enabled = False
    Else
      EditorZone1.ApplyVerb.Enabled = True
    End If
  End Sub