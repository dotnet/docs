<!-- <Snippet1> -->
<%@ page language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    If Context.User.Identity.IsAuthenticated Then
      changepassword1.DisplayUserName = False
    End If
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ChangePassword.DisplayUserName sample.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      User's login status: <asp:loginstatus id="status" runat="server" /><br />
      <asp:changepassword id="Changepassword1" runat="server" displayusername="true" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
