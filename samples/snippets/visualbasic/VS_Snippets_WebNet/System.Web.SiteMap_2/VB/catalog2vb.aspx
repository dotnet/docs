<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<SCRIPT runat="server">
Private Sub Page_Load(Sender As Object, E As EventArgs)

    ' Navigate the SiteMap built by the default SiteMapProvider.
    Response.Write(SiteMap.RootNode.ToString() & "<BR>")

    Response.Write(SiteMap.RootNode.Url & "<BR>")
    Response.Write(SiteMap.RootNode.Title & "<BR>")

    Dim sitemapnode As SiteMapNode
    For Each sitemapnode In SiteMap.RootNode.ChildNodes
        ' Iterate through the ChildNodes SiteMapNodesCollection
        ' maintained by the RootNode.
        Response.Write(sitemapnode.Url & "<BR>" )
    Next

    Dim providers As IDictionaryEnumerator = SiteMap.Providers.GetEnumerator()
    While (providers.MoveNext())
        Response.Write(providers.Current)
        Response.Write("&nbsp;&nbsp;&nbsp;")
        Response.Write("<BR>")
    End While
End Sub ' Page_Load

</SCRIPT>
<!-- </Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
</body>
</html>
