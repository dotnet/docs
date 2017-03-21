    // Create a new instance of a proxy class for the Bank XML Web service.
    BankSession bank = new BankSession();

    // Load the client certificate from a file.
    X509Certificate x509 = X509Certificate.CreateFromCertFile(@"c:\user.cer");

    // Add the client certificate to the ClientCertificates property of the proxy class.
    bank.ClientCertificates.Add(x509);

    // Communicate with the Deposit XML Web service method,
    // which requires authentication using client certificates.
    bank.Deposit(500);