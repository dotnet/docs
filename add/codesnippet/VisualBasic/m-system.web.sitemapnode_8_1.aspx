    Dim siteNodes As SiteMapNodeCollection
    siteNodes = SiteMap.RootNode.GetAllNodes()

    If siteNodes.IsReadOnly Or siteNodes.IsFixedSize Then

        Response.Write("Collection is read-only or has fixed size.<BR>")

        ' Create a new, modifiable collection from the existing one.
        Dim modifiableCollection As SiteMapNodeCollection
        modifiableCollection = New SiteMapNodeCollection(siteNodes)

        ' The MoveNode example method moves a node from position one to
        ' the last position in the collection.
        MoveNode(modifiableCollection)
    Else
        MoveNode(siteNodes)
    End If
