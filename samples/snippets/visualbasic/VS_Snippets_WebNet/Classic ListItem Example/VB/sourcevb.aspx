<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head>
    <title>ListBox Example</title>
<script language="VB" runat="server">
 
         Sub SubmitBtn_Click(Sender As Object, e As EventArgs)
             If ListBox1.SelectedIndex > -1 Then
                 Label1.Text = "You chose: " & ListBox1.SelectedItem.Text
                 Label1.Text &= "<br /> with value: " & ListBox1.SelectedItem.Value
             End If
         End Sub
 
     </script>
 
 </head>
 <body>
 
     <h3>ListBox Example</h3>
     <br />
 
     <form id="form1" runat="server">
 
         <asp:ListBox id="ListBox1" Width="100px" runat="server">
             <asp:ListItem>Item 1</asp:ListItem>
             <asp:ListItem>Item 2</asp:ListItem>
             <asp:ListItem>Item 3</asp:ListItem>
             <asp:ListItem Value="Value 4">Item 4</asp:ListItem>
             <asp:ListItem Text="Item 5" Value="Value 5" Selected="True"/>
             <asp:ListItem>Item 6</asp:ListItem>
         </asp:ListBox>
 
         <asp:button Text="Submit" OnClick="SubmitBtn_Click" runat="server" />
         
         <br />
         
         <asp:Label id="Label1" font-names="Verdana" font-size="10pt" runat="server"/>
         
     </form>
 
 </body>
 </html>
          
<!--</Snippet1>-->
