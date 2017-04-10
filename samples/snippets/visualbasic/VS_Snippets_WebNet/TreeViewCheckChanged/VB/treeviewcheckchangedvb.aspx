<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub LinksTreeView_CheckChanged(ByVal sender As Object, ByVal e As TreeNodeEventArgs)

    If LinksTreeView.CheckedNodes.Count > 0 Then

      ' Clear the message label.
      Message.Text = "You selected: <br /><br />"

      ' Iterate through the CheckedNodes collection and display 
      ' the selected nodes.
      Dim node As TreeNode

      For Each node In LinksTreeView.CheckedNodes

        Message.Text &= node.Text & "<br />"

      Next

    Else

      Message.Text = "No items selected."

    End If

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeView CheckChanged Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView CheckChanged Example</h3>
    
      <!-- Set the ShowCheckBoxes property declaratively.   -->
      <!-- Because the ShowCheckBoxes property uses a flag  -->
      <!-- enumeration, you can combine multiple values by  -->
      <!-- using the bitwise OR operator. In declarative    -->
      <!-- syntax, this is done using a comma separated     -->
      <!-- list.                                            -->  
      <asp:TreeView id="LinksTreeView"
        ForeColor="Blue"
        ExpandDepth="2"
        ShowCheckBoxes="Parent,Leaf" 
        OnTreeNodeCheckChanged="LinksTreeView_CheckChanged" 
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
      
      <br /><br />
      
      <asp:Button id="Submit"
        Text="Select Items"
        runat="server"/>
         
      <br /><br />
      
      <asp:Label id="Message"
        runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->

