<!-- <Snippet1> -->
<%@ Page language="c#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  private void Page_Load(object sender, System.EventArgs e)
  {
    try
    {
      string LabelText = "";

      // Displays the title of the current node.
      Label_CurrentNode.Text = SiteMap.CurrentNode.Title;

      // Determines if the current node has child nodes.
      if (SiteMap.CurrentNode.HasChildNodes)
      {
        foreach (SiteMapNode childNodesEnumerator in SiteMap.CurrentNode.ChildNodes)
        {
          // Displays the title of each node.
          LabelText = LabelText + childNodesEnumerator.Title + "<br />";
        }
      }

      Label_ChildNodes.Text = LabelText;
    }
    catch (System.NullReferenceException ex)
    {
      Label_CurrentNode.Text = "The current file is not in the site map.";
    }
    catch (Exception ex)
    {
      Label_CurrentNode.Text = "Generic exception: " + e.ToString();
    }
  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Enumerating Child Site Map Nodes</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

      <h2>Current Node</h2>
      <asp:Label id="Label_CurrentNode" runat="Server"></asp:Label>

      <h2>Child Nodes</h2>
      <asp:Label id="Label_ChildNodes" runat="Server"></asp:Label>

      <h2>Verify Against Site Map</h2>
      <asp:SiteMapDataSource id="SiteMapDataSource1" runat="server" />
      <asp:TreeView id="TreeView1" runat="server" dataSourceID="SiteMapDataSource1">
      </asp:TreeView>
      
    </form>
  </body>
</html>
<!-- </Snippet1> -->
