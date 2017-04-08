<%@ Page language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="vb" runat="server">

' System.Web.UI.AttributeCollection.CssStyle

'   The following example demonstrates the method 'CssStyle'
'   of class 'AttributeCollection'. This program takes selected item
'   from dropdown list and adds that as a back ground colour to the style collection.
'   It is then reflected in the text box.

' <Snippet1>
Private Sub Button2_Click(sender As Object, e As System.EventArgs)
   Dim myColor As String
   Dim myAttributes As AttributeCollection = TextBox1.Attributes
   myColor = DropDownList1.Items(DropDownList1.SelectedIndex).Text
   ' Add the attribute "background-color" in to the CssStyle.
   myAttributes.CssStyle.Add("background-color", myColor)
End Sub
' </Snippet1>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
   <body>
      <form id="form1" method="post" runat="server">
         <p>
            <asp:Label id="Label1" runat="server" AssociatedControlID="DropDownList1">Color of the text box</asp:Label>
            <asp:DropDownList id="DropDownList1" runat="server">
               <asp:ListItem Value="Blue">Blue</asp:ListItem>
               <asp:ListItem Value="Red">Red</asp:ListItem>
               <asp:ListItem Value="Green">Green</asp:ListItem>
               <asp:ListItem Value="White">White</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox id="TextBox1" runat="server" Width="185px" Height="32px" BackColor="Silver"></asp:TextBox>
         </p>
         <p>
            <asp:Button id="Button2" runat="server" OnClick="Button2_Click" Text="Click to Apply Color"></asp:Button>
         </p>
      </form>
   </body>
</html>
