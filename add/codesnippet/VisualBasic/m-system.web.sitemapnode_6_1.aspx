    Dim providername1 As String = "xAspNetXmlSiteMapProvider"
    Dim providername2 As String = "MyXmlSiteMapProvider"
    Dim providers As SiteMapProviderCollection = SiteMap.Providers
    
    If Not (providers(providername1) Is Nothing) AndAlso Not (providers(providername2) Is Nothing) Then
      Dim provider1 As SiteMapProvider = providers(providername1)
      Dim provider2 As SiteMapProvider = providers(providername2)
      Dim collection1 As SiteMapNodeCollection = provider1.RootNode.ChildNodes
      Dim collection2 As SiteMapNodeCollection = provider2.RootNode.ChildNodes
      Dim matches As Integer = 0
      Dim node As SiteMapNode
      For Each node In collection1
        If collection2.Contains(node) Then
          Response.Write("Match found at " & _
          providername1 & ", index = " & _
          collection1.IndexOf(node) & " with " & _
          providername2 & ", index = " & _
          collection2.IndexOf(node) & ".<br />")
          matches += 1
        End If
      Next node
      Response.Write("Number of matches found = " & _
      matches.ToString() + ".")
    Else
      Response.Write(providername1 & " or " & _
      providername2 & " not found.")
    End If    