    Public Overrides Function GetFile(ByVal virtualPath As String) As VirtualFile
      If (IsPathVirtual(virtualPath)) Then
        Return New SampleVirtualFile(virtualPath, Me)
      Else
        Return Previous.GetFile(virtualPath)
      End If
    End Function