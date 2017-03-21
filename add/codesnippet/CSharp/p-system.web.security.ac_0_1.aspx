    if (user is ActiveDirectoryMembershipUser)
    {
      lastLoginDate.Text = "Not available";
      lastActivityDate.Text = "Not available";
    }
    else
    {
      lastLoginDate.Text = user.LastLoginDate.ToShortDateString();
      lastActivityDate.Text = user.LastActivityDate.ToShortDateString();
    }