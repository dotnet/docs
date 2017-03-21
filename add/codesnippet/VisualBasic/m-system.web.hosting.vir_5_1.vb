    Public Overrides Function DirectoryExists(ByVal virtualDir As String) As Boolean
      If (IsPathVirtual(virtualDir)) Then
        Dim dir As SampleVirtualDirectory
        dir = CType(GetDirectory(virtualDir), SampleVirtualDirectory)
        Return dir.exists
      Else
        Return Previous.DirectoryExists(virtualDir)
      End If
    End Function