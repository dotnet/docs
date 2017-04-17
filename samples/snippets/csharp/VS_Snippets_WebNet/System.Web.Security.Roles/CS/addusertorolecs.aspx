<!-- <Snippet2> -->
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


public void AddUser_OnClick(object sender, EventArgs args)
{
  // Verify that a user and a role are selected.

  if (UsersListBox.SelectedItem == null)
  {
    Msg.Text = "Please select a user.";
    return;
  } 

  if (RolesListBox.SelectedItem == null)
  {
    Msg.Text = "Please select a role.";
    return;
  }

  // Add the user to the selected role.

  try
  {
    Roles.AddUserToRole(UsersListBox.SelectedItem.Value, RolesListBox.SelectedItem.Value);  
    Msg.Text = "User added to Role.";
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