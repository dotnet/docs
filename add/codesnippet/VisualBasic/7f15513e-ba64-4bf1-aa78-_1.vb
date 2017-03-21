    Protected Overrides Sub RenderVerbs(ByVal writer As _
      HtmlTextWriter)
      Dim verbs() As WebPartVerb = {OKVerb, CancelVerb, ApplyVerb}
      Dim verb As WebPartVerb
      For Each verb In verbs
        If Not (verb Is Nothing) Then
          verb.Text += " Verb"
        End If
      Next verb
      MyBase.RenderVerbs(writer)
    End Sub
  End Class