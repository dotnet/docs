<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

MembershipUserCollection users;

public void Page_Load()
{
  users = Membership.GetAllUsers();

  if (!IsPostBack)
  {
    // Bind users to ListBox.
    UsersListBox.DataSource = users;
    UsersListBox.DataBind();
  }


  // If a user is selected, show the properties for the selected user.

  if (UsersListBox.SelectedItem != null)
  {
    MembershipUser u = users[UsersListBox.SelectedItem.Value];

    EmailLabel.Text = u.Email;
    IsOnlineLabel.Text = u.IsOnline.ToString();
    LastLoginDateLabel.Text = u.LastLoginDate.ToString();
    CreationDateLabel.Text = u.CreationDate.ToString();
    LastActivityDateLabel.Text = u.LastActivityDate.ToString();
  }
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: View User Information</title>
</head>
<body>

<form runat="server" id="PageForm">

  <h3>View User Information</h3>

  <table border="0" cellspacing="4">
    <tr>
      <td valign="top">
        <asp:ListBox id="UsersListBox" DataTextField="Username" 
                     Rows="8" AutoPostBack="true" runat="server" />
      </td>
      <td valign="top">
        <table border="0" cellpadding="2" cellspacing="0">
          <tr>
           <td>E-mail:</td>
           <td><asp:Label runat="server" id="EmailLabel" /></td>
          </tr>
          <tr>
           <td>Is Online?:</td>
           <td><asp:Label runat="server" id="IsOnlineLabel" /></td>
          </tr>
          <tr>
           <td>LastLoginDate:</td>
           <td><asp:Label runat="server" id="LastLoginDateLabel" /></td>
          </tr>
          <tr>
           <td>CreationDate:</td>
           <td><asp:Label runat="server" id="CreationDateLabel" /></td>
          </tr>
          <tr>
           <td>LastActivityDate:</td>
           <td><asp:Label runat="server" id="LastActivityDateLabel" /></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>

</form>

</body>
</html>
<!-- </Snippet2> -->