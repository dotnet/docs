    ' Implement the GetChildNodes method.
    Public Overrides Function GetChildNodes(ByVal node As SiteMapNode) As SiteMapNodeCollection
      Dim children As New SiteMapNodeCollection()
      ' Iterate through the ArrayList and find all nodes that have the specified node as a parent.
      SyncLock Me
        Dim i As Integer
        For i = 0 To childParentRelationship.Count - 1

          Dim de As DictionaryEntry = CType(childParentRelationship(i), DictionaryEntry)
          Dim nodeUrl As String = CType(de.Key, String)

          Dim parent As SiteMapNode = GetNode(childParentRelationship, nodeUrl)

          If Not (parent Is Nothing) AndAlso node.Url = parent.Url Then
            ' The SiteMapNode with the Url that corresponds to nodeUrl
            ' is a child of the specified node. Get the SiteMapNode for
            ' the nodeUrl.
            Dim child As SiteMapNode = FindSiteMapNode(nodeUrl)
            If Not (child Is Nothing) Then
              children.Add(CType(child, SiteMapNode))
            Else
              Throw New Exception("ArrayLists not in sync.")
            End If
          End If
        Next i
      End SyncLock
      Return children
    End Function 'GetChildNodes

    Protected Overrides Function GetRootNodeCore() As SiteMapNode
      Return RootNode
    End Function ' GetRootNodeCore()

    ' Implement the GetParentNode method.
    Public Overrides Function GetParentNode(ByVal node As SiteMapNode) As SiteMapNode
      ' Check the childParentRelationship table and find the parent of the current node.
      ' If there is no parent, the current node is the RootNode.
      Dim parent As SiteMapNode = Nothing
      SyncLock Me
        ' Get the Value of the node in childParentRelationship
        parent = GetNode(childParentRelationship, node.Url)
      End SyncLock
      Return parent
    End Function 'GetParentNode