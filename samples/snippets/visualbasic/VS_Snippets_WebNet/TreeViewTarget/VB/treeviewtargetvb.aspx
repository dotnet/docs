<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView Target Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView Target Example</h3>
      
      <asp:TreeView id="LinksTreeView"
         Target="_blank" 
         runat="server">
         
        <Nodes>
        
          <asp:TreeNode Value="Home" 
            NavigateUrl="Home.aspx" 
            Text="Home"
            Expanded="True">
             
            <asp:TreeNode Value="Page 1" 
              NavigateUrl="Page1.aspx" 
              Text="Page1">
               
              <asp:TreeNode Value="Section 1" 
                NavigateUrl="Section1.aspx" 
                Text="Section 1"/>
                 
            </asp:TreeNode>              
            
            <asp:TreeNode Value="Page 2" 
              NavigateUrl="Page2.aspx"
              Text="Page 2">
               
            </asp:TreeNode> 
            
          </asp:TreeNode>
        
        </Nodes>
        
      </asp:TreeView>

    </form>
  </body>
</html>

<!-- </Snippet1> -->