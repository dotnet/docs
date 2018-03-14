<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>TreeView LevelStyles Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView LevelStyles Example</h3>

      <!-- Populate the LevelStyles collection of the TreeView control -->
      <!-- declaratively.                                              -->
      
      <asp:TreeView id="LinksTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
        ShowExpandCollapse="false"
        ExpandDepth="3"
        NodeIndent="0" 
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
            
            <asp:TreeNode Text="Chapter Two">
            
              <asp:TreeNode Text="Section 2.0">
              
                <asp:TreeNode Text="Topic 2.0.1"/>
                <asp:TreeNode Text="Topic 2.0.2"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
          </asp:TreeNode>
          <asp:TreeNode Text="Appendix A" />
          <asp:TreeNode Text="Appendix B" />
          <asp:TreeNode Text="Appendix C" />
        
        </Nodes>
        
      </asp:TreeView>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
