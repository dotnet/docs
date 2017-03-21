
    // Create a resolver and specify the necessary credentials.
    XmlUrlResolver resolver = new XmlUrlResolver();
    System.Net.NetworkCredential myCred;
    myCred  = new System.Net.NetworkCredential(UserName,SecurelyStoredPassword,Domain);  
    resolver.Credentials = myCred;
