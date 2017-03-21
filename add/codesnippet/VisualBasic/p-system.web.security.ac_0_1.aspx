    If TypeOf (user) Is ActiveDirectoryMembershipUser Then
      lastLoginDate.Text = "Not available"
      lastActivityDate.Text = "Not available"
    Else
      lastLoginDate.Text = user.LastLoginDate.ToString()
      lastActivityDate.Text = user.LastActivityDate.ToString()
    End If