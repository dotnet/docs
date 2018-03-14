<!-- <Snippet10> -->
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

    users = Membership.GetAllUsers();
    UsersListBox.DataSource = users;
    UsersListBox.DataBind();
  }
}

public void UsersListBox_OnSelectedIndexChanged(object sender, EventArgs args)
{
  // Bind users to ListBox.

  rolesArray = Roles.GetRolesForUser(UsersListBox.SelectedItem.Value);
  RolesListBox.DataSource = rolesArray;
  RolesListBox.DataBind();
}

public void RemoveUser_OnClick(object sender, EventArgs args)
{
  // Verify that at least a user and at least one role are selected.

  if (UsersListBox.SelectedItem ==  null)
  {
    Msg.Text = "Please select a user.";
    return;
  }

  int[] role_indices = RolesListBox.GetSelectedIndices();

  if (role_indices.Length == 0)
  {
    Msg.Text = "Please select one or more roles.";
    return;
  }


  // Create list of roles to be remove the selected user from.

  string[] rolesList = new string[role_indices.Length];

  for (int i = 0; i < rolesList.Length; i++)
  {
    rolesList[i] = RolesListBox.Items[role_indices[i]].Value;
  }


  // Remove the user to the selected roles.

  try
  {
    Roles.RemoveUserFromRoles(UsersListBox.SelectedItem.Value, rolesList);  
    Msg.Text = "User removed from Role(s).";

    // Rebind roles to ListBox.

    rolesArray = Roles.GetRolesForUser(UsersListBox.SelectedItem.Value);
    RolesListBox.DataSource = rolesArray;
    RolesListBox.DataBind();
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