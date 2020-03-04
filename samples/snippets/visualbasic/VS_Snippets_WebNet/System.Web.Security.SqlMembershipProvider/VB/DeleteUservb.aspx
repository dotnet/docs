<!-- <Snippet6> -->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Public Sub YesButton_OnClick(ByVal sender As Object, ByVal args As EventArgs)

    Membership.DeleteUser(User.Identity.Name, DeleteRelatedData.Checked)

    FormsAuthentication.SignOut()
    FormsAuthentication.RedirectToLoginPage()

  End Sub

  Public Sub CancelButton_OnClick(ByVal sender As Object, ByVal args As EventArgs)
    Response.Redirect("default.aspx")
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
  <title>Sample: Delete User</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      Delete User</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <p style="color:red">Are you sure you want to delete the userid <b><%=User.Identity.Name%></b>?</p>
    <br />
      Delete related profile and roles data:
      <asp:CheckBox ID="DeleteRelatedData" Checked="True" runat="Server" /><br />
        <asp:Button ID="YesButton" Text="Yes" OnClick="YesButton_OnClick" runat="server" />
        <asp:Button ID="CancelButton" Text="Cancel" OnClick="CancelButton_OnClick" runat="server" />
  </form>
</body>
</html>
<!-- </Snippet6> -->
