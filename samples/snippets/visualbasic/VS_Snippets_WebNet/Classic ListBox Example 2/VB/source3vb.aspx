<%@ Page Language="VB" AutoEventWireup="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!-- <Snippet3> -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script language="VB" runat="server">

    Sub SubmitBtn_Click(sender As Object, e As EventArgs)
            Dim msg As String
            Dim li As ListItem
            msg = ""
            For Each li In ListBox1.Items
                If li.Selected = True Then
                    msg = msg & "<br>" & li.Text & " selected."
                End If
            Next
            Label1.Text = msg
    End Sub 'SubmitBtn_Click

  </script>

</head>
<body>

   <h3>ListBox Example</h3>

   <form id="Form1" runat=server>

      <asp:ListBox id="ListBox1" 
           Rows="6"
           Width="100px"
           SelectionMode="Multiple" 
           runat="server">

         <asp:ListItem>Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>
         <asp:ListItem>Item 5</asp:ListItem>
         <asp:ListItem>Item 6</asp:ListItem>

      </asp:ListBox>

      <asp:button id="Button1"
           Text="Submit" 
           OnClick="SubmitBtn_Click" 
           runat="server" />
        
      <asp:Label id="Label1" 
           Font-Name="Verdana" 
           Font-Size="10pt" 
           runat="server"/>
        
   </form>

</body>
</html>
<!-- </Snippet3> -->
