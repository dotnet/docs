    Protected Overrides Function GetWebPartVerbs _
      (ByVal webPart As WebPart) As WebPartVerbCollection

      Dim verbSet As New ArrayList()
      Dim verb As WebPartVerb
      For Each verb In MyBase.GetWebPartVerbs(webPart)
        If verb.Text <> "Close" Then
          verbSet.Add(verb)
        End If
      Next verb

      Dim reducedVerbSet As WebPartVerbCollection = _
        New WebPartVerbCollection(verbSet)

      Return reducedVerbSet
    End Function