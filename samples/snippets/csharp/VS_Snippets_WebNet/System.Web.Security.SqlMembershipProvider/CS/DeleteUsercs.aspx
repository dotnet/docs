<!-- <Snippet6> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void YesButton_OnClick(object sender, EventArgs args)
{
  Membership.DeleteUser(User.Identity.Name, DeleteRelatedData.Checked);

  FormsAuthentication.SignOut();
  FormsAuthentication.RedirectToLoginPage();
}

public void CancelButton_OnClick(object sender, EventArgs args)
{
  Response.Redirect("default.aspx");
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Delete User</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Delete User</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <span style="color:red">Are you sure you want to delete the userid <b><%=User.Identity.Name%></b>?</span><br />

  Delete related profile and roles data: <asp:CheckBox id="DeleteRelatedData" 
                                                       checked="True" runat="Server" /><br />

  <asp:Button id="YesButton" Text="Yes" OnClick="YesButton_OnClick" runat="server" />
  <asp:Button id="CancelButton" Text="Cancel" OnClick="CancelButton_OnClick" runat="server" />
</form>

</body>
</html>
<!-- </Snippet6> -->