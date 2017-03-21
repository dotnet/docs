Public Function MyCreateUser(username As String, password As String, email As String) As MembershipUser

  Dim u As MembershipUser = Nothing

  Try
    u = Membership.CreateUser(username, password, email)
  Catch e As MembershipCreateUserException
    Throw e
  Catch e As Exception  
    Throw New MembershipCreateUserException("An exception occurred creating the user.", e)
  End Try

  Return u
End Function