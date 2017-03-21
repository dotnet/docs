    ' Implement the FindSiteMapNode method.
    Public Overrides Function FindSiteMapNode(ByVal rawUrl As String) As SiteMapNode
      ' Does the root node match the URL?
      If RootNode.Url = rawUrl Then
        Return RootNode
      Else
        Dim candidate As SiteMapNode = Nothing
        ' Retrieve the SiteMapNode that matches the URL.
        SyncLock Me
          candidate = GetNode(siteMapNodes, rawUrl)
        End SyncLock
        Return candidate
      End If
    End Function 'FindSiteMapNode