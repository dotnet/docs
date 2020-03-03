<!-- <Snippet1> -->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Private Sub Page_Load(sender As Object, e As System.EventArgs)

  ' Examine the CurrentNode, and navigate the SiteMap relative to it.
  Response.Write(SiteMap.CurrentNode.Title & "<br />")
  Response.Write("<font COLOR='red'>" & SiteMap.CurrentNode.Url & "</font><br />")

  ' What nodes are children of the CurrentNode?
  If (SiteMap.CurrentNode.HasChildNodes) Then
      Dim childNodesEnumerator As IEnumerator = SiteMap.CurrentNode.ChildNodes.GetEnumerator()

      While (childNodesEnumerator.MoveNext())
          ' Prints the Title of each node.
          Response.Write(childNodesEnumerator.Current.ToString() & "<br />")
      End While

  End If
  Response.Write("<hr />")

  ' Examine the RootNode, and navigate the SiteMap relative to it.
  Response.Write(SiteMap.RootNode.Title & "<br />")
  Response.Write(SiteMap.RootNode.Url & "<br />")

  ' What nodes are children of the RootNode?
  If (SiteMap.RootNode.HasChildNodes) Then
      Dim rootNodesChildrenEnumerator As IEnumerator = SiteMap.RootNode.ChildNodes.GetEnumerator()
      While (rootNodesChildrenEnumerator.MoveNext())
          ' Prints the Title of each node.
          Response.Write(rootNodesChildrenEnumerator.Current.ToString() & "<br />")
      End While
  End If

End Sub ' Page_Load
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:SiteMapPath
            runat="server"
          ID="SiteMapPath1"
          ShowToolTips="false"/>

    </form>
  </body>
</html>
<!-- </Snippet1> -->