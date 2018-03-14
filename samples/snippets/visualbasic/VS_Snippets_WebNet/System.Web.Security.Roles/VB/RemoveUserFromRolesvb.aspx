<!-- <Snippet10> -->
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

    users = Membership.GetAllUsers()
    UsersListBox.DataSource = users
    UsersListBox.DataBind()
  End If
End Sub

Public Sub UsersListBox_OnSelectedIndexChanged(sender As Object, args As EventArgs)
  ' Bind users to ListBox.

  rolesArray = Roles.GetRolesForUser(UsersListBox.SelectedItem.Value)
  RolesListBox.DataSource = rolesArray
  RolesListBox.DataBind()
End Sub

Public Sub RemoveUser_OnClick(sender As Object, args As EventArgs)
  ' Verify that at least a user and at least one role are selected.

  If UsersListBox.SelectedItem Is Nothing Then
    Msg.Text = "Please select a user."
    Return
  End If

  Dim role_indices() As Integer = RolesListBox.GetSelectedIndices()

  If role_indices.Length = 0 Then
    Msg.Text = "Please select one or more roles."
    Return
  End If


  ' Create list of roles to be remove the selected user from.

  Dim rolesList(role_indices.Length - 1) As String

  For i As Integer = 0 To  rolesList.Length - 1
    rolesList(i) = RolesListBox.Items(role_indices(i)).Value
  Next


  ' Remove the user to the selected roles.

  Try
    Roles.RemoveUserFromRoles(UsersListBox.SelectedItem.Value, rolesList)  
    Msg.Text = "User removed from Role(s)."

    ' Rebind roles to ListBox.

    rolesArray = Roles.GetRolesForUser(UsersListBox.SelectedItem.Value)
    RolesListBox.DataSource = rolesArray
    RolesListBox.DataBind()
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
      <td valign="top">Users:</td>
      <td valign="top"><asp:ListBox id="UsersListBox" Rows="8" DataTextField="Username" 
                                    OnSelectedIndexChanged="UsersListBox_OnSelectedIndexChanged" 
                                    AutoPostBack="true" runat="server" /></td>
      <td valign="top">Roles:</td>
      <td valign="top"><asp:ListBox id="RolesListBox" SelectionMode="Multiple" 
                                    runat="server" Rows="8" /></td>
      <td valign="top"><asp:Button Text="Remove User from Roles" id="RemoveUserButton"
                                   runat="server" OnClick="RemoveUser_OnClick" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet10> -->