<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ListBox Example</title>
<script runat="server">

      Sub SubmitBtn_Click(sender As Object, e As EventArgs) 

         Message.Text = "You chose: <br />"
         
         ' Iterate through the Items collection of the ListBox and 
         ' display the selected items.
         Dim item As ListItem
         For Each item in ListBox1.Items

            If item.Selected Then

               Message.Text &= item.Text & "<br />"

            End If

         Next

      End Sub

   </script>

</head>
<body>

   <h3>ListBox Example</h3>

   <form id="form1" runat="server">

      Select items from the list and click Submit. <br />

      <asp:ListBox id="ListBox1" 
           Rows="6"
           Width="100px"
           SelectionMode="Multiple" 
           runat="server">

         <asp:ListItem Selected="True">Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>
         <asp:ListItem>Item 5</asp:ListItem>
         <asp:ListItem>Item 6</asp:ListItem>

      </asp:ListBox>

      <br /><br />

      <asp:button id="Button1"
           Text="Submit" 
           OnClick="SubmitBtn_Click" 
           runat="server" />

      <br /><br />
        
      <asp:Label id="Message" 
           runat="server"/>
        
   </form>

</body>
</html>

<!-- </Snippet1> -->