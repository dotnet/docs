<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- <Snippet1> -->
<script runat="server">

Private Sub Page_Load(sender As Object, e As EventArgs)

    ' Examine the CurrentNode, and navigate the SiteMap relative to it.
    Response.Write(SiteMap.CurrentNode.Title & "<br />")
    Response.Write("<font COLOR='red'>" & SiteMap.CurrentNode.Url & "</font><br />")

    ' What nodes are children of the CurrentNode?
    If (SiteMap.CurrentNode.HasChildNodes) Then
        Dim ChildNodesEnumerator As IEnumerator = SiteMap.CurrentNode.ChildNodes.GetEnumerator()
        While (ChildNodesEnumerator.MoveNext())
            ' Prints the Title of each node.
            Response.Write(ChildNodesEnumerator.Current.ToString() & "<br />")
        End While
    End If
    Response.Write("<hr />")

    ' Examine the RootNode, and navigate the SiteMap relative to it.
    Response.Write(SiteMap.RootNode.Title & "<br />")
    Response.Write(SiteMap.RootNode.Url & "<br />")

    ' What nodes are children of the RootNode?
    If (SiteMap.RootNode.HasChildNodes) Then
        Dim RootNodesChildrenEnumerator As IEnumerator = SiteMap.RootNode.ChildNodes.GetEnumerator()
        While (RootNodesChildrenEnumerator.MoveNext())
            ' Prints the Title of each node.
            Response.Write(RootNodesChildrenEnumerator.Current.ToString() & "<br />")
        End While
    End If

End Sub ' Page_Load
</script>
<!-- </Snippet1> -->
<!-- <Snippet2> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Site Map and SiteMapPath Example</title>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <p><asp:SiteMapPath runat="server" ID="SiteMapPath1"
                    RootNodeStyle-Font-Bold="true"
                    RootNodeStyle-Font-Names="Arial Black"
                    RootNodeStyle-Font-Italic="True"
                    RootNodeStyle-ForeColor="Green"
                    CurrentNodeStyle-ForeColor="Orange"
                    PathSeparator="<::>"
                    PathDirection="CurrentToRoot"
                    RenderCurrentNodeAsLink="false"
                    ShowToolTips="false"/></p>

        </form>
    </body>
</html>
<!-- </Snippet2> -->
