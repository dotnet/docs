<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<Script runat="server">
Private Sub Page_Load(sender As Object, e As EventArgs)

    Response.Write( "Current Site Map.<BR><HR><BR>")
    Response.Write( SiteMap.RootNode.Title + "<BR>")

    Dim node As SiteMapNode
    For Each node In SiteMap.RootNode.GetAllNodes()
        Response.Write( node.Title & "<BR>")
    Next
' <Snippet2>

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

' </Snippet2>
End Sub ' Page_Load
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
