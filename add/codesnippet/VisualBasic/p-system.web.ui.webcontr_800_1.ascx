  ' This property implements the IWebActionable interface.
  ReadOnly Property Verbs() As WebPartVerbCollection _
    Implements IWebActionable.Verbs
    Get
      If (m_Verbs Is Nothing) Then
        Dim verbsList As New ArrayList()
        Dim onlyVerb As New WebPartVerb _
          ("customVerb1", New WebPartEventHandler(AddressOf IncrementVerbCounterClicks))
        onlyVerb.Text = "My Verb"
        onlyVerb.Description = "VerbTooltip"
        onlyVerb.Visible = True
        onlyVerb.Enabled = True
        verbsList.Add(onlyVerb)
        Dim otherVerb As New WebPartVerb _
          ("customVerb2", New WebPartEventHandler(AddressOf IncrementVerbCounterClicks))
        otherVerb.Text = "My other Verb"
        otherVerb.Description = "Other VerbTooltip"
        otherVerb.Visible = True
        otherVerb.Enabled = True
        verbsList.Add(otherVerb)
        m_Verbs = New WebPartVerbCollection(verbsList)
      End If
      Return m_Verbs
    End Get
  End Property