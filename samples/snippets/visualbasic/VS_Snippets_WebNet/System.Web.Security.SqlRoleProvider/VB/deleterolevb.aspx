<!-- <Snippet2> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Dim rolesArray() As String

  Public Sub Page_Load(ByVal sender As Object, ByVal args As EventArgs)

    If Not IsPostBack Then
      ' Bind roles to ListBox.

      rolesArray = Roles.GetAllRoles()
      RolesListBox.DataSource = rolesArray
      RolesListBox.DataBind()
    End If

  End Sub


  Public Sub DeleteRole_OnClick(ByVal sender As Object, ByVal args As EventArgs)

    Dim delRole As String

    Try
      delRole = RolesListBox.SelectedItem.Value

      Roles.DeleteRole(delRole)

      Msg.Text = "Role '" & Server.HtmlEncode(delRole) & "' deleted."

      ' Re-bind roles to ListBox.

      rolesArray = Roles.GetAllRoles()
      RolesListBox.DataSource = rolesArray
      RolesListBox.DataBind()
    Catch
      Msg.Text = "Role '" & Server.HtmlEncode(delRole) & "' <u>not</u> deleted."
    End Try

  End Sub

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
