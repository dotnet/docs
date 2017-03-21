    Public Overrides Function FileExists(ByVal virtualPath As String) As Boolean
      If (IsPathVirtual(virtualPath)) Then
        Dim file As SampleVirtualFile
        file = CType(GetFile(virtualPath), SampleVirtualFile)
        Return file.Exists
      Else
        Return Previous.FileExists(virtualPath)
      End If
    End Function