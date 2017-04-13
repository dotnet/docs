<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <!-- The HoverNodeStyle property needs this head element to work. -->
  <head runat="server">
    <title>TreeView HoverNodeStyle Example</title>
</head>

  <body>
    <form id="form1" runat="server">
    
      <h3>TreeView HoverNodeStyle Example</h3>
      
      <!-- Declaratively set the HoverNodeStyle settings. --> 
      <asp:TreeView id="LinksTreeView"
        HoverNodeStyle-ForeColor="Green"
        runat="server">
         
        <Nodes>
        
          <asp:TreeNode Value="Home" 
            NavigateUrl="Home.aspx" 
            Text="Home"
            Target="Content" 
            Expanded="True">
             
            <asp:TreeNode Value="Page 1" 
              NavigateUrl="Page1.aspx" 
              Text="Page1"
              Target="Content">
               
              <asp:TreeNode Value="Section 1" 
                NavigateUrl="Section1.aspx" 
                Text="Section 1"
                Target="Content"/>
                 
            </asp:TreeNode>              
            
            <asp:TreeNode Value="Page 2" 
              NavigateUrl="Page2.aspx"
              Text="Page 2"
              Target="Content">
               
            </asp:TreeNode> 
            
          </asp:TreeNode>
        
        </Nodes>
        
      </asp:TreeView>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
