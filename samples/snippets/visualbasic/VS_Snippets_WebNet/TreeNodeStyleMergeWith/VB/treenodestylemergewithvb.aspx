<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub MergeButton_Click(ByVal sender As Object, ByVal e As EventArgs)

    ' Combine the leaf node styles of the TreeNodeOne TreeView and the 
    ' TreeViewResults TreeView.
    TreeViewResults.LeafNodeStyle.MergeWith(TreeViewOne.LeafNodeStyle)

  End Sub

  Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs)

    ' Reset the LeafNodeStyle of the TreeViewResults TreeView.
    TreeViewResults.LeafNodeStyle.Reset()

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeStyle MergeWith Example</title>
</head>
<body>  
    <form id="form1" runat="server">
    
      <h3>TreeNodeStyle MergeWith Example</h3>
      
      <table cellspacing="30">
        
        <tr>
        
          <th>
          
            TreeView One
          
          </th>
          
          <th>
          
            TreeView Result
          
          </th>
        
        </tr>
        
        <tr valign="top">
        
          <td>
          
            <!-- Set the styles for the leaf nodes declaratively. -->
            <asp:TreeView id="TreeViewOne"
              ExpandDepth="4" 
              LeafNodeStyle-BackColor="Yellow"
              LeafNodeStyle-Font-Bold="true"  
              LeafNodeStyle-ForeColor="Black"  
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
              
                  </asp:TreeNode>
            
                </asp:TreeNode>
        
              </Nodes>
        
            </asp:TreeView>
          
          </td>
          
          <td>
          
            <!-- Set the styles for the leaf nodes declaratively. -->
            <asp:TreeView id="TreeViewResults"
              ExpandDepth="4" 
              LeafNodeStyle-ForeColor="Green"  
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
              
                  </asp:TreeNode>
            
                </asp:TreeNode>
        
              </Nodes>
        
            </asp:TreeView>
          
          </td>
        
        </tr>
        
        <tr>
        
          <td>
          
            <asp:Button ID="MergeNodeStyleButton" 
              Text="Merge LeafNodeStyle"
              OnClick="MergeButton_Click" 
              runat="server"/>
          
          </td>
          
          <td>
          
            <asp:Button ID="ResetButton" 
              Text="Reset LeafNodeStyle"
              OnClick="ResetButton_Click" 
              runat="server"/>
          
          </td>
        
        </tr>
      
      </table>
       
    </form>
  </body>
</html>

<!-- </Snippet1> -->
