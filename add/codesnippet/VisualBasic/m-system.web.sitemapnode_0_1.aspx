
    ' Create a SiteMapNodeCollection with all the nodes
    ' from the first two hierarchical levels of the current
    ' site map.
    Dim baseCollection As SiteMapNodeCollection
    baseCollection = New SiteMapNodeCollection(SiteMap.RootNode)

    Dim childCollection As SiteMapNodeCollection = SiteMap.RootNode.ChildNodes

    baseCollection.AddRange(childCollection)

    Response.Write( "<BR>Derived SiteMapNodeCollection.<BR><HR><BR>")

    For Each node In baseCollection
        Response.Write( node.Title + "<BR>")
    Next
