<!--<Snippet1>-->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head runat="server">
    <title> ListControl SelectedValue Example </title>
<script runat="server">

      void Button_Click(Object sender, EventArgs e)
      {

         // Perform this operation in a try-catch block in case the item is not found.
         try
         {
            List.SelectedValue = ItemTextBox.Text;
            MessageLabel.Text = "You selected " + List.SelectedValue + ".";
         }
         catch (Exception ex)
         {
            List.SelectedValue = null;
            MessageLabel.Text = "Item not found in ListBox control.";
         }
             
      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> ListControl SelectedValue Example </h3>
 
      <asp:ListBox ID="List"
           runat="server">

         <asp:ListItem>Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>

      </asp:ListBox>

      <hr />

      Enter the value of the item to select: <br />
      <asp:TextBox ID="ItemTextBox"
           MaxLength="6"
           Text="Item 1"
           runat="server"/>

      &nbsp;&nbsp;

      <asp:Button ID="SelectButton"
           Text="Select Item"
           OnClick="Button_Click"
           runat="server"/>

      <br /><br />

      <asp:Label ID="MessageLabel"
           runat="server"/>     

   </form>

</body>
</html>
<!--</Snippet1>-->