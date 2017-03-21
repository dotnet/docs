    // Use the Fields property to add authentication, your username, and your password.
    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");    
    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "marsha"); 
    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "secret");