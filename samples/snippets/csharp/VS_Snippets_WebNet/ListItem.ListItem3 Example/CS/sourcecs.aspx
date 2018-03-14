<!--<Snippet1>-->
<!-- The following example demonstrates adding items to and removing items
from ListBox controls. When an item is selected in ListBox1, a new ListBoxItem with
the same value can be created and added to ListBox2, if ListBox2 does not already 
contain an item with that text. -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ListItem Example</title>
<script runat="server">
 
         void AddBtn_Click(Object Sender, EventArgs e) 
         {
             if (ListBox1.SelectedIndex > -1) 
             {
                  if (ListBox2.Items.FindByText(ListBox1.SelectedItem.Text) == null) 
                 {
                     ListItem Item = new ListItem(ListBox1.SelectedItem.Text, 
                         ListBox1.SelectedItem.Value);
                     ListBox2.Items.Add(Item);
                  }
             }
         }
 
         void DelBtn_Click(Object Sender, EventArgs e) 
         {
             if (ListBox2.SelectedIndex > -1) 
             {
                 ListBox2.Items.Remove(ListBox2.SelectedItem);
             }
         }
 
     </script>
 
 </head>
 <body>
 
     <h3>ListItem Example</h3>
     <form id="form1" runat="server">
     <table>
     <tr><td>
         <asp:ListBox id="ListBox1" Width="100px" runat="server">
             <asp:ListItem Value="Value 1">Item 1</asp:ListItem>
             <asp:ListItem Value="Value 2">Item 2</asp:ListItem>
             <asp:ListItem Value="Value 3">Item 3</asp:ListItem>
             <asp:ListItem Value="Value 4">Item 4</asp:ListItem>
             <asp:ListItem Value="Value 5" Selected="True">Item 5</asp:ListItem>
             <asp:ListItem Value="Value 6">Item 6</asp:ListItem>
         </asp:ListBox>
     </td><td>
         <asp:button Text="--->" OnClick="AddBtn_Click" runat="server" /><br />
         <asp:button Text="<---" OnClick="DelBtn_Click" runat="server" />
    </td><td>
         <asp:ListBox id="ListBox2" Width="100px" runat="server"/>
     </td></tr>
     </table>
     </form>
 
 </body>
 </html>
          
<!--</Snippet1>-->
