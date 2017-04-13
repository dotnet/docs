<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<Script runat="server">
Private Sub Page_Load(Sender As Object, E As EventArgs)
' <Snippet1>
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

' </Snippet1>
End Sub ' Page_Load

Private Sub MoveNode (nodes As SiteMapNodeCollection)
' <Snippet2>

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
' </Snippet2>
End Sub ' MoveNode
</Script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
