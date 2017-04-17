<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void HorizontalPadding_Changed(Object sender, EventArgs e)
  {

    // Programmatically set the HorizontalPadding property based on the 
    // user's selection.
    ItemsTreeView.ParentNodeStyle.HorizontalPadding = Convert.ToInt32(HorizontalPaddingList.SelectedItem.Text);

  }

  void VerticalPadding_Changed(Object sender, EventArgs e)
  {

    // Programmatically set the VerticalPadding property based on the 
    // user's selection.
    ItemsTreeView.ParentNodeStyle.VerticalPadding = Convert.ToInt32(VerticalPaddingList.SelectedItem.Text);

  }

  void NodeSpacing_Changed(Object sender, EventArgs e)
  {

    // Programmatically set the NodeSpacing property based on the 
    // user's selection.
    ItemsTreeView.ParentNodeStyle.NodeSpacing = Convert.ToInt32(NodeSpacingList.SelectedItem.Text);

  }

  void ChildNodePadding_Changed(Object sender, EventArgs e)
  {

    // Programmatically set the ChildNodesPadding property based on the 
    // user's selection.
    ItemsTreeView.ParentNodeStyle.ChildNodesPadding = Convert.ToInt32(ChildNodesPaddingList.SelectedItem.Text);

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeStyle Example</title>
</head>
<body>  
    <form id="form1" runat="server">
    
      <h3>TreeNodeStyle Example</h3>
      
      <!-- Set the styles for the leaf nodes declaratively. -->
      <asp:TreeView id="ItemsTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
        ParentNodeStyle-ForeColor="Green"
        ParentNodeStyle-HorizontalPadding="5" 
        ParentNodeStyle-VerticalPadding="5"  
        ParentNodeStyle-NodeSpacing="5"
        ParentNodeStyle-ChildNodesPadding="5"
        ExpandDepth="4"  
        runat="server">
         
        <Nodes>
        
          <asp:TreeNode Text="Table of Contents"
            SelectAction="None">
             
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
            
          </asp:TreeNode>
        
        </Nodes>
        
      </asp:TreeView>
      
      <hr />
      
      <h5>Select the style settings for the parent nodes.</h5>
      
      <table cellpadding="5">
      
        <tr align="right">
        
          <td>
          
            Horizontal Padding:
          
            <asp:DropDownList id="HorizontalPaddingList"
              AutoPostBack="true"
              OnSelectedIndexChanged="HorizontalPadding_Changed" 
              runat="server">
              
              <asp:ListItem>0</asp:ListItem>
              <asp:ListItem Selected="true">5</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              
            </asp:DropDownList> 
          
          </td>
          
          <td>
          
            Vertical Padding:
          
            <asp:DropDownList id="VerticalPaddingList"
              AutoPostBack="true"
              OnSelectedIndexChanged="VerticalPadding_Changed" 
              runat="server">
              
              <asp:ListItem>0</asp:ListItem>
              <asp:ListItem Selected="true">5</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              
            </asp:DropDownList> 
          
          </td>
          
        </tr>
        
        <tr align="right">
        
          <td>
          
            Node Spacing:
          
            <asp:DropDownList id="NodeSpacingList"
              AutoPostBack="true"
              OnSelectedIndexChanged="NodeSpacing_Changed"   
              runat="server">
              
              <asp:ListItem>0</asp:ListItem>
              <asp:ListItem Selected="true">5</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              
            </asp:DropDownList> 
          
          </td>
          
          <td>
          
            Child Nodes Padding:
          
            <asp:DropDownList id="ChildNodesPaddingList"
              AutoPostBack="true"
              OnSelectedIndexChanged="ChildNodePadding_Changed"  
              runat="server">
              
              <asp:ListItem>0</asp:ListItem>
              <asp:ListItem Selected="true">5</asp:ListItem>
              <asp:ListItem>10</asp:ListItem>
              
            </asp:DropDownList> 
          
          </td>
        
        </tr>
      
      </table>
       
    </form>
  </body>
</html>

<!-- </Snippet1> -->
