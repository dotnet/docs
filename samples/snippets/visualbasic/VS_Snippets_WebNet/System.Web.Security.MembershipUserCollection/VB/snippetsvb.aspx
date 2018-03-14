<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Snippet3()
'<Snippet3>
Dim users As MembershipUserCollection = Membership.GetAllUsers()
Dim copiedUsers(users.Count) As MembershipUser
users.CopyTo(copiedUsers, 0)
'</Snippet3>
End Sub


Public Sub Snippet4()
'<Snippet4>
Dim users As MembershipUserCollection = Membership.GetAllUsers()

' Code to modify MembershipUserCollection here.

users.Clear()
users = Membership.GetAllUsers()
'</Snippet4>
End Sub

'<Snippet5>
Public Function GetUsers(setReadOnly As Boolean) As MembershipUserCollection 
  Dim users As MembershipUserCollection = Membership.GetAllUsers()
  If setReadOnly Then users.SetReadOnly()
  Return users
End Function
'</Snippet5>



'<Snippet7>
Public Sub ListUsers(users As MembershipUserCollection)
  For Each u As MembershipUser in users
    Response.Write(u.UserName & "<br />")
  Next
End Sub
'</Snippet7>


</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: View User Roles</title>
</head>
<body>
<%
Snippet3()
Snippet4()
Dim users As MembershipUserCollection = GetUsers(False)
ListUsers(users)
%>
</body>
</html>
