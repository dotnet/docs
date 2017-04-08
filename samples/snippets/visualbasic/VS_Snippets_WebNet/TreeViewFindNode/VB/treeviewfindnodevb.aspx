<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)

    ' Find the node specified by the user.
    Dim node As TreeNode = LinksTreeView.FindNode(Server.HtmlEncode(ValuePathText.Text))

    If Not node Is Nothing Then
   
      ' Indicate that the node was found.
      Message.Text = "The specified node (" & node.ValuePath & ") was found."

    Else

      ' Indicate that the node is not in the TreeView control.
      Message.Text = "The specified node (" & ValuePathText.Text & ") is not in this TreeView control."

    End If

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>TreeView FindNode Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView FindNode Example</h3>
    
      <asp:TreeView id="LinksTreeView"
        PathSeparator="/"
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
            SelectAction="None">
             
            <asp:TreeNode Text="Chapter One" Value="Chapter One">
            
              <asp:TreeNode Text="Section 1.0" Value="Section 1.0">
              
                <asp:TreeNode Text="Topic 1.0.1" Value="Topic 1.0.1"/>
                <asp:TreeNode Text="Topic 1.0.2" Value="Topic 1.0.2"/>
                <asp:TreeNode Text="Topic 1.0.3" Value="Topic 1.0.3"/>
              
              </asp:TreeNode>
              
              <asp:TreeNode Text="Section 1.1">
              
                <asp:TreeNode Text="Topic 1.1.1" Value="Topic 1.1.1"/>
                <asp:TreeNode Text="Topic 1.1.2" Value="Topic 1.1.2"/>
                <asp:TreeNode Text="Topic 1.1.3" Value="Topic 1.1.3"/>
                <asp:TreeNode Text="Topic 1.1.4" Value="Topic 1.1.4"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
            <asp:TreeNode Text="Chapter Two" Value="Chapter Two">
            
              <asp:TreeNode Text="Section 2.0" Value="Section 2.0">
              
                <asp:TreeNode Text="Topic 2.0.1" Value="Topic 2.0.1"/>
                <asp:TreeNode Text="Topic 2.0.2" Value="Topic 2.0.2"/>
              
              </asp:TreeNode>
            
            </asp:TreeNode>
            
          </asp:TreeNode>
          <asp:TreeNode Text="Appendix A" />
          <asp:TreeNode Text="Appendix B" />
          <asp:TreeNode Text="Appendix C" />
        
        </Nodes>
        
      </asp:TreeView>
      
      <hr/>
      
      <br/><br/>
      
      Enter the value path of the node to locate. <br/>
      Use a forward slash (/) to delimit each node value.<br/>
      <asp:TextBox id="ValuePathText" 
        Text="Table of Contents/Chapter One/Section 1.0"
        Width="50%" 
        runat="server"/>
         
      <br/><br/>
      
      <asp:Button id="Submit"
        Text="Find Node"
        OnClick="Button_Click"  
        runat="server"/>
      
      <br/><br/>
      
      <asp:Label id="Message" runat="server"/>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
