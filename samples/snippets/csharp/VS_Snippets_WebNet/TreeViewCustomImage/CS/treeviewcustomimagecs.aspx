<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView Custom Images Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView Custom Images Example</h3>
      
      <!-- Set the custom images of this TreeView control -->
      <!-- declaratively.                                 -->
      <asp:TreeView id="CustomTreeView"
        NoExpandImageUrl="Space.jpg"
        CollapseImageUrl="Minus.jpg"
        CollapseImageToolTip="Collapse Node"
        ExpandImageUrl="Plus.jpg"
        ExpandImageToolTip="Expand Node"
        RootNodeStyle-ImageUrl="Root.jpg"
        ParentNodeStyle-ImageUrl="Parent.jpg"
        LeafNodeStyle-ImageUrl="Leaf.jpg" 
        ImageSet="Custom"
        runat="server">
         
        <Nodes>
        
          <asp:TreeNode Value="Home" 
            NavigateUrl="Home.aspx" 
            Text="Home"
            Target="_blank" 
            Expanded="True">
             
            <asp:TreeNode Value="Page 1" 
              NavigateUrl="Page1.aspx" 
              Text="Page 1"
              Target="_blank">
                 
              <asp:TreeNode Value="Section 1"
                ImageUrl="custom.jpg" 
                NavigateUrl="Section1.aspx" 
                Text="Section 1"
                Target="_blank">
              </asp:TreeNode>
                
            </asp:TreeNode>
            
            <asp:TreeNode Value="Page 2" 
              Selected="True" 
              NavigateUrl="Page2.aspx"
              Text="Page 2"
              Target="_blank">
            </asp:TreeNode>
            
          </asp:TreeNode>
        
        </Nodes>
        
      </asp:TreeView> 
       

    </form>
  </body>
</html>

<!-- </Snippet1> -->

