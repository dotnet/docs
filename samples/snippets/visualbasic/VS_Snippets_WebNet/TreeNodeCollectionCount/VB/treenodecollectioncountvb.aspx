<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    ' If the TreeView control contains any root nodes, perform a
    ' preorder traversal of the tree and display the text of each node.
    If LinksTreeView.Nodes.Count > 0 Then

      ' Iterate through the root nodes in the Nodes property.
      Dim i As Integer

      For i = 0 To LinksTreeView.Nodes.Count - 1

        ' Display the nodes.
        DisplayChildNodeText(LinksTreeView.Nodes(i))

      Next i

    Else

      Message.Text = "The TreeView control does not have any nodes."

    End If

  End Sub

  Sub DisplayChildNodeText(ByVal node As TreeNode)

    ' Display the node's text value.
    Message.Text &= node.Text & "<br />"

    ' Iterate through the child nodes of the parent node passed into
    ' this method and display their values.
    Dim i As Integer

    For i = 0 To node.ChildNodes.Count - 1

      ' Recursively call the DisplayChildNodeText method to
      ' traverse the tree and display all the child nodes.
      DisplayChildNodeText(node.ChildNodes(i))

    Next i

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeCollection Count Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeNodeCollection Count Example</h3>
    
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
