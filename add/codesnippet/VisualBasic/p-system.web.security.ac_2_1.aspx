    Dim sidValue As System.Security.Principal.SecurityIdentifier
    sidValue = CType(user.ProviderUserKey, System.Security.Principal.SecurityIdentifier)
    
    sid.Text = sidValue.ToString()