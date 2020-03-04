<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Index_Changed(ByVal sender As Object, ByVal e As EventArgs)

    ' Set the PathSeparator character based on the user's selection.
    ' Notice that the value must be converted to a Char data type.
    BookTreeView.PathSeparator = Convert.ToChar(List.SelectedItem.Text)

    ' Display the ValuePath values for the second-level nodes.
    Message.Text = "The ValuePath values for the second-level nodes are:<br />"
    Dim node As TreeNode
    For Each node In BookTreeView.Nodes(0).ChildNodes

      ' Create the delimiter array with the PathSeparator value for the Split method.
      Dim DelimiterArray(1) As Char
      DelimiterArray(0) = BookTreeView.PathSeparator

      ' Parse the ValuePath value using the delimiter array.
      Dim NodeValues() As String = node.ValuePath.Split(DelimiterArray)

      ' Display the node values.
      Dim i As Integer

      For i = 0 To NodeValues.Length - 1

        If i <> NodeValues.Length - 1 Then

          ' Append the delimiter character.
          Message.Text &= NodeValues(i) & BookTreeView.PathSeparator.ToString()

        Else

          ' Do not append the delimiter character.
          Message.Text &= NodeValues(i)

        End If

      Next

      ' Append a line break for the next node.
      Message.Text &= "<br />"

    Next

  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>TreeView PathSeparator Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>TreeView PathSeparator Example</h3>
      
      <asp:TreeView id="BookTreeView"
        ExpandDepth="-1"
        PathSeparator="/"
        runat="server">
         
        <Nodes>
        
          <asp:TreeNode Value="Chapter 1" 
            Text="Chapter 1">
             
            <asp:TreeNode Value="Section 1"
              Text="Section 1">
               
              <asp:TreeNode Value="Paragraph 1" 
                Text="Paragraph 1">
              </asp:TreeNode>
                
            </asp:TreeNode>
            
            <asp:TreeNode Value="Section 2" 
              Text="Section 2">
            </asp:TreeNode>
            
          </asp:TreeNode>
        
        </Nodes>
        
      </asp:TreeView>
      
      <br />
      
      <asp:Label id="Message" runat="server"/>
      
      <hr />
      
      Select a path separator value:<br />
      
      <asp:DropDownList ID="List"
        AutoPostBack="true"
        OnSelectedIndexChanged="Index_Changed"   
        runat="server">
      
        <asp:ListItem Selected="true">/</asp:ListItem>
        <asp:ListItem>\</asp:ListItem>
        <asp:ListItem>|</asp:ListItem>
        <asp:ListItem>,</asp:ListItem>
        <asp:ListItem>;</asp:ListItem>
      
      </asp:DropDownList>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
