<!-- <Snippet8> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub YesButton_OnClick(sender As Object, args As EventArgs)

  Membership.DeleteUser(User.Identity.Name)
  Response.Redirect("loginvb.aspx")

End Sub

Public Sub CancelButton_OnClick(sender As Object, args As EventArgs)
  Response.Redirect("default.aspx")
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Delete User</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Delete User</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <p style="color:red">Are you sure you want to delete the userid <b><%=User.Identity.Name%></b>?</p>

  <asp:Button id="YesButton" Text="Yes" OnClick="YesButton_OnClick" runat="server" />
  <asp:Button id="CancelButton" Text="Cancel" OnClick="CancelButton_OnClick" runat="server" />
</form>

</body>
</html>
<!-- </Snippet8> -->