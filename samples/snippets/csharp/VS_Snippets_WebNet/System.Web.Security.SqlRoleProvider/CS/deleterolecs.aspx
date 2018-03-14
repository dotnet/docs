<!-- <Snippet2> -->

<%@ Page Language="C#" %>

<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  string[] rolesArray;

  public void Page_Load(object sender, EventArgs args)
  {
    if (!IsPostBack)
    {
      // Bind roles to ListBox.

      rolesArray = Roles.GetAllRoles();
      RolesListBox.DataSource = rolesArray;
      RolesListBox.DataBind();
    }
  }


  public void DeleteRole_OnClick(object sender, EventArgs args)
  {
    string delRole = "";

    try
    {
      delRole = RolesListBox.SelectedItem.Value;

      Roles.DeleteRole(delRole);

      Msg.Text = "Role '" + Server.HtmlEncode(delRole) + "' deleted.";


      // Re-bind roles to ListBox.

      rolesArray = Roles.GetAllRoles();
      RolesListBox.DataSource = rolesArray;
      RolesListBox.DataBind();
    }
    catch
    {
      Msg.Text = "Role '" + Server.HtmlEncode(delRole) + "' <u>not</u> deleted.";
    }

  }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Sample: Delete Role</title>
</head>
<body>
  <form runat="server" id="PageForm">
    <h3>
      Delete Role</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <table border="0">
      <tr>
        <td valign="top">
          Delete Role:</td>
        <td valign="top">
          <asp:ListBox ID="RolesListBox" runat="server" Rows="8" /></td>
        <td valign="top">
          <asp:Button Text="Delete Role" ID="DeleteRoleButton" runat="server" OnClick="DeleteRole_OnClick" /></td>
      </tr>
    </table>
  </form>
</body>
</html>
<!-- </Snippet2> -->
