<!-- <Snippet3> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Dim rolesArray() As String
  Dim users As MembershipUserCollection
  Dim usersInRole() As String

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

    If Not RolesListBox.SelectedItem Is Nothing Then
      ' Show users in role. Bind user list to GridView.

      usersInRole = Roles.GetUsersInRole(RolesListBox.SelectedItem.Value)
      UsersInRoleGrid.DataSource = usersInRole
      UsersInRoleGrid.DataBind()
    End If

  End Sub


  Public Sub AddUsers_OnClick(ByVal sender As Object, ByVal args As EventArgs)

    ' Verify that a role is selected.

    If RolesListBox.SelectedItem Is Nothing Then
      Msg.Text = "Please select a role."
      Return
    End If


    ' Verify that at least one user is selected.

    If UsersListBox.SelectedItem Is Nothing Then
      Msg.Text = "Please select one or more users."
      Return
    End If


    ' Create list of users to be added to the selected role.

    Dim newusers(UsersListBox.GetSelectedIndices().Length - 1) As String

    For i As Integer = 0 To newusers.Length - 1
      newusers(i) = UsersListBox.Items(UsersListBox.GetSelectedIndices(i)).Value
    Next


    ' Add the users to the selected role.

    Try
      Roles.AddUsersToRole(newusers, RolesListBox.SelectedItem.Value)

      ' Re-bind users in role to GridView.

      usersInRole = Roles.GetUsersInRole(RolesListBox.SelectedItem.Value)
      UsersInRoleGrid.DataSource = usersInRole
      UsersInRoleGrid.DataBind()
    Catch e As Exception
      Msg.Text = e.Message
    End Try

  End Sub


  Public Sub UsersInRoleGrid_RemoveFromRole(ByVal sender As Object, ByVal args As GridViewCommandEventArgs)

    ' Get the selected user name to remove.

    Dim index As Integer = Convert.ToInt32(args.CommandArgument)

    Dim username As String = (CType(UsersInRoleGrid.Rows(index).Cells(0).Controls(0), DataBoundLiteralControl)).Text


    ' Remove the user from the selected role.

    Try
      Roles.RemoveUserFromRole(username, RolesListBox.SelectedItem.Value)
    Catch e As Exception
      Msg.Text = "An exception of type " & e.GetType().ToString() & _
                 " was encountered removing the user from the role."
    End Try

    ' Re-bind users in role to GridView.

    usersInRole = Roles.GetUsersInRole(RolesListBox.SelectedItem.Value)
    UsersInRoleGrid.DataSource = usersInRole
    UsersInRoleGrid.DataBind()

  End Sub



</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Sample: Role Membership</title>
</head>
<body>
  <form runat="server" id="PageForm">
    <h3>
      Role Membership</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <table cellpadding="3" border="0">
      <tr>
        <td valign="top">
          Roles:</td>
        <td valign="top">
          <asp:ListBox ID="RolesListBox" runat="server" Rows="8" AutoPostBack="true" /></td>
        <td valign="top">
          Users:</td>
        <td valign="top">
          <asp:ListBox ID="UsersListBox" DataTextField="Username" Rows="8" SelectionMode="Multiple"
            runat="server" /></td>
        <td valign="top">
          <asp:Button Text="Add User(s) to Role" ID="AddUsersButton" runat="server" OnClick="AddUsers_OnClick" /></td>
      </tr>
      <tr>
        <td valign="top">
          Users In Role:</td>
        <td valign="top">
          <asp:GridView runat="server" CellPadding="4" ID="UsersInRoleGrid" AutoGenerateColumns="false"
            GridLines="None" CellSpacing="0" OnRowCommand="UsersInRoleGrid_RemoveFromRole">
            <HeaderStyle BackColor="navy" ForeColor="white" />
            <Columns>
              <asp:TemplateField HeaderText="User Name" >
                <ItemTemplate>
                  <%# Container.DataItem.ToString() %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:ButtonField Text="Remove From Role" ButtonType="Link" />
            </Columns>
          </asp:GridView>
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
<!-- </Snippet3> -->
