<!-- <Snippet1> -->
<%@ Page language="VB" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    Try
      
      Dim LabelText As String = ""

      ' Displays the title of the current node.
      Label_CurrentNode.Text = SiteMap.CurrentNode.Title

      ' Determines if the current node has child nodes.
      If (SiteMap.CurrentNode.HasChildNodes) Then
        For Each ChildNodesEnumerator As SiteMapNode In SiteMap.CurrentNode.ChildNodes
          ' Displays the title of each node.
          LabelText = LabelText & ChildNodesEnumerator.Title & "<br />"
        Next
      Else
        LabelText = LabelText & "No child nodes."
      End If
    
      Label_ChildNodes.Text = LabelText
      
    Catch ex As NullReferenceException
      Label_CurrentNode.Text = "The current file is not in the site map."
    Catch ex As Exception
      Label_CurrentNode.Text = "Generic exception: " & e.ToString()
    End Try
    
  End Sub ' Page_Load
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Enumerating Child Site Map Nodes</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

      <h2>Current Node</h2>
      <asp:Label ID="Label_CurrentNode" Runat="Server"></asp:Label>

      <h2>Child Nodes</h2>
      <asp:Label ID="Label_ChildNodes" Runat="Server"></asp:Label>

      <h2>Verify Against Site Map</h2>
      <asp:SiteMapDataSource ID="SiteMapDataSource1" Runat="server" />
      <asp:TreeView ID="TreeView1" Runat="server" DataSourceID="SiteMapDataSource1">
      </asp:TreeView>
      
    </form>
  </body>
</html>
<!-- </Snippet1> -->
