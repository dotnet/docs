    Public Overrides Function GetCacheDependency(ByVal virtualPath As String, ByVal virtualPathDependencies As IEnumerable, ByVal utcStart As Date) As CacheDependency
      If (IsPathVirtual(virtualPath)) Then

        Dim fullPathDependencies As System.Collections.Specialized.StringCollection
        fullPathDependencies = Nothing

        ' Get the full path to all dependencies.
        For Each virtualDependency As String In virtualPathDependencies
          If fullPathDependencies Is Nothing Then
            fullPathDependencies = New System.Collections.Specialized.StringCollection
          End If

          fullPathDependencies.Add(virtualDependency)
        Next

        If fullPathDependencies Is Nothing Then
          Return Nothing
        End If

        Dim fullPathDependenciesArray As String()
        fullPathDependencies.CopyTo(fullPathDependenciesArray, 0)

        Return New CacheDependency(fullPathDependenciesArray, utcStart)
      Else
        Return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart)
      End If
    End Function