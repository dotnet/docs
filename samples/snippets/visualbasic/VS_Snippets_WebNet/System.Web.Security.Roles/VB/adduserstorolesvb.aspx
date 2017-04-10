<!-- <Snippet1> -->
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


Public Sub AddUsers_OnClick(sender As Object, args As EventArgs)

  ' Verify that at least one user and one role are selected.

  Dim user_indices() As Integer = UsersListBox.GetSelectedIndices()

  If user_indices.Length = 0 Then
    Msg.Text = "Please select one or more users."
    Return
  End If

  Dim role_indices() As Integer = RolesListBox.GetSelectedIndices()

  If role_indices.Length = 0 Then
    Msg.Text = "Please select one or more roles."
    Return
  End If


  ' Create list of users to be added to the selected roles.

  Dim newusers(user_indices.Length - 1) As String

  For i As Integer = 0 To newusers.Length - 1
    newusers(i) = UsersListBox.Items(user_indices(i)).Value
  Next


  ' Create list of roles to be add the selected users to.

  Dim rolesList(role_indices.Length - 1) As String

  For i As Integer = 0 To rolesList.Length - 1
    rolesList(i) = RolesListBox.Items(role_indices(i)).Value
  Next


  ' Add the users to the selected role.

  Try
    Roles.AddUsersToRoles(newusers, rolesList)  
    Msg.Text = "User(s) added to Role(s)."
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
      <td valign="top"><asp:ListBox id="RolesListBox" runat="server" SelectionMode="Multiple"
                                    Rows="8" /></td>
      <td valign="top">Users:</td>
      <td valign="top"><asp:ListBox id="UsersListBox" DataTextField="Username" 
                                  Rows="8" SelectionMode="Multiple" runat="server" /></td>
      <td valign="top"><asp:Button Text="Add User(s) to Role(s)" id="AddUsersButton"
                                 runat="server" OnClick="AddUsers_OnClick" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet1> -->