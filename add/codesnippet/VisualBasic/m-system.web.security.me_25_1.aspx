Public Function MyCreateUser(username As String, password As String, email As String, _
                             question As String, answer As String) As MembershipUser

  Dim status As MembershipCreateStatus

  Dim u As MembershipUser = Membership.CreateUser(username, password, email, question, _
                                                  answer, True, status)
  If u Is Nothing Then
    Throw New MembershipCreateUserException()
  End If

  Return u
End Function