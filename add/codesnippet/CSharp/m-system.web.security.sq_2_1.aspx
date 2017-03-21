  SqlMembershipProvider p = (SqlMembershipProvider)Membership.Provider;
  string newPassword = p.GeneratePassword();