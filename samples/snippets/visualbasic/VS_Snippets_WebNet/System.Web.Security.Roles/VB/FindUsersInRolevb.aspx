<!-- <Snippet11> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim users() As String

Public Sub Page_Load()
  If Not IsPostBack Then
    RolesListBox.DataSource = Roles.GetAllRoles()
    RolesListBox.DataBind()
  End If
End SUb

Public Sub GoButton_OnClick(sender As Object, args As EventArgs)
  Msg.Text = ""
  users = Nothing

  If RolesListBox.SelectedItem Is Nothing Then
    Msg.Text = "Please select a role."
    Return
  End If

  users = Roles.FindUsersInRole(RolesListBox.SelectedItem.Text, UsernameTextBox.Text)

  If users.Length < 1 Then
    Msg.Text = "No matching users found in selected role."
  End If

  UserGrid.DataSource = users
  UserGrid.DataBind()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Users</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>User List</h3>

  <asp:Label id="Msg" runat="Server" ForeColor="red" />

  <table border="0" cellpadding="3" cellspacing="3">
    <tr>
      <td valign="top">Role:</td>
      <td valign="top"><asp:ListBox id="RolesListBox" runat="Server" /></td>
    </tr>
    <tr>
      <td valign="top">Username to Search for:</td>
      <td valign="top"><asp:TextBox id="UsernameTextBox" runat="server" /></td>
    </tr>
  </table>
  <asp:Button id="GoButton" Text=" Go " OnClick="GoButton_OnClick" runat="server" /><br />

  <asp:DataGrid id="UserGrid" runat="server"
                CellPadding="2" CellSpacing="1"
                Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:DataGrid>

</form>

</body>
</html>
<!-- </Snippet11> -->