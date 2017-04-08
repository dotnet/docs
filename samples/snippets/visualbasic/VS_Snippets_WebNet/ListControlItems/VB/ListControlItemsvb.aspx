<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head runat="server">
    <title>ASP.NET Example</title>
</head>
 <body>
    <script language="vb" runat="server">
       Sub Check_Clicked(sender As Object, e As EventArgs)
          Message.Text = "Selected Item(s):<br /><br />"
          Dim i As Integer
          For i = 0 To checkboxlist1.Items.Count - 1
             If checkboxlist1.Items(i).Selected Then
                Message.Text = Message.Text & checkboxlist1.Items(i).Text & "<br />"
             End If
          Next
       End Sub
    </script>
 
    <form id="form1" method="post" runat="server">
 
       <asp:CheckBoxList id="checkboxlist1" runat="server"
            AutoPostBack="True"
            CellPadding="5"
            CellSpacing="5"
            RepeatColumns="2"
            RepeatDirection="Vertical"
            RepeatLayout="Flow"
            TextAlign="Right"
            OnSelectedIndexChanged="Check_Clicked">
 
          <asp:ListItem>Item 1</asp:ListItem>
          <asp:ListItem>Item 2</asp:ListItem>
          <asp:ListItem>Item 3</asp:ListItem>
          <asp:ListItem>Item 4</asp:ListItem>
          <asp:ListItem>Item 5</asp:ListItem>
          <asp:ListItem>Item 6</asp:ListItem>
 
       </asp:CheckBoxList>
 
       <br /><br />
       <asp:label id="Message" runat="server"/>
             
    </form>
         
 </body>
 </html>
    
<!--</Snippet1>-->
