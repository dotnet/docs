Public Sub ListUsers(users As MembershipUserCollection)
  For Each u As MembershipUser in users
    Response.Write(u.UserName & "<br />")
  Next
End Sub