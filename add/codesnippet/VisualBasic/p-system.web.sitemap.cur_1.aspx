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