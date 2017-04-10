<!--<Snippet1>-->
<!-- The following example demonstrates adding items to and removing items
from ListBox controls. When an item is selected in ListBox1, a new ListBoxItem with
the same value can be created and added to ListBox2, if ListBox2 does not already 
contain an item with that text. -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ListItem Example</title>
<script runat="server">
 
         Sub AddBtn_Click(Sender As Object, e As EventArgs)
             If ListBox1.SelectedIndex > -1 Then
                  If ListBox2.Items.FindByText(ListBox1.SelectedItem.Text) is Nothing Then
                      Dim Item As ListItem = new ListItem(ListBox1.SelectedItem.Text)
                     Item.Value = ListBox1.SelectedItem.Value
                     ListBox2.Items.Add(Item)
                  End If
             End If
         End Sub
 
         Sub DelBtn_Click(Sender As Object, e As EventArgs)
             If ListBox2.SelectedIndex > -1 Then
                 ListBox2.Items.Remove(ListBox2.SelectedItem)
             End If
         End Sub
 
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
