<!-- <Snippet1> -->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Change Password with Validation</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
  <asp:changepassword id="ChangePassword1" runat="server"
  PasswordHintText = 
    "Please enter a password at least 7 characters long, 
    containing a number and one special character."
  NewPasswordRegularExpression =
    '@\"(?=.{7,})(?=(.*\d){1,})(?=(.*\W){1,})' 
  NewPasswordRegularExpressionErrorMessage =
    "Error: Your password must be at least 7 characters long, 
    and contain at least one number and one special character." >
  </asp:changepassword>
  </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->
