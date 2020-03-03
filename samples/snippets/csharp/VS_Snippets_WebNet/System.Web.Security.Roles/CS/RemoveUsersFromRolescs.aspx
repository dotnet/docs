<!-- <Snippet8> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

string[] rolesArray;
MembershipUserCollection users;

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
}


public void RemoveUsers_OnClick(object sender, EventArgs args)
{
  // Verify that at least one user and one role are selected.

  int[] user_indices = UsersListBox.GetSelectedIndices();

  if (user_indices.Length == 0)
  {
    Msg.Text = "Please select one or more users.";
    return;
  }

  int[] role_indices = RolesListBox.GetSelectedIndices();

  if (role_indices.Length == 0)
  {
    Msg.Text = "Please select one or more roles.";
    return;
  }


  // Create list of users to be removed from the selected roles.

  string[] usersList = new string[user_indices.Length];

  for (int i = 0; i < usersList.Length; i++)
  {
    usersList[i] = UsersListBox.Items[user_indices[i]].Value;
  }


  // Create list of roles to be remove the selected users from.

  string[] rolesList = new string[role_indices.Length];

  for (int i = 0; i < rolesList.Length; i++)
  {
    rolesList[i] = RolesListBox.Items[role_indices[i]].Value;
  }


  // Remove the users from the selected roles.

  try
  {
    Roles.RemoveUsersFromRoles(usersList, rolesList);  
    Msg.Text = "User(s) removed from Role(s).";
  }
  catch (HttpException e)
  {
    Msg.Text = e.Message;
  } 
}

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
      <td valign="top"><asp:Button Text="Remove User(s) from Role(s)" id="RemoveUsersButton"
                                 runat="server" OnClick="RemoveUsers_OnClick" /></td>
    </tr>
  </table>
</form>

</body>
</html>
<!-- </Snippet8> -->