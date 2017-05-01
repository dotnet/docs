<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim rolesArray() As String
Dim users As MembershipUserCollection

Public Sub Page_Load()

  Msg.Text = ""

  If Not IsPostBack Then
    ' Bind roles to ListBox.

    rolesArray = Roles.GetAllRoles()
    RolesListBox.DataSource = rolesArray
    RolesListBox.DataBind()

    ' Bind users to ListBox.

    users = Membership.GetAllUsers()
    UsersListBox.DataSource = users
    UsersListBox.DataBind()
  End If
End Sub


Public Sub AddUser_OnClick(sender As Object, args As EventArgs)

  ' Verify that a user and a role are selected.

  If UsersListBox.SelectedItem Is Nothing Then
    Msg.Text = "Please select a user."
    Return
  End If 

  If RolesListBox.SelectedItem Is Nothing Then
    Msg.Text = "Please select a role."
    Return
  End If


  ' Add the user to the selected role.

  Try
    Roles.AddUserToRole(UsersListBox.SelectedItem.Value, RolesListBox.SelectedItem.Value)  
    Msg.Text = "User added to Role."
  Catch e As HttpException
    Msg.Text = e.Message
  End Try
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Role Membership</title>
</head>
<body>

<form runat="server" id="PageForm">
  <h3>Role Membership</h3>
  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />
  <table cellpadding="3" border="0">
    <tr>
      <td valign="top">Roles:</td>
      <td valign="top"><asp:ListBox id="RolesListBox" runat="server" Rows="8" /></td>
      <td valign="top">Users:</td>
      <td valign="top"><asp:ListBox id="UsersListBox" DataTextField="Username" 
                                  Rows="8" runat="server" /></td>
      <td valign="top"><asp:Button Text="Add User to Role" id="AddUserButton"
                                 runat="server" OnClick="AddUser_OnClick" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet2> -->