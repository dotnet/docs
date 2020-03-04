<!-- <Snippet3> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim currentUser As MembershipUser

Public Sub Page_Load()
  currentUser = Membership.GetUser()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Home Page</title>
</head>
<body>

<form id="form1" runat="server">
Welcome <b><%=currentUser.UserName%></b>.
</form>

</body>
</html>
<!-- </Snippet3> -->