    ' Implement the CurrentNode property.
    Public Overrides ReadOnly Property CurrentNode() As SiteMapNode
      Get
        Dim currentUrl As String = FindCurrentUrl()
        ' Find the SiteMapNode that represents the current page.
        Dim aCurrentNode As SiteMapNode = FindSiteMapNode(currentUrl)
        Return aCurrentNode
      End Get
    End Property

    ' Implement the RootNode property.
    Public Overrides ReadOnly Property RootNode() As SiteMapNode
      Get
        Return aRootNode
      End Get
    End Property