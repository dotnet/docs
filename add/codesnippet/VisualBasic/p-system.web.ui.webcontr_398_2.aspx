  Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    If EditorZone1.OKVerb.Enabled Then
      EditorZone1.OKVerb.Enabled = False
    Else
      EditorZone1.OKVerb.Enabled = True
    End If

  End Sub