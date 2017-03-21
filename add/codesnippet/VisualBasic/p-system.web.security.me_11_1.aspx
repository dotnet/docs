Dim p As SqlMembershipProvider = CType(Membership.Providers("SqlProvider"), SqlMembershipProvider)
PasswordFormatLabel.Text = p.PasswordFormat.ToString()