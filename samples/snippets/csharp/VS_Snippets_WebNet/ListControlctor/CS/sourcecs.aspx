<!--<Snippet1>-->
<!-- The following example demonstrates how to programmatically 
create a ListBox. The example uses a PlaceHolder control as
a container for the ListBox. -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ListBox Example</title>
<script runat="server">
 
      void SubmitBtn_Click(Object sender, EventArgs e) 
      {
         // Create a new ListBox.
         ListBox listbox1 = new ListBox();

         // Create ListItems to populate the ListBox.
         ListItem listItem1 = new ListItem("Item 1","Value 1");
         ListItem listItem2 = new ListItem("Item 2","Value 2");

         // Add the ListItems to the ListBox.
         listbox1.Items.Add(listItem1);
         listbox1.Items.Add(listItem2);
         
         // Add the ListBox to the Controls collection of the PlaceHolder control.
         Place.Controls.Add(listbox1);
      }
 
   </script>
 
</head>
<body>
 
   <h3>ListBox Example</h3>
   <br />
 
   <form id="form1" runat="server">
 
      <asp:button id="Button1"
                  Text="Click to create a two item ListBox" 
                  OnClick="SubmitBtn_Click" 
                  runat="server" />
      <br /><br />
      <asp:PlaceHolder id="Place" runat="server"/>
         
   </form>
 
</body>
</html>
   
<!--</Snippet1>-->
