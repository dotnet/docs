<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Node_Expand(Object sender, TreeNodeEventArgs e)
  {

    Message.Text = "You expanded the " + e.Node.Text + " node.";

  }

  void Node_Collapse(Object sender, TreeNodeEventArgs e)
  {

    Message.Text = "You collapsed the " + e.Node.Text + " node.";

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>TreeView TreeNodeExpand and TreeNodeCollapse Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView TreeNodeExpand and TreeNodeCollapse Example</h3>
      
      <asp:TreeView id="BookTreeView"
        ExpandDepth="1"
        OnTreeNodeExpanded="Node_Expand"
        OnTreeNodeCollapsed="Node_Collapse"
        runat="server">
         
        <Nodes>
        
          <asp:TreeNode Value="Chapter 1" 
            Text="Chapter 1">
             
            <asp:TreeNode Value="Section 1"
              Text="Section 1">
               
              <asp:TreeNode Value="Paragraph 1" 
                Text="Paragraph 1">
              </asp:TreeNode>
                
            </asp:TreeNode>
            
            <asp:TreeNode Value="Section 2" 
              Text="Section 2">
            </asp:TreeNode>
            
          </asp:TreeNode>
        
        </Nodes>
        
      </asp:TreeView>
      
      <br />
      
      <asp:Label id="Message" runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
