    Public Overrides Function GetDirectory(ByVal virtualDir As String) As VirtualDirectory
      If (IsPathVirtual(virtualDir)) Then
        Return New SampleVirtualDirectory(virtualDir, Me)
      Else
        Return Previous.GetDirectory(virtualDir)
      End If
    End Function