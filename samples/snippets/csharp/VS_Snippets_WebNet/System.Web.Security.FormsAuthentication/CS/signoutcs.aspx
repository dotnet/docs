<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void LoginLink_OnClick(object sender, EventArgs args)
{
  FormsAuthentication.SignOut();
  FormsAuthentication.RedirectToLoginPage();
}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>

<form id="form1" runat="server">
Welcome <b><%=User.Identity.Name%></b>. Not <b><%=User.Identity.Name%></b>? 
Click <asp:LinkButton id="LoginLink" Text="here" 
                      OnClick="LoginLink_OnClick" runat="server" />
to sign in.

<!-- Page Contents -->

</form>



</body>
</html>
<!-- </Snippet2> -->