Public Function GetUsers(setReadOnly As Boolean) As MembershipUserCollection 
  Dim users As MembershipUserCollection = Membership.GetAllUsers()
  If setReadOnly Then users.SetReadOnly()
  Return users
End Function