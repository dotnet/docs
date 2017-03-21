    System.Security.Principal.SecurityIdentifier sidValue =
      (System.Security.Principal.SecurityIdentifier)user.ProviderUserKey;

    sid.Text = sidValue.ToString();