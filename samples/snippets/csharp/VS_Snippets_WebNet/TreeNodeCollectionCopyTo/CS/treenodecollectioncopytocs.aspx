<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(Object sender, EventArgs e)
  {

    // If the TreeView control contains any root nodes, display the 
    // text value of each node. 
    if (LinksTreeView.Nodes.Count > 0)
    {

      // Declare an array of TreeNode objects.
      TreeNode[] RootNodeArray = new TreeNode[LinksTreeView.Nodes.Count];

      // Use the CopyTo method to copy the root nodes into the array.
      LinksTreeView.Nodes.CopyTo(RootNodeArray, 0);

      // Display the root nodes.
      foreach (TreeNode node in RootNodeArray)
      {

        Message.Text += node.Text + "<br />";

      }

    }
    else
    {

      Message.Text = "The TreeView control does not have any nodes.";

    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeCollection CopyTo Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeCollection CopyTo Example</h3>
    
      <asp:TreeView id="LinksTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
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
      
      <br /><br />
      
      <asp:Label id="Message"
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
