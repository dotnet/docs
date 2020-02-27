<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Button_Click(Object sender, EventArgs e)
  {

    // Copy the leaf node styles from the TreeNodeOne TreeView into the 
    // TreeViewResults TreeView.
    TreeViewResults.LeafNodeStyle.CopyFrom(TreeViewOne.LeafNodeStyle);

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>TreeNodeStyle CopyFrom Example</title>
</head>
<body>  
    <form id="form1" runat="server">
    
      <h3>TreeNodeStyle CopyFrom Example</h3>
      
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
          
            <asp:Button ID="CopyNodeStyleButton" 
              Text="Copy LeafNodeStyle"
              OnClick="Button_Click" 
              runat="server"/>
          
          </td>
          
          <td>
          
            &nbsp;
          
          </td>
        
        </tr>
      
      </table>
       
    </form>
  </body>
</html>

<!-- </Snippet1> -->
