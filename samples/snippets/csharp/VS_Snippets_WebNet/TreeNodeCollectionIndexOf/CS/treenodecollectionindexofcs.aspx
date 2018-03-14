<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Node_Changed(Object sender, EventArgs e)
  {

    // Determine whether the Nodes collection contains the selected node
    // and display the appropriate message.
    if(LinksTreeView.Nodes.Contains(LinksTreeView.SelectedNode))
    {

      Message.Text = "The index of " + LinksTreeView.SelectedNode.Text + 
        " is " +  LinksTreeView.Nodes.IndexOf(LinksTreeView.SelectedNode).ToString();

    }
    else
    {

      Message.Text = "The selected node is not a root node.";

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeCollection Contains Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeCollection Contains Example</h3>
      
      <h5>Click a root node.</h5>
    
      <asp:TreeView id="LinksTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
        OnSelectedNodeChanged="Node_Changed"  
        runat="server">
         
        <LevelStyles>
        
          <asp:TreeNodeStyle ChildNodesPadding="10" 
            Font-Bold="true" 
            Font-Size="12pt" 
            ForeColor="DarkGreen"/>
          <asp:TreeNodeStyle ChildNodesPadding="5" 
            Font-Bold="true" 
            Font-Size="10pt"/>
          <asp:TreeNodeStyle ChildNodesPadding="5" 
            Font-UnderLine="true" 
            Font-Size="10pt"/>
          <asp:TreeNodeStyle ChildNodesPadding="10" 
            Font-Size="8pt"/>
             
        </LevelStyles>
         
        <Nodes>
        
          <asp:TreeNode Text="Table of Contents"
            Expanded="true">
             
            <asp:TreeNode Text="Chapter One">
            
              <asp:TreeNode Text="Section 1.0">
              
                <asp:TreeNode Text="Topic 1.0.1"/>
                <asp:TreeNode Text="Topic 1.0.2"/>
                <asp:TreeNode Text="Topic 1.0.3"/>
              
              </asp:TreeNode>
              
              <asp:TreeNode Text="Section 1.1">
              
                <asp:TreeNode Text="Topic 1.1.1"/>
                <asp:TreeNode Text="Topic 1.1.2"/>
                <asp:TreeNode Text="Topic 1.1.3"/>
                <asp:TreeNode Text="Topic 1.1.4"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
            <asp:TreeNode Text="Chapter Two">
            
              <asp:TreeNode Text="Section 2.0">
              
                <asp:TreeNode Text="Topic 2.0.1">
                
                  <asp:TreeNode Text="Subtopic 1"/>
                  <asp:TreeNode Text="Subtopic 2"/>
                
                </asp:TreeNode>
                <asp:TreeNode Text="Topic 2.0.2"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
          </asp:TreeNode>
          
          <asp:TreeNode Text="Appendix A" />
          <asp:TreeNode Text="Appendix B" />
          <asp:TreeNode Text="Appendix C" />
        
        </Nodes>

      </asp:TreeView>
           
      <hr />
      
      <asp:Label id="Message"
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
