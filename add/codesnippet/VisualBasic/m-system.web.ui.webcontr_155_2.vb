    Public Overrides Function CreateEditorParts() _
                                As EditorPartCollection
      Dim editorArray As New ArrayList()
      Dim edPart as New TextDisplayEditorPart()
      edPart.ID = Me.ID & "_editorPart1"
      editorArray.Add(edPart)
      Dim editorParts As New EditorPartCollection(editorArray)
      Return editorParts

    End Function

    Public Overrides ReadOnly Property WebBrowsableObject() _
                                        As Object
      Get
        Return Me
      End Get
    End Property