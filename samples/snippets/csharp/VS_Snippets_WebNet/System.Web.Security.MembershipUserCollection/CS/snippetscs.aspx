<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Snippet3()
{
//<Snippet3>
MembershipUserCollection users = Membership.GetAllUsers();
MembershipUser[] copiedUsers = new MembershipUser[users.Count];
users.CopyTo(copiedUsers, 0);
//</Snippet3>
}


public void Snippet4()
{
//<Snippet4>
MembershipUserCollection users = Membership.GetAllUsers();

// Code to modify MembershipUserCollection here.

users.Clear();
users = Membership.GetAllUsers();
//</Snippet4>
}

//<Snippet5>
public MembershipUserCollection GetUsers(bool setReadOnly)
{
  MembershipUserCollection users = Membership.GetAllUsers();
  if (setReadOnly)
    users.SetReadOnly();
  return users;
}
//</Snippet5>



//<Snippet7>
public void ListUsers(MembershipUserCollection users)
{
  foreach (MembershipUser u in users)
    Response.Write(u.UserName + "<br />");
}
//</Snippet7>


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: View User Roles</title>
</head>
<body>
<%
Snippet3();
Snippet4();
MembershipUserCollection users = GetUsers(false);
ListUsers(users);
%>
</body>
</html>
