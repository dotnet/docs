
    ' Move a node from one spot in the list to another.
    Try
        Response.Write("Original node order: <BR>")
        Dim node As SiteMapNode
        For Each node In nodes
            Response.Write( node.Title & "<BR>")
        Next

        Dim aNode As SiteMapNode = nodes(1)

        Response.Write("Adding " & aNode.Title & " to the end of the collection.<BR>")
        nodes.Add(aNode)

        Response.Write("Removing " & aNode.Title & " at position 1. <BR>")
        nodes.Remove(nodes(1))

        Response.Write("New node order: <BR>")

        For Each node In nodes
            Response.Write( node.Title & "<BR>")
        Next

    Catch nse As NotSupportedException
        Response.Write("NotSupportedException caught.<BR>")
    End Try