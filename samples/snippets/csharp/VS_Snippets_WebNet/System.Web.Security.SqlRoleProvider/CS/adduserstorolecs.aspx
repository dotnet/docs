<!-- <Snippet3> -->

<%@ Page Language="C#" %>

<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  string[] rolesArray;
  MembershipUserCollection users;
  string[] usersInRole;

  public void Page_Load()
  {
    Msg.Text = "";

    if (!IsPostBack)
    {
      // Bind roles to ListBox.

      rolesArray = Roles.GetAllRoles();
      RolesListBox.DataSource = rolesArray;
      RolesListBox.DataBind();

      // Bind users to ListBox.

      users = Membership.GetAllUsers();
      UsersListBox.DataSource = users;
      UsersListBox.DataBind();
    }

    if (RolesListBox.SelectedItem != null)
    {
      // Show users in role. Bind user list to GridView.

      usersInRole = Roles.GetUsersInRole(RolesListBox.SelectedItem.Value);
      UsersInRoleGrid.DataSource = usersInRole;
      UsersInRoleGrid.DataBind();
    }
  }


  public void AddUsers_OnClick(object sender, EventArgs args)
  {
    // Verify that a role is selected.

    if (RolesListBox.SelectedItem == null)
    {
      Msg.Text = "Please select a role.";
      return;
    }


    // Verify that at least one user is selected.

    if (UsersListBox.SelectedItem == null)
    {
      Msg.Text = "Please select one or more users.";
      return;
    }


    // Create list of users to be added to the selected role.

    string[] newusers = new string[UsersListBox.GetSelectedIndices().Length];

    for (int i = 0; i < newusers.Length; i++)
    {
      newusers[i] = UsersListBox.Items[UsersListBox.GetSelectedIndices()[i]].Value;
    }


    // Add the users to the selected role.

    try
    {
      Roles.AddUsersToRole(newusers, RolesListBox.SelectedItem.Value);

      // Re-bind users in role to GridView.

      usersInRole = Roles.GetUsersInRole(RolesListBox.SelectedItem.Value);
      UsersInRoleGrid.DataSource = usersInRole;
      UsersInRoleGrid.DataBind();
    }
    catch (Exception e)
    {
      Msg.Text = e.Message;
    }
  }


  public void UsersInRoleGrid_RemoveFromRole(object sender, GridViewCommandEventArgs args)
  {
    // Get the selected user name to remove.

    int index = Convert.ToInt32(args.CommandArgument);

    string username = ((DataBoundLiteralControl)UsersInRoleGrid.Rows[index].Cells[0].Controls[0]).Text;


    // Remove the user from the selected role.

    try
    {
      Roles.RemoveUserFromRole(username, RolesListBox.SelectedItem.Value);
    }
    catch (Exception e)
    {
      Msg.Text = "An exception of type " + e.GetType().ToString() +
                 " was encountered removing the user from the role.";
    }


    // Re-bind users in role to GridView.

    usersInRole = Roles.GetUsersInRole(RolesListBox.SelectedItem.Value);
    UsersInRoleGrid.DataSource = usersInRole;
    UsersInRoleGrid.DataBind();
  }



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
