  Dim p As SqlMembershipProvider = CType(Membership.Provider, SqlMembershipProvider)
  Dim newPassword As String = p.GeneratePassword()