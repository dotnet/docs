<!-- <Snippet9> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub GoButton_OnClick(sender As Object, args As EventArgs)
  UserGrid.DataSource = Membership.FindUsersByEmail(EmailTextBox.Text)
  UserGrid.DataBind()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Users by Email</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>User List</h3>

  E-mail address to Search for: 
    <asp:TextBox id="EmailTextBox" runat="server" />
    <asp:Button id="GoButton" Text=" Go " OnClick="GoButton_OnClick" runat="server" /><br />

  <asp:DataGrid id="UserGrid" runat="server"
                CellPadding="2" CellSpacing="1"
                Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:DataGrid>

</form>

</body>
</html>
<!-- </Snippet9> -->