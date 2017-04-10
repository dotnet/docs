<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNode ImageToolTip Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNode ImageToolTip Example</h3>
      
      <h5>Position the mouse pointer over a node image.</h5>
    
      <asp:TreeView id="LinksTreeView"
        Font-Names= "Arial"
        ForeColor="Blue"
        ExpandDepth="2"
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
            ImageUrl="~\images\Contents.jpg"
            ImageToolTip="Table of Contents Description">
             
            <asp:TreeNode Text="Chapter One"
               ImageUrl="~\images\Chapter1.jpg"
               ImageToolTip="Chapter One Description">
            
              <asp:TreeNode Text="Section 1.0"
                ImageUrl="~\images\Section1.jpg"
                ImageToolTip="Section 1.0 Description">
              
                <asp:TreeNode Text="Topic 1.0.1"/>
                <asp:TreeNode Text="Topic 1.0.2"/>
                <asp:TreeNode Text="Topic 1.0.3"/>
              
              </asp:TreeNode>
              
              <asp:TreeNode Text="Section 1.1"
                ImageUrl="~\images\Section1_1.jpg"
                ImageToolTip="Section 1.1 Description">
              
                <asp:TreeNode Text="Topic 1.1.1"/>
                <asp:TreeNode Text="Topic 1.1.2"/>
                <asp:TreeNode Text="Topic 1.1.3"/>
                <asp:TreeNode Text="Topic 1.1.4"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
            <asp:TreeNode Text="Chapter Two"
              ImageUrl="~\images\Chapter2.jpg"
              ImageToolTip="Chapter Two Description">
            
              <asp:TreeNode Text="Section 2.0"
                ImageUrl="~\images\Section2.jpg"
                ImageToolTip="Section 2.0 Description">
              
                <asp:TreeNode Text="Topic 2.0.1"/>
                <asp:TreeNode Text="Topic 2.0.2"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
          </asp:TreeNode>
          
          <asp:TreeNode Text="Appendix A"
            ImageUrl="~\images\AppendixA.jpg" 
            ImageToolTip="Appendix A Description"/>
          <asp:TreeNode Text="Appendix B"
            ImageUrl="~\images\AppendixB.jpg" 
            ImageToolTip="Appendix B Description"/>
          <asp:TreeNode Text="Appendix C"
            ImageUrl="~\images\AppendixC.jpg" 
            ImageToolTip="Appendix C Description"/>
        
        </Nodes>
        
      </asp:TreeView>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
