SqlMembershipProvider p = (SqlMembershipProvider)Membership.Providers["SqlProvider"];
PasswordFormatLabel.Text = p.PasswordFormat.ToString();